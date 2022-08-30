using ExpenseMgnMobileApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpenseMgnMobileApi.Services
{
    public class WebApi : IWebApiRepository
    {
        HttpClient client = new HttpClient();
        string url = "http://10.0.2.2:7178/";
        public WebApi()
        {
            client= new HttpClient();
            client.BaseAddress = new Uri(url);
       
      

        }

        public async Task<bool> Create(MExpense e)
        { 
        
            var json= JsonConvert.SerializeObject(e);
            var content = new StringContent(json, Encoding.UTF8 , "application/json") ;
            var response =  await client.PostAsync("Expense", content);

            if (!response.IsSuccessStatusCode) {

                return true;
            
            }
            return false;
        }
        public async Task<bool> Update(MExpense e)
        { 
        
            var json= JsonConvert.SerializeObject(e);
            var content = new StringContent(json, Encoding.UTF8 , "application/json") ;
            var response =  await client.PutAsync("Expense/"+e.Id, content);

            if (!response.IsSuccessStatusCode) {

                return true;
            
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await client.DeleteAsync($"Expense/{id}");


            if (!response.IsSuccessStatusCode) {

                return true;
            
            }

            return false;
        }

        public Task<MExpense> GetById(int id)
        {



            return null;
        }

        public async Task<List<MExpense>> GetAll()
        {

            try
            {
             
              
                var resultJson = await client.GetStringAsync("Expense");

                var result = JsonConvert.DeserializeObject<List<MExpense>>(resultJson);


                return result;
            }
            catch (Exception e)
            {
                _ = Application.Current.MainPage.DisplayAlert("Error", e.ToString(), "Ok");

                return null;
            }








            
        }






    }
}
