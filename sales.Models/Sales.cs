using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales.Models
{
    public class Sales
    {
        public int Id { get; set; }

        public int Seller_Id { get; set; }

        public int Shopper_Id { get; set; }

        public int SalesSumm { get; set; }

        public DateTime SalesDate { get; set; }


    }
}
