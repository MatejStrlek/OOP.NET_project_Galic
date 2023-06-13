using DAL.DAO;
using DAL.Repository;
using System.IO;

namespace WindowsFormApp
{
    public partial class FemaleForm : Form
    {
        public static readonly IRepository repo = RepositoryFactory.GetRepository();
        private static string FAVORITE_FEMALE_TEAM_PATH =
            Path.Combine(
                Directory.GetParent(
                    Directory.GetParent(
                        Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName,
                "favorite_female_team.txt");
        private static string FAVORITE_FEMALE_PLAYERS_PATH =
            Path.Combine(
                Directory.GetParent(
                    Directory.GetParent(
                        Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName,
                "favorite_female_players.txt");

        public FemaleForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            cbFavoriteFemaleTeam.Focus();
        }

        private void FemaleForm_Load(object sender, EventArgs e)
        {
            LoadFemaleTeamsToCb();
            LoadFemalePlayersToClb();
        }

        private void LoadFemaleTeamsToCb()
        {
            try
            {
                List<Team> femaleTeams = repo.GetFemaleTeams();
                femaleTeams.ForEach(team =>
                {
                    cbFavoriteFemaleTeam.Items.Add(team.GetCountryAndCode());
                });
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Error while loading API endpoint!",
                    "API Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            if (!File.Exists(FAVORITE_FEMALE_TEAM_PATH))
            {
                cbFavoriteFemaleTeam.SelectedIndex = 0;
            }
            else
            {
                LoadFavoriteFemaleTeamHere();
            }
        }

        private void btnFavoriteFemaleTeam_Click(object sender, EventArgs e)
        {
            if (cbFavoriteFemaleTeam.SelectedIndex == -1)
                MessageBox.Show(
                    "Please select a team!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else
                repo.SaveFavoriteTeam(
                    cbFavoriteFemaleTeam.SelectedItem.ToString(),
                    FAVORITE_FEMALE_TEAM_PATH);

            LoadFemalePlayersToClb();
        }

        private void btnSaveFavoriteFemalePlayers_Click(object sender, EventArgs e)
        {
            if (clbPlayers.CheckedItems.Count == 0)
            {
                MessageBox.Show(
                    "Please select at least one player!",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
            }
            else
            {
                if (!CheckIfMoreThanX())
                {
                    List<string> players = new();

                    foreach (string player in clbPlayers.CheckedItems)
                    {
                        players.Add(player);
                    }

                    repo.SaveFavoritePlayers(players, FAVORITE_FEMALE_PLAYERS_PATH);
                } 
            }

            List<string> favFemalePlayers = LoadFemalePlayersToClb();
            LoadFemalePlayersTolb(favFemalePlayers);
        }

        private bool CheckIfMoreThanX()
        {
            var x = 3;

            if (clbPlayers.CheckedItems.Count > x)
            {
                MessageBox.Show(
                    $"More than {x} players!",
                    "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
                return true;
            }
            return false;
        }

        private List<string> LoadFemalePlayersToClb()
        {
            clbPlayers.Items.Clear();

            try
            {
                repo.GetFemalePlayers()
                    .ForEach(player =>
                    {
                        clbPlayers.Items.Add(player.GetNameAndDress());
                    });

                if (File.Exists(FAVORITE_FEMALE_PLAYERS_PATH))
                {
                    List<string> favoriteFemalePlayers
                        = repo.LoadFavoritePlayers(FAVORITE_FEMALE_PLAYERS_PATH).ToList();

                    for (int i = 0; i < clbPlayers.Items.Count; i++)
                    {
                        if (favoriteFemalePlayers.Contains(clbPlayers.Items[i].ToString()))
                        {
                            clbPlayers.SetItemChecked(i, true);
                        }
                    }

                    return favoriteFemalePlayers;
                }
            }
            catch (Exception ex)
            {
                clbPlayers.Items.Add("No players found!");
                MessageBox.Show(ex.Message);
            }

            return new List<string>();
        }

        private void LoadFemalePlayersTolb(List<string> favFemalePlayers)
        {
            if (favFemalePlayers.Any())
            {
                lbFavoritePlayers.Items.Clear();
                lbOtherPlayers.Items.Clear();

                foreach (string player in favFemalePlayers)
                {
                    lbFavoritePlayers.Items.Add(player);
                }

                foreach (string player in clbPlayers.Items)
                {
                    if (!favFemalePlayers.Contains(player))
                    {
                        lbOtherPlayers.Items.Add(player);
                    }
                }
            }
        }

        private void LoadFavoriteFemaleTeamHere()
        {
            string[] line = repo.LoadFavoriteTeam(FAVORITE_FEMALE_TEAM_PATH);

            if (line.Length == 0)
            {
                cbFavoriteFemaleTeam.SelectedIndex = 0;
            }
            else
            {
                int selectedIndex = cbFavoriteFemaleTeam.FindString(line[0]);
                cbFavoriteFemaleTeam.SelectedIndex = selectedIndex;
            }
        }
    }
}
