using LogicLayer;
using System.Windows.Media.Imaging;

namespace HMI
    {
    /// <summary>
    /// Classe de gestion d'une personne pour l'IHM
    /// </summary>
    public class PersonHMI : IPerson
        {
        #region--attributs--
        /// <summary>
        /// La personne gérée
        /// </summary>
        IPerson person;
        #endregion

        #region--constructeur--
        public PersonHMI(IPerson person)
        {
            this.person = person;
        }
        #endregion

        #region--propriétés--
        public string? Address { get => person.Address; set => person.Address = value; }
        public string? FirstName { get => person.FirstName; set => person.FirstName = value; }
        public GenderType Gender { get => person.Gender; set => person.Gender = value; }
        public string Identity => person.Identity;
        public string LastName { get => person.LastName; set => person.LastName = value; }
        public string? PhoneNumber { get => person.PhoneNumber; set => person.PhoneNumber = value; }

        /// <summary>
        /// Affiche une icône selon le genre de la personne
        /// </summary>
        public BitmapImage? Icon
        {
            get
            {
                BitmapImage? res = null;
                switch (Gender)
                {
                    case GenderType.FEMALE:
                        res = new BitmapImage(new Uri("pack://application:,,,/Images/contact_f.png"));
                        break;
                    case GenderType.MALE:
                        res = new BitmapImage(new Uri("pack://application:,,,/Images/contact_m.png"));
                        break;
                    default:
                        res = new BitmapImage(new Uri("pack://application:,,,/Images/contact_x.png"));
                        break;
                       
                }
                return res;
            }
        }

        /// <summary>
        /// Donne accès à la personne interne 
        /// </summary>
        public IPerson InnerPerson
        {
            get { return person; }
        }

        /// <summary>
        /// Get/set si la personne est de genre masculin
        /// </summary>
        /// <returns></returns>
        public bool IsMale
        {
            get
            {
                return this.Gender == GenderType.MALE;
            }
            set
            {
                if (value)
                {
                    person.Gender = GenderType.MALE;
                }
            }
        }
        /// <summary>
        /// Get/set si la personne est de genre féminin
        /// </summary>
        public bool IsFemale
        {
            get
            {
                return this.Gender == GenderType.FEMALE;
            }
            set
            {
                if (value)
                {
                    person.Gender = GenderType.FEMALE;
                }
            }
        }
        #endregion

        #region---méthodes--

        public object Clone()
        {
            return new PersonHMI((IPerson)person.Clone()); 
        }

        public void Copy(IPerson person)
        {
            this.person.Copy(person);
        }
        #endregion
    }
}
