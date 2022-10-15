using fakestoreapi.domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace fakestoreapi.domain.Entities
{
   public class People : AuditEntity
    {
        public People()
        {
            this.Products = new List<Product>();
        }



        public int Id { get; set; }  
        public string Name { get; set; }
        public string Address { get; set; }
        public string Cardnumber { get; set; }
       
        public int ZipCode { get; set; }
        public double TotalAmount { get; set; }
        
      public IList<Product> Products { get; set; }
       
    }
}
