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
    /// Interaction logic for SideDish.xaml
    /// </summary>
    public partial class SideDish : UserControl
    {
        DataModel.CookingPlanEntities db = new DataModel.CookingPlanEntities();
        public SideDish()
        {
            InitializeComponent();
            DisplayData();
        }

        public void DisplayData()
        {
            var loadData = db.SideDishCategories.ToList();
            sideDishCatDataGrid.ItemsSource = loadData;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Components.MenuCategoryComponents.AddSideDishCategory sideDishCategory = new Components.MenuCategoryComponents.AddSideDishCategory(sideDishCatDataGrid);
            sideDishCategory.lblSideDishCty.Content = "Create Sidedish Category";
            sideDishCategory.btnCreate.Content = "Create";
            sideDishCategory.ShowDialog();
        }

        private void btnEdit(object sender, RoutedEventArgs e)
        {
            DataModel.SideDishCategory selectedItem = sideDishCatDataGrid.SelectedItem as DataModel.SideDishCategory;
            Components.MenuCategoryComponents.AddSideDishCategory sideDCateDialog = new Components.MenuCategoryComponents.AddSideDishCategory(sideDishCatDataGrid);
            sideDCateDialog.lblSideDishCty.Content = "Update SideDish Category";
            sideDCateDialog.btnCreate.Content = "Update";
            sideDCateDialog.txbName.Text = selectedItem.name;
            sideDCateDialog.txbDescription.Text = selectedItem.description;
            sideDCateDialog.ShowDialog();
        }

        private void btnDelete(object sender, RoutedEventArgs e)
        {
            if (DeleteValid())
            {
                try
                {
                    DataModel.SideDishCategory sideDishCategory = sideDishCatDataGrid.SelectedItem as DataModel.SideDishCategory;
                    var deleteCategory = db.SideDishCategories.Where(d => d.id == sideDishCategory.id).Single();
                    db.SideDishCategories.Remove(deleteCategory);
                    db.SaveChanges();
                    sideDishCatDataGrid.ItemsSource = db.SideDishCategories.ToList();
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

        private void searchName_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            string name = searchName.Text;
            Read(name.ToLower());
        }

        public void Read(string _name)
        {

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(sideDishCatDataGrid.ItemsSource);

            if (collectionView != null)
            {
                if (!string.IsNullOrWhiteSpace(_name))
                {
                    collectionView.Filter = (item) =>
                    {
                        // Replace "ColumnName" with the actual name of the column you want to filter
                        var dataItem = item as DataModel.SideDishCategory;
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


    }
}
