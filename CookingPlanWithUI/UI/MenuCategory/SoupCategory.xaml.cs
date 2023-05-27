using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Soup.xaml
    /// </summary>
    public partial class Soup : UserControl
    {
        DataModel.CookingPlanEntities db = new DataModel.CookingPlanEntities();

        public Soup()
        {
            InitializeComponent();
            DisplayData();
        }

        public void DisplayData()
        {
            var loadData = db.SoupCategories.ToList();
            soupCatDataGrid.ItemsSource = loadData;
        }

        private void bntAdd_Click(object sender, RoutedEventArgs e)
        {
            Components.MenuCategoryComponents.AddSoupCategory soupCategoryDialog = new Components.MenuCategoryComponents.AddSoupCategory(soupCatDataGrid);
            soupCategoryDialog.lblSoupCategory.Content = "Create Soup Category";
            soupCategoryDialog.btnCreate.Content = "Create";
            soupCategoryDialog.ShowDialog();
        }

        private void btnEdit(object sender, RoutedEventArgs e)
        {
            DataModel.SoupCategory selectedItem = soupCatDataGrid.SelectedItem as DataModel.SoupCategory;
            Components.MenuCategoryComponents.AddSoupCategory soupCategoryDialog = new Components.MenuCategoryComponents.AddSoupCategory(soupCatDataGrid);
            soupCategoryDialog.lblSoupCategory.Content = "Update Soup Category";
            soupCategoryDialog.btnCreate.Content = "Update";
            soupCategoryDialog.txbName.Text = selectedItem.name;
            soupCategoryDialog.txbDescription.Text = selectedItem.description;
            soupCategoryDialog.ShowDialog();
        }

        private void btnDelete(object sender, RoutedEventArgs e)
        {
            if (DeleteValid())
            {
                try
                {
                    DataModel.SoupCategory sideDishCategory = soupCatDataGrid.SelectedItem as DataModel.SoupCategory;
                    var deleteCategory = db.SoupCategories.Where(d => d.id == sideDishCategory.id).Single();
                    db.SoupCategories.Remove(deleteCategory);
                    db.SaveChanges();
                    soupCatDataGrid.ItemsSource = db.SoupCategories.ToList();
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

        private void searchName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string name = searchName.Text;
            Read(name);
        }

        public void Read(string _name)
        {

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(soupCatDataGrid.ItemsSource);

            if (collectionView != null)
            {
                if (!string.IsNullOrWhiteSpace(_name))
                {
                    collectionView.Filter = (item) =>
                    {
                        // Replace "ColumnName" with the actual name of the column you want to filter
                        var dataItem = item as DataModel.SoupCategory;
                        return dataItem.name.ToLower().Contains(_name);
                    };
                }
                else
                {
                    collectionView.Filter = null; // Clear the filter
                }

                collectionView.Refresh(); // Refresh the view to apply the filter
            }
        }

        private void btnBack(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            MainMenuCategories mainMenuCategory = new MainMenuCategories();
            mainMenuCategory.Visibility = Visibility.Visible;
        }
    }
}
