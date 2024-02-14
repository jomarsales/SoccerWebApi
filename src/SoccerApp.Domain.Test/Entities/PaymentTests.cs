using SoccerApp.Domain.Aggregates;
using SoccerApp.Domain.Entities;

namespace SoccerApp.Domain.Test.Entities
{
    public class PaymentTests
    {
        private Payment CreatePayment()
        {
            return new Payment(70.00M, DateTime.Now, new GuestSoccerPlayer("Soccer1"));
        }

        [Fact(DisplayName = "Ensure that the payment can be updated")]
        public void Ensure_that_the_payment_can_be_updated()
        {
            var payment = CreatePayment();

            var newValue = 80.00M;
            var newPayDay = DateTime.Now.AddDays(-2);
            var newSoccer = new GuestSoccerPlayer("Soccer2");

            payment.UpdatePayment(newValue, newPayDay, newSoccer);

            Assert.Equal(newValue, payment.Value);
            Assert.Equal(newPayDay, payment.PayDay);
            Assert.Equal(newSoccer, payment.SoccerPlayer);
        }

        [Fact(DisplayName = "Ensure that the payment can be associated to any soccer match")]
        public void Ensure_that_the_payment_can_be_associated_to_any_soccer_match()
        {
            var payment = CreatePayment();

            var soccerMatch = new SoccerMatch("Match1", DateTime.Today);

            payment.SetSoccerMatch(soccerMatch);

            Assert.NotNull(payment.SoccerMatchId);
            Assert.NotNull(payment.SoccerMatch);
        }
    }
}
