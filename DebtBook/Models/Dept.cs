using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DebtBook.Utilities;
using Prism.Mvvm;

namespace DebtBook.Models
{
    public class Dept : BindableBase
    {
        private int amount_ { get; set; }
        public string date_ { get; set; }
        


        Clock clock = new Clock();
        public Clock Clock_ { get => clock; set => clock = value; }

        
    }
}
