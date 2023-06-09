using DAL.DAO;
using DAL.Repository;
using System.IO;

namespace WindowsFormApp
{
    public partial class FemaleForm : Form
    {
        public static readonly IRepository repo = RepositoryFactory.GetRepository();
        private static string PATH =
            Path.Combine(
                Directory.GetParent(
                    Directory.GetParent(
                        Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName,
                "favorite_female_team.txt");

        public FemaleForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            cbFavoriteFemaleTeam.Focus();
        }

        private void FemaleForm_Load(object sender, EventArgs e)
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

            if (!File.Exists(PATH))
            {
                cbFavoriteFemaleTeam.SelectedIndex = 0;
            }
            else
            {
                LoadFavoriteFemaleTeamHere();
            }

            repo.GetFemalePlayers();
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
            repo.SaveFavoriteTeam(cbFavoriteFemaleTeam.SelectedItem.ToString(), PATH);
        }

        private void LoadFavoriteFemaleTeamHere()
        {
            string[] line = repo.LoadFavoriteTeam(PATH);

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
