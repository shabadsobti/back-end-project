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


            var response = favorites.Select(u => new TruckViewModel
            {
                TruckId = u.TruckId,
                Title = u.Title,
                Price = u.Price,
                Rating = u.Rating,
                Hours = u.Hours,
                Phone = u.Phone,
                Categories = _mapper.Map<List<Category>, List<CategoryViewModel>>(u.TruckCategory.Select(p => p.Category).ToList()),
                Coordinates = u.Coordinates,
                Location = u.Location
            });

            return Ok(response.ToList());
        }



        // POST api/dashboard/favorites
        [HttpPost("favorites")]
        public async Task<IActionResult> Create([FromBody] FavoriteViewModel model)
        {
            var userId = _caller.Claims.Single(c => c.Type == "id");
          
            var customer = await _appDbContext.Customers.Include(c => c.Identity).SingleAsync(c => c.Identity.Id == userId.Value);
            Truck truck = _appDbContext.Trucks.Find(model.TruckId);
            if(truck == null)
            {
                return NotFound();
            }
            
            _appDbContext.CustomerTrucks.Add(new CustomerTrucks
            {
                TruckId = truck.TruckId,
                CustomerId = customer.Id,

            });
            await _appDbContext.SaveChangesAsync();

            return Ok();
        }


        // GET api/dashboard/trucks
        [HttpGet("trucks")]
        public async Task<IActionResult> GetTrucks()
        {
            // retrieve the user info
            //HttpContext.User

            var userId = _caller.Claims.Single(c => c.Type == "id");

            var customer = await _appDbContext.Customers.Include(c => c.Identity).SingleAsync(c => c.Identity.Id == userId.Value);

            var trucks = _appDbContext.Trucks
            .Where(ci => ci.Created_by == customer);


            var response = trucks.Select(u => new TruckViewModel
            {
                TruckId = u.TruckId,
                Title = u.Title,
                Price = u.Price,
                Rating = u.Rating,
                Hours = u.Hours,
                Phone = u.Phone,
                Categories = _mapper.Map<List<Category>, List<CategoryViewModel>>(u.TruckCategory.Select(p => p.Category).ToList()),
                Coordinates = u.Coordinates,
                Location = u.Location
            });

            return Ok(response.ToList());
        }
    }
}
