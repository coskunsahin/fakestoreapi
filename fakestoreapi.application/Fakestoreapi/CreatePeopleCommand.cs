using fakestoreapi.application.ViewModels;
using fakestoreapi.domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace fakestoreapi.application.Fakestoreapi
{
    public class CreatePeopleCommand:IRequest<int>
    {

        public CreatePeopleCommand()
        {
            this.Products = new List<ProductVm>();
        }



        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Cardnumber { get; set; }

        public int ZipCode { get; set; }
        public double TotalAmount { get; set; }

        public IList<ProductVm> Products { get; set; }
    }
}
