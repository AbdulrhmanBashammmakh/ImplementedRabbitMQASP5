using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RabbitMQ.Client;
using UserService.Data;
using UserService.Entities;
using UserService.MQ;
using UserService.SV;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _context;
        private readonly IRabitMQProducer _Rq;

        public UsersController(IUserService context, IRabitMQProducer Rq)
        {
            _context = context;
            _Rq = Rq;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetList()
        {
            var userLisr = _context.GetList();
            return userLisr;
        }

      

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public User AddProduct(User user)
        {
            var UserData = _context.Add(user);
            //send the inserted product data to the queue and consumer will listening this data from queue
            _Rq.SendProductMessage(UserData);
            return UserData;
        }


    }
}
