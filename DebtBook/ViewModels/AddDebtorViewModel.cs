using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DebtBook.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace DebtBook.ViewModels
{
    public class AddDebtorViewModel : BindableBase
    {
        private ObservableCollection<Debtor> debtors_; 
        public AddDebtorViewModel()
        {
            CurrentDebtor = null; 

            debtors_ = new ObservableCollection<Debtor>()
            {
                new Debtor("mads")  // her evt. smid gæld i
            };
        }

        #region properties
        Debtor currentDebtor_;

        public Debtor CurrentDebtor
        {
            get { return currentDebtor_; }
            set { SetProperty(ref currentDebtor_, value); }
        }

        public ObservableCollection<Debtor> Debtors
        {
            get { return debtors_; }
            set { SetProperty(ref debtors_, value); }
        }

        public bool isValid
        {
            get
            {
                bool isValid = true;
                if(string.IsNullOrWhiteSpace(CurrentDebtor.Name))
                    isValid = false;
                if(string.IsNullOrWhiteSpace(CurrentDebtor.Debts[0].amount_.ToString()))  // konventere amount til string i if-statment
                    isValid = false;
                return isValid;
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
                               .ObservesProperty(() => Debtors.Count));
            }
        }
        // cancelbtn 

        #endregion


    }
}
