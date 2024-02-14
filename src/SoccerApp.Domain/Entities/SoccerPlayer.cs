
using SoccerApp.Domain.Services;

namespace SoccerApp.Domain.Entities
{
    public abstract class SoccerPlayer : EntityBase
    {
        public const int NameMaxLength = 50;

        public string Name { get; private set; }

        public virtual ICollection<SoccerTeam> SoccerTeams { get; private set; }
        public virtual ICollection<Payment> Payments { get; private set; }

        protected SoccerPlayer() { }

        public SoccerPlayer(string name)
        {
            AssertionConcern.AssertNotNull(name, "O nome do jogador é requerido.");
            AssertionConcern.AssertMaxLength(name, NameMaxLength, $"O nome do jogador só pode conter até {NameMaxLength} caracteres.");

            Name = name;
        }

        public void UpdateName(string name)
        {
            AssertionConcern.AssertNotNull(name, "O nome do jogador é requerido.");
            AssertionConcern.AssertMaxLength(name, NameMaxLength, $"O nome do jogador só pode conter até {NameMaxLength} caracteres.");

            Name = name;
        }
    }
}
