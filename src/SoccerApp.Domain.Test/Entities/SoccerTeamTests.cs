using SoccerApp.Domain.Entities;
using SoccerApp.Domain.ValueObjects;

namespace SoccerApp.Domain.Test.Entities
{
    public class SoccerTeamTests
    {
        public static SoccerTeam CreateTeam()
        {
            var team = new SoccerTeam("Team1", Month.January);

            team.SoccerPlayers.Add(new FullSoccerPlayer("Soccer1", new Cpf("725.354.410-20")));
            team.SoccerPlayers.Add(new FullSoccerPlayer("Soccer2", new Cpf("535.676.590-81")));
            team.SoccerPlayers.Add(new FullSoccerPlayer("Soccer3", new Cpf("957.371.390-00")));
            team.SoccerPlayers.Add(new FullSoccerPlayer("Soccer4", new Cpf("745.567.350-76")));
            team.SoccerPlayers.Add(new FullSoccerPlayer("Soccer5", new Cpf("774.401.650-55")));
            team.SoccerPlayers.Add(new FullSoccerPlayer("Soccer6", new Cpf("050.916.770-54")));
            team.SoccerPlayers.Add(new FullSoccerPlayer("Soccer7", new Cpf("826.075.640-42")));

            team.SoccerPlayers.Add(new GuestSoccerPlayer("Soccer8"));
            team.SoccerPlayers.Add(new GuestSoccerPlayer("Soccer9"));
            team.SoccerPlayers.Add(new GuestSoccerPlayer("Soccer10"));

            return team;
        }

        [Fact(DisplayName = "Ensure that a team can be updated")]
        public void Ensure_that_a_team_can_be_updated()
        {
            var name = "Team2";
            var month = Month.February;
           
            var team = CreateTeam();

            team.UpdateTeam(name, month, 8, 2);

            Assert.Equal(name, team.Name);
            Assert.Equal(month, team.Month);
            Assert.Equal(8, team.PlayersCount);
            Assert.Equal(2, team.SubstitutesCount);
        }

        [Fact(DisplayName = "Ensure that the team player list is valid")]
        public void Ensure_that_the_team_player_list_is_valid()
        {
            var team = CreateTeam();

            team.ValidatePlayers();
        }

        [Fact(DisplayName = "Ensure that the team player list is not valid")]
        public void Ensure_that_the_team_player_list_is_not_valid()
        {
            var team = CreateTeam();

            for (int i = 0; i < 4; i++)
            {
                var sp = team.SoccerPlayers.First();
                team.SoccerPlayers.Remove(sp);
            }

            Assert.Throws<Exception>(() => team.ValidatePlayers());
        }

        [Fact(DisplayName = "Ensure that the team player list can be updated")]
        public void Ensure_that_the_team_player_list_can_be_updated()
        {    
            //ACT
            var team = CreateTeam();

            var soccerPlayers = new List<SoccerPlayer>();
            soccerPlayers.AddRange(team.SoccerPlayers);
            
            //remove
            var sp = team.SoccerPlayers.First();
            team.SoccerPlayers.Remove(sp);

            //update
            var sp2 = team.SoccerPlayers.First();
            sp2.UpdateName("NewName");

            //insert
            team.SoccerPlayers.Add(new FullSoccerPlayer("Soccer11", new Cpf("313.920.580-58")));

            //ARRANGE
            team.UpdatePlayers(soccerPlayers);

            //ASSERT
            Assert.Equal(team.SoccerPlayers, soccerPlayers);
        }
    }
}
