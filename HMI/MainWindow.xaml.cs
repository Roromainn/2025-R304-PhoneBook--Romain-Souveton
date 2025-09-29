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
            directory.NewContact(new Person("harris", "steve", GenderType.MALE));
            directory.NewContact(new Person("dickinson", "bruce", GenderType.MALE));
            directory.NewContact(new Person("murray", "dave", GenderType.MALE));
            directory.NewContact(new Person("smith", "adrian", GenderType.MALE));
            directory.NewContact(new Person("gers", "jannick", GenderType.MALE));
            directory.NewContact(new Person("mc brain", "nicko", GenderType.FEMALE));
            PrintList();


        }

        private void edit(object sender, RoutedEventArgs e)
        {
            if (contacts.SelectedItem is PersonHMI p)
            {
                IPerson originale = p.InnerPerson; ;
                IPerson clone = (IPerson)originale.Clone();

                PersonWindow fen = new PersonWindow(clone);

                if (fen.ShowDialog() == true)
                {
                    originale.Copy(clone);
                    PrintList();
                }
            }
        }

        private void remove(object sender, RoutedEventArgs e)
        {
            if (contacts.SelectedItem is PersonHMI p)
            {
                IPerson ARemove = p.InnerPerson;
                if (ARemove is Person person)
                {
                    directory.RemoveContact(person);
                    PrintList();
                }
            }

        }

        private void add(object sender, RoutedEventArgs e)
        {
            Person p = new Person("?", "");
            PersonWindow fen = new PersonWindow(p);
            if (fen.ShowDialog() == true)
            {
                directory.NewContact(p);
                PrintList();
            }

        }

        private void PrintList()
        {
            contacts.Items.Clear();
            foreach (var p in directory.ListContacts())
            {
                contacts.Items.Add(new PersonHMI(p));
            }
        }
    }


}