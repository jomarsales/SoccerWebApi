using SoccerApp.Domain.Aggregates;
using SoccerApp.Domain.Services;

namespace SoccerApp.Domain.Entities
{
    public class Payment : EntityBase
    {
        public decimal Value { get; private set; }
        public DateTime PayDay { get; private set; }

        public int SoccerPlayerId { get; private set; }
        public virtual SoccerPlayer SoccerPlayer { get; set; }

        public int? SoccerMatchId { get; private set; }
        public virtual SoccerMatch SoccerMatch { get; set; }


        protected Payment() { }

        public Payment(decimal value, DateTime payDay, SoccerPlayer soccerPlayer)
        {
            AssertionConcern.AssertTrue(value > 0, "Valor do pagamento deve ser maior que ZERO.");
            AssertionConcern.AssertNotNull(soccerPlayer, "Jogador que efetuou o pagamento é obrigatório.");

            Value = value;
            PayDay = payDay;
            SoccerPlayerId = soccerPlayer.Id;
            SoccerPlayer = soccerPlayer;
        }

        public void UpdatePayment(decimal value, DateTime payDay, SoccerPlayer soccerPlayer)
        {
            AssertionConcern.AssertTrue(value > 0, "Valor do pagamento deve ser maior que ZERO.");
            AssertionConcern.AssertNotNull(soccerPlayer, "Jogador que efetuou o pagamento é obrigatório.");

            Value = value;
            PayDay = payDay;
            SoccerPlayerId = soccerPlayer.Id;
            SoccerPlayer = soccerPlayer;
        }

        public void SetSoccerMatch(SoccerMatch soccerMatch)
        {
            AssertionConcern.AssertNotNull(soccerMatch, "É preciso informar qual foi a partida desse pagamento.");

            SoccerMatchId = soccerMatch.Id;
            SoccerMatch = soccerMatch;
        }
    }
}
