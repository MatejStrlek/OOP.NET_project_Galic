using DAL.DAO;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormApp.Controls
{
    public partial class PlayerControl : UserControl
    {
        private Player player;

        public static readonly IRepository repo = RepositoryFactory.GetRepository();
        private readonly char SEPARATOR = ';';
        private static string IMAGES_DIR_PATH = Path.Combine(
            Directory.GetParent(
                Directory.GetParent(
                    Directory.GetCurrentDirectory()).Parent.FullName)
            .Parent.FullName, "images");
        private static string DEFAULT_IMG_PATH = Path.Combine(
            Directory.GetParent(
                Directory.GetParent(
                    Directory.GetCurrentDirectory()).Parent.FullName)
            .Parent.FullName, "images\\defaultImage.png");
        private static string LANGUAGE_PATH =
            Path.Combine(
                Directory.GetParent(
                    Directory.GetParent(
                        Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName,
                "language_and_gender.txt");

        public PlayerControl()
        {
            InitializeComponent();
            LoadLanguage();
        }

        private void LoadLanguage()
        {
            try
            {
                string[] lines = repo.LoadLanguageAndGender(LANGUAGE_PATH);

                foreach (var line in lines)
                {
                    string[] details = line.Split(SEPARATOR);

                    if (details.Length == 2)
                    {
                        if (details[0] == "English")
                        {
                            gbPlayer.Text = "Player";
                            label1.Text = "Name";
                            label2.Text = "Dress number";
                            label3.Text = "Position";
                            label4.Text = "Is captain";
                            btnUploadPhoto.Text = "Upload photo";
                        }
                        else
                        {
                            gbPlayer.Text = "Igrac";
                            label1.Text = "Ime";
                            label2.Text = "Broj dresa";
                            label3.Text = "Pozicija";
                            label4.Text = "Kapetan?";
                            btnUploadPhoto.Text = "Dodaj sliku";
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Player Player
        {
            get
            {
                return player;
            }
            set
            {
                player = value;

                if (player != null)
                {
                    try
                    {
                        LoadPlayer();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    tbName.Text = "";
                    tbDressNumber.Text = "";
                    tbPosition.Text = "";
                    tbIsCaptain.Text = "";
                }
            }
        }

        private void LoadPlayer()
        {
            tbName.Text = player.Name;
            tbDressNumber.Text = player.DressNumber.ToString();
            tbPosition.Text = player.Position;
            tbIsCaptain.Text = player.IsCaptain ? "Yes" : "Noup";
            pbStar.Visible = player.IsFavorite;

            if (File.Exists(Path.Combine(IMAGES_DIR_PATH, player.Name) + ".png"))
            {
                pbPlayer.Image = Image.FromFile(Path.Combine(IMAGES_DIR_PATH, player.Name) + ".png");
                btnUploadPhoto.Visible = false;
            }
            else if (File.Exists(Path.Combine(IMAGES_DIR_PATH, player.Name) + ".jpg"))
            { 
                pbPlayer.Image = Image.FromFile(Path.Combine(IMAGES_DIR_PATH, player.Name) + ".jpg");
                btnUploadPhoto.Visible = false;
            }
            else
            {
                pbPlayer.Image = Image.FromFile(DEFAULT_IMG_PATH);
                btnUploadPhoto.Visible = true;
            }
        }

        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new ();
            fileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            fileDialog.InitialDirectory = Application.StartupPath;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string imgName = tbName.Text;
                    string imgPath = fileDialog.FileName;
                    string imgExtension = imgPath.Substring(imgPath.LastIndexOf('.'));

                    string newImgPath = Path.Combine(IMAGES_DIR_PATH, imgName) + imgExtension;

                    File.Copy(imgPath, newImgPath);
                    
                    LoadPlayer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
