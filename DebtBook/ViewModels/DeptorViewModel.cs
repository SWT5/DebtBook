using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DebtBook.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace DebtBook
{
    public class DeptorViewModel : BindableBase
    {

        public DeptorViewModel()
        {
        }

        public DeptorViewModel(string title, Debtor debtor)
        {
            Debts = new ObservableCollection<Debt>();
            Title = title;
            CurrentDebtor = debtor;
        }

        #region properties

        private string title_;

        public string Title
        {
            get { return title_; }
            set { SetProperty(ref title_, value); }
        }

        private Debtor currentDebtor_;

        public Debtor CurrentDebtor
        {
            get { return currentDebtor_; }
            set { SetProperty(ref currentDebtor_, value); }
        }

        ObservableCollection<Debt> debts_;

        public ObservableCollection<Debt> Debts
        {
            get { return debts_; }
            set { SetProperty(ref debts_, value); }
        }

        public bool IsValid
        {
            get
            {
                bool isValid = true; 
                if(string.IsNullOrWhiteSpace((CurrentDebtor.Debts.ToString())))
                    isValid = false;
                return isValid; 
            }
        }

        #endregion


        #region commands

        private ICommand addDebtBtnCommand_;

        public ICommand AddDebtBtnCommand
        {
            get
            {
                return addDebtBtnCommand_ ?? (addDebtBtnCommand_ = new DelegateCommand(
                        AddDebtBtnCommand_Execute, AddDebtBtnCommand_CanExecute)
                    .ObservesProperty(() => CurrentDebtor.Debts)); 
            }
        }

        private void AddDebtBtnCommand_Execute()
        {
        }

        private bool AddDebtBtnCommand_CanExecute()
        {
            return IsValid;
        }



        #endregion




    }
}
