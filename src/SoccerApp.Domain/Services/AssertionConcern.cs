using System.Net.Mail;
using System.Text.RegularExpressions;

namespace SoccerApp.Domain.Services
{
    public class AssertionConcern
    {
        public static void AssertLength(string stringValue, int minimum, int maximum, string message)
        {
            var length = stringValue?.Trim()?.Length ?? 0;

            if(length < minimum || length > maximum) throw new Exception(message);
        }

        public static void AssertMaxLength(string stringValue, int maximum, string message)
        {
            if (string.IsNullOrEmpty(stringValue)) return;

            var length = stringValue.Trim().Length;

            if(length > maximum) throw new Exception(message);
        }

        public static void AssertFixedLength(string stringValue, int size, string message)
        {
            var length = stringValue.Trim().Length;

            if(length != size) throw new Exception(message);
        }

        public static void AssertMatches(string pattern, string stringValue, string message)
        {
            var regex = new Regex(pattern);

            if(!regex.IsMatch(stringValue)) throw new Exception(message);
        }

        public static void AssertNotNullOrEmpty(string stringValue, string message)
        {
            if(string.IsNullOrEmpty(stringValue)) throw new Exception(message);
        }

        public static void AssertNotNull(object object1, string message)
        {

            if(object1 == null) throw new Exception(message);
        }

        public static void AssertTrue(bool boolValue, string message)
        {
            if(!boolValue) throw new Exception(message);
        }

        public static void AssertAreEquals(string value, string match, string message)
        {
            if(value != match) throw new Exception(message);
        }

        public static void AssertMailValid(string email, string message)
        {
            try
            {
                if (string.IsNullOrEmpty(email)) return;

                var m = new MailAddress(email);

                return;
            }
            catch (FormatException)
            {
                throw new Exception(message);
            }
        }

        public static void AssertLessThan(decimal value, decimal comparer, string message)
        {
            if (value < comparer) throw new Exception(message);
        }

        public static void AssertDateTimeInSQLRange(DateTime? value, string message)
        {
            AssertValueInRange(value, new DateTime(1753, 1, 1), new DateTime(9999, 12, 31, 23, 59, 59, 997), message);
        }

        public static void AssertValueInRange<T>(T value, T minimum, T maximun, string message) where T : IComparable<T>
        {
            if(value.CompareTo(maximun) > 0 || value.CompareTo(minimum) < 0) throw new Exception(message);
        }

        public static void AssertValueInRange<T>(T? value, T minimum, T maximun, string message) where T : struct, IComparable<T>
        {
            if (!value.HasValue) return;

            if (value.Value.CompareTo(maximun) > 0 || value.Value.CompareTo(minimum) < 0) throw new Exception(message);
        }

        public static void AssertCollectionContainsValue<T>(T value, IEnumerable<T> possibleValues, string message)
        {
            if(!possibleValues.Contains(value)) throw new Exception(message);
        }

        public static void AssertNotFail(Action validation)
        {
            try
            {
                validation.Invoke();
                return;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

    }
}
