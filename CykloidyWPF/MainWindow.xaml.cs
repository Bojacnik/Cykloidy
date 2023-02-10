using CykloidyWPF;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp1
{

    public partial class MainWindow : Window
    {
        Canvas canvas;
        public MainWindow()
        {
            InitializeComponent();
            this.canvas = DrawingCanvas;
        }

        DispatcherTimer gameTimer = new DispatcherTimer(DispatcherPriority.Render);



        private void btnCreate_onClick(object sender, RoutedEventArgs e)
        {
            List<PointD> list = SpocitejBodyNaCykloide();

            for (int i = 0; i < list.Count - 1; i++)
            {
                PointD p = list[i];
                canvas.Children.Add(createPoint(p.X + 10 * i, p.Y, 5, Brushes.Red, Brushes.Black));
            }
        }
        private void btnRun_onClick(object sender, RoutedEventArgs e)
        {

        }
        private List<PointD> SpocitejBodyNaCykloide()
        {
            List<PointD> points = new List<PointD>();

            double step = 360 / canvas.ActualWidth;
            uint stepsTaken = 0;
            btnRun.IsEnabled = true;

            double a = Convert.ToDouble(tbRadius.Text);
            double x, y;

            while (stepsTaken < 360)
            {
                x = step * a * ((stepsTaken / 100) - Math.Sin(stepsTaken));
                y = step * a * (1 - Math.Cos(stepsTaken));
                points.Add(new PointD(x, y));
                stepsTaken++;
            }

            return points;
        }

        private Ellipse createPoint(double x, double y, double radius, Brush? stroke, Brush? fill)
        {
            stroke ??= Brushes.Red;
            fill ??= Brushes.Red;
            Ellipse el = new()
            {
                Width = radius * 2,
                Height = radius * 2,
                StrokeThickness = 1,
                Stroke = stroke,
                Fill = fill,
            };
            var transform = el.RenderTransform as TranslateTransform ?? new TranslateTransform();
            transform.X = x - radius;
            transform.Y = y - radius;
            el.RenderTransform = transform;
            return el;
        }
        private bool IsUserVisible(FrameworkElement element, FrameworkElement container)
        {
            if (!element.IsVisible)
                return false;

            Rect bounds = element.TransformToAncestor(container).TransformBounds(new Rect(0.0, 0.0, element.ActualWidth, element.ActualHeight));
            Rect rect = new Rect(0.0, 0.0, container.ActualWidth, container.ActualHeight);
            return rect.Contains(bounds.TopLeft) || rect.Contains(bounds.BottomRight);
        }
    }
}
