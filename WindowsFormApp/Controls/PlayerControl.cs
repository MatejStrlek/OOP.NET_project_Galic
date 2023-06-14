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

                if (player != null)
                {
                    try
                    {
                        LoadPlayer();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    tbName.Text = "";
                    tbDressNumber.Text = "";
                    tbPosition.Text = "";
                    tbIsCaptain.Text = "";
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
