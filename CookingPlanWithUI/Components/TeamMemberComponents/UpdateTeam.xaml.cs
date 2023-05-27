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

namespace CookingPlanWithUI.Components.TeamMemberComponents
{
    /// <summary>
    /// Interaction logic for UpdateTeam.xaml
    /// </summary>
    public partial class UpdateTeam : Window
    {
        DataModel.CookingPlanEntities db = new DataModel.CookingPlanEntities();
        DataGrid teamDataGrid = new DataGrid();
        int id;
        public UpdateTeam(DataGrid _teamDataGrid, int _id)
        {
            InitializeComponent();
            teamDataGrid = _teamDataGrid;
            id = _id;
        }

        public void DisplayData()
        {
            var loadData = db.Teams.ToList();
            teamDataGrid.ItemsSource = loadData;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            update();
        }

        private void update()
        {
            try
            {
                DataModel.Team updateTeam = (from i in db.Teams where i.id == id select i).Single();
                updateTeam.name = txbName.Text;
                updateTeam.description = txbDescription.Text;
                db.SaveChanges();
                teamDataGrid.ItemsSource = db.Teams.ToList();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
