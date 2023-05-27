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

namespace CookingPlanWithUI.UI.Menu_Categories
{
    /// <summary>
    /// Interaction logic for MainMenuCategories.xaml
    /// </summary>
    public partial class MainMenuCategories : UserControl
    {
        DataModel.CookingPlanEntities db = new DataModel.CookingPlanEntities();

        public MainMenuCategories()
        {
            InitializeComponent();
        }

        private void btnCurryCategory_Click(object sender, RoutedEventArgs e)
        {
            soupCategoryPage.Visibility = Visibility.Hidden;
            sideDCategoryPage.Visibility = Visibility.Hidden;
            curryCategoryPage.Visibility = Visibility.Visible;
        }

        private void btnSoupCategory_Click(object sender, RoutedEventArgs e)
        {
            sideDCategoryPage.Visibility = Visibility.Hidden;
            curryCategoryPage.Visibility = Visibility.Hidden;
            soupCategoryPage.Visibility = Visibility.Visible;
        }

        private void btnSideDishCategory_Click(object sender, RoutedEventArgs e)
        {
            curryCategoryPage.Visibility = Visibility.Hidden;
            soupCategoryPage.Visibility = Visibility.Hidden;
            sideDCategoryPage.Visibility = Visibility.Visible;           
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnBack(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Visibility = Visibility.Hidden;    
            main.Visibility = Visibility.Visible;
        }
    }
}
