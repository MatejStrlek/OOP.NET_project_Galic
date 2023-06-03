using DAL.DAO;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private const string PATH = "favorite_male_team.txt";

        public MaleForm()
        {
            InitializeComponent();
        }

        private void MaleForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<Team> maleTeams = repo.GetMaleTeams();
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
    }
}
