using DAL.DAO;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WIndowsFormApp;

namespace WindowsFormApp
{
    public partial class MainForm : Form
    {
        public static readonly IRepository repo = RepositoryFactory.GetRepository();

        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadFemaleTeams();
            await LoadMaleTeams();
        }

        private static async Task LoadFemaleTeams()
        {
            try
            {
                List<Team> femaleTeams = repo.GetFemaleTeams();
                MessageBox.Show("Loaded succesfuly");
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

        private static async Task LoadMaleTeams()
        {
            try
            {
                List<Team> maleTeams = repo.GetMaleTeams();
                
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
    }
}
