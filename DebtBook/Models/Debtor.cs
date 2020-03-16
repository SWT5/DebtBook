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
            TotalAmount = debt;
            debts_.Add(new Debt(debt));
            
        }
      
        public string Name
        {
            get
            {
                return name_;
            }
            set
            {
                SetProperty(ref name_, value);
            }
        }

        ObservableCollection<Debt> debts_; //list with all debts 

        public ObservableCollection<Debt> Debts //inorder to access list use this property
        {
            get { return debts_; }
            set { SetProperty(ref debts_, value); }
        }
        private double totalamount = 0;
        public double TotalAmount
        {
            get { return totalamount; }
            set { SetProperty(ref totalamount, value); }
        }


        public void addDebtToPerson(int amount)
        {
            debts_.Add(new Debt(amount));
            TotalAmount += amount;
        }

        private string debtAdd;
        public string DebtAdd
        {
            get { return debtAdd; }
            set
            {
                SetProperty(ref debtAdd, value);
               
            }
        }
    }
}

