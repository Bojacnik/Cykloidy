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

    public partial class PericycloidWindow : Window
    {
        readonly Canvas canvas;
        public PericycloidWindow()
        {
            InitializeComponent();
            this.canvas = DrawingCanvas;

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
        Pericycloid baseCircle;
        Pericycloid travellingCircle;
        Pericycloid cycloid;

        TranslateTransform bc;
        TranslateTransform tc;
        TranslateTransform c;
        private void btnCreate_onClick(object sender, RoutedEventArgs e)
        {
            ConvertValues();

            canvas.Children.Add(baseCircle.ToEllipse(out bc));
            canvas.Children.Add(travellingCircle.ToEllipse(out tc));
            canvas.Children.Add(cycloid.ToEllipse(out c));

            btnCreate.IsEnabled = false;
            btnRun.IsEnabled = true;
            btnClear.IsEnabled = true;
        }
        private void btnRun_onClick(object sender, RoutedEventArgs e)
        {
            gameTimer = new DispatcherTimer(DispatcherPriority.Render);
            gameTimer.Tick += (object? sender, EventArgs e) =>
            {
                //Zobrazení předešlého bodu cykloidy
                canvas.Children.Add(cycloid.ToEllipse(out _));

                //Pouze orotuje kružnice
                baseCircle.Update();

                //Otočení rotující kružnice
                travellingCircle.Update();
                tc.X = travellingCircle.X;
                tc.Y = travellingCircle.Y;

                //Otočení bodu cykloidy pro získání dalšího
                cycloid.Update();
                c.X = cycloid.X;
                c.Y = cycloid.Y;
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
            double radius1 = Convert.ToDouble(tbRadius1.Text);
            double radius2 = Convert.ToDouble(tbRadius2.Text);
            double radius3 = Convert.ToDouble(tbRadius3.Text);
            double angleDiff = Convert.ToDouble(tbAngleDiff.Text);
            double stroke = Convert.ToDouble(tbStrokeThickness.Text);
            double angle = 0;
            BrushConverter bc = new BrushConverter();
            Brush color1 = (Brush)bc.ConvertFromString(cbColor1.Text);
            Brush color2 = (Brush)bc.ConvertFromString(cbColor2.Text);
            Brush color3 = (Brush)bc.ConvertFromString(cbColor3.Text);
            Brush fill = (Brush)bc.ConvertFromString(cbFill.Text);

            baseCircle = new Pericycloid(
                (canvas.ActualWidth / 2D) - radius1,
                (canvas.ActualHeight / 2D) - radius1,
                radius1,
                angle,
                angleDiff,
                stroke,
                color1
                );
            // X and Y depends if epicycloid or hypocycloid
            travellingCircle = new Pericycloid(
                (baseCircle.X + baseCircle.Width),
                (baseCircle.Y + baseCircle.Radius - radius2),
                radius2,
                angle,
                angleDiff * 2,
                stroke / 2,
                color2,
                parent: baseCircle,
                child: cycloid
                );
            travellingCircle.RecalculatePosition();
            cycloid = new Pericycloid(
                travellingCircle.X + travellingCircle.Width - radius3, // nedůležité (později ho změní RecalculatePosition
                travellingCircle.Y + travellingCircle.Radius - radius3, // -||-
                radius3,
                angle,      // Vzhledem k tomu že nemá další dítě, není třeba
                angleDiff, // -||-
                stroke / 2,
                color3,
                fill,
                parent: travellingCircle
                );
            cycloid.RecalculatePosition();
        }

    }
}
