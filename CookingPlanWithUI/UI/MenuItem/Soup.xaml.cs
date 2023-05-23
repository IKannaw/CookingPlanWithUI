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

namespace CookingPlanWithUI.UI.Menu_Item
{
    /// <summary>
    /// Interaction logic for Soup.xaml
    /// </summary>
    public partial class Soup : UserControl
    {
        public Soup()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Components.MenuItemComponents.AddSoup soupDialog = new Components.MenuItemComponents.AddSoup();
            soupDialog.ShowDialog();
        }
    }
}
