namespace WindowsFormApp
{
    partial class MaleForm
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
            cbFavoriteMaleTeam = new ComboBox();
            btnFavoriteMaleTeam = new Button();
            menuStrip1 = new MenuStrip();
            tsmiTeamsAndPlayers = new ToolStripMenuItem();
            tsmiRangLists = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            label2 = new Label();
            clbPlayers = new CheckedListBox();
            btnSaveFavoriteMalePlayers = new Button();
            label3 = new Label();
            lbFavoritePlayers = new ListBox();
            lbOtherPlayers = new ListBox();
            label4 = new Label();
            playerControl = new Controls.PlayerControl();
            cbSortLists = new CheckBox();
            pnlRangLists = new Panel();
            lbVisitorsRang = new ListBox();
            lbPlayersRang = new ListBox();
            label6 = new Label();
            label5 = new Label();
            menuStrip1.SuspendLayout();
            pnlRangLists.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 50);
            label1.Name = "label1";
            label1.Size = new Size(111, 15);
            label1.TabIndex = 0;
            label1.Text = "Favorite male team:";
            // 
            // cbFavoriteMaleTeam
            // 
            cbFavoriteMaleTeam.FormattingEnabled = true;
            cbFavoriteMaleTeam.Location = new Point(10, 68);
            cbFavoriteMaleTeam.Name = "cbFavoriteMaleTeam";
            cbFavoriteMaleTeam.Size = new Size(121, 23);
            cbFavoriteMaleTeam.TabIndex = 1;
            // 
            // btnFavoriteMaleTeam
            // 
            btnFavoriteMaleTeam.Location = new Point(137, 68);
            btnFavoriteMaleTeam.Name = "btnFavoriteMaleTeam";
            btnFavoriteMaleTeam.Size = new Size(75, 23);
            btnFavoriteMaleTeam.TabIndex = 2;
            btnFavoriteMaleTeam.Text = "Add";
            btnFavoriteMaleTeam.UseVisualStyleBackColor = true;
            btnFavoriteMaleTeam.Click += btnFavoriteMaleTeam_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { tsmiTeamsAndPlayers, tsmiRangLists, settingsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(868, 24);
            menuStrip1.TabIndex = 3;
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
            tsmiRangLists.Size = new Size(69, 20);
            tsmiRangLists.Text = "Rang lists";
            tsmiRangLists.Click += tsmiRangLists_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 20);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 111);
            label2.Name = "label2";
            label2.Size = new Size(176, 15);
            label2.TabIndex = 4;
            label2.Text = "Favorite players (choose max 3):";
            // 
            // clbPlayers
            // 
            clbPlayers.FormattingEnabled = true;
            clbPlayers.Location = new Point(10, 129);
            clbPlayers.Name = "clbPlayers";
            clbPlayers.Size = new Size(202, 256);
            clbPlayers.TabIndex = 5;
            // 
            // btnSaveFavoriteMalePlayers
            // 
            btnSaveFavoriteMalePlayers.Location = new Point(10, 391);
            btnSaveFavoriteMalePlayers.Name = "btnSaveFavoriteMalePlayers";
            btnSaveFavoriteMalePlayers.Size = new Size(202, 28);
            btnSaveFavoriteMalePlayers.TabIndex = 6;
            btnSaveFavoriteMalePlayers.Text = "Save favorite players";
            btnSaveFavoriteMalePlayers.UseVisualStyleBackColor = true;
            btnSaveFavoriteMalePlayers.Click += btnSaveFavoriteMalePlayers_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(218, 50);
            label3.Name = "label3";
            label3.Size = new Size(100, 15);
            label3.TabIndex = 7;
            label3.Text = "Favorite player(s):";
            // 
            // lbFavoritePlayers
            // 
            lbFavoritePlayers.FormattingEnabled = true;
            lbFavoritePlayers.ItemHeight = 15;
            lbFavoritePlayers.Location = new Point(218, 68);
            lbFavoritePlayers.Name = "lbFavoritePlayers";
            lbFavoritePlayers.SelectionMode = SelectionMode.MultiExtended;
            lbFavoritePlayers.Size = new Size(266, 289);
            lbFavoritePlayers.TabIndex = 8;
            lbFavoritePlayers.DragDrop += lbFavoritePlayers_DragDrop;
            lbFavoritePlayers.DragEnter += lbFavoritePlayers_DragEnter;
            lbFavoritePlayers.MouseDown += lbFavoritePlayers_MouseDown;
            // 
            // lbOtherPlayers
            // 
            lbOtherPlayers.FormattingEnabled = true;
            lbOtherPlayers.ItemHeight = 15;
            lbOtherPlayers.Location = new Point(590, 68);
            lbOtherPlayers.Name = "lbOtherPlayers";
            lbOtherPlayers.SelectionMode = SelectionMode.MultiExtended;
            lbOtherPlayers.Size = new Size(266, 289);
            lbOtherPlayers.TabIndex = 9;
            lbOtherPlayers.DragDrop += lbOtherPlayers_DragDrop;
            lbOtherPlayers.DragEnter += lbOtherPlayers_DragEnter;
            lbOtherPlayers.MouseDown += lbOtherPlayers_MouseDown;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(590, 50);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 10;
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
            cbSortLists.Location = new Point(513, 107);
            cbSortLists.Name = "cbSortLists";
            cbSortLists.Size = new Size(47, 19);
            cbSortLists.TabIndex = 11;
            cbSortLists.Text = "Sort";
            cbSortLists.UseVisualStyleBackColor = true;
            cbSortLists.CheckedChanged += cbSortLists_CheckedChanged;
            // 
            // pnlRangLists
            // 
            pnlRangLists.Controls.Add(lbVisitorsRang);
            pnlRangLists.Controls.Add(lbPlayersRang);
            pnlRangLists.Controls.Add(label6);
            pnlRangLists.Controls.Add(label5);
            pnlRangLists.Location = new Point(0, 27);
            pnlRangLists.Name = "pnlRangLists";
            pnlRangLists.Size = new Size(868, 581);
            pnlRangLists.TabIndex = 13;
            // 
            // lbVisitorsRang
            // 
            lbVisitorsRang.FormattingEnabled = true;
            lbVisitorsRang.ItemHeight = 15;
            lbVisitorsRang.Location = new Point(453, 102);
            lbVisitorsRang.Name = "lbVisitorsRang";
            lbVisitorsRang.Size = new Size(403, 379);
            lbVisitorsRang.TabIndex = 3;
            // 
            // lbPlayersRang
            // 
            lbPlayersRang.FormattingEnabled = true;
            lbPlayersRang.ItemHeight = 15;
            lbPlayersRang.Location = new Point(12, 102);
            lbPlayersRang.Name = "lbPlayersRang";
            lbPlayersRang.Size = new Size(403, 379);
            lbPlayersRang.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(453, 84);
            label6.Name = "label6";
            label6.Size = new Size(75, 15);
            label6.TabIndex = 1;
            label6.Text = "Visitors rang:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 84);
            label5.Name = "label5";
            label5.Size = new Size(74, 15);
            label5.TabIndex = 0;
            label5.Text = "Players rang:";
            // 
            // MaleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(868, 612);
            Controls.Add(pnlRangLists);
            Controls.Add(cbSortLists);
            Controls.Add(label4);
            Controls.Add(playerControl);
            Controls.Add(lbOtherPlayers);
            Controls.Add(lbFavoritePlayers);
            Controls.Add(label3);
            Controls.Add(btnSaveFavoriteMalePlayers);
            Controls.Add(clbPlayers);
            Controls.Add(label2);
            Controls.Add(btnFavoriteMaleTeam);
            Controls.Add(cbFavoriteMaleTeam);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MaleForm";
            Text = "Male Form";
            FormClosing += MaleForm_FormClosing;
            Load += MaleForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            pnlRangLists.ResumeLayout(false);
            pnlRangLists.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbFavoriteMaleTeam;
        private Button btnFavoriteMaleTeam;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem tsmiTeamsAndPlayers;
        private ToolStripMenuItem tsmiRangLists;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private Label label2;
        private CheckedListBox clbPlayers;
        private Button btnSaveFavoriteMalePlayers;
        private Label label3;
        private ListBox lbFavoritePlayers;
        private ListBox lbOtherPlayers;
        private Label label4;
        private Controls.PlayerControl playerControl;
        private CheckBox cbSortLists;
        private Panel pnlRangLists;
        private Label label5;
        private Label label6;
        private ListBox lbPlayersRang;
        private ListBox lbVisitorsRang;
    }
}