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
using System.Windows.Data;

namespace DebtBook
{
    public class MainWindowViewModel : BindableBase
    {
        private ObservableCollection<Debtor> debtors_;


        public MainWindowViewModel()
        {
            Debtors = new ObservableCollection<Debtor>
            {
                #if DEBUG
                new Debtor("maria", 100),
                new Debtor("Jens", 200)
                #endif
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

        public ICommand EditDebtorCommand
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

        private ICommand add_debtor_Command_;

        public ICommand Add_Debtor_Command
        {
            get
            {
                return add_debtor_Command_ ?? (add_debtor_Command_ = new DelegateCommand(() =>
                {
                    var tempAddDebtor = new Debtor();
                    debtors_.Add(tempAddDebtor);
                }));
            }
        }


        #endregion

    }
}
