namespace MTGCardChecker
{
    partial class fMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.btnGet = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbxSearchName = new System.Windows.Forms.TextBox();
            this.lblSearchName = new System.Windows.Forms.Label();
            this.lvCardDetails = new System.Windows.Forms.ListView();
            this.cDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnShowDeck = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lblDeckCount = new System.Windows.Forms.Label();
            this.btnStat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGet
            // 
            this.btnGet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGet.Location = new System.Drawing.Point(686, 397);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(122, 23);
            this.btnGet.TabIndex = 0;
            this.btnGet.Text = "Hole Daten";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(277, 407);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // tbxSearchName
            // 
            this.tbxSearchName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxSearchName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbxSearchName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbxSearchName.Location = new System.Drawing.Point(675, 12);
            this.tbxSearchName.Name = "tbxSearchName";
            this.tbxSearchName.Size = new System.Drawing.Size(133, 20);
            this.tbxSearchName.TabIndex = 2;
            this.tbxSearchName.TextChanged += new System.EventHandler(this.tbxSearchName_TextChanged);
            this.tbxSearchName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxSearchName_KeyDown);
            // 
            // lblSearchName
            // 
            this.lblSearchName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearchName.AutoSize = true;
            this.lblSearchName.Location = new System.Drawing.Point(628, 15);
            this.lblSearchName.Name = "lblSearchName";
            this.lblSearchName.Size = new System.Drawing.Size(41, 13);
            this.lblSearchName.TabIndex = 3;
            this.lblSearchName.Text = "Suche:";
            // 
            // lvCardDetails
            // 
            this.lvCardDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCardDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cDescription,
            this.cData});
            this.lvCardDetails.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvCardDetails.Location = new System.Drawing.Point(295, 38);
            this.lvCardDetails.Name = "lvCardDetails";
            this.lvCardDetails.Size = new System.Drawing.Size(513, 353);
            this.lvCardDetails.TabIndex = 4;
            this.lvCardDetails.UseCompatibleStateImageBehavior = false;
            this.lvCardDetails.View = System.Windows.Forms.View.Details;
            // 
            // cDescription
            // 
            this.cDescription.Text = "";
            this.cDescription.Width = 100;
            // 
            // cData
            // 
            this.cData.Text = "";
            this.cData.Width = 1000;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(558, 397);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(122, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Zu Deck hinzufügen";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnShowDeck
            // 
            this.btnShowDeck.Location = new System.Drawing.Point(295, 12);
            this.btnShowDeck.Name = "btnShowDeck";
            this.btnShowDeck.Size = new System.Drawing.Size(75, 23);
            this.btnShowDeck.TabIndex = 6;
            this.btnShowDeck.Text = "Zeige Deck";
            this.btnShowDeck.UseVisualStyleBackColor = true;
            this.btnShowDeck.Click += new System.EventHandler(this.btnShowDeck_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(485, 400);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // lblDeckCount
            // 
            this.lblDeckCount.AutoSize = true;
            this.lblDeckCount.Location = new System.Drawing.Point(457, 17);
            this.lblDeckCount.Name = "lblDeckCount";
            this.lblDeckCount.Size = new System.Drawing.Size(0, 13);
            this.lblDeckCount.TabIndex = 8;
            // 
            // btnStat
            // 
            this.btnStat.Location = new System.Drawing.Point(376, 12);
            this.btnStat.Name = "btnStat";
            this.btnStat.Size = new System.Drawing.Size(75, 23);
            this.btnStat.TabIndex = 9;
            this.btnStat.Text = "Statistik";
            this.btnStat.UseVisualStyleBackColor = true;
            this.btnStat.Click += new System.EventHandler(this.btnStat_Click);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 432);
            this.Controls.Add(this.btnStat);
            this.Controls.Add(this.lblDeckCount);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.btnShowDeck);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvCardDetails);
            this.Controls.Add(this.lblSearchName);
            this.Controls.Add(this.tbxSearchName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnGet);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MTGDeckBuilder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fMain_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbxSearchName;
        private System.Windows.Forms.Label lblSearchName;
        private System.Windows.Forms.ListView lvCardDetails;
        private System.Windows.Forms.ColumnHeader cDescription;
        private System.Windows.Forms.ColumnHeader cData;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnShowDeck;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lblDeckCount;
        private System.Windows.Forms.Button btnStat;
    }
}

