using ExpenseMgnMobileApi.Models;
using ExpenseMgnMobileApi.Services;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpenseMgnMobileApi.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        
        public ICommand Command { get; set; }
        public ObservableCollection<MExpense> ListCollection { get; set; }
        IWebApiRepository Api = new WebApi();
        public HomeViewModel()
        {
          
            Today = DateTime.Now.ToString();
            Command = new Command(Lordmorer);
            ListCollection = new ObservableCollection<MExpense>();


            /*   ListCollection.Add(new MExpense { Amount = 500, Category = "Pet", Type = "Expense" });
               ListCollection.Add(new MExpense { Amount = 500, Category = "Home", Type = "InCome" });
               ListCollection.Add(new MExpense { Amount = 500, Category = "Home", Type = "Income" });
               ListCollection.Add(new MExpense { Amount = 500, Category = "School", Type = "Income" });
               ListCollection.Add(new MExpense { Amount = 500, Category = "Pet", Type = "Expense" }); */

           Lordmorer();
            calculate();
        }

        private void Lordmorer()
        {
            ListCollection.Clear();
            Amount = 0;
            Income = 0;
            Expense = 0;
            refresh = true;
            _ =Lordmore();
            refresh=false;
           
        }

        private bool _refresh;
        public bool refresh
        {

            get => _refresh;
            set => SetProperty(ref _refresh, value);

        }

        private double _Amount;
        public double Amount {

            get => _Amount;
            set => SetProperty(ref _Amount, value); 
         
        }
        private double _Income;
        public double Income {

            get => _Income;
            set => SetProperty(ref _Income, value); 
         
        }
        private double _Expense;
        public double Expense {

            get => _Expense;
            set => SetProperty(ref _Expense, value); 
         
        }

        private string _Today;
        public string Today { 
        get => _Today;
        set => SetProperty(ref _Today, value);
        
        }


        public async Task Lordmore() {

            double In;
            double Ex;
            var a = await Api.GetAll();

           
            foreach (var item in a)
            {
                if (item.Date==DateTime.Today) {

                    ListCollection.Add(item);

                }
                

            }

            foreach (var item in a) {

                if (item.Date == DateTime.Today)
                {

                    if (item.Type == "InCome")
                    {
                        In = item.Amount;
                        Income = In + Income;

                    }
                    else {
                        Ex = item.Amount;
                        Expense = Ex + Expense;


                    }

                    
                   

                }


            }
            Amount = Income - Expense;
         
        }

        public void calculate() { 
        


        
        
        

        }
    }
}
