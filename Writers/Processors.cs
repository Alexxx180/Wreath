using System;
using System.IO;
using System.Text.Json;
using System.Windows;
using Microsoft.Win32;
using Serilog;
using Wreath.Model;

namespace Wreath.Writers
{
    public static class Processors
    {
        public static string
            ConfigDirectory => Environment.CurrentDirectory + @"\Resources\Configuration\";
        private static string RuntimeDirectory => ConfigDirectory + @"Runtime\";

        static Processors()
        {
            Log.Debug(
                "Configuration directory set as: "
                + ConfigDirectory
                );
        }

        #region Messages Members
        private static void SaveMessage(string exception)
        {
            string noLoad = "Не удалось сохранить файл.";
            string message = "\nУбедитесь, что посторонние процессы не мешают операции.\n";
            string advice = "Свяжитесь с администратором насчет установления причины проблемы.\nПолное сообщение:\n";
            _ = MessageBox.Show(noLoad + message + advice + exception);
        }

        internal static void LoadMessage(string exception)
        {
            string noLoad = "Сбой загрузки.";
            string message = "\nУбедитесь, что файлы не повреждены или отсутствуют в целевой директории.\n";
            string advice = "Свяжитесь с администратором насчет установления причины проблемы.\nПолное сообщение:\n";
            _ = MessageBox.Show(noLoad + message + advice + exception);
        }

        internal static void WriteMessage(string exception)
        {
            string message = "Файл открыт в другой " +
                    "программе или используется другим " +
                    "процессом. Дальнейшая запись в файл" +
                    " невозможна.\nПолное сообщение:\n";
            _ = MessageBox.Show(message + exception);
        }
        #endregion

        #region Dialogs Members
        public static OpenFileDialog
            CallManager(string filter, string fileName)
        {
            return new OpenFileDialog
            {
                FileName = fileName,
                Filter = filter
            };
        }

        public static SaveFileDialog
            CallWriter(string filter, string fileName)
        {
            return new SaveFileDialog
            {
                FileName = fileName,
                Filter = filter
            };
        }
        #endregion

        internal static void TruncateFile(string fileName)
        {
            Log.Information("Truncating file: " + fileName);
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        public static void Save(string path, byte[] bytes)
        {
            Log.Information("Saving data... to: " + path);
            try
            {
                File.WriteAllBytes(path, bytes);
            }
            catch (IOException exception)
            {
                Log.Error("Save problem: " +
                    exception.Message);
                SaveMessage(exception.Message);
            }
        }

        public static T ReadJson<T>(string path)
        {
            Log.Information("Reading user data from: " + path);
            T deserilizeable = default;
            try
            {
                byte[] fileBytes = File.ReadAllBytes(path);
                Utf8JsonReader utf8Reader = new Utf8JsonReader(fileBytes);
                deserilizeable = JsonSerializer.Deserialize<T>(ref utf8Reader);
            }
            catch (JsonException exception)
            {
                Log.Error("Reading user data Json problem: " +
                    exception.Message);
                LoadMessage(exception.Message);
            }
            catch (ArgumentException exception)
            {
                Log.Error("Argument is invalid: " +
                    exception.Message);
                LoadMessage(exception.Message);
            }
            catch (FileNotFoundException exception)
            {
                Log.Error("File not found: " +
                    exception.Message);
                LoadMessage(exception.Message);
            }
            catch (IOException exception)
            {
                Log.Error("I|O blocked by another process: " +
                    exception.Message);
                LoadMessage(exception.Message);
            }
            return deserilizeable;
        }

        private static void ProcessJsonAny<T>(string path, T serilizeable)
        {
            try
            {
                TruncateFile(path);
                byte[] jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(serilizeable);
                File.WriteAllBytes(path, jsonUtf8Bytes);
            }
            catch (IOException exception)
            {
                Log.Error("I|O blocked can't process: " +
                    exception.Message);
                LoadMessage(exception.Message);
            }
        }

        #region SaveLoad Members
        internal static T LoadConfig<T>(string name)
        {
            Log.Debug("Loading config: " + RuntimeDirectory + name);
            return !File.Exists(ConfigDirectory + name) ?
                default : ReadJson<T>(ConfigDirectory + name);
        }

        internal static void SaveConfig<T>(string name, T config)
        {
            ProcessJsonAny(ConfigDirectory + name, config);
        }

        internal static
            Pair<string, T> LoadRuntime<T>(string name)
        {
            Log.Debug("Loading runtime: " + RuntimeDirectory + name);
            return !File.Exists(RuntimeDirectory + name) ? null :
                ReadJson<Pair<string, T>>(RuntimeDirectory + name);
        }

        internal static void SaveRuntime<T>
            (string name, Pair<string, T> data)
        {
            ProcessJsonAny(RuntimeDirectory + name, data);
        }
        #endregion
    }
}