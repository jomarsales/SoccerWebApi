
using SoccerApp.Domain.ValueObjects;

namespace SoccerApp.Domain.Entities
{
    internal class SoccerPlayer : EntityBase
    {
        public string Name { get; private set; }

        public Cpf Cpf { get; private set; }
    }
}
