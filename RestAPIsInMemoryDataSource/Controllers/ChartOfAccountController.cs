using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIsInMemoryData.Controllers
{
    [ApiController]
    [Route("api/chartofaccounts")]
    
    public class ChartOfAccountController: ControllerBase
    {
        
        [HttpGet]
        public IActionResult GetChartOfAccounts()
        {
            return Ok(ChartOfAccountsDataStore.Current.ChartOfAccounts);
        }

        [HttpGet("{acctId}")]
        public IActionResult GetChartOfAccount(int acctId)
        {
            var chartOfAccounts = ChartOfAccountsDataStore.Current.ChartOfAccounts
                .FirstOrDefault(c => c.AcctId == acctId);

            if (chartOfAccounts == null)
            {
                return NotFound();
            }

            return Ok(chartOfAccounts);
        }
    }
}
