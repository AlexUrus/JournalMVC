using Microsoft.Data.SqlClient;
using System.Data;

namespace JournalMVC.Repositories.ADO
{
    public class BaseRepository
    {
        public event EventHandler? ConnectionStateChanged;

        public ConnectionState ConnectionState
        {
            get => connectionState;
            protected set
            {
                if (connectionState != value)
                {
                    connectionState = value;
                    ConnectionStateChanged?.Invoke(this, null);
                }
            }
        }

        public string? ConnectionString { get; set; }

        ConnectionState connectionState = ConnectionState.Closed;
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        readonly object lockObject = new object();
        public BaseRepository()
        {
            SqlConnection.StateChange += OnSqlConnectionStateChange;
            ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=JournalMVC;Trusted_Connection=True;";
            Seed();
        }

        public void OnSqlConnectionStateChange(object sender, StateChangeEventArgs e)
        {
            ConnectionState = e.CurrentState;
        }

        public bool Connect()
        {
            if (ConnectionState == ConnectionState.Open) { return true; }
            if (ConnectionString == null) { throw new InvalidOperationException("ConnectionString not set"); }
            try
            {
                SqlConnection.ConnectionString = ConnectionString;
                SqlConnection.Open();
                ConnectionState = ConnectionState.Open;
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Close()
        {
            if (ConnectionState == ConnectionState.Closed) { return; }
            SqlConnection.Close();
            ConnectionState = ConnectionState.Closed;
        }

        public DataTable? ExecuteQuery(string cmdText)
        {
            lock (lockObject)
            {
                if (ConnectionState == ConnectionState.Closed || SqlConnection.State != ConnectionState.Open)
                {
                    if (!Connect())
                    {
                        return null;
                    }
                }
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, SqlConnection))
                {
                    adapter.SelectCommand.CommandTimeout = 300;
                    DataTable table = new DataTable();
                    try
                    {
                        adapter.Fill(table);
                        return table;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
        }
        public async Task<DataTable?> ExecuteQueryAsync(string cmdText)
        {
            lock (lockObject)
            {
                if (ConnectionState == ConnectionState.Closed || SqlConnection.State != ConnectionState.Open)
                {
                    if (!Connect())
                    {
                        return null;
                    }
                }
            }

            using (SqlCommand command = new SqlCommand(cmdText, SqlConnection))
            {
                command.CommandTimeout = 300;

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable table = new DataTable();
                    try
                    {
                        await Task.Run(() => adapter.Fill(table));
                        return table;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
        }
        public bool ExecuteNonQuery(string cmdText, List<SqlParameter>? _params = null)
        {
            lock (lockObject)
            {
                if (ConnectionState == ConnectionState.Closed || SqlConnection.State != ConnectionState.Open)
                {
                    if (!Connect())
                    {
                        return false;
                    }
                }

                try
                {
                    using (var cmd = SqlConnection.CreateCommand())
                    {
                        using (var transaction = SqlConnection.BeginTransaction("Transaction non query"))
                        {
                            cmd.CommandText = cmdText;
                            cmd.Transaction = transaction;
                            cmd.CommandTimeout = 60;

                            try
                            {
                                if (_params != null) { cmd.Parameters.AddRange(_params.ToArray()); }
                                cmd.ExecuteNonQuery();
                                transaction.Commit();
                                return true;
                            }
                            catch (Exception)
                            {
                                try
                                {
                                    transaction.Rollback();
                                }
                                catch (Exception)
                                {

                                }
                                return false;
                            }
                        }
                    }
                }
                catch (Exception) 
                { 
                    return false;
                }
            }
        }
        public async Task<bool> ExecuteNonQueryAsync(string cmdText, List<SqlParameter>? _params = null)
        {
            lock (lockObject)
            {
                if (ConnectionState == ConnectionState.Closed || SqlConnection.State != ConnectionState.Open)
                {
                    if (!Connect())
                    {
                        return false;
                    }
                }
            }

            try
            {
                using (var cmd = SqlConnection.CreateCommand())
                {
                    using (var transaction = await SqlConnection.BeginTransactionAsync())
                    {
                        cmd.CommandText = cmdText;
                        cmd.Transaction = (SqlTransaction)transaction;
                        cmd.CommandTimeout = 60;

                        try
                        {
                            if (_params != null)
                            {
                                cmd.Parameters.AddRange(_params.ToArray());
                            }
                            await cmd.ExecuteNonQueryAsync();
                            await transaction.CommitAsync();
                            return true;
                        }
                        catch (Exception)
                        {
                            try
                            {
                                await transaction.RollbackAsync();
                            }
                            catch (Exception)
                            {
                            }
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Seed()
        {
            string cmd = @"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TypeActivities]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE TypeActivities (
                        Id INT PRIMARY KEY IDENTITY(1,1),
                        Name NVARCHAR(100) NOT NULL
                    );
                END

                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TimeIntervals]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE TimeIntervals (
                        Id INT PRIMARY KEY IDENTITY(1,1),
                        StartActivity TIME NOT NULL,
                        EndActivity TIME NOT NULL
                    );
                END

                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Activities]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE Activities (
                        Id INT PRIMARY KEY IDENTITY(1,1),
                        TypeId INT NOT NULL,
                        TimeIntervalId INT NOT NULL,
                        Description NVARCHAR(MAX),
                        FOREIGN KEY (TypeId) REFERENCES TypeActivities(Id),
                        FOREIGN KEY (TimeIntervalId) REFERENCES TimeIntervals(Id)
                    );
                END
            ";

            ExecuteNonQuery(cmd);
        }
    }
}
