using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using DebtBook.Models;
using Prism.Mvvm;

namespace DebtBook.Models
{
    public class Debtor : BindableBase
    {
        private string name_;
        private int totalDebt_;
        

        public Debtor()
        {
        }

        public Debtor(string name)
        {
            name_ = name;
            // ekstra parameter i construoter som smider den gæld ind på næste ledige plads i listen af gæld
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

        ObservableCollection<Debt> debts_;

        public ObservableCollection<Debt> Debts
        {
            get { return debts_; }
            set { SetProperty(ref debts_, value); }
        }

        public int TotalDebt
        {
            get { return totalDebt_; }
            set
            {
                foreach (var debt in Debts)
                {
                    totalDebt_ += debt.amount_;
                }
            }

        }

    }
}
