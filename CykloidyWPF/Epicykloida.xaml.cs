using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp1
{

    public partial class Epicykloida : Window
    {
        readonly Canvas canvas;
        public Epicykloida()
        {
            InitializeComponent();
            this.canvas = DrawingCanvas;
        }

        DispatcherTimer? gameTimer;
        int xOffset, yOffset;
        double cxOffset, cyOffset;
        double radius;
        double radiusC;
        double angle;
        double angleDifference;
        double strokeThickness;
        double baseRadius;
        double baseX, baseY;
        Brush circleColor;
        Brush cycloidColor;

        TranslateTransform? tbase;
        TranslateTransform? tt;
        TranslateTransform? tc;
        Line? lajn;
        Ellipse? cyc;
        private void btnCreate_onClick(object sender, RoutedEventArgs e)
        {
            ConvertValues();

            tbase = new()
            {
                X = baseX - baseRadius,
                Y = baseY - baseRadius,
            };
            Ellipse baseEl = new()
            {
                Width = baseRadius * 2,
                Height = baseRadius * 2,
                Stroke = Brushes.DarkBlue,
                RenderTransform = tbase,
                StrokeThickness = strokeThickness,
            };
            canvas.Children.Add(baseEl);

            tt = new()
            {
                X = baseX + baseRadius,
                Y = baseY - baseRadius + radius + strokeThickness,
            };
            Ellipse ell = new()
            {
                Width = radius * 2,
                Height = radius * 2,
                Stroke = Brushes.DarkMagenta,
                RenderTransform = tt,
                StrokeThickness = strokeThickness,
            };
            canvas.Children.Add(ell);
            tc = new()
            {
                X = tt.X - radiusC + Math.Cos(angle) * (radius + cxOffset),
                Y = tt.Y + radiusC + Math.Sin(-angle) * (radius + cyOffset),
            };
            cyc = new()
            {
                Width = radiusC * 2,
                Height = radiusC * 2,
                Stroke = Brushes.Red,
                RenderTransform = tc,
                StrokeThickness = strokeThickness / 2,
            };
            canvas.Children.Add(cyc);
            lajn = new()
            {
                X1 = xOffset,
                Y1 = yOffset,

                X2 = tc.X + radiusC,
                Y2 = tc.Y + radiusC,

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
                    Width = cyc.Width,
                    Height = cyc.Height,
                    Stroke = cyc.Stroke,
                    Fill = cyc.Fill ?? cyc.Stroke,
                    RenderTransform = tc.Clone(),
                    StrokeThickness = cyc.StrokeThickness,
                });

                angle += angleDifference;
                tt.X = xOffset - radius + angle * radius;

                tc.X = xOffset - radiusC + Math.Cos(angle) * (radius + cxOffset) + angle * radius;
                tc.Y = yOffset - radiusC + Math.Sin(-angle) * (radius + cyOffset);

                lajn.X1 = tt.X + radius;
                lajn.Y1 = tt.Y + radius;

                lajn.X2 = tc.X + radiusC;
                lajn.Y2 = tc.Y + radiusC;
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
            xOffset = Convert.ToInt32(tbX.Text);
            yOffset = Convert.ToInt32(tbY.Text);
            radius = Convert.ToDouble(tbRadius.Text);
            radiusC = Convert.ToDouble(tbRadiusC.Text);
            angle = Convert.ToDouble(tbAngle.Text);
            angleDifference = Convert.ToDouble(tbAngleDiff.Text);
            strokeThickness = Convert.ToDouble(tbStrokeThickness.Text);
            cxOffset = Convert.ToInt32(tbPointX.Text);
            cyOffset = Convert.ToInt32(tbPointY.Text);
            baseRadius = Convert.ToInt32(tbBaseRadius.Text);
            baseX = Convert.ToInt32(tbBaseX.Text);
            baseY = Convert.ToInt32(tbBaseY.Text);
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
