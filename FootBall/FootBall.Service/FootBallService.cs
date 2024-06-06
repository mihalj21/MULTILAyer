
using FootBall.Service.Common;
using FootBall.Service;
using FootBall.Model;
using FootBall.Repository;
using System.Dynamic;
using FootBall.Common;
using FootBall.Repository.Common;

namespace FootBall.Service
{
    public class FootBallService : IFootBallService

    {
        private readonly IFootballRepository _repository;
        public  FootBallService(IFootballRepository _repository)
        {

           this. _repository = _repository;

        }

        public async Task PostPlayer(FootBallPlayer player)
        {
            await _repository.PostPlayer(player);
        }


        public async Task DeletePlayer(Guid Id)
        {
            
                await _repository.DeletePlayer(Id);
           
        }
        public async  Task<IEnumerable<FootBallPlayer>> GetPlayer()
        {
           return  await _repository.GetPlayer();
        }

        public async  Task<FootBallPlayer> GetPlayerById(Guid id)
        {
           return await _repository.GetPlayerById(id);
        }

        public async Task<IList<FootBallPlayer>> GetAllAsync(GetPlayer getPlayer) 
        {
            return await _repository.GetAllAsync(getPlayer);
        }

        
    }
}
