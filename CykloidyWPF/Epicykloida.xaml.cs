﻿using CykloidyWPF;
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
        CycloidCircle baseCircle;
        CycloidCircle travellingCircle;
        CycloidCircle cycloid;

        TranslateTransform bc;
        TranslateTransform tc;
        TranslateTransform c;
        private void btnCreate_onClick(object sender, RoutedEventArgs e)
        {
            ConvertValues();

            bc = new()
            {
                X = baseCircle.X,
                Y = baseCircle.Y
            };
            Ellipse baseEllipse = new()
            {
                Width = baseCircle.Width,
                Height = baseCircle.Height,
                Stroke = baseCircle.StrokeBrush,
                StrokeThickness = baseCircle.StrokeThickness,
                RenderTransform = bc
            };
            canvas.Children.Add(baseEllipse);

            tc = new()
            {
                X = travellingCircle.X,
                Y = travellingCircle.Y,
            };
            Ellipse travellingEllipse = new()
            {
                Width = travellingCircle.Width,
                Height = travellingCircle.Height,
                Stroke = travellingCircle.StrokeBrush,
                StrokeThickness = travellingCircle.StrokeThickness,
                RenderTransform = tc
            };
            canvas.Children.Add(travellingEllipse);

            c = new()
            {
                X = cycloid.X,
                Y = cycloid.Y
            };
            Ellipse ellipse = new()
            {
                Width = cycloid.Width,
                Height = cycloid.Height,
                Stroke = cycloid.StrokeBrush,
                StrokeThickness = cycloid.StrokeThickness,
                RenderTransform = c
            };
            canvas.Children.Add(ellipse);


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
            double radius1 = Convert.ToDouble(tbRadius1.Text);
            double radius2 = Convert.ToDouble(tbRadius2.Text);
            double radius3 = Convert.ToDouble(tbRadius3.Text);
            double offset = Convert.ToDouble(tbOffset.Text);
            double angleDiff = Convert.ToDouble(tbAngleDiff.Text);
            double stroke = Convert.ToDouble(tbStrokeThickness.Text);
            double angle = 0;
            BrushConverter bc = new BrushConverter();
            Brush color1 = (Brush)bc.ConvertFromString(cbColor1.Text);
            Brush color2 = (Brush)bc.ConvertFromString(cbColor2.Text);
            Brush color3 = (Brush)bc.ConvertFromString(cbColor3.Text);
            Brush fill = (Brush)bc.ConvertFromString(cbFill.Text);

            baseCircle = new CycloidCircle(
                (canvas.ActualWidth / 2D) - radius1,
                (canvas.ActualHeight / 2D) - radius1,
                0,
                0,
                radius1,
                angle,
                angleDiff,
                stroke,
                color1,
                null,
                null
                );
            // X and Y depends if epicycloid or hypocycloid
            travellingCircle = new CycloidCircle(
                (baseCircle.X + baseCircle.Width),
                (baseCircle.Y + baseCircle.Radius - radius2),
                0,
                0,
                radius2,
                angle,
                angleDiff,
                stroke / 2,
                color2,
                null,
                baseCircle);
            cycloid = new CycloidCircle(
                travellingCircle.X + travellingCircle.Width - radius3,
                travellingCircle.Y + travellingCircle.Radius - radius3,
                0,
                0,
                radius3,
                angle,
                angleDiff,
                stroke / 2,
                color3,
                fill,
                travellingCircle
                );
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
