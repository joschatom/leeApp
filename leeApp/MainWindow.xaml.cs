using System;
using System.Collections.Generic;
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
using System.Diagnostics;
using leeApp;
using Microsoft.Win32;

namespace leeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StackPanel StartMenu = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LeeGame_Click(object sender, RoutedEventArgs e)
        {
            State res = StartGame();
            MessageBox.Show("Return of Lee-Game: \"" + res + "\"", "Lee-Game", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private State StartGame()
        {
            startmenu.Height = 0;
            startmenu.Width = 0;
            startmenu.Visibility = Visibility.Hidden;
            startmenu.Background = Brushes.Transparent;
            Title = "Lee - Game";
            root.Children.Add(new LeeGame());
            if (((LeeGame)root.Children[1]).ReturnCode == 0) {
                return State.Finisch;
            }
            return State.Error;
        }

        enum State
        {
            Finisch,
            Error,
            RunTime,
            GUIError,
            ProcError
        }

        private void menubtn_quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
