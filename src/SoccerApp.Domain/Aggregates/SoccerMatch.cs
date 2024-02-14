using SoccerApp.Domain.Entities;
using SoccerApp.Domain.Services;

namespace SoccerApp.Domain.Aggregates
{
    public class SoccerMatch : EntityBase
    {
        public const int NameMaxLength = 60;

        public string Name { get; private set; }
        public DateTime Date { get; private set; }

        public virtual ICollection<SoccerTeam> Teams { get; private set; }
        public virtual ICollection<Payment> Payments { get; private set; }
        public virtual ICollection<Substitution> Substitutions { get; private set; }

        protected SoccerMatch() { }

        public SoccerMatch(string name, DateTime date)
        {
            AssertionConcern.AssertNotNull(name, "O nome da partida é requerido.");
            AssertionConcern.AssertMaxLength(name, NameMaxLength, $"O nome da partida só pode conter até {NameMaxLength} caracteres.");

            Name = name;
            Date = date.Date;

            Teams = new List<SoccerTeam>();
        }

        public void UpdateSoccerMatch(string name, DateTime date)
        {
            AssertionConcern.AssertNotNull(name, "O nome da partida é requerido.");
            AssertionConcern.AssertMaxLength(name, NameMaxLength, $"O nome da partida só pode conter até {NameMaxLength} caracteres.");

            Name = name;
            Date = date.Date;

            Teams = new List<SoccerTeam>();
        }

        public void SetTeams(List<SoccerTeam> teams)
        {
            AssertionConcern.AssertTrue(teams.Count == 2, "Permitidos apenas DOIS times por partida.");
            AssertionConcern.AssertTrue(teams.GroupBy(x => x.Month).Count() == 1, "Os times da partida precisam estar configurados para o mesmo mês.");

            Teams.Clear();
            Teams = teams;
        }
    }
}
