using FootBall.Model;


namespace FootBall.Service.Common
 
{ 
    public interface IFootBallService
    {
        public string PostPlayer(FootBallPlayer player);
        public string DeletePlayer(Guid Id);
         public List<FootBallPlayer> GetPlayer();

        public FootBallPlayer GetPlayerById(Guid id);

       
    }
}
