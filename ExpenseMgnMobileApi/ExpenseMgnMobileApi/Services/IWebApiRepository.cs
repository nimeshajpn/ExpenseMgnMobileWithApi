using ExpenseMgnMobileApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseMgnMobileApi.Services
{
    public interface IWebApiRepository
    {

      Task<bool> Create(MExpense e);
      Task<bool> Update(MExpense e);


         Task<bool> Delete(int id);


         Task<MExpense> GetById(int id);


         Task<List<MExpense>> GetAll();
        


    }
}
