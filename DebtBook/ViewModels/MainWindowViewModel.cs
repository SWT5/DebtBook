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
        private ObservableCollection<Deptor> deptors_;


        public MainWindowViewModel()
        {
            deptors_ = new ObservableCollection<Deptor>
            {
                new Deptor("maria")
            };
            CurrentDeptor = null; 
        }

        #region properties

        public ObservableCollection<Deptor> Deptors
        {
            get { return deptors_; }
            set { SetProperty(ref deptors_, value);  }
        }

        private Deptor currentDeptor_ = null;

        public Deptor CurrentDeptor
        {
            get { return currentDeptor_; }
            set { SetProperty(ref currentDeptor_, value); }
        }

        int currentIndex_ = -1;

        public int CurrentIndex
        {
            get { return currentIndex_; }
            set { SetProperty(ref currentIndex_, value); }
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

        #region commands

        private ICommand editCommand_;

        public ICommand EdiDeptorCommand
        {
            get
            {
                return editCommand_ ?? (editCommand_ = new DelegateCommand(() =>
                {
                    var tempDeptor = CurrentDeptor.Clone();
                    var vm = new DeptorViewModel("Edit Deptor", tempDeptor)
                    {
                        Depts = depts_
                    };
                    var dlg = new DeptorView()
                    {
                        DataContext = vm,
                        Owner = App.Current.MainWindow
                    };
                    if (dlg.ShowDialog() == true)
                    {
                        // Copy values back
                        CurrentDeptor.Name = tempDeptor.Name;
                        CurrentDeptor.Dept = tempDeptor.Dept;
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
