using System.Numerics;
using FootBall.Model;

namespace FootBall.Repository.Common
  
{
    public interface IFootballRepository
    {
        Task PostPlayer(FootBallPlayer player);
        Task DeletePlayer(Guid Id);
        Task <IEnumerable<FootBallPlayer>> GetPlayer();

        Task <FootBallPlayer> GetPlayerById(Guid id);

        
    }
}
