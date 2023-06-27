using DAL.DAO;
using DAL.Repository;

namespace WindowsFormApp
{
    public partial class MaleForm : Form
    {
        public static readonly IRepository repo = RepositoryFactory.GetRepository();
        private readonly char SEPARATOR = ';';
        private static string FAVORITE_MALE_TEAM_PATH =
            Path.Combine(
                Directory.GetParent(
                    Directory.GetParent(
                        Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName,
                "favorite_male_team.txt");
        private static string FAVORITE_MALE_PLAYERS_PATH =
            Path.Combine(
                Directory.GetParent(
                    Directory.GetParent(
                        Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName,
                "favorite_male_players.txt");
        private static string LANGUAGE_PATH =
            Path.Combine(
                Directory.GetParent(
                    Directory.GetParent(
                        Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName,
                "language_and_gender.txt");

        public MaleForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            cbFavoriteMaleTeam.Focus();
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

        private void MaleForm_Load(object sender, EventArgs e)
        {
            LoadMaleTeamsToCb();
            LoadMalePlayersToClb();
            pnlRangLists.Visible = false;
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
                            label1.Text = "Favorite male team:";
                            label2.Text = "Favorite players (choose max 3):";
                            label3.Text = "Favorite player(s):";
                            label4.Text = "Other players:";
                            label5.Text = "Players rang:";
                            label6.Text = "Visitors rang:";
                            tsmiTeamsAndPlayers.Text = "Teams and players";
                            tsmiRangLists.Text = "Rang lists";
                            settingsToolStripMenuItem.Text = "Settings";
                            btnFavoriteMaleTeam.Text = "Add";
                            btnSaveFavoriteMalePlayers.Text = "Save favorite players";
                            cbSortLists.Text = "Sort";
                        }
                        else
                        {
                            label1.Text = "Omiljeni muski tim:";
                            label2.Text = "Omiljeni igraci (max 3):";
                            label3.Text = "Omiljeni igrac(i):";
                            label4.Text = "Drugi igraci:";
                            label5.Text = "Rang igraca:";
                            label6.Text = "Rang posjetitelja:";
                            tsmiTeamsAndPlayers.Text = "Timovi i igraci";
                            tsmiRangLists.Text = "Rang liste";
                            settingsToolStripMenuItem.Text = "Postavke";
                            btnFavoriteMaleTeam.Text = "Dodaj";
                            btnSaveFavoriteMalePlayers.Text = "Spremi omiljene igrace";
                            cbSortLists.Text = "Sortiraj";
                        }
                    }
                    else return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Error while loading language file!",
                    "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        private void LoadMaleTeamsToCb()
        {
            try
            {
                List<Team> maleTeams = repo.GetMaleTeams();
                maleTeams.ForEach(team =>
                {
                    cbFavoriteMaleTeam.Items.Add(team.GetCountryAndCode());
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

            if (!File.Exists(FAVORITE_MALE_TEAM_PATH))
            {
                cbFavoriteMaleTeam.SelectedIndex = 0;
            }
            else
            {
                LoadFavoriteMaleTeamHere();
            }
        }

        private void btnFavoriteMaleTeam_Click(object sender, EventArgs e)
        {
            if (cbFavoriteMaleTeam.SelectedIndex == -1)
                MessageBox.Show(
                    "Please select a team!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else
                repo.SaveFavoriteTeam(
                    cbFavoriteMaleTeam.SelectedItem.ToString(),
                    FAVORITE_MALE_TEAM_PATH);

            LoadMalePlayersToClb();
            ClearListBoxes();
        }

        private void ClearListBoxes()
        {
            lbFavoritePlayers.Items.Clear();
            lbOtherPlayers.Items.Clear();
        }

        private void LoadFavoriteMaleTeamHere()
        {
            string[] line = repo.LoadFavoriteTeam(FAVORITE_MALE_TEAM_PATH);

            if (line.Length == 0)
            {
                cbFavoriteMaleTeam.SelectedIndex = 0;
            }
            else
            {
                int selectedIndex = cbFavoriteMaleTeam.FindString(line[0]);
                cbFavoriteMaleTeam.SelectedIndex = selectedIndex;
            }
        }

        private List<string> LoadMalePlayersToClb()
        {
            clbPlayers.Items.Clear();

            try
            {
                repo.GetMalePlayers()
                    .ForEach(player =>
                    {
                        clbPlayers.Items.Add(player.GetNameAndDress());
                    });

                if (File.Exists(FAVORITE_MALE_PLAYERS_PATH))
                {
                    List<string> favoriteMalePlayers
                        = repo.LoadFavoritePlayers(FAVORITE_MALE_PLAYERS_PATH).ToList();

                    for (int i = 0; i < clbPlayers.Items.Count; i++)
                    {
                        if (favoriteMalePlayers.Contains(clbPlayers.Items[i].ToString()))
                        {
                            clbPlayers.SetItemChecked(i, true);
                        }
                    }

                    return favoriteMalePlayers;
                }
            }
            catch (Exception ex)
            {
                clbPlayers.Items.Add("No players found!");
                MessageBox.Show(ex.Message);
            }

            return new List<string>();
        }

        private void btnSaveFavoriteMalePlayers_Click(object sender, EventArgs e)
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

                    repo.SaveFavoritePlayers(players, FAVORITE_MALE_PLAYERS_PATH);
                }
            }

            List<string> favMalePlayers = LoadMalePlayersToClb();
            LoadMalePlayersTolb(favMalePlayers);
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

        private void LoadMalePlayersTolb(List<string> favMalePlayers)
        {
            if (favMalePlayers.Any())
            {
                lbFavoritePlayers.Items.Clear();
                lbOtherPlayers.Items.Clear();

                foreach (string player in favMalePlayers)
                {
                    lbFavoritePlayers.Items.Add(player);
                }

                foreach (string player in clbPlayers.Items)
                {
                    if (!favMalePlayers.Contains(player))
                    {
                        lbOtherPlayers.Items.Add(player);
                    }
                }
            }
        }

        private bool drag = false;

        private void lbFavoritePlayers_MouseDown(object sender, MouseEventArgs e)
        {
            ShowOnPlayerControl(lbFavoritePlayers, true);

            if (lbFavoritePlayers.SelectedItem != null)
            {
                drag = true;
                lbFavoritePlayers.DoDragDrop(lbFavoritePlayers.SelectedItem, DragDropEffects.Move);
                lbFavoritePlayers.SelectedItem = null;
            }
        }

        private void lbOtherPlayers_MouseDown(object sender, MouseEventArgs e)
        {
            ShowOnPlayerControl(lbOtherPlayers, false);

            var x = 3;
            if (lbFavoritePlayers.Items.Count == x)
            {
                lbFavoritePlayers.AllowDrop = false;
            }
            else
            {
                lbFavoritePlayers.AllowDrop = true;
            }

            if (lbOtherPlayers.SelectedItem != null)
            {
                drag = true;
                lbOtherPlayers.DoDragDrop(lbOtherPlayers.SelectedItem, DragDropEffects.Move);
                lbOtherPlayers.SelectedItem = null;
            }
        }

        private void ShowOnPlayerControl(ListBox lbPlayers, bool isFavorite)
        {
            if (lbPlayers.SelectedItem != null)
            {
                string selectedFavPlayer = lbPlayers.SelectedItem.ToString();
                string[] playerParts = selectedFavPlayer.Split(" (");

                string playerName = playerParts[0];
                List<Player> players = repo.GetMalePlayers();
                Player player = players.Find(player => player.Name == playerName);

                if (player != null)
                {
                    player.IsFavorite = isFavorite;
                }

                playerControl.Player = player;
            }
        }

        private void cbSortLists_CheckedChanged(object sender, EventArgs e)
        {
            lbFavoritePlayers.Sorted = lbOtherPlayers.Sorted = cbSortLists.Checked;
        }

        private void lbOtherPlayers_DragEnter(object sender, DragEventArgs e)
        {
            if (drag && lbFavoritePlayers.SelectedItem != null)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void lbOtherPlayers_DragDrop(object sender, DragEventArgs e)
        {
            if (drag && lbFavoritePlayers.SelectedItem != null)
            {
                string draggedPlayer = (string)e.Data.GetData(typeof(string));

                lbOtherPlayers.Items.Add(draggedPlayer);
                lbFavoritePlayers.Items.Remove(draggedPlayer);

                SaveFavPlayersAfterDnD();
            }
        }

        private void lbFavoritePlayers_DragEnter(object sender, DragEventArgs e)
        {
            if (drag && lbOtherPlayers.SelectedItem != null)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void lbFavoritePlayers_DragDrop(object sender, DragEventArgs e)
        {
            if (drag && lbOtherPlayers.SelectedItem != null)
            {
                string draggedPlayer = (string)e.Data.GetData(typeof(string));

                lbOtherPlayers.Items.Remove(draggedPlayer);
                lbFavoritePlayers.Items.Add(draggedPlayer);

                SaveFavPlayersAfterDnD();
            }
        }

        private void SaveFavPlayersAfterDnD()
        {
            List<string> players = new();

            foreach (string player in lbFavoritePlayers.Items)
            {
                players.Add(player);
            }

            repo.SaveFavoritePlayers(players, FAVORITE_MALE_PLAYERS_PATH);
        }

        private void MaleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to exit?",
                    "Exit",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    );

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                    "Restart application for changing settings",
                    "Settings",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
        }

        private void tsmiRangLists_Click(object sender, EventArgs e)
        {
            pnlRangLists.Visible = true;

            try
            {
                lbPlayersRang.Items.Clear();
                lbVisitorsRang.Items.Clear();

                LoadPlayersStats();
                LoadVisitorStats();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void LoadPlayersStats()
        {
            repo.GetMalePlayersEvents()
                .GroupBy(e => e.Player)
                .Select(g => new
                {
                    Player = g.Key,
                    Goals = g.Count(e => e.TypeOfEvent == "goal"),
                    YellowCards = g.Count(e => e.TypeOfEvent == "yellow-card")
                })
                .OrderByDescending(x => x.Goals)

                .ToList()
                .ForEach(
                    p => lbPlayersRang.Items.Add(
                        $"{p.Player} - {p.Goals} goals, {p.YellowCards} yellow cards"
                    )
                );
        }

        private void LoadVisitorStats()
        {
            repo.GetMaleVisitorsStats()
                .ForEach(
                    x => lbVisitorsRang.Items.Add(x.GetInfoForRankList())
                );
        }

        private void tsmiTeamsAndPlayers_Click(object sender, EventArgs e)
        {
            pnlRangLists.Visible = false;
        }
    }
}
