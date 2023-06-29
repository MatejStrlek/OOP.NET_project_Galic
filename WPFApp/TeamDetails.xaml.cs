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
    /// Interaction logic for TeamDetails.xaml
    /// </summary>
    public partial class TeamDetails : Window
    {
        public static readonly IRepository repo = RepositoryFactory.GetRepository();
        private readonly char SEPARATOR = ';';
        private static string LANGUAGE_AND_GENDER_PATH =
        System.IO.Path.Combine(
        Directory.GetParent(
            Directory.GetParent(
                Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName,
        "language_and_gender.txt");

        public TeamDetails(Team team)
        {
            InitializeComponent();
            WriteLanguage();
            LoadTeamInfo(team);
        }

        private void LoadTeamInfo(Team team)
        {
            lblTeamName.Content = team.Country;
            lblFifaCode.Content = team.FifaCode;
            lblPlayedGames.Content = team.GamesPlayed;
            lblWonGames.Content = team.Wins;
            lblLostGames.Content = team.Losses;
            lblDrawGames.Content = team.Draws;
            lblScoredGoals.Content = team.GoalsFor;
            lblConcededGoals.Content = team.GoalsAgainst;
            lblGoalDifferential.Content = team.GoalDifferential;
        }

        private void WriteLanguage()
        {
            if (File.Exists(LANGUAGE_AND_GENDER_PATH))
            {
                try
                {
                    string[] lines = repo.LoadLanguageAndGender(LANGUAGE_AND_GENDER_PATH);

                    foreach (var line in lines)
                    {
                        string[] details = line.Split(SEPARATOR);

                        if (details[0] == "English")
                        {
                            lblTextTeamName.Content = "Team name";
                            lblFifaCode.Content = "Fifa code";
                            lblTextPlayedGames.Content = "Played games";
                            lblTextWonGames.Content = "Won games";
                            lblTextLostGames.Content = "Lost games";
                            lblTextDrawGames.Content = "Draw games";
                            lblTextScoredGoals.Content = "Scored goals";
                            lblTextConcededGoals.Content = "Conceded goals";
                            lblTextGoalDifferential.Content = "Goal differential";
                        }
                        else
                        {
                            lblTextTeamName.Content = "Ime tima";
                            lblFifaCode.Content = "Fifa kod";
                            lblTextPlayedGames.Content = "Odigrane utakmice";
                            lblTextWonGames.Content = "Pobjede";
                            lblTextLostGames.Content = "Porazi";
                            lblTextDrawGames.Content = "Nerijeseno";
                            lblTextScoredGoals.Content = "Postignuti golovi";
                            lblTextConcededGoals.Content = "Primljeni golovi";
                            lblTextGoalDifferential.Content = "Razlika u golovima";
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
}
