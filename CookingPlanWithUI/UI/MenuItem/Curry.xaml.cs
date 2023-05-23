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
    /// Interaction logic for Curry.xaml
    /// </summary>
    public partial class Curry : UserControl
    {
        DataModel.CookingPlanEntities db = new DataModel.CookingPlanEntities();
        public Curry()
        {
            InitializeComponent();
            DisplayData();
        }

        public void DisplayData()
        {
            var curryData = db.Curries.ToList();
            curryDataGrid.ItemsSource = curryData;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Components.MenuItemComponents.AddCurry curryDialog = new Components.MenuItemComponents.AddCurry(curryDataGrid);
            curryDialog.lblCurry.Content = "Create Curry";
            curryDialog.btnCreate.Content = "Create";
            curryDialog.ShowDialog();
        }

        private void btnEdit(object sender, RoutedEventArgs e)
        {
            Components.MenuItemComponents.AddCurry editCurryDialog = new Components.MenuItemComponents.AddCurry(curryDataGrid);
            editCurryDialog.lblCurry.Content = "Update Curry";
            editCurryDialog.btnCreate.Content = "Update";
            editCurryDialog.ShowDialog();
        }

        private void btnDelete(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            MainMenuItem mainMenuPage = new MainMenuItem();
            mainMenuPage.Visibility = Visibility.Visible;
        }
    }
}
