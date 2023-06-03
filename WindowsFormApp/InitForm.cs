using DAL.Repository;
using WindowsFormApp;

namespace WIndowsFormApp
{
    public partial class InitForm : Form
    {
        public static readonly IRepository repo = RepositoryFactory.GetRepository();
        private const string PATH = "language_and_gender.txt";
        private const char SEPARATOR = ';';

        public InitForm()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        private void InitForm_Load(object sender, EventArgs e)
        {
            cbLanguage.SelectedIndex = 0;
            cbGender.SelectedIndex = 0;

            LoadLanguageAndGenderHere();
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
    }
}