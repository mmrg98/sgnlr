using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SgnlrServer.Data;
using SgnlrServer.HubConfig;
using SgnlrServer.Models;

namespace SgnlrServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IHubContext<CustomerHub, IHubClient> _hub;
        private readonly IConfiguration _configuration;
        private readonly TravelDemoContext _db;


        public CustomerController(IHubContext<CustomerHub, IHubClient> hub, IConfiguration configuration, TravelDemoContext db)
        {
            _hub = hub;
            _configuration = configuration;
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {

            // _hub.Clients.All.SendAsync("TransferCustomerData", _db.Customers);
            return await _db.Customers.ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult> PostCus(Customer cus)
        {
            string retMessage = "h";
            try
            {
                _db.Customers.AddAsync(cus);
                _db.SaveChanges();
                _hub.Clients.All.BroadcastCustumer(_db.Customers.Count());
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }

            return Ok(retMessage);
        }

      

    }
}



//[HttpGet]
//public async Task<ActionResult> Get()
//{

//    await _hub.Clients.All.SendAsync("transferdata", new List<Customer>());
//    return Ok();

//}


//[HttpPost]
//public async Task<ActionResult> PostCus(Customer cus)
//{
//    try
//    {
//        await _hub.Clients.All.SendAsync("transferdata", new List<Customer>());
//        return Ok("h");
//    }
//    catch (Exception e)
//    {
//        return BadRequest(e.Message);
//    }


//}