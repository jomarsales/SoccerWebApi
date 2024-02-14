using SoccerApp.Domain.Aggregates;
using SoccerApp.Domain.Entities;
using SoccerApp.Domain.Services;

namespace SoccerApp.Domain.Test.Aggregates
{
    public class SoccerMatchTests
    {
        private SoccerMatch CreateSoccerMatch()
        {
            return new SoccerMatch("Match1", DateTime.Today); ;
        }

        [Fact(DisplayName = "Ensure that a soccer match can be updated")]
        public void Ensure_that_a_soccer_match_can_be_updated()
        {
            var match = CreateSoccerMatch();

            var newName = "Match2";
            var newDate = DateTime.Now.AddDays(5);

            match.UpdateSoccerMatch(newName, newDate);

            Assert.Equal(newName, match.Name);
            Assert.Equal(newDate.Date, match.Date);
            Assert.True(match.Teams.Count == 0);
        }

        [Fact(DisplayName = "Ensure that a team can have two teams associated")]
        public void Ensure_that_a_team_can_have_two_teams_associated()
        {
            var match = CreateSoccerMatch();

            var team1 = new SoccerTeam("Team1", Domain.ValueObjects.Month.January);
            var team2 = new SoccerTeam("Team2", Domain.ValueObjects.Month.January);

            match.SetTeams(new() { team1, team2 });

            Assert.True(match.Teams.Count == 2);
            Assert.True(match.Teams.All(x => x.Month == Domain.ValueObjects.Month.January));
        }
       
        [Fact(DisplayName = "Ensure that a team can not have only one team associated")]
        public void Ensure_that_a_team_can_not_have_only_one_team_associated()
        {
            var match = CreateSoccerMatch();

            var team1 = new SoccerTeam("Team1", Domain.ValueObjects.Month.January);

            Assert.Throws<Exception>(() => match.SetTeams(new() { team1 }));
        }

        [Fact(DisplayName = "Ensure that a team can not have two different month teams associated")]
        public void Ensure_that_a_team_can_not_have_two_differente_month_teams_associated()
        {
            var match = CreateSoccerMatch();

            var team1 = new SoccerTeam("Team1", Domain.ValueObjects.Month.January);
            var team2 = new SoccerTeam("Team2", Domain.ValueObjects.Month.February);

            Assert.Throws<Exception>(() => match.SetTeams(new() { team1 }));
        }
    }
}
