namespace IStore.Data
{
    public static class RepositoryUtils
    {
        public static string GetByIdQuery(string tableName, int id, string idColumnName = "id")
        {
            return $"SELECT * FROM {tableName} WHERE {idColumnName}={id}";
        }
        public static string GetAllQuery(string tableName)
        {
            return $"SELECT * FROM {tableName}";
        }
        public static string DeleteByIdQuery(string tableName, int id, string idColumnName = "id")
        {
            return $"DELETE FROM {tableName} WHERE {idColumnName}={id}";
        }
    }
}
