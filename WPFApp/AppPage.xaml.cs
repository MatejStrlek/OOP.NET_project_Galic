using DAL.DAO;
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
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for AppPage.xaml
    /// </summary>
    public partial class AppPage : Window
    {
        public static readonly IRepository repo = RepositoryFactory.GetRepository();
        private readonly char SEPARATOR = ';';
        private static string FAVORITE_FEMALE_TEAM_PATH =
            System.IO.Path.Combine(
                Directory.GetParent(
                    Directory.GetParent(
                        Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName,
                "favorite_female_team.txt");
        private static string FAVORITE_MALE_TEAM_PATH =
            System.IO.Path.Combine(
                Directory.GetParent(
                    Directory.GetParent(
                        Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName,
                "favorite_male_team.txt");
        private static string LANGUAGE_AND_GENDER_PATH =
            System.IO.Path.Combine(
                Directory.GetParent(
                    Directory.GetParent(
                        Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName,
                "language_and_gender.txt");

        public AppPage()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadFirstTeamcb();
            AddFavoriteIfExists();
        }

        private void AddFavoriteIfExists()
        {
            try
            {
                string[] lines = repo.LoadLanguageAndGender(LANGUAGE_AND_GENDER_PATH);

                foreach (string line in lines)
                {
                    string[] details = line.Split(SEPARATOR);

                    if (details[1] == "Male")
                    {
                        try
                        {
                            string[] team = repo.LoadFavoriteTeam(FAVORITE_MALE_TEAM_PATH);

                            if (team.Length == 0)
                            {
                                cbFirstTeam.SelectedIndex = 0;
                            }
                            else
                            {
                                string selectedTeam = team[0];

                                var selectedItem
                                    = cbFirstTeam.Items.Cast<string>()
                                    .Where(i => i == selectedTeam)
                                    .FirstOrDefault();

                                if (selectedItem != null)
                                {
                                      cbFirstTeam.SelectedItem = selectedItem;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            string[] team = repo.LoadFavoriteTeam(FAVORITE_FEMALE_TEAM_PATH);

                            if (team.Length == 0)
                            {
                                cbFirstTeam.SelectedIndex = 0;
                            }
                            else
                            {
                                string selectedTeam = team[0];

                                var selectedItem
                                    = cbFirstTeam.Items.Cast<string>()
                                    .Where(i => i == selectedTeam)
                                    .FirstOrDefault();

                                if (selectedItem != null)
                                {
                                    cbFirstTeam.SelectedItem = selectedItem;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LoadFirstTeamcb()
        {
            try
            {
                string[] lines = repo.LoadLanguageAndGender(LANGUAGE_AND_GENDER_PATH);

                foreach (string line in lines)
                {
                    string[] details = line.Split(SEPARATOR);

                    if (details[1] == "Male")
                    {
                        try
                        {
                            List<Team> teams = repo.GetMaleTeams();

                            foreach (var team in teams)
                            {
                                cbFirstTeam.Items.Add(team.GetCountryAndCode());
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            List<Team> teams = repo.GetFemaleTeams();

                            foreach (var team in teams)
                            {
                                cbFirstTeam.Items.Add(team.GetCountryAndCode());
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbFirstTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearCurrentTeamsInSecondcb();
            LoadSecondTeamcb();
        }

        private void cbSecondTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbSecondTeam.SelectedIndex == -1)
            {
                return;
            }

            try
            {
                string[] lines = repo.LoadLanguageAndGender(LANGUAGE_AND_GENDER_PATH);

                foreach (string line in lines)
                {
                    string[] details = line.Split(SEPARATOR);

                    if (details[1] == "Female")
                    {
                        lblResults.Content
                            = repo.GetFemaleResult(GetFirstFemaleTeam(), GetSecondFemaleTeam());
                    }
                    else
                    {
                        lblResults.Content
                            = repo.GetMaleResult(GetFirstMaleTeam(), GetSecondMaleTeam());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFirstTeamDetails_Click(object sender, RoutedEventArgs e)
        {
            if (cbFirstTeam.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a team",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );

                return;
            }

            try
            {
                string[] lines = repo.LoadLanguageAndGender(LANGUAGE_AND_GENDER_PATH);

                foreach (string line in lines)
                {
                    string[] details = line.Split(SEPARATOR);

                    if (details[1] == "Female")
                    {
                        TeamDetails teamDetails = new TeamDetails(GetFirstFemaleTeam());
                        teamDetails.Show();
                    }
                    else
                    {
                        TeamDetails teamDetails = new TeamDetails(GetFirstMaleTeam());
                        teamDetails.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSecondTeamDetails_Click(object sender, RoutedEventArgs e)
        {
            if (cbFirstTeam.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a team",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );

                return;
            }

            try
            {
                string[] lines = repo.LoadLanguageAndGender(LANGUAGE_AND_GENDER_PATH);

                foreach (string line in lines)
                {
                    string[] details = line.Split(SEPARATOR);

                    if (details[1] == "Female")
                    {
                        TeamDetails teamDetails = new TeamDetails(GetSecondFemaleTeam());
                        teamDetails.Show();
                    }
                    else
                    {
                        TeamDetails teamDetails = new TeamDetails(GetSecondMaleTeam());
                        teamDetails.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                    "Restart application for changing settings",
                    "Settings",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );
        }

        private void ClearCurrentTeamsInSecondcb()
        {
            cbSecondTeam.Items.Clear();
        }

        private void LoadSecondTeamcb()
        {
            try
            {
                string[] lines = repo.LoadLanguageAndGender(LANGUAGE_AND_GENDER_PATH);

                foreach (string line in lines)
                {
                    string[] details = line.Split(SEPARATOR);

                    if (details[1] == "Female")
                    {
                        repo.GetFemaleEnemyTeams(GetFirstFemaleTeam())
                            .ForEach(team => cbSecondTeam.Items.Add(team.GetCountryAndCode()));
                    }
                    else
                    {
                        repo.GetMaleEnemyTeams(GetFirstMaleTeam())
                            .ForEach(team => cbSecondTeam.Items.Add(team.GetCountryAndCode()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Team GetFirstFemaleTeam()
        {
            try
            {
                if (cbFirstTeam.SelectedItem != null)
                {
                    List<Team> teams = repo.GetFemaleTeams();

                    foreach (Team team in teams)
                    {
                          if (team.GetCountryAndCode() == cbFirstTeam.SelectedItem.ToString())
                        {
                            return team;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }

        private Team GetSecondFemaleTeam()
        {
            try
            {
                if (cbSecondTeam.SelectedItem != null)
                {
                    List<Team> teams = repo.GetFemaleTeams();

                    foreach (Team team in teams)
                    {
                        if (team.GetCountryAndCode() == cbSecondTeam.SelectedItem.ToString())
                        {
                            return team;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }

        private Team GetFirstMaleTeam()
        {
            try
            {
                if (cbFirstTeam.SelectedItem != null)
                {
                    List<Team> teams = repo.GetMaleTeams();

                    foreach (Team team in teams)
                    {
                        if (team.GetCountryAndCode() == cbFirstTeam.SelectedItem.ToString())
                        {
                            return team;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }

        private Team GetSecondMaleTeam()
        {
            try
            {
                if (cbSecondTeam.SelectedItem != null)
                {
                    List<Team> teams = repo.GetMaleTeams();

                    foreach (Team team in teams)
                    {
                        if (team.GetCountryAndCode() == cbSecondTeam.SelectedItem.ToString())
                        {
                            return team;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                                "Are you sure you want to exit?",
                                "Exit",
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Question
                                );
            
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
