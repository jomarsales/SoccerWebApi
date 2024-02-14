using SoccerApp.Domain.Aggregates;
using SoccerApp.Domain.Services;

namespace SoccerApp.Domain.Entities
{
    public class Substitution : EntityBase
    {
        public int BeforeSoccerPlayerId { get; private set; }
        public virtual SoccerPlayer BeforeSoccerPlayer { get; private set; }

        public int CurrentSoccerPlayerId { get; private set; }
        public virtual SoccerPlayer CurrentSoccerPlayer { get; private set; }

        public int SoccerTeamId { get; private set; }
        public virtual SoccerTeam SoccerTeam { get; private set; }

        public int SoccerMatchId { get; private set; }
        public virtual SoccerMatch SoccerMatch { get; private set; }

        protected Substitution() { }

        public Substitution(SoccerPlayer beforeSoccerPlayer, SoccerPlayer currentSoccerPlayer, SoccerTeam soccerTeam, SoccerMatch soccerMatch)
        {
            AssertionConcern.AssertNotNull(beforeSoccerPlayer, "Jogador a ser substituído é requerido.");
            AssertionConcern.AssertNotNull(currentSoccerPlayer, "Jogador substituto é requerido.");
            AssertionConcern.AssertNotNull(soccerTeam, "Time é requerido.");
            AssertionConcern.AssertNotNull(soccerMatch, "Partida é requerida.");

            BeforeSoccerPlayerId = beforeSoccerPlayer.Id;
            BeforeSoccerPlayer = beforeSoccerPlayer;

            CurrentSoccerPlayerId = currentSoccerPlayer.Id;
            CurrentSoccerPlayer = currentSoccerPlayer;

            SoccerTeamId = soccerTeam.Id;
            SoccerTeam = soccerTeam;

            SoccerMatchId = soccerMatch.Id;
            SoccerMatch = soccerMatch;
        }

        public void UpdateSubstitution(SoccerPlayer beforeSoccerPlayer, SoccerPlayer currentSoccerPlayer, SoccerTeam soccerTeam, SoccerMatch soccerMatch)
        {
            AssertionConcern.AssertNotNull(beforeSoccerPlayer, "Jogador a ser substituído é requerido.");
            AssertionConcern.AssertNotNull(currentSoccerPlayer, "Jogador substituto é requerido.");
            AssertionConcern.AssertNotNull(soccerTeam, "Time é requerido.");
            AssertionConcern.AssertNotNull(soccerMatch, "Partida é requerida.");
            
            BeforeSoccerPlayerId = beforeSoccerPlayer.Id;
            BeforeSoccerPlayer = beforeSoccerPlayer;

            CurrentSoccerPlayerId = currentSoccerPlayer.Id;
            CurrentSoccerPlayer = currentSoccerPlayer;

            SoccerTeamId = soccerTeam.Id;
            SoccerTeam = soccerTeam;

            SoccerMatchId = soccerMatch.Id;
            SoccerMatch = soccerMatch;
        }
    }
}
