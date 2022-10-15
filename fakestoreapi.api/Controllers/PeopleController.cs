using fakestoreapi.application.Common.Interfaces;
using fakestoreapi.application.Fakestoreapi;
using fakestoreapi.application.Queries;
using fakestoreapi.application.ViewModels;
using RabbitMQ;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
 
using fakestoreapi.api.Services;
using fakestoreapi.rabbit;

namespace fakestoreapi.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   //[Authorize]
    public class fakestoreapiController : ApiController
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IRabitMQProducer _rabitMQProducer;
        public fakestoreapiController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            
        }
       
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreatePeopleCommand command)
        {   
            return await Mediator.Send(command);

        }

        [HttpGet]
        public async Task<IList<PeopleVM>> Get()
        {
            return await Mediator.Send(new GetUserPeopleQuery { User = _currentUserService.UserId });
        }
    }
}
