using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UAParser;
using WafDash.Data;
using WafDash.Models;

namespace WafDash.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly FundingApplicationWafDatabaseContext _context;

        public DataController(FundingApplicationWafDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Get-by-attack")]
        public IEnumerable<Model> GetByAttack()
        {
            var data = _context.WafLogs;

            var result = data.GroupBy(log => log.Attack)
                .Select(group => new { browser = @group.Key, count = @group.Count() })
                .OrderByDescending(x => x.count)
                .Select(arg => new Model { Name = arg.browser, Count = arg.count }).ToList();

            return result.Count >= 10 ? result.Take(10) : result;
        }

        [HttpGet]
        [Route("Get-by-country")]
        public IEnumerable<Country> GetByCountry()
        {
            var data = _context.WafLogs;

            var result = data.GroupBy(log => log.Country)
                .Select(group => new { country = @group.Key, count = @group.Count() })
                .OrderBy(x => x.country)
                .Select(arg => new Country { Name = arg.country, Count = arg.count }).ToList();

            return result;
        }

        [HttpGet]
        [Route("Get-by-device")]
        public IEnumerable<Browser> GetByDevice()
        {
            var data = _context.WafLogs;
            var userAgents = data.Select(x => x.UserAgent);

            var browsers = new List<string>();
            var parser = Parser.GetDefault();

            foreach (var useragent in userAgents)
            {
                var ua = parser.Parse(useragent);
                browsers.Add(ua.UA.ToString());
            }

            var result = browsers.GroupBy(log => log)
                .Select(group => new { browser = @group.Key, count = @group.Count() })
                .OrderByDescending(x => x.count)
                .Select(arg => new Browser { Name = arg.browser, Count = arg.count }).ToList();

            return result.Count >= 5 ? result.Take(10) : result;
        }

        [HttpGet]
        [Route("Get-by-ip")]
        public IEnumerable<Ip> GetByIp()
        {
            var data = _context.WafLogs;

            var result = data.GroupBy(log => log.ClientIp)
                .Select(group => new { browser = @group.Key, count = @group.Count() })
                .OrderByDescending(x => x.count)
                .Select(arg => new Ip { Name = arg.browser, Count = arg.count }).ToList();

            return result.Count >= 10 ? result.Take(10) : result;
        }

        [HttpGet]
        [Route("Get-by-time")]
        public IEnumerable<Model> GetByTime()
        {
            var data = _context.WafLogs.ToList();
            var result = data.GroupBy(log => Convert.ToDateTime(log.TimeStamp).ToString("dd/MMM HH:00"))
                .Select(group => new { date = @group.Key, count = @group.Count() })
                .OrderBy(x => x.date)
                .Select(arg => new Model { Name = arg.date.ToString(), Count = arg.count }).ToList();

            return result;
        }
    }
}