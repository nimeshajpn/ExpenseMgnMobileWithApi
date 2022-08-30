using ExpenseMgnMobileApi.Models;
using ExpenseMgnMobileApi.Services;
using ExpenseMgnMobileApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseMgnMobileApi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddExpense : ContentPage 
    {

        IWebApiRepository web = new WebApi();
        private MExpense aa;

        public AddExpense()
        {
            InitializeComponent();
            BindingContext = this;
        }
        Models.MExpense list;
        public AddExpense(Models.MExpense aa)
        {
          
            InitializeComponent();
            list = aa;
            Amount.Text = aa.Amount.ToString();
            Category.SelectedItem = aa.Category;
            Datepicker.Date = aa.Date.Date;
            Timepicker.Time = aa.Date.TimeOfDay;
            Typepicker.SelectedItem = aa.Type;
            lbid.Text=aa.Id.ToString();
            Amount.Focus();





        }

        public string category;
        public string sCategory {

            get => category;
            set { 
            
            
            category = value;
                OnPropertyChanged(sCategory);
            
            }
        
        
        }

        private void btnAdd(object sender, EventArgs e)
        {


            if (lbid.Text == null)
            {

                MExpense list = new MExpense();

                list.Category = Category.SelectedItem.ToString();
                list.Amount = Convert.ToDouble(Amount.Text);

                list.Date = Datepicker.Date + Timepicker.Time;
                list.Type = Typepicker.SelectedItem.ToString(); ;

                web.Create(list);
                 Navigation.PushAsync(new MainPage());



            }
            else {

                MExpense list = new MExpense();
                list.Id = Convert.ToInt16(lbid.Text);
                list.Category = Category.SelectedItem.ToString();
                list.Amount = Convert.ToDouble(Amount.Text);

                list.Date = Datepicker.Date + Timepicker.Time;
                list.Type = Typepicker.SelectedItem.ToString(); ;

                web.Update(list);
                Navigation.PushAsync(new MainPage());

            }

        }
    }
}