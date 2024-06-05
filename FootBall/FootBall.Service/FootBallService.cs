
using FootBall.Service.Common;
using FootBall.Service;
using FootBall.Model;
using FootBall.Repository;

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

        

        
    }
}
