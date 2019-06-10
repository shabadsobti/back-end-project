using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Levvel_backend_project.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Levvel_backend_project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Levvel_backend_project.Controllers
{

    [Route("api/trucks")]
    [ApiController]
   
    public class TruckController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly ClaimsPrincipal _caller;
        private readonly IMapper _mapper;
        public TruckController(ApiContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _caller = httpContextAccessor.HttpContext.User;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var trucks = _context.Trucks.Include(u => u.TruckCategory);
            var response = trucks.Select(u => new TruckViewModel
            {
                TruckId = u.TruckId,
                Title = u.Title,
                Price = u.Price,
                Rating = u.Rating,
                Hours = u.Hours,
                Phone = u.Phone,
                Categories = _mapper.Map<List<Category>, List<CategoryViewModel>> (u.TruckCategory.Select(p => p.Category).ToList()),
                Coordinates = u.Coordinates,
                Location = u.Location
            });

            return Ok(response.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var t = _context.Trucks.Include(u => u.TruckCategory).ToList();
            List<string> category_names = new List<string>();
            var truck_categories = _context.TruckCategories
                .Where(a => a.TruckId == id);
            foreach (var tc in truck_categories)
            {
                int catId = tc.CategoryId;
                Category c = _context.Categories.Find(catId);
                category_names.Add(c.CategoryName);
            };

            var truck = t.FirstOrDefault((p => p.TruckId == id));

            if(truck == null)
            {
                return NotFound();
            }
            var resp = new TruckViewModel
            {
                TruckId = truck.TruckId,
                Title = truck.Title,
                Price = truck.Price,
                Rating = truck.Rating,
                Hours = truck.Hours,
                Phone = truck.Phone,
                Categories = _mapper.Map<List<Category>, List<CategoryViewModel>>(truck.TruckCategory.Select(p => p.Category).ToList()),
                Coordinates = truck.Coordinates,
                Location = truck.Location

            };
            return Ok(resp);
        }

        // POST: api/trucks/search?price=$$&rating=2.3&category=Indian
        [HttpGet("search")]
        public ActionResult GetByQuery(string price = null, decimal rating = 0, string category = null)
        {
            var trucks = _context.Trucks.Include(u => u.TruckCategory)
                .Where(p => p.Price == price)
                .Where(r => r.Rating >= rating)
                .Where(x => x.TruckCategory
                .Any(r => r.Category.CategoryName.Equals(category)));


            if (price == null)
            {
                trucks = _context.Trucks.Include(u => u.TruckCategory)
                .Where(r => r.Rating >= rating)
                .Where(x => x.TruckCategory
                .Any(r => r.Category.CategoryName.Equals(category)));
            }

            else if (price == null && category == null)
            {
                trucks = _context.Trucks.Include(u => u.TruckCategory)
                .Where(r => r.Rating >= rating);
            }

            else if(category == null)
            {
                trucks = _context.Trucks.Include(u => u.TruckCategory)
                .Where(p => p.Price == price)
                .Where(r => r.Rating >= rating);
            }


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

        // POST: api/trucks/
        [Authorize(Policy = "ApiUser")]
        [HttpPost]
        public async Task<IActionResult> CreateTruck(TruckViewModel model)
        {
            var userId = _caller.Claims.Single(c => c.Type == "id");

            var customer = await _context.Customers.Include(c => c.Identity).SingleAsync(c => c.Identity.Id == userId.Value);

            if (ModelState.IsValid)
            {
                var truck = _mapper.Map<Truck>(model);
                truck.Created_by = customer;
                _context.Trucks.Add(truck);
                await _context.SaveChangesAsync();


                var audit = new Audit
                {
                    TruckId = truck.TruckId,
                    TypeOfOperation = "INSERT",
                    Timestamp = DateTime.Now
                };
                _context.Audits.Add(audit);
                await _context.SaveChangesAsync();

                var resp = new TruckViewModel
                {
                    TruckId = truck.TruckId,
                    Title = truck.Title,
                    Price = truck.Price,
                    Rating = truck.Rating,
                    Hours = truck.Hours,
                    Phone = truck.Phone,
                    Categories = _mapper.Map<List<Category>, List<CategoryViewModel>>(truck.TruckCategory.Select(p => p.Category).ToList()),
                    Coordinates = truck.Coordinates,
                    Location = truck.Location

                };
                return Ok(resp);
            }

            return NotFound();
        }

        // PUT: api/trucks/5
        [Authorize(Policy = "ApiUser")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTruck(int id, [FromBody]UpdateTruckViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = _caller.Claims.Single(c => c.Type == "id");

            var customer = await _context.Customers.Include(c => c.Identity).SingleAsync(c => c.Identity.Id == userId.Value);

            var truck = _context.Trucks.Find(id);

            if (truck == null)
            {
                return NotFound();
            }

            if (truck.Created_by != customer)
            {

                return StatusCode(401, "Update not allowed on this truck");
            }

            var old_hours = truck.Hours;
            var old_location = truck.Location;
            String hours = model.Hours;
            Address location = model.Location;
            truck.Hours = hours;
            truck.Location = location;
            _context.SaveChanges();

            var audit = new Audit
            {
                TruckId = truck.TruckId,
                TypeOfOperation = "UPDATE",
                Timestamp = DateTime.Now,
                Hours = old_hours,
                Street = old_location.Street,
                City = old_location.City,
                State = old_location.State,
                Country = old_location.Country,
                Zip = old_location.Zip
            };

            _context.Audits.Add(audit);
            await _context.SaveChangesAsync();
            return Ok();
        }


        // DELETE: api/trucks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {

            var userId = _caller.Claims.Single(c => c.Type == "id");

            var customer = await _context.Customers.Include(c => c.Identity).SingleAsync(c => c.Identity.Id == userId.Value);

            var truckItem = await _context.Trucks.FindAsync(id);

            if (truckItem == null)
            {

                return NotFound();
            }

            if (truckItem.Created_by != customer)
            {
                return StatusCode(401, "Delete not allowed on this truck");
            }

            var truckId = truckItem.TruckId;
            _context.Trucks.Remove(truckItem);
            await _context.SaveChangesAsync();

            var audit = new Audit
            {
                TruckId = id,
                TypeOfOperation = "DELETE",
                Timestamp = DateTime.Now,
            };

            _context.Audits.Add(audit);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}


