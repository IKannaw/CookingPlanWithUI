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
    /// Interaction logic for UpdateMember.xaml
    /// </summary>
    public partial class UpdateMember : Window
    {
        DataModel.CookingPlanEntities db = new DataModel.CookingPlanEntities();
        DataGrid memberDataGrid = new DataGrid();
        int id;

        public UpdateMember(DataGrid _memberDataGrid, int _id)
        {
            InitializeComponent();
            memberDataGrid = _memberDataGrid;
            loadCmbMember();
            id = _id;
        }

        private void loadCmbMember()
        {
            var teamData = db.Teams.ToList();
            cmbSelectTeam.ItemsSource = teamData;
        }

        private void btnUpdate(object sender, RoutedEventArgs e)
        {

        }
    }
}
