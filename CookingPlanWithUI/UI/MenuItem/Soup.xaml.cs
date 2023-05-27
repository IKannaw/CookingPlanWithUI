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
        DataModel.CookingPlanEntities db = new DataModel.CookingPlanEntities();

        public Soup()
        {
            InitializeComponent();
            //LoadData();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Components.MenuItemComponents.AddSoup soupDialog = new Components.MenuItemComponents.AddSoup(soupDataGrid);
            soupDialog.lblSoup.Content = "Create Soup";
            soupDialog.btnCreate.Content = "Create";
            soupDialog.ShowDialog();
        }

        //public void LoadData()
        //{
        //    var loadData = db.Soups.ToList();
        //    soupDataGrid.ItemsSource = loadData;
        //}

        private void btnEdit(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete(object sender, RoutedEventArgs e)
        {
            if (DeleteValid())
            {
                try
                {
                    DataModel.Soup soup = soupDataGrid.SelectedItem as DataModel.Soup;
                    var deleteSoup = db.Soups.Where(d => d.id == soup.id).Single();
                    db.Soups.Remove(deleteSoup);
                    db.SaveChanges();
                    soupDataGrid.ItemsSource = db.Soups.ToList();
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
            mainMenuItem.Visibility = Visibility.Visible;
        }
    }
}
