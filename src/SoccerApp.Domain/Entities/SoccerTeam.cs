using SoccerApp.Domain.Services;
using SoccerApp.Domain.ValueObjects;

namespace SoccerApp.Domain.Entities
{
    public class SoccerTeam : EntityBase
    {
        public const int NameMaxLength = 100;

        public string Name { get; private set; }
        public Month Month { get; private set; }
        public byte PlayersCount { get; private set; }
        public byte SubstitutesCount { get; private set; }

        public virtual ICollection<SoccerPlayer> SoccerPlayers { get; private set; }
        public virtual ICollection<Substitution> Substitutions { get; private set; }

        protected SoccerTeam() { }

        public SoccerTeam(string name, Month month, byte playersCount = 7, byte substitutesCount = 3)
        {
            AssertionConcern.AssertNotNullOrEmpty(name, "Nome do time inválido!");
            AssertionConcern.AssertLength(name, 3, NameMaxLength, $"O nome do time deve estar entre 3 e {NameMaxLength}");

            AssertionConcern.AssertTrue(month >= Month.January && month <= Month.December, "Mês inválido");

            AssertionConcern.AssertTrue(playersCount > 0, "Número de jogadores precisa ser maior que zero.");
            AssertionConcern.AssertTrue(substitutesCount > 0, "Número de reservas precisa ser maior que zero.");

            Name = name;
            Month = month;
            PlayersCount = playersCount;
            SubstitutesCount = substitutesCount;

            SoccerPlayers = new List<SoccerPlayer>();
        }

        public void ValidatePlayers()
        {
            AssertionConcern.AssertTrue(SoccerPlayers.Count >= PlayersCount, $"Minimo de {PlayersCount} por jogo.");
            AssertionConcern.AssertTrue(SoccerPlayers.Count <= (PlayersCount + SubstitutesCount), $"Máximo de {PlayersCount + SubstitutesCount} por jogo, incluído os reservas.");
        }

        public void UpdateTeam(string name, Month month, byte playersCount, byte substitutesCount)
        {
            AssertionConcern.AssertNotNullOrEmpty(name, "Nome do time inválido!");
            AssertionConcern.AssertLength(name, 3, NameMaxLength, $"O nome do time deve estar entre 3 e {NameMaxLength}");

            AssertionConcern.AssertTrue(month >= Month.January && month <= Month.December, "Mês inválido");

            AssertionConcern.AssertTrue(playersCount > 0, "Número de jogadores precisa ser maior que zero.");
            AssertionConcern.AssertTrue(substitutesCount > 0, "Número de reservas precisa ser maior que zero.");

            Name = name;
            Month = month;
            PlayersCount = playersCount;
            SubstitutesCount = substitutesCount;
        }

        public void UpdatePlayers(List<SoccerPlayer> newSoccerPlayers)
        {
            SoccerPlayers.Clear();
            SoccerPlayers = newSoccerPlayers;
        }
    }
}
