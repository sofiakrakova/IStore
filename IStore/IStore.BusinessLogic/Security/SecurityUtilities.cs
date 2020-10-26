namespace IStore.BusinessLogic.Security
{
    public static class SecurityUtilities
    {
        public static bool Verify(string text, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(text, hash);
        }
    }
}
