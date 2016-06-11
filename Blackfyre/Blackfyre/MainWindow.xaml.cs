using System;
using System.Collections.Generic;
using System.Configuration;
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
using log4net;
using log4net.Config;
using Blackfyre.Models;

namespace Blackfyre
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(MainWindow));
        private readonly int _totalPlayers = int.Parse(ConfigurationManager.AppSettings["totalPlayers"]);

        public MainWindow()
        {
            SetupLog4Net();

            InitializeComponent();
            lvPlayers.ItemsSource = AddPlayers();
        }

        private void SetupLog4Net()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        private List<Player> AddPlayers()
        {
            List<Player> playersList = new List<Player>();

            for (int i = 0; i <= _totalPlayers; i++)
            {
                playersList.Add(new Player() { Number = i });
            }

            _logger.Info("Created 15 player list.");
            return playersList;
        }
    }
}
