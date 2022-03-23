using System.Windows;
namespace Prac1
{
  public partial class MainWindow : Window
  {
      private readonly Logic _logic;

        public MainWindow()
        {
            InitializeComponent();
            _logic = new Logic();
        }

        public void WriteToFile_Click(object sender, RoutedEventArgs e)
        {
            var fName = FNameBox.Text;
            var gName = GNameBox.Text;
            var text = _logic.ReadFromFile(fName);
            var res = _logic.Filter(text, 20);
            _logic.WriteToFile(res, gName);
            MessageBox.Show($"Результат записан в файл '{gName}'");
        }

        public void WriteToArray_Click(object sender, RoutedEventArgs e)
        {
            var fName = FNameBox.Text;
            var text = _logic.ReadFromFile(fName);
            var res = _logic.Filter(text, 20);
            CompResBlock.Text = string.Join("\n", res);
        }
    }
}
