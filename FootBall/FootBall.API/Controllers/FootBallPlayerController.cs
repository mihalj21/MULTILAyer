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

        public ActionResult Post( FootBallPlayer player)
        {
            try
            {
                service.PostPlayer(player);
                return Ok("Succesfully added");
            }
            catch (Exception ex) {
                 return BadRequest(ex.Message);
            }

        }
        [HttpGet("GetFootballPlayerByGUID")]

        public ActionResult GetById(Guid id)
        {


            try
            {
                service.GetPlayerById(id);
                return Ok("Succesfully updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetFootballPlayers")]

        public ActionResult Get()
        {
            try
            {
                return Ok(service.GetPlayer());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlayer(Guid id)
        {
            try
            {
                var footBallPlayer = service.GetPlayerById(id);

                if (footBallPlayer == null) { 
                 return NotFound();
                }
                service.DeletePlayer(id);
                return Ok("Player added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
