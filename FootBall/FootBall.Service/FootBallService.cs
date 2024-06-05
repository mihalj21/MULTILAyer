
using FootBall.Service.Common;
using FootBall.Service;
using FootBall.Model;
using FootBall.Repository;

namespace FootBall.Service
{
    public class FootBallService : IFootBallService

    {
        FootBallRepository playerRepository = new FootBallRepository();

        public string PostPlayer(FootBallPlayer player)
        {
            return playerRepository.PostPlayer(player);
        }


        public string DeletePlayer(Guid Id)
        {
            
                return playerRepository.DeletePlayer(Id);
           
        }
        public List<FootBallPlayer> GetPlayer()
        {
            return playerRepository.GetPlayer();
        }

        public FootBallPlayer GetPlayerById(Guid id)
        {
            return playerRepository.GetPlayerById(id);
        }

        

        
    }
}
