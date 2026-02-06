using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedDTOLayer.Earning;
using SharedDTOLayer.Income.IncomesDTO;

namespace PropertyRentingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EarningController : ControllerBase
    {


        [HttpGet("GetAllOwnerEarnings", Name = "GetAllOwnerEarnings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<ICollection<AllOwnerEarningsDTO>> GetAllOwnerEarnings(int ClientID)
        {

            if (ClientID < 0)
            {

                return BadRequest($"Not accepted ID  {ClientID}");
            }

            ICollection<AllOwnerEarningsDTO> Earnings = PR_BusinessLayer.clsEarnings.GetAllOwnerEarnings(ClientID);
            if (Earnings.Count == 0)
            {
                return NotFound($"Earning Records with client ID =  {ClientID} is Empty/invalid clientid ! .");
            }

            return Ok(Earnings);
        }


        [HttpGet("GetAllOwnerEarningsByProperty", Name = "GetAllOwnerEarningsByProperty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<ICollection<AllOwnerEarningsByPropertyDTO>> GetAllOwnerEarningsByProperty(int PropertyID)
        {

            if (PropertyID < 0)
            {

                return BadRequest($"Not accepted ID  {PropertyID}");
            }

            ICollection<AllOwnerEarningsByPropertyDTO> Earnings = PR_BusinessLayer.clsEarnings.GetAllOwnerEarningsByProperty(PropertyID);
            if (Earnings.Count == 0)
            {
                return NotFound($"Earning Records with property ID = {PropertyID} is Empty/invalid clientid ! .");
            }

            return Ok(Earnings);
        }


        [HttpPost("SettleClientIncomeByPeriod", Name = "SettleClientIncomeByPeriod")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<SettleClientIncomeByPeriodDTO> SettleClientIncomeByPeriod(SettleClientIncomeByPeriodValuesDTO IncomeValues)
        {

            if (IncomeValues == null || IncomeValues.ClientId < 0 || IncomeValues.StartDate == default(DateOnly) || IncomeValues.EndDate == default(DateOnly))
            {

                return BadRequest($"Invalid data {IncomeValues}");
            }

            SettleClientIncomeByPeriodDTO Income = PR_BusinessLayer.clsEarnings.SettleClientIncomeByPeriod(IncomeValues);
            if (Income == null)
            {
                return NotFound($"Payment Record with values = {IncomeValues} is Empty/invalid ! .");
            }

            return Ok(Income);
        }

        [HttpGet("GetTotalIncomeByProperty", Name = "GetTotalIncomeByProperty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<decimal> GetTotalIncomeByProperty(int PropertyId)
        {

            if ( PropertyId < 0)
            {

                return BadRequest($"Invalid data {PropertyId}");
            }

            decimal Income = PR_BusinessLayer.clsEarnings.TotalIncomeByProperty(PropertyId);
            if (Income == null)
            {
                return NotFound($"Total Income is empty or not found from property id {PropertyId}");
            }

            return Ok(Income);
        }

    }
}
