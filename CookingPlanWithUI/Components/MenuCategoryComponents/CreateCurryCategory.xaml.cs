
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

namespace CookingPlanWithUI.Components.MenuCategoryComponents
{
    /// <summary>
    /// Interaction logic for CreateCurryCategory.xaml
    /// </summary>
    public partial class CreateCurryCategory : Window
    {
        DataModel.CookingPlanEntities db = new DataModel.CookingPlanEntities();

        DataGrid curryCateDataGrid = new DataGrid();

        public CreateCurryCategory(DataGrid dg)
        {
            InitializeComponent();
            LoadData();
            curryCateDataGrid = dg;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (btnCreate.Content == "Create")
               create();
            if(btnCreate.Content == "Update")        
                update();       
        }

        private void create()
        {
            try
            {
                DataModel.CurryCategory newCurryCategory = new DataModel.CurryCategory()
                {
                    name = txbName.Text,
                    description = txbDescription.Text,
                    created_at = DateTime.Now
                };
                db.CurryCategories.Add(newCurryCategory);
                db.SaveChanges();
                curryCateDataGrid.ItemsSource = db.CurryCategories.ToList();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update()
        {
            try
            {
                DataModel.CurryCategory selectedCurryCat = curryCateDataGrid.SelectedItem as DataModel.CurryCategory;
                DataModel.CurryCategory updateCryCty = ( from i in db.CurryCategories where i.id == selectedCurryCat.id select i).Single();
                updateCryCty.name = txbName.Text;
                updateCryCty.description = txbDescription.Text;
                db.SaveChanges();
                curryCateDataGrid.ItemsSource = db.CurryCategories.ToList();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        public void LoadData()
        {
            var loadData = db.CurryCategories.ToList();
            curryCateDataGrid.ItemsSource = loadData;
        }
    }
}
