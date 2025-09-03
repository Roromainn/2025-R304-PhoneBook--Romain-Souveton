using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// A directory composes persons
    /// </summary>
    /// <see cref="Person"/>
    public class Directory
    {
        #region associations

        #endregion

        #region operations
        /// <summary>
        /// Add a person as a contact
        /// </summary>
        /// <param name="p">the person to add</param>
        public void NewContact(Person p)
        {
            
        }
        /// <summary>
        /// Remove a person from the contacts
        /// </summary>
        /// <param name="p">person to remove</param>
        public void RemoveContact(Person p)
        {
            
        }
        /// <summary>
        /// List all the contacts
        /// </summary>
        /// <returns>An simple array containing contacts</returns>
        public Person[] ListContacts()
        {
            return null;
        }

        /// <summary>
        /// Get persons with lastname starts with the give letter 
        /// </summary>
        /// <param name="initial">the initial (case-sensitive)</param>
        /// <returns>an array with the contacts found</returns>
        public Person[] ListContacts(char initial)
        {
            return null;
        }
        #endregion
    }
}
