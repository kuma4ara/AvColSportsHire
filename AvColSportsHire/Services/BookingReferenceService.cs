namespace AvColSportsHire.Services
{
    public class BookingReferenceService
    {
        private static readonly Random _random = new Random();

        public string GenerateReference()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var code = new string(Enumerable
                .Repeat(chars, 6)
                .Select(s => s[_random.Next(s.Length)])
                .ToArray());

            return $"SH-{code}";
        }
    }
}
