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
using System.Windows.Shapes;

namespace CookingPlanWithUI.Components.MenuItemComponents
{
    /// <summary>
    /// Interaction logic for AddSideDish.xaml
    /// </summary>
    public partial class AddSideDish : Window
    {
        DataModel.CookingPlanEntities db = new DataModel.CookingPlanEntities();
        DataGrid sideDishDataGrid = new DataGrid();

        public AddSideDish(DataGrid _sideDishDataGrid)
        {
            InitializeComponent();
            sideDishDataGrid = _sideDishDataGrid;
            LoadData();
            LoadCmbSideDish();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (btnCreate.Content == "Create")
                create();
            if (btnCreate.Content == "Update")
                update();
        }

        private void LoadCmbSideDish()
        {
            var curryCatData = db.SideDishCategories.ToList();
            cmbSDishCategory.ItemsSource = curryCatData;
        }

        private void create()
        {
            try
            {
                DataModel.SideDishCategory selectedCategory = cmbSDishCategory.SelectedItem as DataModel.SideDishCategory;
                // Retrieve the selected value from the ComboBox
                string selectedTaste = cmbTaste.SelectedItem?.ToString();

                // Remove "System.Windows.Controls.ComboBoxItem: " from the selected value
                selectedTaste = selectedTaste?.Replace("System.Windows.Controls.ComboBoxItem: ", "");

                DataModel.SideDish newSideDish = new DataModel.SideDish()
                {
                    sideDishCategory_id = selectedCategory.id,
                    name = txbName.Text,
                    taste = selectedTaste,
                    description = txbDescription.Text,
                    created_at = DateTime.Now
                };
                db.SideDishes.Add(newSideDish);
                db.SaveChanges();
                sideDishDataGrid.ItemsSource = db.SideDishes.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            };
        }

        private void update()
        {
            //try
            //{
            //    DataModel.SideDish selectedSideDish = sideDishDataGrid.SelectedItems as DataModel.SideDish;
            //    DataModel.SideDish updateSideDish = (from c in db.SideDishes where c.id == selectedSideDish.id select c).Single();
            //    updateSideDish.name = txbName.Text;
            //    updateSideDish.sideDishCategory_id = int.Parse(cmbSDishCategory.SelectedValuePath);
            //    updateSideDish.taste = cmbTaste.SelectedItem.ToString();
            //    updateSideDish.description = txbDescription.Text;
            //    db.SaveChanges();
            //    sideDishDataGrid.ItemsSource = db.SideDishes.ToList();
            //    this.Close();
            //}
            //catch
            //{

            //}
        }

        public void LoadData()
        {
            var loadData = db.SideDishes.ToList();
            sideDishDataGrid.ItemsSource = loadData;
        }
    }
}
