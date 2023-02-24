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
    public class SellerController : ControllerBase
    {
        private readonly SuperMarketDbContext _superMarketDbContext;

        public SellerController(SuperMarketDbContext superMarketDbContext)
        {
            _superMarketDbContext = superMarketDbContext;
        }
        [HttpGet]
        [Route("GetSeller")]
        public async Task<ActionResult<IEnumerable<seller>>> GetSeller()
        {
            return await _superMarketDbContext.Sellers.ToListAsync();
        }


        [HttpPost]
        [Route("AddSeller")]
        public async Task<ActionResult<seller>> AddSeller(seller objseller)
        {
            _superMarketDbContext.Sellers.Add(objseller);
            await _superMarketDbContext.SaveChangesAsync();
            return objseller;
        }

        [HttpPatch]
        [Route("UpdateSeller/{id}")]
        public async Task<ActionResult<seller>> UpdateSeller(seller objseller)
        {
            _superMarketDbContext.Entry(objseller).State = EntityState.Modified;
            await _superMarketDbContext.SaveChangesAsync();
            return objseller;
        }


        [HttpDelete]
        [Route("DeleteSeller/{id}")]
        public bool DeleteSeller(int id)
        {
            bool a = false;
            var seller = _superMarketDbContext.Sellers.Find(id);
            if (seller != null)
            {
                a = true;
                _superMarketDbContext.Entry(seller).State = EntityState.Deleted;
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
