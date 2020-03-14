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
        private Debt debt_ = new Debt();

        public Debtor()
        {}

        public Debtor(string name, int debt)    // skal muligvis være af type Debt
        {
            debts_ = new ObservableCollection<Debt>();
            name_ = name;
            debt_.amount_ = debt;
            debts_.Add(debt_);
            
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

        ObservableCollection<Debt> debts_; //list with all debts 

        public ObservableCollection<Debt> Debts //inorder to access list use this property
        {
            get { return debts_; }
            set { SetProperty(ref debts_, value); }
        }

        public int TotalDebt
        {
            get
            {
                foreach (var debt in Debts)
                {
                    totalDebt_ += debt.amount_;
                }
                return totalDebt_;
            }
            set { SetProperty(ref totalDebt_, value); }
        }

        //public Debt debt;
        //public void Add_debt()
        //{
        //    debt = new Debt();
        //    debts_.Add(debt);
        //}

    }
}
