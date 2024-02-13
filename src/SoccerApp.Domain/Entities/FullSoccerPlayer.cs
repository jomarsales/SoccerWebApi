using SoccerApp.Domain.ValueObjects;

namespace SoccerApp.Domain.Entities
{
    public class FullSoccerPlayer : SoccerPlayer
    {
        public Cpf? Cpf { get; private set; }

        public FullSoccerPlayer(string name, Cpf? cpf = null) : base(name)
        {
        }

        public void UpdateCpf(Cpf cpf)
        {
            Cpf = cpf;
        }
    }
}
