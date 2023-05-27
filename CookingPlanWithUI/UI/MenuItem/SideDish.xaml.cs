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
    /// Interaction logic for SideDish.xaml
    /// </summary>
    public partial class SideDish : UserControl
    {
        DataModel.CookingPlanEntities db = new DataModel.CookingPlanEntities();

        public SideDish()
        {
            InitializeComponent();
            LoadData(); 
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Components.MenuItemComponents.AddSideDish sideDishDialog = new Components.MenuItemComponents.AddSideDish(sideDishDataGrid);
            sideDishDialog.lblSideDish.Content= "Create SideDish";
            sideDishDialog.btnCreate.Content = "Create";
            sideDishDialog.ShowDialog();
        }

        public void LoadData()
        {
            var loadData = db.SideDishes.ToList();
            sideDishDataGrid.ItemsSource = loadData;
        }

        private void sideDishDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnEdit(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete(object sender, RoutedEventArgs e)
        {
            if (DeleteValid())
            {
                try
                {
                    DataModel.SideDish sideDish = sideDishDataGrid.SelectedItem as DataModel.SideDish;
                    var deleteSideDish = db.SideDishes.Where(d => d.id == sideDish.id).Single();
                    db.SideDishes.Remove(deleteSideDish);
                    db.SaveChanges();
                    sideDishDataGrid.ItemsSource = db.SideDishes.ToList();
                    MessageBox.Show("Deleted successfully", " ", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public bool DeleteValid()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure to delete?", " ", MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes ? true : false;
        }

        private void btnBack(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            MainMenuItem mainMenuItem = new MainMenuItem();
            mainMenuItem.Visibility = Visibility.Hidden;
        }
    }
}
