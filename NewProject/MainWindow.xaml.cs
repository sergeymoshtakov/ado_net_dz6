using Microsoft.EntityFrameworkCore.Query.Internal;
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

namespace NewProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Data.Data data;
        public MainWindow()
        {
            InitializeComponent();
            data = new Data.Data();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DepartmentCountLabel.Content = data.Departments.Count().ToString();
            ManagerCountLabel.Content = data.Managers.Count().ToString();
            // predicate -> sql query
            TopChiefsCountLabel.Content = data.Managers.Where(manager => manager.IdChief == null).Count().ToString();
            SubordinatesCountLabel.Content = data.Managers.Where(manager => manager.IdChief != null).Count().ToString();
            ITDepartmentCountLabel.Content = data.Managers.Where(manager => manager.IdMainDep == new Guid("D3C376E4-BCE3-4D85-ABA4-E3CF49612C94")).Count().ToString();
            TwoDepartmentsCountLabel.Content = data.Managers.Where(manager => manager.IdMainDep != null && manager.IdSecDep != null).Count().ToString();
        }
    }
}
