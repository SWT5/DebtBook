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
            date_ = DateTime.Now;
        }
        public int amount_;
        public DateTime date_;

        public DateTime Date
        {
            get { return date_.Date; }
            set { SetProperty(ref date_, value); }
        }

        public int Amount
        {
            get { return amount_;}
            set { SetProperty(ref amount_, value); }
        } 




        /*Clock clock = new Clock();
        public Clock Clock_ { get => clock; set => clock = value; }*/

        
    }
}
