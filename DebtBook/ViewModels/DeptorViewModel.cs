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
            Title = title + ": " + debtor.Name;
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

        #endregion


        #region commands


        ICommand addDebtCommand_;

        public ICommand AddDebtCommand
        {
            get
            {
                return addDebtCommand_ ?? (addDebtCommand_ = new DelegateCommand(
                               AddDebtCommand_Execute)
                           .ObservesProperty(() => CurrentDebtor.Debts));
            }
        }
        private void AddDebtCommand_Execute()
        {
            CurrentDebtor.addDebtToPerson(int.Parse(CurrentDebtor.DebtAdd));
            
        }
        #endregion
    }
}


   











