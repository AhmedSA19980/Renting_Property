using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedDTOLayer.Role;
using System.Security.Claims;

namespace PropertyRentingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        [Authorize(Policy = "Admin")]
        [HttpPut("SetRole", Name = "SetRole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<bool>> SetRole(AddClientRoleLogDTO client)
        {
            try
            {

                var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
                var userId = -1;
                var username = User.FindFirst(ClaimTypes.Name)?.Value;
                var roles = User.FindAll(ClaimTypes.Role).Select(x => x.Value).ToList();

                if (string.IsNullOrEmpty(userIdStr))
                {

                    return BadRequest("Authenticated user ID is missing.");
                }
                if (int.TryParse(userIdStr, out userId))
                {
                    client.AdminCommiteeId = userId;


                }
                else return BadRequest("! admin Id is null ");


                if (client.Report.Length == 0) { return BadRequest("Report is required field !"); }
                

                bool isRoleSetted = await PR_BusinessLayer.clsClients.SetRole(client);
                if (!isRoleSetted)
                {
                    return BadRequest("Object is Empty");
                }
                return Ok(client);
            }
            catch (Exception ex)
            {
                return BadRequest("process Failed to adjust user role ! ");
            }

        }



        [HttpGet("RoleLogs", Name = "RoleLogs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]


        public ActionResult<List<ClientsRoleLogsDTO>> RoleLogs()
        {

            List<ClientsRoleLogsDTO> roleLogs = PR_BusinessLayer.clsClients.GetRoleLogs();
            if (roleLogs.Count == 0)
            {
                return NotFound("Not a single Role Logs is Recroded in data!");
            }
            return Ok(roleLogs);

        }


        [HttpGet("GetRoleById", Name = "GetRoleById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ClientsRoleLogsDTO> GetRoleById(int logsId)
        {

            if (logsId < 1)
            {
                return BadRequest($"Not accepted ID {logsId}");
            }



            var RoleLogs = PR_BusinessLayer.clsClients.GetRoleLogsById(logsId);

            if (RoleLogs == null)
            {
                return NotFound($"Client with ID {logsId} not found.");
            }


          

            return Ok(RoleLogs);

        }
    }
}
