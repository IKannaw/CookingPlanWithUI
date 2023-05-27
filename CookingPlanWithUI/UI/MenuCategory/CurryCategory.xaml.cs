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
using CookingPlanWithUI.Components.MenuCategoryComponents;

namespace CookingPlanWithUI.UI.Menu_Categories
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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Components.MenuCategoryComponents.CreateCurryCategory curryCateDialog = new CreateCurryCategory(curryCategoryDatagrid);
            curryCateDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            curryCateDialog.lblCurryCategory.Content = "Create Curry Category";
            curryCateDialog.btnCreate.Content = "Create";
            curryCateDialog.ShowDialog();
        }


        public void DisplayData()
        {
            var loadData = db.CurryCategories.ToList();
            curryCategoryDatagrid.ItemsSource = loadData;
        }

        private void btnEdit(object sender, RoutedEventArgs e)
        {
            Components.MenuCategoryComponents.CreateCurryCategory curryCateDialog = new CreateCurryCategory(curryCategoryDatagrid);
            DataModel.CurryCategory curryCategory = curryCategoryDatagrid.SelectedItem as DataModel.CurryCategory;
            string name = curryCategory.name.ToString();
            string description = curryCategory.description.ToString();
            curryCateDialog.txbName.Text = name;
            curryCateDialog.txbDescription.Text = description;
            curryCateDialog.lblCurryCategory.Content = "Update Curry Category";
            curryCateDialog.btnCreate.Content = "Update";
            curryCateDialog.ShowDialog();
        }

        private void btnDelete(object sender, RoutedEventArgs e)
        {
            if (DeleteValid())
            {
                try
                {
                    DataModel.CurryCategory curryCategory = curryCategoryDatagrid.SelectedItem as DataModel.CurryCategory;
                    var deleteCategory = db.CurryCategories.Where(d => d.id == curryCategory.id).Single();
                    db.CurryCategories.Remove(deleteCategory);
                    db.SaveChanges();
                    curryCategoryDatagrid.ItemsSource = db.CurryCategories.ToList();
                    MessageBox.Show("Deleted successfully"," ",MessageBoxButton.OK,MessageBoxImage.Information);
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
            Read(name.ToLower());
        }

        public void Read(string _name)
        {
           
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(curryCategoryDatagrid.ItemsSource);

            if (collectionView != null)
            {
                if (!string.IsNullOrWhiteSpace(_name))
                {
                    collectionView.Filter = (item) =>
                    {
                        // Replace "ColumnName" with the actual name of the column you want to filter
                        var dataItem = item as DataModel.CurryCategory;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            MainMenuCategories mainMenuCategories = new MainMenuCategories();
            mainMenuCategories.Visibility = Visibility.Visible;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            MainMenuCategories main = new MainMenuCategories();
            main.Visibility = Visibility.Visible;
        }
    }
}
