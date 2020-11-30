using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WafDash.Data;
using WafDash.Models;

namespace WafDash.Services
{
    public class DataService : IDataService
    {
        private readonly FundingApplicationWafDatabaseContext _context;

        public DataService(FundingApplicationWafDatabaseContext context)
        {
            _context = context;
        }

        public IList<WafLogs> GetLogs()
        {
            return _context.WafLogs.ToList();
        }
    }
}