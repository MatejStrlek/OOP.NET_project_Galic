namespace WindowsFormApp
{
    partial class FemaleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            cbFavoriteFemaleTeam = new ComboBox();
            btnFavoriteFemaleTeam = new Button();
            clbPlayers = new CheckedListBox();
            label2 = new Label();
            btnSaveFavoriteFemalePlayers = new Button();
            lbOtherPlayers = new ListBox();
            lbFavoritePlayers = new ListBox();
            label3 = new Label();
            label4 = new Label();
            playerControl = new Controls.PlayerControl();
            btnToOtherPlayers = new Button();
            btnToFavoritePlayers = new Button();
            cbSortLists = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 6);
            label1.Name = "label1";
            label1.Size = new Size(121, 15);
            label1.TabIndex = 0;
            label1.Text = "Favorite female team:";
            // 
            // cbFavoriteFemaleTeam
            // 
            cbFavoriteFemaleTeam.FormattingEnabled = true;
            cbFavoriteFemaleTeam.Location = new Point(12, 24);
            cbFavoriteFemaleTeam.Name = "cbFavoriteFemaleTeam";
            cbFavoriteFemaleTeam.Size = new Size(121, 23);
            cbFavoriteFemaleTeam.TabIndex = 1;
            // 
            // btnFavoriteFemaleTeam
            // 
            btnFavoriteFemaleTeam.Location = new Point(139, 24);
            btnFavoriteFemaleTeam.Name = "btnFavoriteFemaleTeam";
            btnFavoriteFemaleTeam.Size = new Size(75, 23);
            btnFavoriteFemaleTeam.TabIndex = 2;
            btnFavoriteFemaleTeam.Text = "Add favorite";
            btnFavoriteFemaleTeam.UseVisualStyleBackColor = true;
            btnFavoriteFemaleTeam.Click += btnFavoriteFemaleTeam_Click;
            // 
            // clbPlayers
            // 
            clbPlayers.FormattingEnabled = true;
            clbPlayers.Location = new Point(12, 99);
            clbPlayers.Name = "clbPlayers";
            clbPlayers.Size = new Size(202, 256);
            clbPlayers.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 81);
            label2.Name = "label2";
            label2.Size = new Size(176, 15);
            label2.TabIndex = 4;
            label2.Text = "Favorite players (choose max 3):";
            // 
            // btnSaveFavoriteFemalePlayers
            // 
            btnSaveFavoriteFemalePlayers.Location = new Point(12, 361);
            btnSaveFavoriteFemalePlayers.Name = "btnSaveFavoriteFemalePlayers";
            btnSaveFavoriteFemalePlayers.Size = new Size(202, 28);
            btnSaveFavoriteFemalePlayers.TabIndex = 5;
            btnSaveFavoriteFemalePlayers.Text = "Save favorite players";
            btnSaveFavoriteFemalePlayers.UseVisualStyleBackColor = true;
            btnSaveFavoriteFemalePlayers.Click += btnSaveFavoriteFemalePlayers_Click;
            // 
            // lbOtherPlayers
            // 
            lbOtherPlayers.FormattingEnabled = true;
            lbOtherPlayers.ItemHeight = 15;
            lbOtherPlayers.Location = new Point(589, 66);
            lbOtherPlayers.Name = "lbOtherPlayers";
            lbOtherPlayers.Size = new Size(267, 289);
            lbOtherPlayers.TabIndex = 6;
            lbOtherPlayers.MouseDown += lbOtherPlayers_MouseDown;
            // 
            // lbFavoritePlayers
            // 
            lbFavoritePlayers.FormattingEnabled = true;
            lbFavoritePlayers.ItemHeight = 15;
            lbFavoritePlayers.Location = new Point(220, 66);
            lbFavoritePlayers.Name = "lbFavoritePlayers";
            lbFavoritePlayers.Size = new Size(266, 289);
            lbFavoritePlayers.TabIndex = 7;
            lbFavoritePlayers.MouseDown += lbFavoritePlayers_MouseDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(220, 48);
            label3.Name = "label3";
            label3.Size = new Size(100, 15);
            label3.TabIndex = 8;
            label3.Text = "Favorite player(s):";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(589, 48);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 9;
            label4.Text = "Other players:";
            // 
            // playerControl
            // 
            playerControl.Location = new Point(343, 361);
            playerControl.Name = "playerControl";
            playerControl.Player = null;
            playerControl.Size = new Size(427, 250);
            playerControl.TabIndex = 10;
            // 
            // btnToOtherPlayers
            // 
            btnToOtherPlayers.Location = new Point(500, 160);
            btnToOtherPlayers.Name = "btnToOtherPlayers";
            btnToOtherPlayers.Size = new Size(75, 42);
            btnToOtherPlayers.TabIndex = 11;
            btnToOtherPlayers.Text = ">";
            btnToOtherPlayers.UseVisualStyleBackColor = true;
            btnToOtherPlayers.Click += btnToOtherPlayers_Click;
            // 
            // btnToFavoritePlayers
            // 
            btnToFavoritePlayers.Location = new Point(500, 208);
            btnToFavoritePlayers.Name = "btnToFavoritePlayers";
            btnToFavoritePlayers.Size = new Size(75, 42);
            btnToFavoritePlayers.TabIndex = 12;
            btnToFavoritePlayers.Text = "<";
            btnToFavoritePlayers.UseVisualStyleBackColor = true;
            btnToFavoritePlayers.Click += btnToFavoritePlayers_Click;
            // 
            // cbSortLists
            // 
            cbSortLists.AutoSize = true;
            cbSortLists.Location = new Point(517, 111);
            cbSortLists.Name = "cbSortLists";
            cbSortLists.Size = new Size(47, 19);
            cbSortLists.TabIndex = 13;
            cbSortLists.Text = "Sort";
            cbSortLists.UseVisualStyleBackColor = true;
            cbSortLists.CheckedChanged += cbSortLists_CheckedChanged;
            // 
            // FemaleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(868, 618);
            Controls.Add(cbSortLists);
            Controls.Add(btnToFavoritePlayers);
            Controls.Add(btnToOtherPlayers);
            Controls.Add(playerControl);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(lbFavoritePlayers);
            Controls.Add(lbOtherPlayers);
            Controls.Add(btnSaveFavoriteFemalePlayers);
            Controls.Add(label2);
            Controls.Add(clbPlayers);
            Controls.Add(btnFavoriteFemaleTeam);
            Controls.Add(cbFavoriteFemaleTeam);
            Controls.Add(label1);
            Name = "FemaleForm";
            Text = "Female Form";
            Load += FemaleForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbFavoriteFemaleTeam;
        private Button btnFavoriteFemaleTeam;
        private CheckedListBox clbPlayers;
        private Label label2;
        private Button btnSaveFavoriteFemalePlayers;
        private ListBox lbOtherPlayers;
        private ListBox lbFavoritePlayers;
        private Label label3;
        private Label label4;
        private Controls.PlayerControl playerControl;
        private Button btnToOtherPlayers;
        private Button btnToFavoritePlayers;
        private CheckBox cbSortLists;
    }
}