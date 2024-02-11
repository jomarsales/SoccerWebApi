
using SoccerApp.Domain.ValueObjects;

namespace SoccerApp.Domain.Test.ValueObjects
{
    public class CpfTests
    {
        [Fact(DisplayName = "Ensure that CPF is Valid")]
        public void EnsureThatCpfIsValid()
        {
            var number = "945.775.105-10";

            Assert.True(new Cpf(number).ToString() == number);
        }

        [Fact(DisplayName = "Ensure that invalid CPF throws an exception")]
        public void EnsureThatInvalidCpfThrowsAnEcxeption()
        {
            var number = "940.770.100-15";

            var ex = Assert.Throws<Exception>(() => new Cpf(number));
            Assert.Equal(@"CPF Inválido!", ex.Message);
        }
    }
}
