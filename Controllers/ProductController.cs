using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperMarketManagementSystem.Models;
using SuperMarketManagementSystem.Services;
using System.Data;

namespace SuperMarketManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(Roles = "Admin")]
    public class ProductController : ControllerBase
    {
        private readonly SuperMarketDbContext _superMarketDbContext;

        public ProductController(SuperMarketDbContext superMarketDbContext)
        {
            _superMarketDbContext = superMarketDbContext;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<ActionResult<IEnumerable<product>>> GetProducts()
        {
            return await _superMarketDbContext.Products.ToListAsync();
        }

        [HttpPost]
        [Route("AddProducts")]
        public async Task<ActionResult<product>> AddProducts(product objproduct)
        {
            _superMarketDbContext.Products.Add(objproduct);
            await _superMarketDbContext.SaveChangesAsync();
            return  objproduct;
        }

        [HttpPatch]
        [Route("UpdateProducts/{id}")]
        public async Task<ActionResult<product>> UpdateProducts(product objproduct)
        {
            _superMarketDbContext.Entry(objproduct).State = EntityState.Modified;
            await _superMarketDbContext.SaveChangesAsync();
            return objproduct;
        }

        [HttpDelete]
        [Route("DeleteProducts/{id}")]
        public bool DeleteProduct(int id)
        {
            bool a = false;
            var product = _superMarketDbContext.Products.Find(id);
            if (product != null)
            {
                a = true;
                _superMarketDbContext.Entry(product).State = EntityState.Deleted;
                _superMarketDbContext.SaveChanges();
            }
            else
            {
                a = false;
            }

            return a;
        }
       
    }
}
