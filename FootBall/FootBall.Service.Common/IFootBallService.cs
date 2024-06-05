using FootBall.Common;
using FootBall.Model;


namespace FootBall.Service.Common
 
{ 
    public interface IFootBallService
    {
        Task PostPlayer(FootBallPlayer player);
        Task DeletePlayer(Guid Id);
        Task<IEnumerable<FootBallPlayer>> GetPlayer();

        Task<FootBallPlayer> GetPlayerById(Guid id);
        Task<IList<FootBallPlayer>> GetAllAsync(GetPlayer getPlayer);

    }
}
