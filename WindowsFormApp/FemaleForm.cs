using DAL.DAO;
using DAL.Repository;

namespace WindowsFormApp
{
    public partial class FemaleForm : Form
    {
        public static readonly IRepository repo = RepositoryFactory.GetRepository();
        private const string PATH = "favorite_female_team.txt";

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

            cbFavoriteFemaleTeam.SelectedIndex = 0;
            LoadFavoriteFemaleTeamHere();
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
            string line = repo.LoadFavoriteTeam(PATH);

            int selectedIndex = cbFavoriteFemaleTeam.FindString(line);

            if (selectedIndex != -1)
                cbFavoriteFemaleTeam.SelectedIndex = selectedIndex;
        }
    }
}
