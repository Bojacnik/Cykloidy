using CykloidyWPF;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Linq;

namespace WpfApp1
{

    public partial class MainWindow : Window
    {
        readonly Canvas canvas;
        public MainWindow()
        {
            InitializeComponent();

            var brushProperties = typeof(Brushes).GetProperties();

            // Add the available Brush names to the ComboBox
            foreach (var brushProperty in brushProperties)
            {
                cbStrokeColor.Items.Add(brushProperty.Name);
                cbCycloidColor.Items.Add(brushProperty.Name);
            }
            cbStrokeColor.SelectedIndex = 27;
            cbCycloidColor.SelectedIndex = 113;
            this.canvas = DrawingCanvas;
        }

        DispatcherTimer? gameTimer;

        CycloidCircle circle;
        CycloidCircle cycloid;

        TranslateTransform? tt;
        TranslateTransform? tc;
        Line? lajn;
        Ellipse? cyc;
        private void btnCreate_onClick(object sender, RoutedEventArgs e)
        {
            ConvertValues();
            tt = new()
            {
                X = circle.X,
                Y = circle.Y,
            };
            Ellipse ell = new()
            {
                Width = circle.Width,
                Height = circle.Height,
                Fill = circle.FillBrush,
                Stroke = circle.StrokeBrush,
                StrokeThickness = circle.StrokeThickness,
                RenderTransform = tt,
            };
            canvas.Children.Add(ell);
            tc = new()
            {
                X = cycloid.X,
                Y = cycloid.Y,
            };
            cyc = new()
            {
                Width = cycloid.Width,
                Height = cycloid.Height,
                Fill = cycloid.FillBrush,
                Stroke = cycloid.StrokeBrush,
                StrokeThickness = cycloid.StrokeThickness,
                RenderTransform = tc,
            };
            canvas.Children.Add(cyc);
            lajn = new()
            {
                X1 = circle.xOffset,
                Y1 = circle.yOffset,

                X2 = tc.X + cycloid.Radius,
                Y2 = tc.Y + cycloid.Radius,

                Stroke = Brushes.Orange,

            };
            canvas.Children.Add(lajn);
            btnCreate.IsEnabled = false;
            btnRun.IsEnabled = true;
            btnClear.IsEnabled = true;
        }
        private void btnRun_onClick(object sender, RoutedEventArgs e)
        {
            gameTimer = new DispatcherTimer(DispatcherPriority.Render);
            gameTimer.Tick += (object? sender, EventArgs e) =>
            {
                canvas.Children.Add(new Ellipse()
                {
                    Width = cycloid.Width,
                    Height = cycloid.Height,
                    Fill = cycloid.FillBrush,
                    Stroke = cycloid.StrokeBrush,
                    StrokeThickness = cycloid.StrokeThickness,
                    RenderTransform = tc.Clone(),
                });

                circle.Update();
                tt.X = circle.X;

                cycloid.Update();
                tc.X = cycloid.X;
                tc.Y = cycloid.Y;

                lajn.X1 = tt.X + circle.Radius;
                lajn.Y1 = tt.Y + circle.Radius;

                lajn.X2 = tc.X + cycloid.Radius;
                lajn.Y2 = tc.Y + cycloid.Radius;
            };
            gameTimer.Interval = TimeSpan.FromMilliseconds(2);
            gameTimer.Start();
            btnCreate.IsEnabled = false;
            btnRun.IsEnabled = false;
            btnClear.IsEnabled = true;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            gameTimer?.Stop();
            canvas.Children.Clear();
            btnCreate.IsEnabled = true;
            btnRun.IsEnabled = false;
            btnClear.IsEnabled = false;
        }

        private void ConvertValues()
        {
            double xOffset = Convert.ToInt32(tbX.Text);
            double yOffset = Convert.ToInt32(tbY.Text);
            double radius = Convert.ToDouble(tbRadius.Text);
            double radiusC = Convert.ToDouble(tbRadiusC.Text);
            const double angle = 0;
            double angleDifference = Convert.ToDouble(tbAngleDiff.Text);
            double strokeThickness = Convert.ToDouble(tbStrokeThickness.Text);
            double cycloidOffset = Convert.ToDouble(tbOffset.Text);
            BrushConverter bc = new BrushConverter();
            Brush circleStrokeColor = (Brush)bc.ConvertFromString(cbStrokeColor.Text);
            Brush cycloidColor = (Brush)bc.ConvertFromString(cbCycloidColor.Text);

            circle = new CycloidCircle(
                xOffset - radius,
                yOffset - radius,
                xOffset, yOffset,
                radius,
                angle, angleDifference,
                strokeThickness,
                circleStrokeColor, null,
                null);
            cycloid = new CycloidCircle(
                xOffset - radiusC + Math.Cos(angle) * (radius + Math.Abs(cycloidOffset)),
                yOffset - radiusC + Math.Sin(-angle) * (radius + Math.Abs(cycloidOffset)),
                cycloidOffset, cycloidOffset,
                radiusC,
                angle, angleDifference,
                strokeThickness,
                cycloidColor, cycloidColor,
                circle);
        }
        private static bool IsUserVisible(FrameworkElement element, FrameworkElement container)
        {
            if (!element.IsVisible)
                return false;

            Rect bounds = element.TransformToAncestor(container).TransformBounds(new Rect(0.0, 0.0, element.ActualWidth, element.ActualHeight));
            Rect rect = new Rect(0.0, 0.0, container.ActualWidth, container.ActualHeight);
            return rect.Contains(bounds.TopLeft) || rect.Contains(bounds.BottomRight);
        }
    }
}
