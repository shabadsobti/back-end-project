using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Levvel_backend_project.Models;
using Levvel_backend_project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Levvel_backend_project.Controllers
{
    [Authorize(Policy = "ApiUser")]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly ClaimsPrincipal _caller;
        private readonly ApiContext _appDbContext;
        private readonly IMapper _mapper;

        public DashboardController(UserManager<AppUser> userManager, ApiContext appDbContext, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _appDbContext = appDbContext;
            _mapper = mapper;
        }


        // GET api/dashboard/favorites
        [HttpGet("favorites")]
        public async Task<IActionResult> Favorites()
        {
            // retrieve the user info
            //HttpContext.User

            var userId = _caller.Claims.Single(c => c.Type == "id");

            var customer = await _appDbContext.Customers.Include(c => c.Identity).SingleAsync(c => c.Identity.Id == userId.Value);

            var favorites = _appDbContext.CustomerTrucks
            .Where(ci => ci.CustomerId == customer.Id)
             .Select(ci => ci.Truck);

            var nc = _mapper.Map<List<TruckViewModel>>(favorites);

            var response = favorites.Select(u => new
            {
                id = u.TruckId,
                title = u.Title,
                price = u.Price,
                rating = u.Rating,
                hours = u.Hours,
                phone = u.Phone,

                categories = u.TruckCategory.Select(p => p.Category).Select(
                    p => new
                    {
                        name = p.CategoryName
                    }),
                coordinates = u.Coordinates,
                location = u.Location
            });

            var cs = _mapper.Map<CustomerViewModel>(customer);
            return new OkObjectResult(new
            {
                customer.Id,
                customer.Identity.FirstName,
                customer.Identity.LastName,
                favorites = response
            });
        }



        // POST api/dashboard/favorites
        [HttpPost("favorites")]
        public async Task<IActionResult> Create([FromBody] FavoriteViewModel model)
        {
            var userId = _caller.Claims.Single(c => c.Type == "id");
          
            var customer = await _appDbContext.Customers.Include(c => c.Identity).SingleAsync(c => c.Identity.Id == userId.Value);
            Truck truck = _appDbContext.Trucks.Find(model.TruckId);
            
            _appDbContext.CustomerTrucks.Add(new CustomerTrucks
            {
                TruckId = truck.TruckId,
                CustomerId = customer.Id,

            });
            await _appDbContext.SaveChangesAsync();

            var resp = new
            {
                UserId = customer.Id,
                TruckId = truck.TruckId,

            };
            return Ok(resp);
        }


        // GET api/dashboard/favorites
        [HttpGet("trucks")]
        public async Task<IActionResult> getTrucks()
        {
            // retrieve the user info
            //HttpContext.User

            var userId = _caller.Claims.Single(c => c.Type == "id");

            var customer = await _appDbContext.Customers.Include(c => c.Identity).SingleAsync(c => c.Identity.Id == userId.Value);

            var trucks = _appDbContext.Trucks
            .Where(ci => ci.Created_by == customer);


            var response = trucks.Select(u => new
            {
                id = u.TruckId,
                title = u.Title,
                price = u.Price,
                rating = u.Rating,
                hours = u.Hours,
                phone = u.Phone,

                categories = u.TruckCategory.Select(p => p.Category).Select(
                    p => new
                    {
                        name = p.CategoryName
                    }),
                coordinates = u.Coordinates,
                location = u.Location
            });

            var cs = _mapper.Map<CustomerViewModel>(customer);
            return new OkObjectResult(new
            {
                customer.Id,
                customer.Identity.FirstName,
                customer.Identity.LastName,
                trucks = response
            });
        }



    }
}
