using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Répertoire de contacts
    /// </summary>
    /// <see cref="Person"/>
    [DataContract]
    public class Directory
    {
        #region--attributs--
        [DataMember]
        ///<summary>
        ///Contacts dans le répertoire
        ///</summary>
        private List<IPerson> contacts;
        #endregion

        #region--constructeur--
        /// <summary>
        /// Constructeur du répertoire de contacts
        /// </summary>
        public Directory()
        {
            contacts = new List<IPerson>();
        }
        #endregion

        #region--Méthodes--
        /// <summary>
        /// Ajoute une personne aux contacts
        /// </summary>
        /// <param name="p">personne a ajouter</param>
        public void NewContact(IPerson p)
        {
                       
            this.contacts.Add(p);
            
        }
        /// <summary>
        /// Supprime une personne des contacts
        /// </summary>
        /// <param name="p">personne a supprimer </param>
        public void RemoveContact(IPerson p)
        {
          
             contacts.Remove(p);
              
        }
        /// <summary>
        /// Liste tous les contacts
        /// </summary>
        /// <returns>Un string de tout les contacts</returns>
        public IPerson[] ListContacts()
        {
            return contacts.ToArray();
        }

        /// <summary>
        /// Liste les contacts dont le nom de famille commence par l'initiale donnée
        /// </summary>
        /// <param name="initial">Initiale de la recherche</param>
        /// <returns>Une liste de personnes commencant par l'initiale</returns>
        public IPerson[] ListContacts(char initial)
        {
            List<IPerson> res = new List<IPerson> ();
            foreach (IPerson p in contacts)
            {
                if (p.LastName[0] == initial)
                {
                    res.Add(p);
                }
            }
            return res.ToArray();
        }

        [OnDeserializing]
        /// <summary>
        /// Permet d'initialiser la liste de contacts lors de la désérialisation
        /// </summary>
        private void OnDeserializing(StreamingContext context)
        {
            contacts = new List<IPerson>();
        }
        #endregion

    }
}
