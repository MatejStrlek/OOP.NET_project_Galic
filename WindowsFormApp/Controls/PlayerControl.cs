using DAL.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormApp.Controls
{
    public partial class PlayerControl : UserControl
    {
        private Player player;

        public PlayerControl()
        {
            InitializeComponent();
        }

        public Player Player
        {
            get
            {
                return player;
            }
            set
            {
                player = value;
                try
                {
                    LoadPlayer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void LoadPlayer()
        {
            tbName.Text = player.Name;
            tbDressNumber.Text = player.DressNumber.ToString();
            tbPosition.Text = player.Position;
            tbIsCaptain.Text = player.IsCaptain ? "Yes" : "Noup";
            pbStar.Visible = player.IsFavorite;
        }
    }
}
