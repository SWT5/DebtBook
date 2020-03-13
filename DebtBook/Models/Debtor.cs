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
        //private int totalDebt_;
        private Debt debt_ = new Debt();

        public Debtor()
        {}

        public Debtor(string name, int debt)    // skal muligvis være af type Debt
        {
            name_ = name;
            debt_.amount_ = debt;
            // ekstra parameter i construoter som smider den gæld ind på næste ledige plads i listen af gæld
            // kald funktion til at indsætte
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

        //public int TotalDebt
        //{
        //    get { return totalDebt_; }
        //    set
        //    {
        //        totalDebt_ = 0;
        //        foreach (var debt in Debts)
        //        {
        //            totalDebt_ += debt.amount_;
        //        }
        //    }
        //}

    }
}
