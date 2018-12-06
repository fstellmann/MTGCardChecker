using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Linq;

namespace MTGCardChecker
{
    public partial class fMain : Form
    {
        private enum cardType
        {
            CREATURE,
            LAND,
            PLANESWALKER,
            INSTANT,
            SORCERY,
            ENTCHANTMENT,
            NONE
        }

        private static readonly HttpClient client = new HttpClient();
        private AutoCompleteStringCollection vs = new AutoCompleteStringCollection();
        public static List<Card> deck = new List<Card>();
        public static readonly string rootPath = @"C://temp/mtg_img_lib/";
        cardType currentType = cardType.NONE;
        private static dynamic currentCard;
        public fMain()
        {
            InitializeComponent();
        }
        private void resetGui()
        {
            pictureBox1.Image = null;
            lvCardDetails.Items.Clear();
            tbxSearchName.Clear();
            vs.Clear();
            btnGet.Enabled = true;
            currentType = cardType.NONE;
            numericUpDown1.ResetText();
            numericUpDown1.Value = 0;
        }
        private async void download(string cardName)
        {
            string apiUrl = string.Format("https://api.scryfall.com/cards/named?fuzzy={0}", cardName.Replace(' ', '+'));
            try
            {
                var response = await client.GetStringAsync(apiUrl);
                dynamic result = JObject.Parse(response);
                currentCard = result;
                setCardDetails(result);
                pictureBox1.Image = Image.FromFile(getImage(result.image_uris.large.ToString(), cardName, result));
            }
            catch (HttpRequestException wexc)
            {
                tbxSearchName.Text = wexc.Message;
            }
        }
        public string getImage(string url, string cardName, dynamic data)
        {
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }
            string path = rootPath + cardName.Replace(' ', '_') + ".png";
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri(url), path);
            }
            File.WriteAllText(rootPath + cardName.Replace(' ', '_') + ".json", data.ToString());
            return path;
        }
        private async void getCardNames(string cardName)
        {
            var response = await client.GetStringAsync(string.Format(@"https://api.scryfall.com/cards/autocomplete?q={0}", cardName));
            dynamic result = JObject.Parse(response);
            string[] arr = result.data.ToObject<string[]>();
            vs.Clear();
            vs.AddRange(arr);
            tbxSearchName.AutoCompleteCustomSource = vs;
        }
        private void setCardDetails(dynamic data)
        {
            lvCardDetails.Items.Clear();

            lvCardDetails.Items.Add((new ListViewItem(new string[] { "Name", data.name.ToString() })));
            if (data.type_line.ToString().Contains("Land"))
            {
                currentType = cardType.LAND;
            }
            else
            {
                byte[] bytes = Encoding.Default.GetBytes(data.mana_cost.ToString());
                string cost = Encoding.UTF8.GetString(bytes);
                lvCardDetails.Items.Add((new ListViewItem(new string[] { "Cost", cost })));
            }
            lvCardDetails.Items.Add((new ListViewItem(new string[] { "Text", "" })));
            foreach (string s in data.oracle_text.ToString().Split('\n'))
            {
                lvCardDetails.Items.Add((new ListViewItem(new string[] { "", s })));
            }
            if (data.type_line.ToString().Contains("Creature"))
            {
                lvCardDetails.Items.Add((new ListViewItem(new string[] { "Power", data.power.ToString() })));
                lvCardDetails.Items.Add((new ListViewItem(new string[] { "Toughness", data.toughness.ToString() })));
                currentType = cardType.CREATURE;
            }
            if (data.type_line.ToString().Contains("Planeswalker"))
            {
                lvCardDetails.Items.Add((new ListViewItem(new string[] { "Loyalty", data.loyalty.ToString() })));
                currentType = cardType.PLANESWALKER;
            }
            if (data.type_line.ToString().Contains("Instant"))
            {
                currentType = cardType.INSTANT;
            }
            if (data.type_line.ToString().Contains("Sorcery"))
            {
                currentType = cardType.SORCERY;
            }
            if (data.type_line.ToString().Contains("Entchantment"))
            {
                currentType = cardType.ENTCHANTMENT;
            }
        }
        private void cleanUpTMP()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            foreach (string s in Directory.GetFiles(rootPath))
            {
                File.Delete(s);
            }
        }
        #region EventMethods
        private void btnGet_Click(object sender, EventArgs e)
        {
            download(tbxSearchName.Text);
            btnGet.Enabled = false;
        }
        private void tbxSearchName_TextChanged(object sender, EventArgs e)
        {
            if (tbxSearchName.Text.Length == 0 && vs.Count != 0)
            {
                vs.Clear();
            }
            if (tbxSearchName.Text.Length == 3 && vs.Count == 0)
            {
                getCardNames(tbxSearchName.Text);
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            btnGet.Enabled = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tbxSearchName.AutoCompleteCustomSource = vs;
        }
        private void tbxSearchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnGet.PerformClick();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string text = "";
            foreach (ListViewItem lvi in lvCardDetails.Items)
            {
                if (String.IsNullOrEmpty(lvi.SubItems[0].Text))
                {
                    text += lvi.SubItems[1].Text;
                }
            }

            switch (currentType)
            {
                case cardType.CREATURE:
                    int power = 0;
                    int toughness = 0;
                    foreach (ListViewItem lvi in lvCardDetails.Items)
                    {
                        if (lvi.SubItems[0].Text == "Power")
                        {
                            power = Convert.ToInt32(lvi.SubItems[1].Text);
                        }
                        if (lvi.SubItems[0].Text == "Toughness")
                        {
                            toughness = Convert.ToInt32(lvi.SubItems[1].Text);
                        }
                    }
                    deck.Add(new CreatureCard(lvCardDetails.Items[0].SubItems[1].Text, lvCardDetails.Items[1].SubItems[1].Text, text, power, toughness, (int)numericUpDown1.Value));
                    break;
                case cardType.INSTANT:
                    deck.Add(new InstantCard(lvCardDetails.Items[0].SubItems[1].Text, lvCardDetails.Items[1].SubItems[1].Text, text, (int)numericUpDown1.Value));
                    break;
                case cardType.PLANESWALKER:
                    int loyalty = 0;
                    foreach (ListViewItem lvi in lvCardDetails.Items)
                    {
                        if (lvi.SubItems[0].Text == "Loyalty")
                        {
                            loyalty = Convert.ToInt32(lvi.SubItems[1].Text);
                        }
                    }
                    deck.Add(new PlaneswalkerCard(lvCardDetails.Items[0].SubItems[1].Text, lvCardDetails.Items[1].SubItems[1].Text, text, loyalty, (int)numericUpDown1.Value));
                    break;
                case cardType.SORCERY:
                    deck.Add(new SorceryCard(lvCardDetails.Items[0].SubItems[1].Text, lvCardDetails.Items[1].SubItems[1].Text, text, (int)numericUpDown1.Value));
                    break;
                case cardType.LAND:
                    deck.Add(new LandCard(lvCardDetails.Items[0].SubItems[1].Text, text, (int)numericUpDown1.Value));
                    break;
                case cardType.ENTCHANTMENT:
                    deck.Add(new EntchantmentCard(lvCardDetails.Items[0].SubItems[1].Text, lvCardDetails.Items[1].SubItems[1].Text, text, (int)numericUpDown1.Value));
                    break;
                default:
                    break;
            }
            lblDeckCount.Text = deck.Sum(x => x.amountInDeck).ToString();
            resetGui();
        }
        private void btnShowDeck_Click(object sender, EventArgs e)
        {
            fDeckViewer fdv = new fDeckViewer(deck);
            fdv.ShowDialog();
            lblDeckCount.Text = deck.Sum(x => x.amountInDeck).ToString();
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if(currentType != cardType.LAND)
            {
                if (currentCard.legalities.vintage == "restricted")
                {
                    numericUpDown1.Maximum = 1;
                }
                else
                {
                    numericUpDown1.Maximum = 4;
                }
            }
            else
            {
                numericUpDown1.Maximum = 60-(deck.Sum(x => x.amountInDeck));
            }
        }        
        private void fMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            pictureBox1.Dispose();
            cleanUpTMP();
        }
        #endregion

        private void btnStat_Click(object sender, EventArgs e)
        {
            fStatistics fStat = new fStatistics(deck);
            fStat.ShowDialog();
        }
    }
}
