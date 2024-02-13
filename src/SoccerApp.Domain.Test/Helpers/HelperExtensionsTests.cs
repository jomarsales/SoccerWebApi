using SoccerApp.Domain.Helpers;

namespace SoccerApp.Domain.Test.Helpers
{
    public class HelperExtensionsTests
    {
        [Theory(DisplayName = "Ensure that the CPF is normalized")]
        [InlineData("839.402.340-10")]
        [InlineData("83940234010")]
        public void Ensure_that_the_cpf_is_normalized(string cpf)
        {
            var normilizedCpf = cpf.NormalizeCpf();

            Assert.Equal(83940234010, normilizedCpf);
            Assert.IsType<long>(normilizedCpf);
        }

        [Fact(DisplayName = "Ensure that the CPF be displayed")]
        public void Ensure_that_the_cpf_be_displayed()
        {
            var cpf = 83940234010;

            var cpfToDisplay = cpf.DisplayCpf();

            Assert.Equal("839.402.340-10", cpfToDisplay);
        }
    }
}
