using System.IO;
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
using LogicLayer;

namespace HMI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LogicLayer.Directory directory = new LogicLayer.Directory();

        public MainWindow()
        {
            InitializeComponent();
            directory.NewContact(new Person("harris", "steve"));
            directory.NewContact(new Person("dickinson", "bruce"));
            directory.NewContact(new Person("murray", "dave"));
            directory.NewContact(new Person("smith", "adrian"));
            directory.NewContact(new Person("gers", "jannick"));
            directory.NewContact(new Person("mc brain", "nicko"));
            PrintList();


        }

        private void edit(object sender, RoutedEventArgs e)
        { 
                       
        }

        private void remove(object sender, RoutedEventArgs e)
        {
                
        }

        private void add(object sender, RoutedEventArgs e)
        {
            
        }

        private void PrintList()
        {
            contacts.Items.Clear();
            foreach (var p in directory.ListContacts())
            {
                contacts.Items.Add(p);
            }
        }
    }


}