using DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFApp.Controls
{
    /// <summary>
    /// Interaction logic for PlayerControl.xaml
    /// </summary>
    public partial class PlayerControl : Window
    {
        public PlayerControl(Player player)
        {
            InitializeComponent();
            LoadPlayer(player);
        }

        private void LoadPlayer(Player player)
        {
            lblPlayerName.Content = player.Name;
            lblShirtNumber.Content = player.DressNumber;
            lblPosition.Content = player.Position;
            lblCaptain.Content = player.IsCaptain ? "Captain" : "Player";
        }
    }
}
