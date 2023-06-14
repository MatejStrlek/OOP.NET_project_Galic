namespace WindowsFormApp.Controls
{
    partial class PlayerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerControl));
            gbPlayer = new GroupBox();
            tbIsCaptain = new TextBox();
            label4 = new Label();
            tbPosition = new TextBox();
            label3 = new Label();
            tbDressNumber = new TextBox();
            label2 = new Label();
            tbName = new TextBox();
            label1 = new Label();
            btnUploadPhoto = new Button();
            pbPlayer = new PictureBox();
            pbStar = new PictureBox();
            gbPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPlayer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbStar).BeginInit();
            SuspendLayout();
            // 
            // gbPlayer
            // 
            gbPlayer.Controls.Add(tbIsCaptain);
            gbPlayer.Controls.Add(label4);
            gbPlayer.Controls.Add(tbPosition);
            gbPlayer.Controls.Add(label3);
            gbPlayer.Controls.Add(tbDressNumber);
            gbPlayer.Controls.Add(label2);
            gbPlayer.Controls.Add(tbName);
            gbPlayer.Controls.Add(label1);
            gbPlayer.Location = new Point(3, 3);
            gbPlayer.Name = "gbPlayer";
            gbPlayer.Size = new Size(184, 207);
            gbPlayer.TabIndex = 0;
            gbPlayer.TabStop = false;
            gbPlayer.Text = "Player";
            // 
            // tbIsCaptain
            // 
            tbIsCaptain.Location = new Point(6, 179);
            tbIsCaptain.Name = "tbIsCaptain";
            tbIsCaptain.ReadOnly = true;
            tbIsCaptain.Size = new Size(100, 23);
            tbIsCaptain.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 161);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 6;
            label4.Text = "Is Captain?";
            // 
            // tbPosition
            // 
            tbPosition.Location = new Point(6, 132);
            tbPosition.Name = "tbPosition";
            tbPosition.ReadOnly = true;
            tbPosition.Size = new Size(100, 23);
            tbPosition.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 114);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 4;
            label3.Text = "Position";
            // 
            // tbDressNumber
            // 
            tbDressNumber.Location = new Point(6, 86);
            tbDressNumber.Name = "tbDressNumber";
            tbDressNumber.ReadOnly = true;
            tbDressNumber.Size = new Size(100, 23);
            tbDressNumber.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 68);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 2;
            label2.Text = "Dress number";
            // 
            // tbName
            // 
            tbName.Location = new Point(6, 40);
            tbName.Name = "tbName";
            tbName.ReadOnly = true;
            tbName.Size = new Size(172, 23);
            tbName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 22);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // btnUploadPhoto
            // 
            btnUploadPhoto.Location = new Point(97, 216);
            btnUploadPhoto.Name = "btnUploadPhoto";
            btnUploadPhoto.Size = new Size(173, 23);
            btnUploadPhoto.TabIndex = 1;
            btnUploadPhoto.Text = "Upload photo";
            btnUploadPhoto.UseVisualStyleBackColor = true;
            // 
            // pbPlayer
            // 
            pbPlayer.Image = (Image)resources.GetObject("pbPlayer.Image");
            pbPlayer.Location = new Point(193, 11);
            pbPlayer.Name = "pbPlayer";
            pbPlayer.Size = new Size(229, 194);
            pbPlayer.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPlayer.TabIndex = 2;
            pbPlayer.TabStop = false;
            // 
            // pbStar
            // 
            pbStar.Image = (Image)resources.GetObject("pbStar.Image");
            pbStar.Location = new Point(374, 211);
            pbStar.Name = "pbStar";
            pbStar.Size = new Size(48, 36);
            pbStar.SizeMode = PictureBoxSizeMode.StretchImage;
            pbStar.TabIndex = 3;
            pbStar.TabStop = false;
            // 
            // PlayerControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pbStar);
            Controls.Add(pbPlayer);
            Controls.Add(btnUploadPhoto);
            Controls.Add(gbPlayer);
            Name = "PlayerControl";
            Size = new Size(425, 250);
            gbPlayer.ResumeLayout(false);
            gbPlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbPlayer).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbStar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbPlayer;
        private Label label1;
        private TextBox tbName;
        private TextBox tbDressNumber;
        private Label label2;
        private TextBox tbPosition;
        private Label label3;
        private TextBox tbIsCaptain;
        private Label label4;
        private Button btnUploadPhoto;
        private PictureBox pbPlayer;
        private PictureBox pbStar;
    }
}
