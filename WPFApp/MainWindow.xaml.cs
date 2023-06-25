using DAL.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly IRepository repo = RepositoryFactory.GetRepository();
        private readonly char SEPARATOR = ';';
        private static string FAVORITE_FEMALE_TEAM_PATH =
            System.IO.Path.Combine(
                Directory.GetParent(
                    Directory.GetParent(
                        Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName,
                "favorite_female_team.txt");
        private static string FAVORITE_FEMALE_PLAYERS_PATH =
            System.IO.Path.Combine(
                Directory.GetParent(
                    Directory.GetParent(
                        Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName,
                "favorite_female_players.txt");
        private static string LANGUAGE_AND_GENDER_PATH =
            System.IO.Path.Combine(
                Directory.GetParent(
                    Directory.GetParent(
                        Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName,
                "language_and_gender.txt");
        private static string SCREEN_SIZE_PATH =
            System.IO.Path.Combine(
                Directory.GetParent(
                    Directory.GetParent(
                        Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName,
                "screen_size.txt");

        public MainWindow()
        {
            InitializeComponent();
            LoadcbGender();
            LoadcbLanguage();
            LoadcbScreenSize();
            Init();
            LoadLanguageAndGender();
            LoadScreenSize();
        }

        private void LoadScreenSize()
        {
            try
            {
                string[] lines = repo.LoadScreenSize(SCREEN_SIZE_PATH);

                foreach (string line in lines)
                {
                    string[] details = line.Split(SEPARATOR);

                    if (details.Length == 1)
                    {
                        cbScreenSize.SelectedItem = details[0];
                    }
                    else return;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LoadLanguageAndGender()
        {
            try
            {
                string[] lines = repo.LoadLanguageAndGender(LANGUAGE_AND_GENDER_PATH);

                foreach (string line in lines)
                {
                    string[] details = line.Split(SEPARATOR);

                    if (details.Length == 2)
                    {
                        cbLanguage.SelectedItem = details[0];
                        cbGender.SelectedItem = details[1];
                    }
                    else return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Init()
        {
            cbGender.SelectedIndex = 0;
            cbLanguage.SelectedIndex = 0;
            cbScreenSize.SelectedIndex = 0;
        }

        private void LoadcbScreenSize()
        {
            cbScreenSize.Items.Add("Small");
            cbScreenSize.Items.Add("Medium");
            cbScreenSize.Items.Add("Large");
        }

        private void LoadcbLanguage()
        {
            cbLanguage.Items.Add("English");
            cbLanguage.Items.Add("Croatian");
        }

        private void LoadcbGender()
        {
            cbGender.Items.Add("Male");
            cbGender.Items.Add("Female");
        }

        private void btnSaveFavouriteTeam_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSettings_Click_1(object sender, RoutedEventArgs e)
        {
            spSettings.Visibility = Visibility.Collapsed;
            spFavouriteTeam.Visibility = Visibility.Visible;

            SaveLanguageAndGenderHere();
            SaveScreenSizeHere();
        }

        private void SaveScreenSizeHere()
        {
            string screenSize = cbScreenSize.SelectedItem.ToString();

            try
            {
                repo.SaveScreenSize(screenSize, SCREEN_SIZE_PATH);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveLanguageAndGenderHere()
        {
            string language = cbLanguage.SelectedItem.ToString();
            string gender = cbGender.SelectedItem.ToString();

            try
            {
                repo.SaveLanguageAndGender(language, gender, LANGUAGE_AND_GENDER_PATH);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SettingsWPFWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(SCREEN_SIZE_PATH))
            {
                File.Create(SCREEN_SIZE_PATH).Close();
            }        
        }
    }
}
