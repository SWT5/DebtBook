﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DebtBook.ViewModels;

namespace DebtBook.Views
{
    /// <summary>
    /// Interaction logic for DeptorWindow.xaml
    /// </summary>
    public partial class AddDeptorWindow : Window
    {
        public AddDeptorWindow()
        {
            InitializeComponent();
        }

        private void tbxAmount_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            /*
              DialogResult = true;
             */
            var vm = DataContext as AddDebtorViewModel;
            if (vm.IsValid)
            {
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Enter values for Name and amount", "Missing data");
            }
            
        }
    }
}
