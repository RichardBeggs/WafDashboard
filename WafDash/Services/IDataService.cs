using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WafDash.Models;

namespace WafDash.Services
{
    public interface IDataService
    {
        public IList<WafLogs> GetLogs();
    }
}