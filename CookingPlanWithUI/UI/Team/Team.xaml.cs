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

namespace CookingPlanWithUI.UI.Team
{
    /// <summary>
    /// Interaction logic for Team.xaml
    /// </summary>
    public partial class Team : UserControl
    {
        DataModel.CookingPlanEntities db = new DataModel.CookingPlanEntities();
        public Team()
        {
            InitializeComponent();
            DisplayData();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Components.TeamMemberComponents.AddTeam teamDialog = new Components.TeamMemberComponents.AddTeam(teamDataGrid);
            teamDialog.lblTeam.Content = "Add Team";
            teamDialog.btnCreate.Content = "Add";
            teamDialog.ShowDialog();
        }

        private void btnEdit(object sender, RoutedEventArgs e)
        {
            DataModel.Team team = teamDataGrid.SelectedItem as DataModel.Team;       
            string name = team.name?.ToString();
            string description = team.description?.ToString();
            int id = team.id;
            Components.TeamMemberComponents.UpdateTeam updateDialog = new Components.TeamMemberComponents.UpdateTeam(teamDataGrid,id);
            updateDialog.txbName.Text = name;
            updateDialog.txbDescription.Text = description;
            updateDialog.lblTeam.Content = "Update Team";
            updateDialog.btnCreate.Content = "Update";
            updateDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            updateDialog.ShowDialog();
        }

        public void DisplayData()
        {
            var loadData = db.Teams.ToList();
            teamDataGrid.ItemsSource = loadData;
        }

        private void btnDelete(object sender, RoutedEventArgs e)
        {

            if (DeleteValid())
            {
                try
                {
                    DataModel.Team selectedTeam = teamDataGrid.SelectedItem as DataModel.Team;
                    var team = db.Teams.Where(d => d.id == selectedTeam.id).Single();
                    db.Teams.Remove(team);
                    db.SaveChanges();
                    teamDataGrid.ItemsSource = db.Teams.ToList();
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
            string name = txtSearch.Text;
            Read(name.ToLower());
        }

        public void Read(string _name)
        {

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(teamDataGrid.ItemsSource);

            if (collectionView != null)
            {
                if (!string.IsNullOrWhiteSpace(_name))
                {
                    collectionView.Filter = (item) =>
                    {
                        // Replace "ColumnName" with the actual name of the column you want to filter
                        var dataItem = item as DataModel.Team;
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
            MainTeamxaml mainTeam =new MainTeamxaml();
            mainTeam.Visibility = Visibility.Visible;

        }
    }
}
