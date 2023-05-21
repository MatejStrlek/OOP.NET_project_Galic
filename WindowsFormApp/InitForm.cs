using DAL.DAO;
using DAL.Repository;

namespace WIndowsFormApp
{
    public partial class InitForm : Form
    {
        public static readonly IRepository repo = RepositoryFactory.GetRepository();

        public InitForm()
        {
            InitializeComponent();
        }

        private void InitForm_Load(object sender, EventArgs e)
        {
        }

        private void btnLanguage_Click(object sender, EventArgs e)
        {
            if (cbLanguage.SelectedIndex == 0)
            {
                MessageBox.Show("You selected English");
                //implement logic for English
            }
            else if (cbLanguage.SelectedIndex == 1)
            {
                MessageBox.Show("You selected Croatian");
                //implement logic for Croatian
            }
            else return;
        }

        private void btnGender_Click(object sender, EventArgs e)
        {
            if (cbGender.SelectedIndex == 0) //male
            {
                try
                {
                    List<Team> maleTeams = repo.GetMaleTeams();
                    MessageBox.Show(maleTeams[0].ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show(
                        "Error while loading API endpoint!",
                        "API Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else if (cbGender.SelectedIndex == 1) //female
            {
                try
                {
                    List<Team> femaleTeams = repo.GetFemaleTeams();
                    MessageBox.Show(femaleTeams[0].ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show(
                        "Error while loading API endpoint!",
                        "API Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

            }
            else return;
        }
    }
}