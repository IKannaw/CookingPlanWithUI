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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CookingPlanWithUI.UI.Team
{
    /// <summary>
    /// Interaction logic for MainTeamxaml.xaml
    /// </summary>
    public partial class MainTeamxaml : UserControl
    {
        public MainTeamxaml()
        {
            InitializeComponent();
        }

        private void btnTeam_Click(object sender, RoutedEventArgs e)
        {
            memberPage.Visibility = Visibility.Hidden;
            teamPage.Visibility = Visibility.Visible;
        }

        private void btnTeamMember_Click(object sender, RoutedEventArgs e)
        {
            teamPage.Visibility = Visibility.Hidden;
            memberPage.Visibility = Visibility.Visible;       
        }
    }
}
