using FootBall.Model;
using FootBall.Service;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Net;


namespace Example.WebApi.Controllers
{



    [ApiController]
    [Route("[controller]")]

    public class FootBallPlayerController : ControllerBase
    {
        string connectionString = "Host = localhost; Port=5433;Database=FootballClub;Username=postgres;Password=mono";

        FootBallService service = new FootBallService();
       

        [HttpPost("PostFootballPlayer")]

        public async Task<IActionResult> Post( FootBallPlayer player)
        {
            try
            {
               await  service.PostPlayer(player);
                return Ok("Succesfully added");
            }
            catch (Exception ex) {
                 return BadRequest(ex.Message);
            }

        }
        [HttpGet("GetFootballPlayerByGUID")]

        public async Task<ActionResult> GetById(Guid id)
        {


            try
            {
               await  service.GetPlayerById(id);
                return Ok("Succesfully updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetFootballPlayers")]

        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await service.GetPlayer());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public  async Task<IActionResult> DeletePlayer(Guid id)
        {
            try
            {
                var footBallPlayer = service.GetPlayerById(id);

                if (footBallPlayer == null) { 
                 return NotFound();
                }
                await service.DeletePlayer(id);
                return Ok("Player added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
