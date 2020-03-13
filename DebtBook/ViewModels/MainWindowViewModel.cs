using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using DebtBook.Models;
using DebtBook.ViewModels;
using DebtBook.Views;
using Prism.Commands;
using Prism.Mvvm;

namespace DebtBook
{
    public class MainWindowViewModel : BindableBase
    {
        private ObservableCollection<Debtor> debtors_;


        public MainWindowViewModel()
        {
            debtors_ = new ObservableCollection<Debtor>
            {
                new Debtor("maria", 100),//  debtor tager ikke to parametre endnu
                new Debtor("Jens", 200)
            };
            CurrentDebtor = null; 
        }

        #region properties

        public ObservableCollection<Debtor> Debtors
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

        ObservableCollection<int> debts_;

        public ObservableCollection<int> Depts
        {
            get { return debts_; }
            set
            {
                SetProperty(ref debts_, value);
            }
        }

        #endregion

        #region commands

        private ICommand editCommand_;

        public ICommand EdiDeptorCommand
        {
            get
            {
                return editCommand_ ?? (editCommand_ = new DelegateCommand(() =>
                {
                    var tempDebtor = CurrentDebtor.Clone();
                    var vm = new DeptorViewModel("Edit Deptor", tempDebtor)
                    {
                        Debts = debts_
                    };
                    var dlg = new DeptorView()
                    {
                        DataContext = vm,
                        Owner = App.Current.MainWindow
                    };
                    if (dlg.ShowDialog() == true)
                    {
                        // Copy values back
                        CurrentDebtor.Name = tempDebtor.Name;
                        CurrentDebtor.Debts = tempDebtor.Debts;
                        //Dirty = true;
                    }
                },
                () => { 
                    return CurrentIndex >= 0;
                }
                ).ObservesProperty(()=> CurrentIndex));
            }
        }

        #endregion

    }
}
