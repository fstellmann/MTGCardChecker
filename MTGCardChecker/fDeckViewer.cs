using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        private void lbDeck_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!delete)
            {
                string holdName = lbDeck.SelectedItem.ToString().Substring(lbDeck.SelectedItem.ToString().IndexOf(' ')+1, lbDeck.SelectedItem.ToString().Length - lbDeck.SelectedItem.ToString().IndexOf(' ')-1).Replace(' ', '_');
                pictureBox1.Image = Image.FromFile(fMain.rootPath + holdName + ".png");
                Card card = lDeck.Find(x => x.cardName == holdName.Replace('_',' '));
                lblCardName.Text = card.cardName;
                lblCost.Text = card.cost;
                lblText.Text = card.text;

                switch(lDeck.Find(x => x.cardName == holdName.Replace('_', ' ')).GetType().Name)
                {
                    case "PlaneswalkerCard":
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
            pictureBox1.Image = null;
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
            pictureBox1.Dispose();
        }
    }
}
