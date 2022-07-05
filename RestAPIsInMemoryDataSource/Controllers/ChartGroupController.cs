using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestAPIsInMemoryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIsInMemoryData.Controllers
{
    [ApiController]
    [Route("api/chartofaccounts/{acctId}/chartgroup")]
    public class ChartGroupController : ControllerBase
    {
        [HttpGet] /*' Attributes*/
        public IActionResult GetChartGroups(int acctId)
        {
            var chartOfAccounts = ChartOfAccountsDataStore.Current.ChartOfAccounts
                .FirstOrDefault(o => o.AcctId == acctId);

            if (chartOfAccounts == null)
            {
                return NotFound();
            }

            return Ok(chartOfAccounts.ChartGroup);
        }

        [HttpGet("{id}", Name = "GetChartGroup")]
        public IActionResult GetChartGroup(int acctId, int id)
        {
            var chartOfAccounts = ChartOfAccountsDataStore.Current.ChartOfAccounts
                .FirstOrDefault(o => o.AcctId == acctId);

            if (chartOfAccounts == null)
            {
                return NotFound();
            }

            var chartGroup = chartOfAccounts.ChartGroup
                .FirstOrDefault(o => o.Id == id);

            if (chartGroup == null)
            {
                return NotFound();
            }

            return Ok(chartGroup);
        }

        [HttpPost]
        public IActionResult CreateChartGroup(int acctId,
            [FromBody] ChartGroupForCreationDto chartgroup)
        {
            var chartOfAccounts = ChartOfAccountsDataStore.Current.ChartOfAccounts
               .FirstOrDefault(o => o.AcctId == acctId);

            if (chartOfAccounts == null)
            {
                return NotFound();
            }

            var maxId = ChartOfAccountsDataStore.Current.ChartOfAccounts.SelectMany(c => c.ChartGroup).Max(p => p.Id);

            var finalChartGroup = new ChartGroupDto()
            {
                Id = ++maxId,
                Description = chartgroup.Description
            };

            chartOfAccounts.ChartGroup.Add(finalChartGroup);

            return CreatedAtRoute("GetChartGroup",
            new { acctId, id = finalChartGroup .Id}, finalChartGroup);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateChartGroup(int acctId, int id,
            [FromBody] ChartGroupForUpdateDto chartgroup)
        {
            //Error validation can use the model state or the Data Annotations
            //Manual Error Trapping
            /*if (chartgroup.Description.Length > 200)
            {
               ModelState.AddModelError("Description", "The provided descriptiob should not exceed 200");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            */
            //FluentValidation - for more sophisticated validation

            var chartOfAccounts = ChartOfAccountsDataStore.Current.ChartOfAccounts
               .FirstOrDefault(o => o.AcctId == acctId);

            if (chartOfAccounts == null)
            {
                return NotFound();
            }

            var chartGroupFromStore = chartOfAccounts.ChartGroup
                .FirstOrDefault(o => o.Id == id);

            if (chartGroupFromStore == null)
            {
                return NotFound();
            }

            chartGroupFromStore.Description = chartgroup.Description;

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdateChartGroup(int acctId, int id,
            [FromBody] JsonPatchDocument<ChartGroupForUpdateDto> patchDoc)
        {
            var chartOfAccounts = ChartOfAccountsDataStore.Current.ChartOfAccounts
               .FirstOrDefault(o => o.AcctId == acctId);

            if (chartOfAccounts == null)
            {
                return NotFound();
            }

            var chartGroupFromStore = chartOfAccounts.ChartGroup
                .FirstOrDefault(o => o.Id == id);

            if (chartGroupFromStore == null)
            {
                return NotFound();
            }

            var chartGroupToPatch =
                new ChartGroupForUpdateDto()
                {
                    Description = chartGroupFromStore.Description
                };

            patchDoc.ApplyTo(chartGroupToPatch, ModelState);
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(chartGroupToPatch))
            {
                return BadRequest();
            }

            chartGroupFromStore.Description = chartGroupToPatch.Description;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteChartGroup(int acctId, int id)
        {
            var chartOfAccounts = ChartOfAccountsDataStore.Current.ChartOfAccounts
               .FirstOrDefault(o => o.AcctId == acctId);

            if (chartOfAccounts == null)
            {
                return NotFound();
            }

            var chartGroupFromStore = chartOfAccounts.ChartGroup
                .FirstOrDefault(o => o.Id == id);

            if (chartGroupFromStore == null)
            {
                return NotFound();
            }

            chartOfAccounts.ChartGroup.Remove(chartGroupFromStore);

            return NoContent();
        }
    }
}
