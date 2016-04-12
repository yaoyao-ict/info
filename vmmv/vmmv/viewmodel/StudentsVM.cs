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
using System.Collections.Generic;

namespace vmmv
{
    public class StudentsVM : INotifyPropertyChanged
    {
        private List<Student> students;
        public List<Student> Students
        {
            get
            {
                return students;
            }
            set
            {
                students = value;
                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Students"));
                }
            }
        }

        public StudentsVM()
        {
            students = new List<Student>()
            {
                new Student() {Age = 20, Name = "Vivian", StuNum = 1},
                new Student() {Age = 21, Name = "James", StuNum = 2},
                new Student() {Age = 22, Name = "Henry", StuNum = 5},
                new Student() {Age = 26, Name = "Jack", StuNum = 13},
                new Student() {Age = 17, Name = "Mike", StuNum = 23}
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
