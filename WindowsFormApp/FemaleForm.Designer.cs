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
            cbSortLists = new CheckBox();
            menuStrip1 = new MenuStrip();
            tsmiTeamsAndPlayers = new ToolStripMenuItem();
            tsmiRangLists = new ToolStripMenuItem();
            pnlRangLists = new Panel();
            lbPlayersRang = new ListBox();
            lbVisitorsRang = new ListBox();
            label5 = new Label();
            label6 = new Label();
            menuStrip1.SuspendLayout();
            pnlRangLists.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 48);
            label1.Name = "label1";
            label1.Size = new Size(121, 15);
            label1.TabIndex = 0;
            label1.Text = "Favorite female team:";
            // 
            // cbFavoriteFemaleTeam
            // 
            cbFavoriteFemaleTeam.FormattingEnabled = true;
            cbFavoriteFemaleTeam.Location = new Point(12, 66);
            cbFavoriteFemaleTeam.Name = "cbFavoriteFemaleTeam";
            cbFavoriteFemaleTeam.Size = new Size(121, 23);
            cbFavoriteFemaleTeam.TabIndex = 1;
            // 
            // btnFavoriteFemaleTeam
            // 
            btnFavoriteFemaleTeam.Location = new Point(139, 66);
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
            clbPlayers.Location = new Point(12, 122);
            clbPlayers.Name = "clbPlayers";
            clbPlayers.Size = new Size(202, 256);
            clbPlayers.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 104);
            label2.Name = "label2";
            label2.Size = new Size(176, 15);
            label2.TabIndex = 4;
            label2.Text = "Favorite players (choose max 3):";
            // 
            // btnSaveFavoriteFemalePlayers
            // 
            btnSaveFavoriteFemalePlayers.Location = new Point(12, 384);
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
            lbOtherPlayers.SelectionMode = SelectionMode.MultiExtended;
            lbOtherPlayers.Size = new Size(267, 289);
            lbOtherPlayers.TabIndex = 6;
            lbOtherPlayers.DragDrop += lbOtherPlayers_DragDrop;
            lbOtherPlayers.DragEnter += lbOtherPlayers_DragEnter;
            lbOtherPlayers.MouseDown += lbOtherPlayers_MouseDown;
            // 
            // lbFavoritePlayers
            // 
            lbFavoritePlayers.FormattingEnabled = true;
            lbFavoritePlayers.ItemHeight = 15;
            lbFavoritePlayers.Location = new Point(220, 66);
            lbFavoritePlayers.Name = "lbFavoritePlayers";
            lbFavoritePlayers.SelectionMode = SelectionMode.MultiExtended;
            lbFavoritePlayers.Size = new Size(266, 289);
            lbFavoritePlayers.TabIndex = 7;
            lbFavoritePlayers.DragDrop += lbFavoritePlayers_DragDrop;
            lbFavoritePlayers.DragEnter += lbFavoritePlayers_DragEnter;
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
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { tsmiTeamsAndPlayers, tsmiRangLists });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(868, 24);
            menuStrip1.TabIndex = 14;
            menuStrip1.Text = "menuStrip1";
            // 
            // tsmiTeamsAndPlayers
            // 
            tsmiTeamsAndPlayers.Name = "tsmiTeamsAndPlayers";
            tsmiTeamsAndPlayers.Size = new Size(115, 20);
            tsmiTeamsAndPlayers.Text = "Teams and players";
            tsmiTeamsAndPlayers.Click += tsmiTeamsAndPlayers_Click;
            // 
            // tsmiRangLists
            // 
            tsmiRangLists.Name = "tsmiRangLists";
            tsmiRangLists.Size = new Size(68, 20);
            tsmiRangLists.Text = "Rank lists";
            tsmiRangLists.Click += tsmiRangLists_Click;
            // 
            // pnlRangLists
            // 
            pnlRangLists.Controls.Add(label6);
            pnlRangLists.Controls.Add(label5);
            pnlRangLists.Controls.Add(lbVisitorsRang);
            pnlRangLists.Controls.Add(lbPlayersRang);
            pnlRangLists.Location = new Point(0, 27);
            pnlRangLists.Name = "pnlRangLists";
            pnlRangLists.Size = new Size(868, 584);
            pnlRangLists.TabIndex = 15;
            // 
            // lbPlayersRang
            // 
            lbPlayersRang.FormattingEnabled = true;
            lbPlayersRang.ItemHeight = 15;
            lbPlayersRang.Location = new Point(12, 77);
            lbPlayersRang.Name = "lbPlayersRang";
            lbPlayersRang.Size = new Size(403, 379);
            lbPlayersRang.TabIndex = 0;
            // 
            // lbVisitorsRang
            // 
            lbVisitorsRang.FormattingEnabled = true;
            lbVisitorsRang.ItemHeight = 15;
            lbVisitorsRang.Location = new Point(448, 77);
            lbVisitorsRang.Name = "lbVisitorsRang";
            lbVisitorsRang.Size = new Size(408, 379);
            lbVisitorsRang.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 59);
            label5.Name = "label5";
            label5.Size = new Size(74, 15);
            label5.TabIndex = 2;
            label5.Text = "Players rang:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(448, 59);
            label6.Name = "label6";
            label6.Size = new Size(75, 15);
            label6.TabIndex = 3;
            label6.Text = "Visitors rang:";
            // 
            // FemaleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(868, 608);
            Controls.Add(pnlRangLists);
            Controls.Add(cbSortLists);
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
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FemaleForm";
            Text = "Female Form";
            FormClosing += FemaleForm_FormClosing;
            Load += FemaleForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            pnlRangLists.ResumeLayout(false);
            pnlRangLists.PerformLayout();
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
        private CheckBox cbSortLists;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem tsmiTeamsAndPlayers;
        private ToolStripMenuItem tsmiRangLists;
        private Panel pnlRangLists;
        private ListBox lbVisitorsRang;
        private ListBox lbPlayersRang;
        private Label label6;
        private Label label5;
    }
}