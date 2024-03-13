using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Enumeration;


namespace Grafika_IT2
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private Board board;

    public MainWindow()
    {
      InitializeComponent();
      board = new Board();
    }

    private void canvasBoard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      board.Add(e.GetPosition(canvasBoard));
      board.Draw(canvasBoard);
    }

    private void ButtonOpen_Click(object sender, RoutedEventArgs e)
    {
            try
            {
                var openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "CSV Files (*.csv)|*.csv|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == true)
                {
                    var text = File.ReadAllText(openFileDialog.FileName);
                    board.FromString(text);
                    board.Draw(canvasBoard);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Soubor nebyl otevřen:\r\n" + ex.Message);
            }


            //var text = File.ReadAllText("data.csv");
            //board.FromString(cestaKSouboru);
            //board.Draw(canvasBoard);
        }

    private void ButtonSave_Click(object sender, RoutedEventArgs e)
    {
            try
            {
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV Files (*.csv)|*.csv|All files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, board.ToString());
                    MessageBox.Show("Soubor byl uložen.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Soubor nebyl uložen z důvodu chyby:\r\n" + ex.Message);
            }
    }

    private void ButtonClear_Click(object sender, RoutedEventArgs e)
    {
      board.Clear();
      board.Draw(canvasBoard);
    }


  }
}
