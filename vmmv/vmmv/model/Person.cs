using System;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace vmmv
{
    public class Person : INotifyPropertyChanged, IDataErrorInfo
    {
        private string firstname;
        public string FirstName
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string lastname;
        public string LastName
        {
            get
            {
                return lastname;
            }
            set 
            {
                lastname = value;
                OnPropertyChanged("LastName");
            }
        }

        private DateTime updatedDate;
        public DateTime UpdatedDate
        {
            get
            {
                return updatedDate;
            }
            set
            {
                updatedDate = value;
                OnPropertyChanged("UpdatedDate");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            { 
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                if (columnName == "FirstName")
                {
                    if (string.IsNullOrEmpty(FirstName))
                    {
                        error = "First name is required.";
                    }
                }
                else if (columnName == "LastName")
                {
                    if (string.IsNullOrEmpty(LastName))
                    {
                        error = "Last name is required.";
                    }                 
                }
                return error;
            }
        }
    }
}
