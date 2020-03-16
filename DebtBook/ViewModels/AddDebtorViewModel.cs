using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DebtBook.Data;
using DebtBook.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace DebtBook.ViewModels
{
    public class AddDebtorViewModel : BindableBase
    {
        private string filePath_ = "";
        private readonly string AppTitle = "DebtBook";

        public AddDebtorViewModel()
        {
        }


        public AddDebtorViewModel(Debtor debtor)
        {
            CurrentDebtor = debtor;
        }

        #region properties




        Debtor currentDebtor_;

        public Debtor CurrentDebtor
        {
            get { return currentDebtor_; }
            set { SetProperty(ref currentDebtor_, value); }
        }

        public bool IsValid
        {
            get
            {
                bool isValid = true;
                if (CurrentDebtor != null)
                {
                    if (string.IsNullOrWhiteSpace(CurrentDebtor.Name))
                        isValid = false;
                    if (double.IsNaN(CurrentDebtor.TotalAmount))  // konventere amount til string i if-statment
                        isValid = false;
                }
                return isValid;
            }
        }


        private string filename_ = "";
        public string Filename
        {
            get { return filename_; }
            set
            {
                SetProperty(ref filename_, value);
                RaisePropertyChanged("Title");
            }
        }

        public string Title
        {
            get
            {
                var s = "";
                if (Dirty)
                    s = "*";
                return Filename + s + " - " + AppTitle;
            }
        }

        private bool dirty = false;
        public bool Dirty
        {
            get { return dirty; }
            set
            {
                SetProperty(ref dirty, value);
                RaisePropertyChanged("Title");
            }
        }


        #endregion

        #region Commands

        // btnSave
        private ICommand saveBtnCommand_;

        public ICommand SaveBtnCommand
        {
            get
            {
                return saveBtnCommand_ ?? (saveBtnCommand_ =
                           new DelegateCommand(SaveFileCommand_Execute, SaveFileCommand_CanExecute)
                               .ObservesProperty(() => CurrentDebtor.Name)
                               .ObservesProperty(() => CurrentDebtor.Debts));
            }
        }


        private void SaveFileCommand_Execute()
        {
            CurrentDebtor.addDebtToPerson(int.Parse(CurrentDebtor.DebtAdd));
        }

        private bool SaveFileCommand_CanExecute()
        {
            return IsValid;
        }


        #endregion


    }
}
