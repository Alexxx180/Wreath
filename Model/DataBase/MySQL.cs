using System;
using System.Collections.Generic;
using System.Data;
using Serilog;
using MySql.Data.MySqlClient;

namespace Wreath.Model.DataBase
{
    /// <summary>
    /// Connection to database via MySQL
    /// </summary>
    public class MySQL : Sql
    {
        private static string ConnectionString;

        public MySQL()
        {
            Con = NewConnection(ConnectionString);
        }

        public static bool TestConnection(string login, string password)
        {
            IsConnected = true;
            Log.Debug("Connecting to DB...");
            MySqlConnection test = EnterConnection(login, password);
            try
            {
                test.Open();
            }
            catch (MySqlException dbException)
            {
                Log.Warning("Tried to connect to DB, no sucess: " + dbException.Message);
                IsConnected = false;
            }
            catch (InvalidOperationException operationException)
            {
                Log.Warning("Tried to connect to DB, no sucess: " + operationException.Message);
                IsConnected = false;
            }
            catch (Exception exception)
            {
                Log.Warning("Tried to connect to DB, no sucess: " + exception.Message);
                IsConnected = false;
            }
            finally
            {
                test.Close();
            }
            return IsConnected;
        }

        public static MySqlConnection NewConnection(string path)
        {
            return new MySqlConnection(path);
        }

        // Server connection
        public static MySqlConnection EnterConnection(
            string login, string password)
        {
            string source = "SERVER=127.0.0.1;";
            string catalog = "DATABASE=prosperity;";
            string user = "UID=" + login + ";";
            string pass = "PASSWORD=" + password + ";";
            ConnectionString = source + catalog + user + pass;
            return NewConnection(ConnectionString);
        }

        public override void Procedure(in string name)
        {
            Cmd = new MySqlCommand(name, Con)
            {
                CommandType = CommandType.StoredProcedure
            };
        }

        public override void OnlyExecute()
        {
            Log.Debug("Executing...");
            try
            {
                Cmd.Connection.Open();
                _ = Cmd.ExecuteNonQuery();
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
                Cmd.Connection.Close();
            }
        }

        public override List<object[]> ReadData()
        {
            Log.Debug("Reading recordset from DB table...");
            List<object[]> table = new List<object[]>();
            try
            {
                Cmd.Connection.Open();
                using (DataReader = Cmd.ExecuteReader())
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
                Cmd.Connection.Close();
            }
            return table;
        }

        public override List<object> ReadData(in int column)
        {
            Log.Debug("Reading column standalone recordset from DB table...");
            List<object> table = new List<object>();
            try
            {
                Cmd.Connection.Open();
                using (DataReader = Cmd.ExecuteReader())
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
                Cmd.Connection.Close();
            }
            return table;
        }

        public override List<object[]> ReadData(in byte StartValue, in byte EndValue)
        {
            Log.Debug("Reading column range recordset from DB table...");
            List<object[]> table = new List<object[]>();
            try
            {
                Cmd.Connection.Open();
                using (DataReader = Cmd.ExecuteReader())
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
                Cmd.Connection.Close();
            }
            return table;
        }

        public override void PassParameter(in string ParamName, in object newParam)
        {
            Dictionary<string, MySqlDbType> types = new Dictionary<string, MySqlDbType>()
            {
                { "Boolean", MySqlDbType.Bit }, { "UInt16", MySqlDbType.UInt16 }, //SqlDbType.SmallInt
                { "Byte", MySqlDbType.UByte }, { "String", MySqlDbType.VarChar }, //MySqlDbType.TinyInt
                { "UInt32", MySqlDbType.UInt32 }, { "UInt64", MySqlDbType.UInt64 }
            };
            Cmd.Parameters.Add(ParamName, types[newParam.GetType().Name]).Value = newParam;
        }

        public override void ClearParameters()
        {
            Cmd.Parameters.Clear();
        }

        private static void MySqlMessage(MySqlException exception, string problem)
        {
            string fullMessage = $"Error: {exception.ErrorCode}\n{exception.HelpLink}\n{exception.Message}";
            Log.Error("Operation was interrupted: " + exception.Message);
            ConnectionMessage(problem, fullMessage);
        }

        public MySqlCommand Cmd { get; set; }
        public MySqlDataReader DataReader { get; set; }
        public MySqlConnection Con { get; set; }
    }
}