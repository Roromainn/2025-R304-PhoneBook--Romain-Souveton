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
        private IStorage storage;

        public MainWindow()
        {
            InitializeComponent();
            storage = new MockStorage();
            directory = storage.Load();


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
                    storage.Update((Person)originale);
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
                    storage.Delete(person);
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
                storage.Update(p);
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