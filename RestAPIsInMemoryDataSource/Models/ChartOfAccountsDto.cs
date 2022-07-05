using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIsInMemoryData.Models
{
    public class ChartOfAccountsDto
    {
        public int AcctId { get; set; }
        public string AcctDescription { get; set; }
        public string AcctType { get; set; }
        public string AcctBalance { get; set; }
        public string ActiveStatus { get; set; }
        public int NumberOfChartGroup
        {
            get
            {
                return ChartGroup.Count;
            }
        }

        public ICollection<ChartGroupDto> ChartGroup { get; set; } = new List<ChartGroupDto>();
    }
}
