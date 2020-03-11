using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DebtBook.Models;
using Prism.Mvvm;

namespace DebtBook.ViewModels
{
    public class AddDebtorViewModel : BindableBase
    {
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

        public bool isValid
        {
            get
            {
                bool isValid = true;
                if(string.IsNullOrWhiteSpace(CurrentDebtor.Name))
                    isValid = false;
                if (string.IsNullOrWhiteSpace(CurrentDebtor.Debts[0].amount_.ToString()))   // konventere amount til string i if-statment
                    isValid = false;
                return isValid;
            }

                
        }

        #endregion
        
    }
}
