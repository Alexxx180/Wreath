using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Wreath.Model;

namespace Wreath.Controls.FieldsForm
{
    /// <summary>
    /// Part responsible for record choosing
    /// </summary>
    public partial class MainPart : UserControl, INotifyPropertyChanged
    {
        private string _fullText;
        public string FullText
        {
            get => _fullText ?? "";
            set
            {
                _fullText = value;
                OnPropertyChanged();
            }
        }

        public MainPart()
        {
            InitializeComponent();
        }

        public void SeparateTopics(params Pair<string, string>[] row)
        {
            for (byte i = 0; i < row.Length; i++)
            {
                Pair<string, string> field = row[i];
                SeparateTopic(field.Name, field.Value);
            }
        }

        public void SeparateTopic(string name, string value)
        {
            TextSection topic = new TextSection(name, value);
            topic.SetTextLabel(this);
            _ = Sections.Children.Add(topic);
        }

        private void CopyText(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(FullText);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}