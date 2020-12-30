namespace IStore.BusinessLogic.Security
{
    internal static class SecurityUtilities
    {
        public static bool Verify(string text, string hash)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(text, hash);
            }
            catch (BCrypt.Net.SaltParseException)
            {
                return false;
            }
        }

        public static string Hash(string text)
        {
            return BCrypt.Net.BCrypt.HashPassword(text);
        }
    }
}
