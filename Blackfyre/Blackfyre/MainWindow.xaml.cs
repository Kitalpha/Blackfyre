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
            lvRoles.ItemsSource = AddRoles();
        }

        private void SetupLog4Net()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        private List<Player> AddPlayers()
        {
            List<Player> playersList = new List<Player>();

            for (int i = 1; i <= _totalPlayers; i++)
            {
                playersList.Add(new Player() { Number = i });
            }

            _logger.Info("Created 15 player list.");
            return playersList;
        }

        private List<Role> AddRoles()
        {
            List<Role> rolesList = new List<Role>();

            rolesList.Add(new Role("Jailor", new List<string> { "Jailor" }));
            rolesList.Add(new Role("Town Investigative", new List<string> { "Sheriff", "Investigator", "Lookout", "Spy" }));
            rolesList.Add(new Role("Town Investigative", new List<string> { "Sheriff", "Investigator", "Lookout", "Spy" }));
            rolesList.Add(new Role("Town Support", new List<string> { "Mayor", "Escort", "Medium", "Retributionist", "Transporter" }));
            rolesList.Add(new Role("Town Support", new List<string> { "Mayor", "Escort", "Medium", "Retributionist", "Transporter" }));
            rolesList.Add(new Role("Town Protective", new List<string> { "Bodyguard", "Doctor" }));
            rolesList.Add(new Role("Town Killing", new List<string> { "Veteren", "Vigilante", "Vampire Hunter" }));
            rolesList.Add(new Role("Town Random", new List<string> { "Sheriff", "Investigator", "Lookout", "Spy", "Mayor", "Escort", "Medium", "Retributionist", "Transporter", "Bodyguard", "Doctor", "Veteren", "Vigilante", "Vampire Hunter" }));
            rolesList.Add(new Role("Godfather", new List<string> { "Godfather" }));
            rolesList.Add(new Role("Mafioso", new List<string> { "Mafioso" }));
            rolesList.Add(new Role("Mafia Random", new List<string> { "Blackmailer", "Consigliere", "Consort", "Disguiser", "Janitor", "Framer", "Forger" }));
            rolesList.Add(new Role("Neutral Killing", new List<string> { "Arsonist", "Werewolf", "Seriel Killer" }));
            rolesList.Add(new Role("Neutral Evil", new List<string> { "Witch", "Jester", "Executioner" }));
            rolesList.Add(new Role("Neutral Benign", new List<string> { "Survivor", "Amnesiac" }));
            rolesList.Add(new Role("Any", new List<string> { "Sheriff", "Investigator", "Lookout", "Spy", "Mayor", "Escort", "Medium", "Retributionist", "Transporter", "Bodyguard", "Doctor", "Veteren", "Vigilante", "Vampire Hunter", "Blackmailer", "Consigliere", "Consort", "Disguiser", "Janitor", "Framer", "Forger", "Arsonist", "Werewolf", "Seriel Killer", "Witch", "Jester", "Executioner", "Survivor", "Amnesiac" }));

            return rolesList;
        }
    }
}
