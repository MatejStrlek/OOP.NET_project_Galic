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
    public partial class MaleForm : Form
    {
        public static readonly IRepository repo = RepositoryFactory.GetRepository();

        public MaleForm()
        {
            InitializeComponent();
        }

        private void MaleForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<Team> maleTeams = repo.GetMaleTeams();
                MessageBox.Show("loaded male");
                maleTeams.ForEach(team =>
                {
                    cbFavoriteMaleTeam.Items.Add(team.ToString());
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
