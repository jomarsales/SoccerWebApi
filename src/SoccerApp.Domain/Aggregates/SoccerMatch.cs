using SoccerApp.Domain.Entities;

namespace SoccerApp.Domain.Aggregates
{
    public class SoccerMatch : EntityBase
    {
        public string Name { get; private set; }
        public DateTime Date { get; private set; }

        //missing properties...
    }
}
