using System;

namespace IStore.Data
{
    public static class RepositoryUtils
    {
        public static string DateTimeToString(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd H:mm:ss");
        }
    }
}
