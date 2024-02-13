using SoccerApp.Domain.Services;
using SoccerApp.Domain.ValueObjects;

namespace SoccerApp.Domain.Entities
{
    public class Team : EntityBase
    {
        public const int NameMaxLength = 100;

        public string Name { get; private set; }
        public Month Month { get; private set; }
        public byte PlayersCount { get; private set; }
        public byte SubstitutesCount { get; private set; }

        public List<SoccerPlayer> SoccerPlayers { get; private set; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="name">Nome do time</param>
        /// <param name="month">Mês de ocorrência dos jogos</param>
        /// <param name="playersCount">Número de jogadores em campo</param>
        /// <param name="substitutesCount">Núumero de reservares</param>
        public Team(string name, Month month, byte playersCount = 7, byte substitutesCount = 3)
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

        /// <summary>
        /// To be used when saving a team
        /// </summary>
        /// <param name="players"># of players</param>
        /// <param name="substitutes"># of substitutes</param>
        public void ValidatePlayers()
        {
            AssertionConcern.AssertTrue(SoccerPlayers.Count >= PlayersCount, $"Minimo de {PlayersCount} por jogo.");
            AssertionConcern.AssertTrue(SoccerPlayers.Count <= (PlayersCount + SubstitutesCount), $"Máximo de {PlayersCount + SubstitutesCount} por jogo, incluído os reservas.");
        }

        /// <summary>
        /// To be used when updating a team
        /// </summary>
        /// <param name="name">Nome do time</param>
        /// <param name="month">Mês de ocorrência dos jogos</param>
        /// <param name="playersCount">Número de jogadores em campo</param>
        /// <param name="substitutesCount">Núumero de reservares</param>
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
            SoccerPlayers.AddRange(newSoccerPlayers);
        }
    }
}
