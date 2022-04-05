using System;
using System.Collections.Generic;
using System.Data;
using Serilog;
using MySqlConnector;
using static Wreath.Writers.Processors;
using static Wreath.Model.Tools.Security.Encryption;

namespace Wreath.Model.Tools.DataBase
{
    /// <summary>
    /// Connection to database via MySQL
    /// </summary>
    public class MySQL : Sql
    {
        private string _dataBaseName;
        private string _hostName;

        public MySQL()
        {
            ResetConfiguration();
        }

        #region Configuration Members
        internal override void SetConfiguration
            (in string dataBase, in string host)
        {
            _dataBaseName = dataBase;
            _hostName = host;
        }

        private void ResetConfiguration()
        {
            Pair<string, string> config = LoadRuntime<string>("Config.json");
            SetConfiguration(config.Name, config.Value);
        }

        internal void NewConfiguration(string host, string dbName)
        {
            SaveRuntime("Config.json",
                new Pair<string, string>
                (host, dbName));
            ResetConfiguration();
        }

        private void LoginMemory(string login, string pass)
        {
            SaveRuntime("Data.json",
                new Pair<string, byte[]>
                (login, ProtectData(pass)));
        }
        #endregion

        #region Connection Members
        private bool FileConnection()
        {
            Pair<string, byte[]>
                initials = LoadRuntime<byte[]>("Data.json");

            bool connectionSuccessful =
                !(initials is null ||
                (initials.Name is null) ||
                (initials.Value is null))
                && TestConnection(
                    initials.Name,
                    UnprotectData(initials.Value)
                );

            return connectionSuccessful;
        }

        internal override bool Connect()
        {
            if (FileConnection())
                return true;

            bool userAgreement, connectionSuccessful = false;
            EntryWindow entry;

            do
            {
                entry = new EntryWindow();
                userAgreement = entry.ShowDialog().Value;

                if (entry.NewConfig)
                {
                    NewConfiguration(entry.Login, entry.Pass);
                    entry = new EntryWindow();
                    continue;
                }

                if (!userAgreement)
                {
                    IndependentMode = true;
                    break;
                }

                connectionSuccessful =
                    TestConnection
                    (entry.Login, entry.Pass);
            }
            while (!connectionSuccessful);

            if (entry.MemberMe)
            {
                LoginMemory(entry.Login, entry.Pass);
            }

            return connectionSuccessful;
        }
        #endregion

        #region Connecting Members
        private static void ConnectionFault(string message)
        {
            Log.Warning("Tried to connect to DB, no sucess: " + message);
        }

        private static MySqlConnection NewConnection(string path)
        {
            return new MySqlConnection(path);
        }

        // Server connection
        private MySqlConnection EnterConnection
            (string login, string password)
        {
            Log.Debug("Connecting to DB...");
            string source = "SERVER=" + _hostName + ";";
            string catalog = "DATABASE=" + _dataBaseName + ";";
            string user = "UID=" + login + ";";
            string pass = "PASSWORD=" + password + ";";
            return NewConnection(source + catalog + user + pass);
        }

        public override bool TestConnection
            (in string login, in string password)
        {
            MySqlConnection test = EnterConnection(login, password);
            try
            {
                test.Open();
                _connection = test;
            }
            catch (MySqlException dbException)
            {
                ConnectionFault("configuration is not correct" +
                    dbException.HelpLink);
            }
            catch (InvalidOperationException operationException)
            {
                ConnectionFault(operationException.Message);
            }
            catch (Exception exception)
            {
                ConnectionFault(exception.Message);
            }
            finally
            {
                test.Close();
            }
            return _connection is not null;
        }
        #endregion

