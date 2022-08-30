using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseMgnMobileApi.Models
{
    public class MExpense
    {
        public int Id { get; set; }
        public string Category { get; set; }



        public DateTime Date { get; set; }


        public double Amount { get; set; }

        public string Type { get; set; }

    }
}
