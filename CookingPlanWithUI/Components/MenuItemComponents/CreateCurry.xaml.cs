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
    /// Interaction logic for AddCurry.xaml
    /// </summary>
    public partial class AddCurry : Window
    {
        DataModel.CookingPlanEntities db = new DataModel.CookingPlanEntities();
        DataGrid curryDataGrid = new DataGrid();

        public AddCurry(DataGrid _curryDataGrid)
        {
            InitializeComponent();
            curryDataGrid = _curryDataGrid;
            loadCmbCurry();
        }

        private void loadCmbCurry()
        {
            var curryCatData = db.CurryCategories.ToList();          
            cmbCurryCategory.ItemsSource = curryCatData.ToList();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (btnCreate.Content == "Create")
                create();
            if (btnCreate.Content == "Update")
                update();
        }

        private void create()
        {
            try
            {
                DataModel.CurryCategory selectedCategory = new DataModel.CurryCategory();
                // Retrieve the selected value from the ComboBox
                string selectedTaste = cmbTaste.SelectedItem?.ToString();

                // Remove "System.Windows.Controls.ComboBoxItem: " from the selected value
                selectedTaste = selectedTaste?.Replace("System.Windows.Controls.ComboBoxItem: ", "");

                DataModel.Curry newCurry = new DataModel.Curry()
                {
                    curryCategory_id = int.Parse(cmbCurryCategory.SelectedIndex.ToString()),
                    name = txbName.Text,
                    taste = selectedTaste,
                    description = txbDescription.Text,
                    created_at = DateTime.Now
                };
                db.Curries.Add(newCurry);
                db.SaveChanges();
                curryDataGrid.ItemsSource = db.Curries.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            };
        }

        private void update()
        {

        }

        private void cmbCurryCategory_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }
    }
}
