using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace DebtBook.Models
{
    public class Debt : BindableBase
    {
        public Debt()
        {

        }
        public Debt(int amount)
        {
            amount_ = amount;
            date_ = DateTime.Now.ToString("dd/MM/yyy");
        }
        public int amount_;
        public string date_;

        public string Date
        {
            get { return date_; } //.Date;
            set { SetProperty(ref date_, value); }
        }

        public int Amount
        {
            get { return amount_;}
            set { SetProperty(ref amount_, value); }
        }
    }
}
