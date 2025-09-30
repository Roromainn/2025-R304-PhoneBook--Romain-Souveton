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
using JsonStorage;
using LogicLayer;


namespace HMI
{
    /// <summary>
    /// Classe principale de l'IHM
    /// </summary>
    public partial class MainWindow : Window
    {
        #region--attributs--
        /// <summary>
        /// Répertoire de contacts
        /// </summary>
        LogicLayer.Directory directory = new LogicLayer.Directory();
        /// <summary>
        /// Storage des contacts
        /// </summary>
        private IStorage storage;
        #endregion

        #region---constructeur--
        /// <summary>
        /// Constructeur de la fenêtre principale
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            string chemin = System.IO.Directory.GetCurrentDirectory();  

            storage = new StorageJson(chemin + "/sauvegarde.json");
            directory = storage.Load();
            PrintList();
        }
        #endregion

        #region--Méthodes--
        /// <summary>
        /// Modifie le contact sélectionné
        /// </summary>
        private void edit(object sender, RoutedEventArgs e)
        {
            if (contacts.SelectedItem is PersonHMI p)
            {
                PersonHMI originale = p; ;
                PersonHMI clone = (PersonHMI)originale.Clone();

                PersonWindow fen = new PersonWindow(clone);

                if (fen.ShowDialog() == true)
                {
                    originale.Copy(clone);
                    PrintList();
                    storage.Update(originale);
                }
            }
        }

        /// <summary>
        /// Supprime le contact sélectionné
        /// </summary>
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

        /// <summary>
        /// Ajoute un nouveau contact
        /// </summary>
        private void add(object sender, RoutedEventArgs e)
        {
            IPerson p = storage.Create();
            PersonHMI phmi = new PersonHMI(p);
            PersonWindow fen = new PersonWindow(phmi);
            if (fen.ShowDialog() == true)
            {
                directory.NewContact(p);
                PrintList();
                storage.Update(p);
            }

        }

        /// <summary>
        /// Affiche la liste des contacts dans la ListBox
        /// </summary>
        private void PrintList()
        {
            contacts.Items.Clear();
            try
            {
                var list = this.directory.ListContacts();
                if (!(list == null))
                {
                    foreach (var p in list)
                    {
                        contacts.Items.Add(new PersonHMI(p));
                    }
                }
            }
            catch
            {
            }
        }
        #endregion

    }


}