using SoccerApp.Domain.Aggregates;
using SoccerApp.Domain.Entities;

namespace SoccerApp.Domain.Test.Entities
{
    public class SubtitutionTests
    {
        [Fact(DisplayName = "Ensure that some soccer player can be substituted by another one")]
        public void Ensure_that_some_soccer_player_can_be_substituted_by_another_one()
        {
            var team = SoccerTeamTests.CreateTeam();
            var match = new SoccerMatch("Match1", new DateTime(2024, 1, 1));
            var beforeSoccerPlayer = team.SoccerPlayers.First(x => x.Name == "Soccer1");
            var currentSoccerPlayer = new GuestSoccerPlayer("Soccer11");

            var substitution = new Substitution(
                beforeSoccerPlayer,
                currentSoccerPlayer,
                team,
                match
                );

            var newCurrentSoccerPlayer = new GuestSoccerPlayer("Soccer12");

            substitution.UpdateSubstitution(currentSoccerPlayer, newCurrentSoccerPlayer, team, match);

            Assert.Equal(currentSoccerPlayer.Name.ToUpper(), substitution.BeforeSoccerPlayer.Name.ToUpper());
            Assert.Equal(newCurrentSoccerPlayer.Name.ToUpper(), substitution.CurrentSoccerPlayer.Name.ToUpper());
            Assert.Equal(team.Name.ToUpper(), substitution.SoccerTeam.Name.ToUpper());
            Assert.Equal(match.Name.ToUpper(), substitution.SoccerMatch.Name.ToUpper());
        }
    }
}
