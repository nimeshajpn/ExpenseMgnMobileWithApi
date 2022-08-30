using ExpenseMgnMobileApi.Models;
using ExpenseMgnMobileApi.Services;
using ExpenseMgnMobileApi.Views;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ExpenseMgnMobileApi.ViewModels
{
    public class AddExpenseViewModel : ViewModelBase
    {
         public ICommand addCommand { get; set; }
        IWebApiRepository web = new WebApi();
     
        public AddExpenseViewModel()
        {
            addCommand = new Command(add);

        }

        private void add(object obj)
        {
           MExpense item = new MExpense();
            item.Amount = Amount;
            item.Category = Category;
          
            item.Type= Type;

            web.Create(item);

        }

        private double _Amount;
        private string _Category;
        private DateTime _Date;
        private DateTime _Time;
        private string _Type;
        public double Amount
        {
            get => _Amount;
            set => SetProperty(ref _Amount, value);
        }

        public string Category { 
        get => _Category;
            set => SetProperty(ref _Category, value);   
        
        
        } public DateTime Date { 
        get => _Date;
            set => SetProperty(ref _Date, value);   
        
        
        } public DateTime Time { 
        get => _Time;
            set => SetProperty(ref _Time, value);   
        
        
        } public string Type { 
        get => _Type;
            set => SetProperty(ref _Type, value);   
        
        
        }

    }
}
