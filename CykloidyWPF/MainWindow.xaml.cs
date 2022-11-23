using Cykloidy;
using Domain.Basic.Implementations;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp1
{

    public partial class MainWindow : Window
    {
        ISimManager simManager;
        public MainWindow()
        {
            InitializeComponent();

            simManager = new BasicSimManager(
                DrawingCanvas,
                new Domain.Primitives.Implementations.Vector2(5, 5),
                new Domain.Primitives.Implementations.Circle(new Domain.Primitives.Implementations.Vector2(50, 50), 50)
            );
            btnCreate.Click += (object sender, RoutedEventArgs e) =>
            {
                simManager.DrawSetup();
                simManager.DrawScenery();
            };
            btnRun.Click += (object sender, RoutedEventArgs e) =>
            {
                simManager.Start();
            };
        }

    }
}
