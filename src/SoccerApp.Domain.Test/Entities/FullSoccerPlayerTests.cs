using SoccerApp.Domain.Entities;
using SoccerApp.Domain.ValueObjects;

namespace SoccerApp.Domain.Test.Entities
{
    public class FullSoccerPlayerTests
    {
        [Fact(DisplayName = "Ensure that the CPF can be updated")]
        public void Ensure_that_the_cpf_can_be_updated()
        {
            var soccer = new FullSoccerPlayer("Test1");
            var cpf = new Cpf("253.331.740-32");

            soccer.UpdateCpf(cpf);

            Assert.NotNull(soccer.Cpf);
            Assert.Equal(cpf, soccer.Cpf);
            Assert.Equal("253.331.740-32", soccer.Cpf.ToString());
        }
    }
}
