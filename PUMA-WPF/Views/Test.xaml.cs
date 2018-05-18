using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using PUMA_WPF.Models;
using PUMA_WPF.ViewModels;
using Xceed.Wpf.AvalonDock.Layout;

namespace PUMA_WPF.Views
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        public SurveyViewModel ViewModel { get; set; }
        public ObservableCollection<LayoutAnchorable> Mypanels { get; private set; }

        public Test()
        {
            ViewModel = new SurveyViewModel();
            Mypanels = new ObservableCollection<LayoutAnchorable>();
            InitializeComponent();
            DataContext = ViewModel;
        }

        public void CreateView()
        {

            LayoutAnchorable newPanel = new LayoutAnchorable() { Title = "New Panel" };
            newPanel.AddToLayout(DockManager, AnchorableShowStrategy.Left);

        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            CreateView();
        }
    }
}
