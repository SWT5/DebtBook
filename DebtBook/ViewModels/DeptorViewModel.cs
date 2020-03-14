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

namespace DebtBook
{
    public class DeptorViewModel : BindableBase
    {

        public DeptorViewModel()
        { }

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

        ObservableCollection<Debt> debts_;

        public ObservableCollection<Debt> Debts
        {
            get { return debts_; }
            set
            {
                SetProperty(ref debts_, value);
            }
        }

        #endregion


        private ICommand addDebtCommand_;

        public ICommand AddDebtCommand
        {
            get
            {
                return addDebtCommand_ ?? (addDebtCommand_ = new DelegateCommand() => )
            }
        }
        return add_debtor_Command_ ?? (add_debtor_Command_ = new DelegateCommand(() =>
        {
            var tempAddDebtor = new Debtor();
            var vm = new AddDebtorViewModel();
            var dlg = new AddDeptorWindow();
            dlg.DataContext = vm;
            if (dlg.ShowDialog()==true)
            {
                debtors_.Add(tempAddDebtor);
                CurrentDebtor = tempAddDebtor;
                CurrentIndex = 0;
            }
    }
}
