using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Levvel_backend_project.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Levvel_backend_project.ViewModels;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Levvel_backend_project.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TruckController : ControllerBase
    {
        private ApiContext _context;
        private readonly ClaimsPrincipal _caller;
        private readonly IMapper _mapper;
        public TruckController(ApiContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _caller = httpContextAccessor.HttpContext.User;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var trucks = _context.Trucks.Include(u => u.TruckCategory);
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
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var t = _context.Trucks.Include(u => u.TruckCategory).ToList();
            List<string> category_names = new List<string>();
            var truck_categories = _context.TruckCategories
                .Where(a => a.TruckId == id);
            foreach (var tc in truck_categories) // query executed and data obtained from database
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
            var resp = new
            {
                id = truck.TruckId,
                title = truck.Title,
                price = truck.Price,
                rating = truck.Rating,
                hours = truck.Hours,
                phone = truck.Phone,
                categories = category_names,
                coordinates = truck.Coordinates,
                location = truck.Location

            };
            return Ok(resp);
        }

        [HttpGet("search")]
        public IActionResult GetByQuery(int price, decimal rating, string category)
        {
            var trucks = _context.Trucks.Include(u => u.TruckCategory)
                .Where(p => p.Price == price)
                .Where(r => r.Rating == rating)
                .Where(x => x.TruckCategory
                .Any(r => r.Category.CategoryName.Equals(category)));

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
            return Ok(response);
        }

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
                var resp = new
                {
                    id = truck.TruckId,
                    title = truck.Title,
                    price = truck.Price,
                    rating = truck.Rating,
                    hours = truck.Hours,
                    phone = truck.Phone,
                    categories = model.Categories,
                    coordinates = truck.Coordinates,
                    location = truck.Location

                };
                return Ok(resp);
            }
            else
            {
                return NotFound();
            }


        }

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


        // DELETE: api/Truck/5
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
                //todo: Return unauthorized access
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


