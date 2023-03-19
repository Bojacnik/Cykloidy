using CykloidyWPF;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Linq;

namespace CykloidyWPF
{
    /// <summary>
    /// Interaction logic for EpicycloidWindow.xaml
    /// </summary>
    public partial class EpicycloidWindow : Window
    {
        const string EPICYCLOID = "Epicykloida";
        const string HYPOCYCLOID = "Hypocykloida";
        readonly Canvas canvas;
        public EpicycloidWindow()
        {
            InitializeComponent();
            this.canvas = DrawingCanvas;

            cbType.Items.Add(EPICYCLOID);
            cbType.Items.Add(HYPOCYCLOID);
            cbType.SelectedIndex = 0;
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
        Epicycloid baseCircle;
        Epicycloid travellingCircle;
        Epicycloid cycloid;
        Line baseToTravelling;
        Line travellingToCycloid;

        TranslateTransform bc;
        TranslateTransform tc;
        TranslateTransform c;
        private void btnCreate_onClick(object sender, RoutedEventArgs e)
        {
            ConvertValues();

            canvas.Children.Add(baseCircle.ToEllipse(out bc));
            canvas.Children.Add(travellingCircle.ToEllipse(out tc));
            canvas.Children.Add(cycloid.ToEllipse(out c));
            canvas.Children.Add(baseToTravelling = new()
            {
                X1 = baseCircle.CenterX,
                Y1 = baseCircle.CenterY,
                X2 = travellingCircle.CenterX,
                Y2 = travellingCircle.CenterY,
                Stroke = Brushes.Orange
            });
            canvas.Children.Add(travellingToCycloid = new()
            {
                X1 = travellingCircle.CenterX,
                Y1 = travellingCircle.CenterY,
                X2 = cycloid.CenterX,
                Y2 = cycloid.CenterY,
                Stroke = Brushes.Orange
            });

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

                baseToTravelling.X1 = baseCircle.CenterX;
                baseToTravelling.Y1 = baseCircle.CenterY;
                baseToTravelling.X2 = travellingCircle.CenterX;
                baseToTravelling.Y2 = travellingCircle.CenterY;

                travellingToCycloid.X1 = travellingCircle.CenterX;
                travellingToCycloid.Y1 = travellingCircle.CenterY;
                travellingToCycloid.X2 = cycloid.CenterX;
                travellingToCycloid.Y2 = cycloid.CenterY;
            };
            gameTimer.Interval = TimeSpan.FromMilliseconds(2);
            gameTimer.Start();
            btnCreate.IsEnabled = false;
            btnRun.IsEnabled = false;
            btnClear.IsEnabled = true;
            btnStop.IsEnabled = true;
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            gameTimer?.Stop();
            canvas.Children.Clear();
            btnCreate.IsEnabled = true;
            btnRun.IsEnabled = false;
            btnClear.IsEnabled = false;
            btnStop.IsEnabled = false;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            if (gameTimer.IsEnabled)
                gameTimer?.Stop();
            else
                gameTimer?.Start();
        }

        private void ConvertValues()
        {
            try
            {
                double radius1 = Convert.ToDouble(tbRadius1.Text);
                double radius2 = Convert.ToDouble(tbRadius2.Text);
                double radius3 = Convert.ToDouble(tbRadius3.Text);
                double angleDiff1 = Convert.ToDouble(tbAngleDiff1.Text);
                double angleDiff2 = Convert.ToDouble(tbAngleDiff2.Text);

                double stroke = Convert.ToDouble(tbStrokeThickness.Text);
                double angle = 0;
                BrushConverter bc = new BrushConverter();
                Brush color1 = (Brush)bc.ConvertFromString(cbColor1.Text);
                Brush color2 = (Brush)bc.ConvertFromString(cbColor2.Text);
                Brush color3 = (Brush)bc.ConvertFromString(cbColor3.Text);
                Brush fill = (Brush)bc.ConvertFromString(cbFill.Text);


                string cycloidType = cbType.Text;
                bool hypocycloid = cycloidType == HYPOCYCLOID;

                baseCircle = new Epicycloid(
                    (canvas.ActualWidth / 2D) - radius1,
                    (canvas.ActualHeight / 2D) - radius1,
                    radius1,
                    angle,
                    angleDiff1,
                    stroke,
                    color1
                    );
                // X and Y depends if epicycloid or hypocycloid
                travellingCircle = new Epicycloid(
                    0, // nedůležité (později ho změní RecalculatePosition
                    0, // -||-
                    radius2,
                    angle,
                    angleDiff2,
                    stroke / 2,
                    color2,
                    parent: baseCircle,
                    isHypocycloid: hypocycloid
                    );
                travellingCircle.RecalculatePosition();
                cycloid = new Epicycloid(
                    0, // nedůležité (později ho změní RecalculatePosition
                    0, // -||-
                    radius3,
                    0,      // Vzhledem k tomu že nemá další dítě, není třeba
                    0, // -||-
                    stroke / 2,
                    color3,
                    fill,
                    parent: travellingCircle,
                    last: true
                    );
                cycloid.RecalculatePosition();

            }
            catch { return; }
        }


    }
}
