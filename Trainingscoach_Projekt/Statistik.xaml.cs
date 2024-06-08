﻿using LiveCharts.Wpf;
using LiveCharts;
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
using System.Windows.Shapes;

namespace Trainingscoach_Projekt
{
    /// <summary>
    /// Interaction logic for Statistik.xaml
    /// </summary>
    public partial class Statistik : Window
    {
        public HauptprogrammTimer timerArm = ArmTrainingsFenster.timer;
        public HauptprogrammTimer timerBauch = BauchTrainingsFenster.timer;

        public Statistik()
        {
            InitializeComponent();

            double armdauer = 0;
            double beindauer = 0;
            double bauchdauer = 0;
            double brustdauer = 0;
            double rueckendauer = 0;
            double ganzkörperdauer = 0;
            double cardiodauer = 0;

            if (timerArm != null && timerArm.derzeitigeGrundEinheitTextBox != null)
            {
                if (timerArm.derzeitigeGrundEinheitTextBox.Text == "Armtraining")
                {
                    foreach (double zahl in timerArm.dauerListe)
                    {
                        armdauer += zahl;
                    }
                }
            }

            if (timerBauch != null && timerBauch.derzeitigeGrundEinheitTextBox != null)
            {
                if (timerBauch.derzeitigeGrundEinheitTextBox.Text == "Bauchtraining")
                {
                    foreach (double zahl in timerBauch.dauerListe)
                    {
                        bauchdauer += zahl;
                    }
                }
            }

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Trainingsdauer",
                    Values = new ChartValues<double> { armdauer, beindauer, bauchdauer, brustdauer, rueckendauer, ganzkörperdauer, cardiodauer },
                }
            };

            Labels = new[] { "Armtraining", "Beintraining", "Bauchtraining", "Brusttraining", "Rückentraining", "Ganzkörpertraining", "Cardiotraining" };
            Formatter = value => value.ToString("N");

            this.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF383838"));
            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
    }
}
