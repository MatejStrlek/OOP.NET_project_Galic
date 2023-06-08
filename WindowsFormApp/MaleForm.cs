using DAL.DAO;
using DAL.Repository;

namespace WindowsFormApp
{
    public partial class MaleForm : Form
    {
        public static readonly IRepository repo = RepositoryFactory.GetRepository();
        private const string PATH = "favorite_male_team.txt";

        public MaleForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            cbFavoriteMaleTeam.Focus();
        }

        private void MaleForm_Load(object sender, EventArgs e)
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

            cbFavoriteMaleTeam.SelectedIndex = 0;
            LoadFavoriteMaleTeamHere();
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
                repo.SaveFavoriteTeam(cbFavoriteMaleTeam.SelectedItem.ToString(), PATH);
        }

        private void LoadFavoriteMaleTeamHere()
        {
            string line = repo.LoadFavoriteTeam(PATH);

            int selectedIndex = cbFavoriteMaleTeam.FindString(line);

            if (selectedIndex != -1)
                cbFavoriteMaleTeam.SelectedIndex = selectedIndex;
            else 
                cbFavoriteMaleTeam.SelectedIndex = 0;
        }
    }
}
