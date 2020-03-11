using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DebtBook.Models;
using Prism.Mvvm;

namespace DebtBook.Models
{
    public class Deptor : BindableBase
    {
        private string name_;
        private int dept_;

        public Deptor()
        {
        }

        public Deptor(string name)
        {
            name_ = name;
        }

        public Deptor Clone()
        {
            return this.MemberwiseClone() as Deptor;
        }

        public string Name
        {
            get { return name_; }
            set
            {
                SetProperty(ref name_, value);
            }
        }

        public ObservableCollection<Dept> depts_;
        public ObservableCollection<Dept> Depts
        {
            get { return depts_; }
            set { SetProperty(ref depts_, value); }
        }


        /*public int Dept
        {
            get { return dept_; }
            set { SetProperty(ref dept_, value); }
        }*/



    }
}
