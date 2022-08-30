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
    public partial class ViewAll : ContentPage
    {

        IWebApiRepository web = new WebApi();
        public ViewAll()
        {
            InitializeComponent();
        }



        async void Swipe(object sender, EventArgs k)
        {
            MExpense mExpense = new MExpense();

            var item = sender as SwipeItem;
            var emp = item.CommandParameter as MExpense;
            mExpense = item.CommandParameter as MExpense;
            
            var aa = emp;

            await Navigation.PushAsync(new AddExpense(aa));

        }

        async void SwipeDelete(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var emp = item.CommandParameter as MExpense;

            _ = await web.Delete(emp.Id);
            _ = Navigation.PushAsync(new MainPage());
        }
    }
}