using DAL.DAO;
using DAL.Repository;
using System.Collections;
using System.IO;
using WindowsFormApp.Controls;

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
            AllowDropOnListBoxes();
        }

        private void AllowDropOnListBoxes()
        {
            var listBoxes = this.Controls.OfType<ListBox>();

            foreach (var listBox in listBoxes)
            {
                listBox.AllowDrop = true;
            }
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

        private void btnToOtherPlayers_Click(object sender, EventArgs e)
        {
            MovePlayers(lbFavoritePlayers, lbOtherPlayers, lbFavoritePlayers.SelectedItems);
        }

        private void btnToFavoritePlayers_Click(object sender, EventArgs e)
        {
            MovePlayers(lbOtherPlayers, lbFavoritePlayers, lbOtherPlayers.SelectedItems);
        }

        private void MovePlayers(ListBox fromList, ListBox toList, IEnumerable selectedItems)
        {
            List<string> players = new();

            foreach (string player in selectedItems)
            {
                players.Add(player);
            }

            foreach (string player in players)
            {
                fromList.Items.Remove(player);
                toList.Items.Add(player);
            }
        }

        private void lbFavoritePlayers_MouseDown(object sender, MouseEventArgs e)
        {
            ShowOnPlayerControl(lbFavoritePlayers, true);
        }

        private void lbOtherPlayers_MouseDown(object sender, MouseEventArgs e)
        {
            ShowOnPlayerControl(lbOtherPlayers, false);
        }

        private void ShowOnPlayerControl(ListBox lbPlayers, bool isFavorite)
        {
            if (lbPlayers.SelectedItem != null)
            {
                string selectedFavPlayer = lbPlayers.SelectedItem.ToString();
                string[] playerParts = selectedFavPlayer.Split(" (");

                string playerName = playerParts[0];
                List<Player> players = repo.GetFemalePlayers();
                Player player = players.Find(player => player.Name == playerName);
                player.IsFavorite = isFavorite;

                playerControl.Player = player;
            }
        }

        private void cbSortLists_CheckedChanged(object sender, EventArgs e)
        {
            lbFavoritePlayers.Sorted = lbOtherPlayers.Sorted = cbSortLists.Checked;
        }
    }
}
