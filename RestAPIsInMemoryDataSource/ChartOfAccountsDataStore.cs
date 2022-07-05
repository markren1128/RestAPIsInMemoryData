using RestAPIsInMemoryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIsInMemoryData
{
    public class ChartOfAccountsDataStore
    {
        public static ChartOfAccountsDataStore Current { get; } = new ChartOfAccountsDataStore();
        public List<ChartOfAccountsDto> ChartOfAccounts { get; set; }

        public ChartOfAccountsDataStore()
        {
            ChartOfAccounts = new List<ChartOfAccountsDto>()
            {
                new ChartOfAccountsDto()
                {
                    AcctId = 1,
                    AcctDescription = "Accounts Receivable",
                    AcctType = "Income Statement",
                    AcctBalance = "Debit",
                    ActiveStatus = "Active",
                    ChartGroup = new List<ChartGroupDto>()
                    {
                        new ChartGroupDto()
                        {
                            Id = 1,
                            Description = "Account Receivable"
                        },
                        new ChartGroupDto()
                        {
                            Id = 2,
                            Description = "Account Receivable Aging"
                        }
                    }
                },
                new ChartOfAccountsDto()
                {
                    AcctId = 2,
                    AcctDescription = "Accounts Payable",
                    AcctType = "Balance Sheet",
                    AcctBalance = "Credit",
                    ActiveStatus = "Active",
                    ChartGroup = new List<ChartGroupDto>()
                    {
                        new ChartGroupDto()
                        {
                            Id = 3,
                            Description = "Account Payable"
                        },
                        new ChartGroupDto()
                        {
                            Id = 4,
                            Description = "Account Payable Aging"
                        }
                    }
                }
            };
        }

    }
}
