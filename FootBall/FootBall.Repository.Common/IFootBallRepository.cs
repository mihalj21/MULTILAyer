using System.Numerics;
using FootBall.Model;

namespace FootBall.Repository.Common
  
{
    public interface IFootballRepository
    {
        string PostPlayer(FootBallPlayer player);
        string DeletePlayer(FootBallPlayer player);
        public List<FootBallPlayer> GetPlayer();

        public FootBallPlayer GetPlayerById(Guid id);

        
    }
}
