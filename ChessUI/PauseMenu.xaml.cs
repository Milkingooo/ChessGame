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

namespace ChessUI
{
    /// <summary>
    /// Логика взаимодействия для PauseMenu.xaml
    /// </summary>
    public partial class PauseMenu : UserControl
    {
        public event Action<Option> OptionSelected;
        public PauseMenu()
        {
            InitializeComponent();
        }

        private void Continue_Clik(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Contune);
        }

        private void Reatart_Clik(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Restart);
        }
    }
}
