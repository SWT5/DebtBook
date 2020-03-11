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
        public int amount_ { get; set; }
        public DateTime date_;

        public DateTime Date
        {
            get { return date_.Date; }
            set { SetProperty(ref date_, value); }
        }
        


        /*Clock clock = new Clock();
        public Clock Clock_ { get => clock; set => clock = value; }*/

        
    }
}
