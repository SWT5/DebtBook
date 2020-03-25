using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DebtBook.Models;
using DebtBook.ViewModels;
using DebtBook.Views;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Data;
using System.Xml.Serialization;

namespace DebtBook
{
    public class MainWindowViewModel : BindableBase
    {
        private ObservableCollection<Debtor> debtors_;
        private string filename = "";

        public MainWindowViewModel()
        {
            Debtors = new ObservableCollection<Debtor>
            {
                #if DEBUG
                new Debtor("maria", 100),
                new Debtor("Jens", 200)
                #endif
            };
            CurrentDebtor = null;}

        #region properties

        public ObservableCollection<Debtor> Debtors     // dette skulle gerne virke ny kommentar igen
        {
            get { return debtors_; }
            set { SetProperty(ref debtors_, value);  }
        }

        private Debtor currentDebtor_ = null;

        public Debtor CurrentDebtor
        {
            get { return currentDebtor_; }
            set { SetProperty(ref currentDebtor_, value); }
        }

        int currentIndex_ = -1;

        public int CurrentIndex
        {
            get { return currentIndex_; }
            set { SetProperty(ref currentIndex_, value); }
        }


        #endregion

        #region commands

        private ICommand editCommand_;

        public ICommand EditDebtorCommand
        {
            get
            {
                return editCommand_ ?? (editCommand_ = new DelegateCommand(() =>
                {
                    var vm = new DeptorViewModel("Edit Debtor", CurrentDebtor) { };
                    var dlg = new DeptorView(){ };
                    dlg.DataContext = vm;
                    dlg.ShowDialog();

                },
                () =>
                {
                    return CurrentIndex >= 0;
                }
                ).ObservesProperty(() => CurrentIndex));
            }
        }

        private ICommand add_debtor_Command_;

        public ICommand Add_Debtor_Command
        {
            get
            {
                return add_debtor_Command_ ?? (add_debtor_Command_ = new DelegateCommand(() =>
                {
                    var tempAddDebtor = new Debtor();
                    var vm = new AddDebtorViewModel(tempAddDebtor);
                    var dlg = new AddDeptorWindow();
                    dlg.DataContext = vm;
                    if (dlg.ShowDialog()==true)
                    {
                    }
                     debtors_.Add(tempAddDebtor);
                     CurrentDebtor = tempAddDebtor;
                }));
            }
        }

        ICommand _closeAppCommand;
        public ICommand CloseAppCommand
        {
            get
            {
                return _closeAppCommand ?? (_closeAppCommand = new DelegateCommand(() =>
                {
                    App.Current.MainWindow.Close();
                }));
            }
        }

        ICommand _SaveAsCommand;
        public ICommand SaveAsCommand
        {
            get { return _SaveAsCommand ?? (_SaveAsCommand = new DelegateCommand<string>(SaveAsCommand_Execute)); }
        }

        private void SaveAsCommand_Execute(string argFilename)
        {
            if (argFilename == "")
            {
                MessageBox.Show("You must enter a file name in the File Name textbox!", "Unable to save file",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                filename = argFilename;
                SaveFileCommand_Execute();
            }
        }

        ICommand _SaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return _SaveCommand ?? (_SaveCommand = new DelegateCommand(SaveFileCommand_Execute, SaveFileCommand_CanExecute)
                  .ObservesProperty(() => Debtors.Count));
            }
        }

        private void SaveFileCommand_Execute()
        {
            // Create an instance of the XmlSerializer class and specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Debtor>));
            TextWriter writer = new StreamWriter(filename);
            // Serialize all the agents.
            serializer.Serialize(writer, Debtors);
            writer.Close();
        }

        private bool SaveFileCommand_CanExecute()
        {
            return (filename != "") && (Debtors.Count > 0);
        }

        ICommand _NewFileCommand;
        public ICommand NewFileCommand
        {
            get { return _NewFileCommand ?? (_NewFileCommand = new DelegateCommand(NewFileCommand_Execute)); }
        }

        private void NewFileCommand_Execute()
        {
            MessageBoxResult res = MessageBox.Show("Any unsaved data will be lost. Are you sure you want to initiate a new file?", "Warning",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (res == MessageBoxResult.Yes)
            {
                Debtors.Clear();
                filename = "";
            }
        }


        ICommand _OpenFileCommand;
        public ICommand OpenFileCommand
        {
            get { return _OpenFileCommand ?? (_OpenFileCommand = new DelegateCommand<string>(OpenFileCommand_Execute)); }
        }

        private void OpenFileCommand_Execute(string argFilename)
        {
            if (argFilename == "")
            {

                MessageBox.Show("You must enter a file name in the File Name textbox!", "Unable to save file",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                filename = argFilename;
                var tempAgents = new ObservableCollection<Debtor>();

                // Create an instance of the XmlSerializer class and specify the type of object to deserialize.
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Debtor>));
                try
                {
                    TextReader reader = new StreamReader(filename);
                    // Deserialize all the agents.
                    tempAgents = (ObservableCollection<Debtor>)serializer.Deserialize(reader);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unable to open file", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                Debtors = tempAgents;

                // We have to insert the agents in the existing collection. 
                //Agents.Clear();
                //foreach (var agent in tempAgents)
                //    Add(agent);
            }
        }


        #endregion

    }
}
