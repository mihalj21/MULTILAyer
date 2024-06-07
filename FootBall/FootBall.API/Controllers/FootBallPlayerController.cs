using AutoMapper;
using FootBall.API.RestModels;
using FootBall.Common;
using FootBall.Model;
using FootBall.Service.Common;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;


namespace Example.WebApi.Controllers
{



    [ApiController]
    [Route("[controller]")]

    public class FootBallPlayerController : ControllerBase
    {
        string connectionString = "Host = localhost; Port=5433;Database=FootballClub;Username=postgres;Password=mono";

        private readonly IFootBallService _footBallService;
        private readonly IMapper _mapper;
        public FootBallPlayerController(IFootBallService footBallService, IMapper mapper)
        {
            _footBallService = footBallService;
            _mapper = mapper;
        }

        [HttpPost("PostFootballPlayer")]

        public async Task<IActionResult> Post( FootBallPlayer player)
        {
            try
            {
               await  _footBallService.PostPlayer(player);
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
               await  _footBallService.GetPlayerById(id);
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
                var players = await _footBallService.GetPlayer();
                var restPlayers = _mapper.Map<IEnumerable<RestFootBallPlayer>>(players);
                return Ok(restPlayers);

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
                var footBallPlayer = _footBallService.GetPlayerById(id);

                if (footBallPlayer == null) { 
                 return NotFound();
                }
                await _footBallService.DeletePlayer(id);
                return Ok("Player added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("FilteredFormulas")]

        public async Task<IActionResult> Get(Guid? Id, string? firstName, string? lastName, Guid? clubName, string? sortBy = "FirstName", string? sortOrder = "ASC")
        {
            
            try
            {
                GetPlayer getPlayer = new GetPlayer(new Filter(Id, firstName, lastName, clubName), new Sort(sortBy, sortOrder));
                IList<FootBallPlayer> players = await _footBallService.GetAllAsync(getPlayer);
                
                return Ok(players);
                
                
            }
            catch (Exception ex) { 
            return BadRequest(ex.Message);
            }
        
        
        
        
        }

    }
}
