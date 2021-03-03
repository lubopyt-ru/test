using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASP.NET_Core_3._1_Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
       
        private readonly ILogger<StoreController> _logger;

        public StoreController(ILogger<StoreController> logger)
        {
            _logger = logger;
        }

        //маршрут: api/Store/BirthdayPeoples/date
        [HttpGet("BirthdayPeoples/{date}")]
        public ActionResult GetBirthdayPeoples(DateTime date)
        {
            var rep = new Repository();
            var retval = rep.GetBirthdayPeoples(date).Select(Peoples =>
                new
                {
                    Peoples.Id,
                    FIO = Peoples.Fio
                });
            return Ok(retval);
        }
        //маршрут: api/Store/GetLastBuyers/days
        [HttpGet("GetLastBuyers/{days}")]
        public ActionResult GetLastBuyers(int days)
        {
            var rep = new Repository();
            var retval = rep.GetLastBuyers(days).Select(Peoples =>
                new
                {
                    Peoples.Id,
                    FIO = Peoples.Fio,
                    Date = Peoples.Registration 
                });
            return Ok(retval);
        }

        //маршрут: api/Store/GetCategories/id
        [HttpGet("GetCategories/{id}")]
        public IActionResult GetCategories(Guid id)
        {
            var rep = new Repository();
            var retval = rep.GetCategories(id).Select(Categories =>
                new
                {
                  category = Categories.category,
                    count = Categories.count
                });

            return Ok(retval);
        }
    }
}
// маршруты для проверки:
//    /api/Store/BirthdayPeoples/09.09.1971%200:00:00
//    /api/Store/GetLastBuyers/3
//   /api/Store/GetCategories/999c9aa8-ce97-440c-bee0-21efc2d5a5bb

