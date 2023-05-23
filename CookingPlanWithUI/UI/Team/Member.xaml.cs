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
    /// Interaction logic for Member.xaml
    /// </summary>
    public partial class Member : UserControl
    {
        public Member()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Components.TeamMemberComponents.AddMember memberDialog = new Components.TeamMemberComponents.AddMember();
            memberDialog.ShowDialog();
        }
    }
}
