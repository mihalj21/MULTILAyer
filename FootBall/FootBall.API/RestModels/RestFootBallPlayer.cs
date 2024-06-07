namespace FootBall.API.RestModels
{
    public class RestFootBallPlayer
    {


        public Guid RestId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Nation { get; set; }
        public int Age { get; set; }
        public Guid? ClubId { get; set; }

        public bool IsActive { get; set; }
    }
}
