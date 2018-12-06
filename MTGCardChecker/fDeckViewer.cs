using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTGCardChecker
{
    public partial class fDeckViewer : Form
    {
        List<Card> lDeck = new List<Card>();
        private int _selectedMenuItem;
        private readonly ContextMenuStrip collectionRoundMenuStrip;
        private bool delete = false;
        public fDeckViewer(List<Card> _lCards)
        {
            InitializeComponent();
            lDeck = _lCards;
            fillListBox();
            var toolStripMenuItem1 = new ToolStripMenuItem { Text = "Lösche aus Deck" };
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            collectionRoundMenuStrip = new ContextMenuStrip();
            collectionRoundMenuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            lbDeck.MouseDown += lbDeck_MouseDown;
        }
        private void fillListBox()
        {
            foreach(Card c in lDeck)
            {
                lbDeck.Items.Add(c.amountInDeck+" "+c.cardName);
            }
        }
        private string getCardNameFromListBox(string data)
        {
            return data.Substring(data.IndexOf(' ') + 1, data.Length - data.IndexOf(' ') - 1);
        }
        public Image getImageToText(string text)
        {
            switch(text)
            {
                case "{W}":
                    return Properties.Resources.W;
                case "{U}":
                    return Properties.Resources.U;
                case "{B}":
                    return Properties.Resources.B;
                case "{G}":
                    return Properties.Resources.G;
                case "{R}":
                    return Properties.Resources.R;
                case "{X}":
                    return Properties.Resources.X;
                case "{0}":
                    return Properties.Resources._0;
                case "{1}":
                    return Properties.Resources._1;
                case "{2}":
                    return Properties.Resources._2;
                case "{3}":
                    return Properties.Resources._3;
                case "{4}":
                    return Properties.Resources._4;
                case "{5}":
                    return Properties.Resources._5;
                case "{6}":
                    return Properties.Resources._6;
                default:
                    return Properties.Resources._0;
            }
        }
        private void lbDeck_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!delete)
            {
                string holdName = lbDeck.SelectedItem.ToString().Substring(lbDeck.SelectedItem.ToString().IndexOf(' ')+1, lbDeck.SelectedItem.ToString().Length - lbDeck.SelectedItem.ToString().IndexOf(' ')-1).Replace(' ', '_');
                cardImage.Image = Image.FromFile(fMain.rootPath + holdName + ".png");
                Card card = lDeck.Find(x => x.cardName == holdName.Replace('_',' '));
                lblCardName.Text = card.cardName;
                foreach(Control c in groupBox1.Controls)
                {
                    if(c is PictureBox)
                    {
                        (c as PictureBox).Image = null;
                    }
                }
                var m1 = Regex.Matches(card.cost, @"{(.*?)}");
                int count = 1;
                foreach(Match m in m1)
                {
                    (groupBox1.Controls.Find("pictureBox" + count, false)[0] as PictureBox).Image = getImageToText(m.Value);
                    count++;
                }
                count = 1;
                lblText.Text = card.text;
                lblPower.Text = "";
                lblLoyalty.Text = "";
                switch (lDeck.Find(x => x.cardName == holdName.Replace('_', ' ')).GetType().Name)
                {
                    case "PlaneswalkerCard":
                        lblLoyalty.ForeColor = Color.White;
                        pbLoyalty.Image = Properties.Resources.Loyalty;
                        lblLoyalty.Text = (card as PlaneswalkerCard).loyalty.ToString();
                        lblLoyalty.BringToFront();
                        break;
                    case "CreatureCard":
                        lblPower.Text = (card as CreatureCard).power.ToString() +"/" +(card as CreatureCard).toughness.ToString();
                        break;
                    case "LandCard":
                        break;
                    case "EntchantmentCard":
                        break;
                    case "InstantCard":
                        break;
                    case "SorceryCard":
                        break;
                }
            }
            delete = false;
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            delete = true;
            lDeck.Remove(lDeck.Find(x => x.cardName == getCardNameFromListBox(lbDeck.Items[_selectedMenuItem].ToString())));
            lbDeck.Items.RemoveAt(_selectedMenuItem);
            cardImage.Image = null;
            foreach(Control c in this.groupBox1.Controls)
            {
                if(c is Label)
                (c as Label).ResetText();
            }
        }
        private void lbDeck_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var index = lbDeck.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                _selectedMenuItem = index;
                collectionRoundMenuStrip.Show(Cursor.Position);
                collectionRoundMenuStrip.Visible = true;
            }
            else
            {
                collectionRoundMenuStrip.Visible = false;
            }
        }
        private void fDeckViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            cardImage.Dispose();
        }
    }
}
