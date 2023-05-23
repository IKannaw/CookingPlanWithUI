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

namespace CookingPlanWithUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnMenuItems_Click(object sender, RoutedEventArgs e)
        {
            mainPage.Visibility = Visibility.Hidden;
            mainMenuCategory.Visibility = Visibility.Hidden;
            mainTeam.Visibility = Visibility.Hidden;
            mainMenuItem.Visibility = Visibility.Visible;
        }

        private void btnMenuCategories_Click(object sender, RoutedEventArgs e)
        {
            mainMenuItem.Visibility = Visibility.Hidden;
            mainPage.Visibility = Visibility.Hidden;
            mainTeam.Visibility = Visibility.Hidden;
            mainMenuCategory.Visibility = Visibility.Visible;
        }

        private void btnTeam_Click(object sender, RoutedEventArgs e)
        {
            mainMenuItem.Visibility = Visibility.Hidden;
            mainPage.Visibility = Visibility.Hidden;
            mainMenuCategory.Visibility = Visibility.Hidden;
            mainTeam.Visibility = Visibility.Visible;
        }
    }
}
