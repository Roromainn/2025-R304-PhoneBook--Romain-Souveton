using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
	    /// <summary>
    /// Exception thrown when we try to set an empty name
    /// </summary>
    public class NameEmptyException:Exception
    {

    }
	
    /// <summary>
    /// A simple person
    /// </summary>
    public class Person
    {
        #region attributes
        private string? firstName;
        private string lastName;
        private string? adress;
        private string? phone; 
        #endregion

        #region properties
        /// <summary>
        /// get or set the person last name
        /// </summary>
        /// <exception cref="NameEmptyException">if an empty name is set</exception>		
        public string LastName 
		{ 
			get 
            {
                return lastName;
            } 
			set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new NameEmptyException();
                lastName = value;
            } 
		}
        /// <summary>
        /// get or set the person first name.
        /// </summary>
        public string? FirstName 
		{ 
			get
            {
                return firstName; 
            }
            set
            {
                firstName = value ;
            }
        }
        
        /// <summary>
        /// get or set the person's address
        /// </summary>
        public string? Address 
		{
            get
            {
                return adress;
            }
			set 
            {
                adress = value;
            } 
		}
        
		/// <summary>
        /// get or set the phone number of the person
        /// </summary>
        public string? Phone 
		{ 
			get 
            {
                return phone;
            }
			set 
            {   
                phone = value;
            }
		}

        /// <summary>
        /// get the person's identity (LastName FirstName)
        /// </summary>
        public string Identity
        {
            get 
            {
                return LastName.ToUpper() + " " + FirstName[0].ToString().ToUpper() +  FirstName.Substring(1).ToLower(); ;

            }
        }
        #endregion

        #region builder 

        /// <summary>
        /// Init a person
        /// </summary>
        /// <param name="last">person's lastname (must not be empty)</param>
        /// <param name="first">person's firstname</param>
        /// <exception cref="NameEmptyException">if an empty lastname is set</exception>
        public Person(string last, string first)
        {
            this.lastName = last;
            this.firstName = first;
            this.adress = null;
            this.phone = null;
        }
        #endregion

        #region Methods

        /// <summary>
        /// get a string value of the person
        /// </summary>
        /// <returns>a string contains the person's last & first names</returns>
        public override string ToString()
        {
            return Identity;
        }
        #endregion

    }
}
