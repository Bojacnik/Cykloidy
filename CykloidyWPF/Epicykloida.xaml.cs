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

            cbType.Items.Add("epicykloidy");
            cbType.Items.Add("hypocykloidy");
            var brushProperties = typeof(Brushes).GetProperties();
            foreach (var brushProperty in brushProperties)
            {
                cbColor1.Items.Add(brushProperty.Name);
                cbColor2.Items.Add(brushProperty.Name);
                cbColor3.Items.Add(brushProperty.Name);
                cbFill.Items.Add(brushProperty.Name);
            }
            cbColor1.SelectedIndex = 12;
            cbColor2.SelectedIndex = 27;
            cbColor3.SelectedIndex = 113;
            cbFill.SelectedIndex = 113;
        }

        DispatcherTimer gameTimer;
        private void btnCreate_onClick(object sender, RoutedEventArgs e)
        {
            ConvertValues();




            btnCreate.IsEnabled = false;
            btnRun.IsEnabled = true;
            btnClear.IsEnabled = true;
        }
        private void btnRun_onClick(object sender, RoutedEventArgs e)
        {
            /*

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
            */

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
            double radius1 = Convert.ToInt32(tbRadius1);
            double radius2 = Convert.ToInt32(tbRadius2);
            double radius3 = Convert.ToInt32(tbRadius3);
            double offset = Convert.ToInt32(tbOffset);
            double angleDiff = Convert.ToInt32(tbAngleDiff);
            double stroke = Convert.ToInt32(tbStrokeThickness);
            double angle = 0;
            BrushConverter bc = new BrushConverter();
            Brush color1 = (Brush)bc.ConvertFromString(cbColor1.Text);
            Brush color2 = (Brush)bc.ConvertFromString(cbColor2.Text);
            Brush color3 = (Brush)bc.ConvertFromString(cbColor2.Text);
            Brush fill = (Brush)bc.ConvertFromString(cbFill.Text);
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
