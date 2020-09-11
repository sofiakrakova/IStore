using log4net.Appender;
using log4net.Core;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;

namespace IStore.Logging
{
    public class MySqlAppender : AppenderSkeleton
    {
        public string ConnectionString { get; private set; }
        public string Server { get; set; }
        public string Database { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string CommandText { get; set; }

        public override void ActivateOptions()
        {
            base.ActivateOptions();

            DbConnectionStringBuilder sb = new DbConnectionStringBuilder();
            sb.Add("Server", Server);
            sb.Add("Database", Database);
            sb.Add("User Id", UserId);
            sb.Add("Password", Password);

            ConnectionString = sb.ConnectionString;
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(
                    $"INSERT INTO log VALUE(NULL, '{loggingEvent.TimeStamp.ToString("yyyy-MM-dd H:mm:ss")}', '{loggingEvent.Level}', '{loggingEvent.LoggerName}', '{loggingEvent.RenderedMessage}');");
                
                command.Connection = (MySqlConnection)connection;
                command.Connection.Open();
                int affectedRows = command.ExecuteNonQuery();
                command.Connection.Close();
            }
        }
    }
}
