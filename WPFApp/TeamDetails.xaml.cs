using DAL.DAO;
using System;
using System.Collections.Generic;
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
        public TeamDetails(Team team)
        {
            InitializeComponent();
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
    }
}
