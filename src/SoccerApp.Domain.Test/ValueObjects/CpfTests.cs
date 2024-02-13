
using SoccerApp.Domain.ValueObjects;

namespace SoccerApp.Domain.Test.ValueObjects
{
    public class CpfTests
    {
        [Fact(DisplayName = "Ensure that CPF is Valid")]
        public void Ensure_that_tpf_is_valid()
        {
            var number = "839.402.340-10";

            Assert.True(new Cpf(number).ToString() == number);
        }

        [Fact(DisplayName = "Ensure that invalid CPF throws an exception")]
        public void Ensure_that_invalid_cpf_throws_an_ecxeption()
        {
            var number = "940.770.100-15";

            var ex = Assert.Throws<Exception>(() => new Cpf(number));
            Assert.Equal(@"CPF Inválido!", ex.Message);
        }
    }
}
