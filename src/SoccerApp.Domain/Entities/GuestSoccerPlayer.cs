namespace SoccerApp.Domain.Entities
{
    public class GuestSoccerPlayer : SoccerPlayer
    {
        protected GuestSoccerPlayer() { }

        public GuestSoccerPlayer(string name) : base(name)
        {
        }
    }
}
