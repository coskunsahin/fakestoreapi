using fakestoreapi.application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using fakestoreapi.application.Fakestoreapi;
using fakestoreapi.domain.Entities;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
 
using fakestoreapi.rabbit;

namespace fakestoreapi.application.Handlers
{
    public class CreatePeopleCommandHandler : IRequestHandler<CreatePeopleCommand, int>
    {
        private readonly IApplicationDbContext _context;
       // private readonly IRabitMQProducer _rabitMQProducer;
        public CreatePeopleCommandHandler(IApplicationDbContext context/* IRabitMQProducer rabitMQProducer*/)
        {
            _context = context;
            //_rabitMQProducer = rabitMQProducer;


        }
        public async Task<int> Handle(CreatePeopleCommand request, CancellationToken cancellationToken)
        {
            var entity = new People
            {
              //Name = request.Name,
              //Address = request.Address,
              //ZipCode =request.ZipCode,
              //Cardnumber=request.Cardnumber,
              TotalAmount=request.TotalAmount,
              Products = request.Products.Select(i => new Product
                {
                    Title = i.Title,
                   Quanty=i.Quanty, 
                   Price=i.Price,
                   Description=i.Description,
                   Category=i.Category,
                  Image=i.Image,
                  Rating=i.Rating

              }).ToList()
            };

            _context.Peoples.Add(entity);
           // _rabitMQProducer.SendProductMessage(entity);
            await _context.SaveChangesAsync(cancellationToken);
           
            return entity.Id;
        }
    }
}
