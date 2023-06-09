using DAL.DAO;
using DAL.Repository;

namespace WindowsFormApp
{
    public partial class MaleForm : Form
    {
        public static readonly IRepository repo = RepositoryFactory.GetRepository();
        private static string PATH =
            Path.Combine(
                Directory.GetParent(
                    Directory.GetParent(
                        Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName,
                "favorite_male_team.txt");

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

            if (!File.Exists(PATH))
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
                repo.SaveFavoriteTeam(cbFavoriteMaleTeam.SelectedItem.ToString(), PATH);
        }

        private void LoadFavoriteMaleTeamHere()
        {
            string[] line = repo.LoadFavoriteTeam(PATH);

            if(line.Length == 0)
            {
                cbFavoriteMaleTeam.SelectedIndex = 0;
            }
            else
            {
                int selectedIndex = cbFavoriteMaleTeam.FindString(line[0]);
                cbFavoriteMaleTeam.SelectedIndex = selectedIndex;
            }     
        }
    }
}
