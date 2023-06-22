using DAL.Repository;
using WindowsFormApp;

namespace WIndowsFormApp
{
    public partial class InitForm : Form
    {
        public static readonly IRepository repo = RepositoryFactory.GetRepository();
        private static string PATH =
            Path.Combine(
                Directory.GetParent(
                    Directory.GetParent(
                        Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName, 
                "language_and_gender.txt");
        private const char SEPARATOR = ';';

        public InitForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitForm_Load(object sender, EventArgs e)
        {
            if (!File.Exists(PATH))
            {
                cbLanguage.SelectedIndex = 0;
                cbGender.SelectedIndex = 0;
            }
            else
            {
                LoadLanguageAndGenderHere();
            }
        }

        private void LoadLanguageAndGenderHere()
        {
            try
            {
                string[] lines = repo.LoadLanguageAndGender(PATH);

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

        private void InitForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveLanguageAndGenderHere();

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

        private void btnOpenApp_Click(object sender, EventArgs e)
        {
            if (cbGender.SelectedIndex == -1 || cbLanguage.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please choose gender and language",
                    "Choose",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }
            else if (cbGender.SelectedIndex == 0) //male form            
                OpenMaleForm();
            else if (cbGender.SelectedIndex == 1) //female form            
                OpenFemaleForm();
            else return;
        }

        private void OpenFemaleForm()
        {
            Form femaleForm = new FemaleForm();
            femaleForm.Show();
        }

        private void OpenMaleForm()
        {
            Form maleForm = new MaleForm();
            maleForm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            SaveLanguageAndGenderHere();
            Close();
        }

        private void SaveLanguageAndGenderHere()
        {
            string language = cbLanguage.SelectedItem.ToString();
            string gender = cbGender.SelectedItem.ToString();

            try
            {              
                repo.SaveLanguageAndGender(language, gender, PATH);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}