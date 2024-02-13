using SoccerApp.Domain.Services;

namespace SoccerApp.Domain.Test.Services
{
    public class AssertionConcernTests
    {
        [Fact]
        public void AssertLength_ThrowsExceptionWhenLengthOutOfRange()
        {
            Assert.Throws<Exception>(() => AssertionConcern.AssertLength("test", 2, 3, "Tamanho fora do intervalo"));
        }

        [Fact]
        public void AssertMaxLength_ThrowsExceptionWhenLengthExceedsMaximum()
        {
            Assert.Throws<Exception>(() => AssertionConcern.AssertMaxLength("test", 2, "Tamanho excede máximo"));
        }

        [Fact]
        public void AssertFixedLength_ThrowsExceptionWhenLengthDiffers()
        {
            Assert.Throws<Exception>(() => AssertionConcern.AssertFixedLength("test", 2, "Tamanho difere"));
        }

        [Fact]
        public void AssertMatches_ThrowsExceptionWhenPatternDoesNotMatch()
        {
            Assert.Throws<Exception>(() => AssertionConcern.AssertMatches("[0-9]+", "test", "Padrão não corresponde"));
        }

        [Fact]
        public void AssertNotNullOrEmpty_ThrowsExceptionWhenNullOrEmpty()
        {
            Assert.Throws<Exception>(() => AssertionConcern.AssertNotNullOrEmpty(null, "String é nula ou vazia"));
            Assert.Throws<Exception>(() => AssertionConcern.AssertNotNullOrEmpty("", "String é nula ou vazia"));
        }

        [Fact]
        public void AssertNotNull_ThrowsExceptionWhenNull()
        {
            Assert.Throws<Exception>(() => AssertionConcern.AssertNotNull(null, "Object é nulo"));
        }

        [Fact]
        public void AssertTrue_ThrowsExceptionWhenFalse()
        {
            Assert.Throws<Exception>(() => AssertionConcern.AssertTrue(false, "Afirmação é falsa"));
        }

        [Fact]
        public void AssertAreEquals_ThrowsExceptionWhenNotEqual()
        {
            Assert.Throws<Exception>(() => AssertionConcern.AssertAreEquals("test", "match", "Strings não são iguais"));
        }

        [Fact]
        public void AssertMailValid_ThrowsExceptionWhenInvalidEmail()
        {
            Assert.Throws<Exception>(() => AssertionConcern.AssertMailValid("invalidemail", "Email inválido"));
        }

        [Fact]
        public void AssertLessThan_ThrowsExceptionWhenNotLessThan()
        {
            Assert.Throws<Exception>(() => AssertionConcern.AssertLessThan(2, 5, "Valor não é menor que comparador"));
        }

        [Fact]
        public void AssertDateTimeInSQLRange_ThrowsExceptionWhenOutOfRange()
        {
            Assert.Throws<Exception>(() => AssertionConcern.AssertDateTimeInSQLRange(new DateTime(1752, 12, 31), "Data e hora estão fora do intervalo SQL"));
        }

        [Fact]
        public void AssertValueInRange_ThrowsExceptionWhenOutOfRange()
        {
            Assert.Throws<Exception>(() => AssertionConcern.AssertValueInRange(5, 2, 4, "Valor está fora do intervalo"));
        }

        [Fact]
        public void AssertCollectionContainsValue_ThrowsExceptionWhenValueContained()
        {
            Assert.Throws<Exception>(() => AssertionConcern.AssertCollectionDoNotContainsValue(2, new List<int> { 1, 2, 3 }, "Valor está contido na coleção"));
        }

        [Fact]
        public void AssertCollectionContainsValue_ThrowsExceptionWhenValueNotContained()
        {
            Assert.Throws<Exception>(() => AssertionConcern.AssertCollectionContainsValue(5, new List<int> { 1, 2, 3 }, "Valor não está contido na coleção"));
        }

        [Fact]
        public void AssertNotFail_DoesNotThrowExceptionWhenValidationSucceeds()
        {
            AssertionConcern.AssertNotFail(() => { });
        }

        [Fact]
        public void AssertNotFail_ThrowsExceptionWhenValidationFails()
        {
            Assert.Throws<Exception>(() => AssertionConcern.AssertNotFail(() => throw new Exception("Validação falhou")));
        }
    }
}
