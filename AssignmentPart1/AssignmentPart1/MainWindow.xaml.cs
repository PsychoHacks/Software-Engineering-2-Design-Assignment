﻿using System;
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

namespace AssignmentPart1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Team> teamDisplay = new List<Team>();
        public List<Player> PlayerDisplay = new List<Player>();
        public List<Player> FilteredPlayerDisplay = new List<Player>();

        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Team t1 = new Team() { TeamName = "Heart", GoalDifference = 9, Points = 6 };
            Team t2 = new Team() { TeamName = "ManU", GoalDifference = 4, Points = 2435 };
            Team t3 = new Team() { TeamName = "Live", GoalDifference = 89, Points = 34 };
            Team t4 = new Team() { TeamName = "Arse", GoalDifference = 420, Points = 987234 };

            Player p1 = new Player() { PlayerSurname = "Gerrard", PlayerNationality = "English", ShirtNumber = "9", TeamName = "Live" };
            Player p2 = new Player() { PlayerSurname = "Ibrah", PlayerNationality = "Sweedish", ShirtNumber = "7", TeamName = "ManU" };
            Player p3 = new Player() { PlayerSurname = "Sanchez", PlayerNationality = "Chilean", ShirtNumber = "7", TeamName = "Arse" };
            Player p4 = new Player() { PlayerSurname = "Coutinho", PlayerNationality = "Brazilean", ShirtNumber = "8", TeamName = "Heart" };

            teamDisplay.Add(t1);
            teamDisplay.Add(t2);
            teamDisplay.Add(t3);
            teamDisplay.Add(t4);

            PlayerDisplay.Add(p1);
            PlayerDisplay.Add(p2);
            PlayerDisplay.Add(p3);
            PlayerDisplay.Add(p4);

            lbxDisplay.ItemsSource = teamDisplay;
            listBox_Players.ItemsSource = PlayerDisplay;
        }

        private void btnAddTeam_Click(object sender, RoutedEventArgs e)
        {
            lbxDisplay.ItemsSource = "";

            teamDisplay.Add(new Team() { TeamName = tbxTeamName.Text, GoalDifference = int.Parse(tbxGoalDifference.Text), Points = int.Parse(tbxClubPoints.Text) });

            lbxDisplay.ItemsSource = teamDisplay;
        }

        private void lbxDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Team selectedTeam = lbxDisplay.SelectedItem as Team;
            FilteredPlayerDisplay.Clear();

            foreach (var FiltPlayer in PlayerDisplay)
            {
                // Player s1 = new Player() { PlayerSurname = FiltPlayer.PlayerSurname, PlayerNationality = FiltPlayer.PlayerNationality, ShirtNumber = FiltPlayer.ShirtNumber, TeamName = FiltPlayer.TeamName };

                if (selectedTeam.TeamName == FiltPlayer.TeamName)
                {
                    FilteredPlayerDisplay.Add(new Player() { PlayerSurname = FiltPlayer.PlayerSurname, PlayerNationality = FiltPlayer.PlayerNationality, ShirtNumber = FiltPlayer.ShirtNumber, TeamName = FiltPlayer.TeamName });
                }
            }
            listBox_Players.ItemsSource = "";
            listBox_Players.ItemsSource = FilteredPlayerDisplay;


        }
    }
}
