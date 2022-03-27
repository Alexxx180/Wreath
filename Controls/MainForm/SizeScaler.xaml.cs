using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Wreath.Model.Tools;

namespace Wreath.Controls.MainForm
{
    /// <summary>
    /// Size scaler unit
    /// </summary>
    public partial class SizeScaler : UserControl, INotifyPropertyChanged
    {
        private string _tableName;
        public string TableName
        {
            get => _tableName;
            set
            {
                _tableName = value;
                OnPropertyChanged();
            }
        }

        private string _columnName;
        public string ColumnName
        {
            get => _columnName;
            set
            {
                _columnName = value;
                OnPropertyChanged();
            }
        }

        private ISizeScaler.ColumnSizeIncrease _scaleMethod;
        internal ISizeScaler.ColumnSizeIncrease ScaleMethod
        {
            get => _scaleMethod;
            set
            {
                _scaleMethod = value;
                OnPropertyChanged();
            }
        }

        private ISizeScaler.CheckForDefaultSize _checkSizeMethod;
        internal ISizeScaler.CheckForDefaultSize CheckSizeMethod
        {
            get => _checkSizeMethod;
            set
            {
                _checkSizeMethod = value;
                OnPropertyChanged();
            }
        }

        private ushort _defaultSize;

        public SizeScaler()
        {
            InitializeComponent();
        }

        public void SetDefaultSize()
        {
            _defaultSize = Convert.ToUInt16(CheckSizeMethod());
            ColumnSize.Text = _defaultSize.ToString();
        }

        private void SizeInputLostFocus(object sender, RoutedEventArgs e)
        {
            _defaultSize = Convert.ToUInt16(CheckSizeMethod());
            ushort result = Convert.ToUInt16(
                uint.TryParse(ColumnSize.Text, out uint size) ?
                Math.Min(size, 9999) : 0);
            ColumnSize.Text = result.ToString();
            if (result < _defaultSize)
            {
                if (DataTruncateMessage(result))
                {
                    ScaleMethod(result);
                    _defaultSize = result;
                }
                else
                {
                    ColumnSize.Text = _defaultSize.ToString();
                }
            }
            else
            {
                ScaleMethod(result);
                _defaultSize = result;
            }
        }

        public bool DataTruncateMessage(in ushort count)
        {
            string noOperation = "Выставленное значение: " + count;
            string message = "\nНиже изначального: " + _defaultSize;
            string useCount = "\nЭто может повлечь повреждение данных.";
            string confirm = "\nПродолжить?";

            string caption = "Потенциальная потеря данных";
            string fullMessage = noOperation + message + useCount + confirm;
            MessageBoxResult result = MessageBox.Show(fullMessage,
                caption, MessageBoxButton.YesNo, MessageBoxImage.Warning);
            return result == MessageBoxResult.Yes;
        }

        private static readonly Regex _size = new Regex(@"^\d+$");
        private void CheckForSize(object sender, TextCompositionEventArgs e)
        {
            TextBox box = e.OriginalSource as TextBox;
            string full = box.Text.Insert(box.CaretIndex, e.Text);
            e.Handled = !_size.IsMatch(full);
        }

        private static string GetProposedText(TextBox textBox, string newText)
        {
            var text = textBox.Text;
            if (textBox.SelectionStart != -1)
                text = text.Remove(textBox.SelectionStart, textBox.SelectionLength);
            text = text.Insert(textBox.CaretIndex, newText);
            return text;
        }

        private void CheckForPastingSize(object sender, DataObjectPastingEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string pastedText = e.DataObject.GetData(typeof(string)) as string;
                string proposedText = GetProposedText(textBox, pastedText);

                if (!_size.IsMatch(proposedText))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}