using DAL.DAO;
using WindowsFormApp;

namespace WIndowsFormApp
{
    public partial class InitForm : Form
    {
        private const string PATH = "language_and_gender.txt";
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

        private void InitForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveLanguageAndGender();
        }

        private void SaveLanguageAndGender()
        {
            List<string> lines = new();
            lines.Add($"{cbLanguage.SelectedItem}{SEPARATOR}{cbGender.SelectedItem}");

            try
            {
                File.WriteAllLines(PATH, lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOpenApp_Click(object sender, EventArgs e)
        {
            if (cbGender.SelectedIndex == 0) //male
            {
                OpenMaleForm();
            }
            else if (cbGender.SelectedIndex == 1) 
            {
                OpenFemaleForm();
            }
            else
            {
                return;
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