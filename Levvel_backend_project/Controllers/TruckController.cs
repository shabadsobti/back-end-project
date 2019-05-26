using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Levvel_backend_project.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Levvel_backend_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckController : ControllerBase
    {
        private ApiContext _context;
        public TruckController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var trucks = _context.Trucks.Include(u => u.TruckCategory);
            var response = trucks.Select(u => new
            {

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
            var truck_categories = _context.TruckCategories.Where(a => a.TruckId == id);
            foreach (var tc in truck_categories) // query executed and data obtained from database
            {
                int catId = tc.CategoryId;
                Category c = _context.Categories.Find(catId);
                category_names.Add(c.CategoryName);
            };

            var truck = t.FirstOrDefault((p => p.TruckId == id));
            var resp = new
            {
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
            var trucks = _context.Trucks.Include(u => u.TruckCategory).Where(p => p.Price == price).Where(r => r.Rating == rating).Where(x => x.TruckCategory.Any(r => r.Category.CategoryName.Equals(category)));
   
            var response = trucks.Select(u => new
            {
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
    }
}
