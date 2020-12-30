using log4net.Appender;
using log4net.Core;
using MySql.Data.MySqlClient;
using System.Data;
using Dapper;
using System.Data.Common;

namespace IStore.Logging
{
    public class MySqlAppender : AppenderSkeleton
    {
        const string LOG_TABLE = "log";

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
                var query = $@"INSERT INTO {LOG_TABLE} VALUE(NULL, @time, @level, @logger, @message);";
                int affectedRows = connection.Execute(query,
                    new
                    {
                        time = loggingEvent.TimeStamp,
                        level = loggingEvent.Level.DisplayName,
                        logger = loggingEvent.LoggerName,
                        message = loggingEvent.RenderedMessage
                    });
            }
        }
    }
}
