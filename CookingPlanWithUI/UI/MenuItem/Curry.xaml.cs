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

            DataModel.Curry selectedItem = curryDataGrid.SelectedItem as DataModel.Curry;
            DataModel.CurryCategory curryCategory = (from d in db.CurryCategories
                                                    where d.id == selectedItem.curryCategory_id
                                                    select d.name) as DataModel.CurryCategory;
            string name = selectedItem.name;
            string category = curryCategory.name;
            string description = selectedItem.description;
            string taste = selectedItem.taste;
            Components.MenuItemComponents.AddCurry editCurryDialog = new Components.MenuItemComponents.AddCurry(curryDataGrid);
            // Use the id variable as needed
            // Retrieve the name from the database using LINQ query
            
                editCurryDialog.lblCurry.Content = "Update Curry";
                editCurryDialog.btnCreate.Content = "Update";
       
                // Populate the ComboBox items for cmbCurryCategory
                editCurryDialog.cmbCurryCategory.ItemsSource = db.CurryCategories.ToList();
                editCurryDialog.cmbCurryCategory.DisplayMemberPath = "name";
                editCurryDialog.cmbCurryCategory.SelectedValuePath = "id";
                editCurryDialog.cmbCurryCategory.SelectedValue = category;
               editCurryDialog.cmbTaste.Text = taste;

                //// Populate the ComboBox items for cmbTaste
                //ComboBoxItem selectedTasteItem = editCurryDialog.cmbTaste.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == selectedItem.taste);
                //editCurryDialog.cmbTaste.SelectedItem = selectedTasteItem;

                editCurryDialog.ShowDialog();
           
           
        }

        private void btnDelete(object sender, RoutedEventArgs e)
        {
            if (DeleteValid())
            {
                try
                {
                    DataModel.Curry curry = curryDataGrid.SelectedItem as DataModel.Curry;
                    var deleteCurry = db.Curries.Where(d => d.id == curry.id).Single();
                    db.Curries.Remove(deleteCurry);
                    db.SaveChanges();
                    curryDataGrid.ItemsSource = db.Curries.ToList();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            MainMenuItem mainMenuPage = new MainMenuItem();
            mainMenuPage.Visibility = Visibility.Visible;
        }
    }
}
