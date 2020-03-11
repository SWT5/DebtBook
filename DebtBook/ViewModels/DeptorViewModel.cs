using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DebtBook.Models;
using Prism.Mvvm;

namespace DebtBook.ViewModels
{
    public class DeptorViewModel : BindableBase
    {

        public DeptorViewModel(string title, Debtor debtor)
        {
            Title = title;
            CurrentDebtor = debtor; 
        }

        #region properties

        private string title_;

        public string Title
        {
            get { return title_; }
            set
            {
                SetProperty(ref title_, value); 

            }
        }

        private Debtor currentDebtor_;

        public Debtor CurrentDebtor
        {
            get { return currentDebtor_; }
            set { SetProperty(ref currentDebtor_, value); }
        }

        ObservableCollection<int> debts_;

        public ObservableCollection<int> Debts
        {
            get { return debts_; }
            set
            {
                SetProperty(ref debts_, value);
            }
        }

        #endregion
    }
}
