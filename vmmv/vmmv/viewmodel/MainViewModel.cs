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
    public class MainViewModel : INotifyPropertyChanged
    {
        private Person modelPerson;
        public Person ModelPerson
        {
            get
            {
                return modelPerson;
            }
            set
            {
                modelPerson = value;
                OnPropertyChanged("ModelPerson");
            }
        }

        private SaveCommand savePersonCommand;
        public SaveCommand SavePersonCommand
        {
            get
            {
                return savePersonCommand;
            }
            set
            {
                savePersonCommand = value;
                OnPropertyChanged("SavePersonCommand");
            }
        }

        private NewPageCommand newPageCommand;
        public NewPageCommand NewPageCommand
        {
            get
            {
                return newPageCommand;
            }
            set
            {
                newPageCommand = value;
                OnPropertyChanged("NewPageCommand");
            }
        }

        private string welcomeMessage;
        public string WelcomeMessage
        {
            get
            {
                return welcomeMessage;
            }
            set
            {
                welcomeMessage = value;
                OnPropertyChanged("WelcomeMessage");
            }
        }

        public MainViewModel()
        {
            LoadPerson();
            LoadCommand();
            Binding();
            SettingDefault();
        }

        private void SettingDefault()
        {
            ModelPerson.FirstName = "Kobe";
            ModelPerson.LastName = "Bryant";
        }

        private void Binding()
        {
            ModelPerson.PropertyChanged += OnCMD;
        }

        private void LoadCommand()
        {
            SavePersonCommand = new SaveCommand(this, UpdateDate);
            NewPageCommand = new NewPageCommand(ShowNewPage);
        }

        private void ShowNewPage()
        {
            
        }

        private void OnCMD(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("FirstName") || e.PropertyName.Equals("LastName"))
            {
                SavePersonCommand.RaiseCanExecuteChanged();
            }
        }

        private void UpdateDate()
        {
            ModelPerson.UpdatedDate = DateTime.Now;
            WelcomeMessage = string.Format("Hello {0} {1}, your info has been saved.", ModelPerson.FirstName, ModelPerson.LastName);
            ModelPerson.FirstName = null;
            ModelPerson.LastName = null;
        }

        private void LoadPerson()
        {
            ModelPerson = new Person();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }

    public class SaveCommand : ICommand
    {
        private MainViewModel mainViewModel;
        Action method;

        public bool CanExecute(object parameter)
        {

            if (string.IsNullOrEmpty(mainViewModel.ModelPerson.FirstName) || string.IsNullOrEmpty(mainViewModel.ModelPerson.LastName))
            {
                return false;
            }

            return true;
        }

        public SaveCommand(MainViewModel viewModel, Action method)
        {
            this.mainViewModel = viewModel;
            this.method = method;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            method.Invoke();
        }

        internal void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged(EventArgs.Empty);
        }

        private void OnCanExecuteChanged(EventArgs eventArgs)
        {
            var canExecuteChanged = CanExecuteChanged;

            if (canExecuteChanged != null)
                canExecuteChanged(this, eventArgs);
        }
    }

    public class NewPageCommand : ICommand
    {
        Action method;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public NewPageCommand(Action method)
        {
            this.method = method;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            method.Invoke();
        }
    }
}
