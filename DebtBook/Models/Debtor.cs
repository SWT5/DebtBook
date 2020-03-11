using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DebtBook.Models;
using Prism.Mvvm;

namespace DebtBook.Models
{
    public class Debtor : BindableBase
    {
        private string name_;
        private int debt_;

        //private List<Dept> depts_;

        public Debtor()
        {
        }

        public Debtor(string name, int dept)
        {
            name_ = name;
            debt_ = dept;
        }

        public Debtor Clone()
        {
            return this.MemberwiseClone() as Debtor;
        }

        public string Name
        {
            get { return name_; }
            set { SetProperty(ref name_, value); }
        }

        public int Debt
        {
            get { return debt_; }
            set { SetProperty(ref debt_, value); }
        }



    }
}
