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

namespace WindowsFormApp
{
    public partial class FemaleForm : Form
    {
        public static readonly IRepository repo = RepositoryFactory.GetRepository();

        public FemaleForm()
        {
            InitializeComponent();
        }

        private void FemaleForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<Team> femaleTeams = repo.GetFemaleTeams();
                femaleTeams.ForEach(team =>
                {
                    cbFavoriteFemaleTeam.Items.Add(team.ToString());
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
        }
    }
}
