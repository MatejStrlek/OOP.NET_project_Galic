﻿namespace WindowsFormApp
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
            clbPlayers.Location = new Point(12, 102);
            clbPlayers.Name = "clbPlayers";
            clbPlayers.Size = new Size(202, 130);
            clbPlayers.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 84);
            label2.Name = "label2";
            label2.Size = new Size(176, 15);
            label2.TabIndex = 4;
            label2.Text = "Favorite players (choose max 3):";
            // 
            // btnSaveFavoriteFemalePlayers
            // 
            btnSaveFavoriteFemalePlayers.Location = new Point(12, 238);
            btnSaveFavoriteFemalePlayers.Name = "btnSaveFavoriteFemalePlayers";
            btnSaveFavoriteFemalePlayers.Size = new Size(149, 28);
            btnSaveFavoriteFemalePlayers.TabIndex = 5;
            btnSaveFavoriteFemalePlayers.Text = "Save favorite players";
            btnSaveFavoriteFemalePlayers.UseVisualStyleBackColor = true;
            btnSaveFavoriteFemalePlayers.Click += btnSaveFavoriteFemalePlayers_Click;
            // 
            // FemaleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(988, 527);
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
    }
}