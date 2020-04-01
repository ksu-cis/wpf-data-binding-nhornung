using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UniversityRegistry.Data
{
    /// <summary>
    /// A class representing a person associated with the university
    /// </summary>
    public class Person : INotifyPropertyChanged
    {
        /// <summary>
        /// Event triggered when properties of Person change
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The next ID to assign to a newly-created person
        /// </summary>
        public static uint NextID = 80000000;

        /// <summary>
        /// The uinque identifier of this person
        /// </summary>
        public uint ID { get; private set; }


        private string firstName;
        /// <summary>
        /// The person's first name
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName == value) return; // if the value is changing at all
                firstName = value; // assign to private backing var
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FirstName")); //invoke event handler while checking for listener, source of event is THIS class
            }
        }

        private string lastName;
        /// <summary>
        /// The person's last name
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName == value) return; // if the value is changing at all
                lastName = value; // assign to private backing var
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastName"));
            }
        }

        private DateTime dateOfBirth;
        /// <summary>
        /// The person's date of birth
        /// </summary>
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                if (dateOfBirth == value) return; // if the value is changing at all
                dateOfBirth = value; // assign to private backing var
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastName"));
            }
        }

        private bool active;
        /// <summary>
        /// If this person is active in the university (currently a part of the university)
        /// </summary>
        public bool Active
        {
            get { return active; }
            set
            {
                if (active == value) return; // if the value is changing at all
                active = value; // assign to private backing var
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Active"));
            }
        }


        private Role role;
        /// <summary>
        /// The person's role
        /// </summary>
        public Role Role
        {
            get => role;
            set
            {
                if (role == value) return;
                role = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Role"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Role"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsUndergraduateStudent"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsGraduateStudent"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsFaculty"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsStaff"));
            }
        }

        public bool IsFaculty
        {
            get { return Role == Role.Faculty; }
            set { Role = Role.Faculty; }
        }

        /// <summary>
        /// Creates a new user, assigning them an ID
        /// </summary>
        public Person()
        {
            ID = NextID++;
        }

        public override string ToString()
        {
            return $"{LastName}, { FirstName} [{ID}]";
        }
    }
}
