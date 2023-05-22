using DAL.DAO;
using DAL.Repository;

namespace WIndowsFormApp
{
    public partial class InitForm : Form
    {
        public static readonly IRepository repo = RepositoryFactory.GetRepository();
        private const string PATH = @"D:\Algebra\4. semestar\.NET\OOP.NET_FIFA_project\language_and_gender.txt";
        private const char SEPARATOR = ';';

        public InitForm()
        {
            InitializeComponent();
        }

        private void InitForm_Load(object sender, EventArgs e)
        {
            cbLanguage.SelectedIndex = 0;
            cbGender.SelectedIndex = 0;

            LoadLanguageAndGender();
        }

        private void LoadLanguageAndGender()
        {
            if (!File.Exists(PATH))
            {
                File.Create(PATH);
            }

            try
            {
                string[] lines = File.ReadAllLines(PATH);

                foreach (var line in lines)
                {
                    string[] details = line.Split(SEPARATOR);

                    if (details.Length == 2)
                    {
                        cbLanguage.SelectedItem = details[0];
                        cbGender.SelectedItem = details[1];
                    }
                    else return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void InitForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveLanguageAndGender();
        }

        private void SaveLanguageAndGender()
        {
            List<string> lines = new ();
            lines.Add($"{cbLanguage.SelectedItem.ToString()}{SEPARATOR}{cbGender.SelectedItem.ToString()}");

            try
            {
                File.WriteAllLines(PATH, lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
    }
}