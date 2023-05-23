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
    /// Interaction logic for MainMenuItem.xaml
    /// </summary>
    public partial class MainMenuItem : UserControl
    {
        public MainMenuItem()
        {
            InitializeComponent();
        }

        private void btnCurry_Click(object sender, RoutedEventArgs e)
        {
            soupPage.Visibility = Visibility.Hidden;
            sideDishPage.Visibility = Visibility.Hidden;
            curryPage.Visibility = Visibility.Visible;
        }

        private void btnSoup_Click(object sender, RoutedEventArgs e)
        {
            sideDishPage.Visibility = Visibility.Hidden;
            curryPage.Visibility = Visibility.Hidden;
            soupPage.Visibility = Visibility.Visible;
        }

        private void btnSideDish_Click(object sender, RoutedEventArgs e)
        {
            curryPage.Visibility = Visibility.Hidden;
            soupPage.Visibility = Visibility.Hidden;
            sideDishPage.Visibility = Visibility.Visible;         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            MainWindow main = new MainWindow();
            main.Visibility = Visibility.Visible;
        }
    }
}
