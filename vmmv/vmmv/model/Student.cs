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
    public class Student: INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set 
            {
                name = value;
                if (PropertyChanged != null)
                { 
                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }

        private int age;
        public int Age
        {
            get
            {
                return age;
            }
            set 
            {
                age = value;
                if (PropertyChanged != null)
                { 
                    PropertyChanged(this, new PropertyChangedEventArgs("Age"));
                }
            }
        }

        private int stuNum;
        public int StuNum
        {
            get
            {
                return stuNum;
            }
            set 
            {
                stuNum = value;
                if (PropertyChanged != null)
                { 
                    PropertyChanged(this, new PropertyChangedEventArgs("StuNum"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
