
using FootBall.Service.Common;
using FootBall.Service;
using FootBall.Model;
using FootBall.Repository;
using System.Dynamic;
using FootBall.Common;

namespace FootBall.Service
{
    public class FootBallService : IFootBallService

    {
        FootBallRepository playerRepository = new FootBallRepository();

        public async Task PostPlayer(FootBallPlayer player)
        {
            await playerRepository.PostPlayer(player);
        }


        public async Task DeletePlayer(Guid Id)
        {
            
                await playerRepository.DeletePlayer(Id);
           
        }
        public async  Task<IEnumerable<FootBallPlayer>> GetPlayer()
        {
           return  await playerRepository.GetPlayer();
        }

        public async  Task<FootBallPlayer> GetPlayerById(Guid id)
        {
           return await playerRepository.GetPlayerById(id);
        }

        public async Task<IList<FootBallPlayer>> GetAllAsync(GetPlayer getPlayer) 
        {
            return await playerRepository.GetAllAsync(getPlayer);
        }

        
    }
}
