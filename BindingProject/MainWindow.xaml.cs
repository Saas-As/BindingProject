using BindingProject.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BindingProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // В ветке with-toolkit используем Toolkit ViewModel
            DataContext = new MainViewModelToolkit();

            // В ветке manual используем старую ViewModel
            // DataContext = new MainViewModel();
        }
    }
}