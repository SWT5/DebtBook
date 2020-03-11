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
            CurrentDeptor = debtor; 
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

        private Debtor currentDeptor_;

        public Debtor CurrentDeptor
        {
            get { return currentDeptor_; }
            set { SetProperty(ref currentDeptor_, value); }
        }

        ObservableCollection<int> depts_;

        public ObservableCollection<int> Depts
        {
            get { return depts_; }
            set
            {
                SetProperty(ref depts_, value);
            }
        }

        #endregion
    }
}