        public override void Procedure(in string name)
        {
            Command = new MySqlCommand(name, _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
        }

        #region ProcedureExecuteOnly Members
        public override void OnlyExecute()
        {
            Log.Debug("Executing...");
            try
            {
                Command.Connection.Open();
                _ = Command.ExecuteNonQuery();
            }
            catch (MySqlException dbException)
            {
                MySqlMessage(dbException, "выборочные данные в источнике");
            }
            catch (InvalidOperationException operationException)
            {
                NetMessage(operationException, "неподдерживаемая операция");
            }
            catch (Exception exception)
            {
                NetMessage(exception, "программный сбой");
            }
            finally
            {
                Command.Connection.Close();
            }
        }
        #endregion

        #region ReadRecords Members
        public override object ReadScalar()
        {
            Log.Debug("Reading aggregate value from DB table...");
            object field = null;
            try
            {
                Command.Connection.Open();
                field = Command.ExecuteScalar();
            }
            catch (MySqlException dbException)
            {
                MySqlMessage(dbException, "агрегатное значение из источника");
            }
            catch (InvalidOperationException operationException)
            {
                NetMessage(operationException, "неподдерживаемая операция");
            }
            catch (Exception exception)
            {
                NetMessage(exception, "программный сбой");
            }
            finally
            {
                Command.Connection.Close();
            }
            return field;
        }

        public override List<object> ReadData(in int column)
        {
            Log.Debug("Reading column standalone recordset from DB table...");
            List<object> table = new List<object>();
            try
            {
                Command.Connection.Open();
                using (DataReader = Command.ExecuteReader())
                {
                    if (DataReader.HasRows)
                        while (DataReader.Read())
                        {
                            object cell = DataReader.GetValue(column);
                            table.Add(cell);
                        }
                }
            }
            catch (MySqlException dbException)
            {
                MySqlMessage(dbException, "выборочные данные из источника");
            }
            catch (InvalidOperationException operationException)
            {
                NetMessage(operationException, "неподдерживаемая операция");
            }
            catch (Exception exception)
            {
                NetMessage(exception, "программный сбой");
            }
            finally
            {
                Command.Connection.Close();
            }
            return table;
        }

        public override List<object[]> ReadData()
        {
            Log.Debug("Reading recordset from DB table...");
            List<object[]> table = new List<object[]>();
            try
            {
                Command.Connection.Open();
                using (DataReader = Command.ExecuteReader())
                {
                    if (DataReader.HasRows)
                        while (DataReader.Read())
                        {
                            object[] row = new object[DataReader.FieldCount];
                            for (int i = 0; i < DataReader.FieldCount; i++)
                                row[i] = DataReader.GetValue(i);
                            table.Add(row);
                        }
                }
            }
            catch (MySqlException dbException)
            {
                MySqlMessage(dbException, "полные данные из источника");
            }
            catch (InvalidOperationException operationException)
            {
                NetMessage(operationException, "неподдерживаемая операция");
            }
            catch (Exception exception)
            {
                NetMessage(exception, "программный сбой");
            }
            finally
            {
                Command.Connection.Close();
            }
            return table;
        }

        public override List<object[]> ReadData(in byte StartValue, in byte EndValue)
        {
            Log.Debug("Reading column range recordset from DB table...");
            List<object[]> table = new List<object[]>();
            try
            {
                Command.Connection.Open();
                using (DataReader = Command.ExecuteReader())
                {
                    int count = EndValue - StartValue;
                    if (DataReader.HasRows)
                        while (DataReader.Read())
                        {
                            object[] row = new object[count];
                            for (int i = 0, j = StartValue; j < EndValue; i++, j++)
                                row[i] = DataReader.GetValue(j);
                            table.Add(row);
                        }
                }
            }
            catch(MySqlException dbException)
            {
                MySqlMessage(dbException, "выборочные данные из источника");
            }
            catch (InvalidOperationException operationException)
            {
                NetMessage(operationException, "неподдерживаемая операция");
            }
            catch (Exception exception)
            {
                NetMessage(exception, "программный сбой");
            }
            finally
            {
                Command.Connection.Close();
            }
            return table;
        }
        #endregion

        #region WorkWithParameters Members
        public override void PassParameter(in string ParamName, in object newParam)
        {
            Dictionary<string, MySqlDbType> types = new Dictionary<string, MySqlDbType>()
            {
                { "Boolean", MySqlDbType.Bit }, { "UInt16", MySqlDbType.UInt16 },
                { "Byte", MySqlDbType.UByte }, { "String", MySqlDbType.VarChar },
                { "UInt32", MySqlDbType.UInt32 }, { "UInt64", MySqlDbType.UInt64 }
            };
            Command.Parameters.Add(ParamName, types[newParam.GetType().Name]).Value = newParam;
        }

        public override void ClearParameters()
        {
            Command.Parameters.Clear();
        }
        #endregion

        public MySqlCommand Command { get; set; }
        public MySqlDataReader DataReader { get; set; }
        private MySqlConnection _connection { get; set; }

        #region Message Members
        private static void MySqlMessage(MySqlException exception, string problem)
        {
            string fullMessage = $"Error: {exception.ErrorCode}\n{exception.HelpLink}\n{exception.Message}";
            Log.Error("Operation was interrupted: " + exception.Message);
            ConnectionMessage(problem, fullMessage);
        }
        #endregion
    }
}