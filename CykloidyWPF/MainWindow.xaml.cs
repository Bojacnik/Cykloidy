using CykloidyWPF;
using System;
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
        Ellipse ellipse;
        int radius;
        double obvod;
        double angleStep;
        double angle = 0;
        Ellipse point;

        int pointX;
        int pointY;

        private void btnCreate_onClick(object sender, RoutedEventArgs e)
        {
            if (ellipse is not null)
                canvas.Children.Clear();

            radius = Convert.ToInt32(tbRadius.Text);
            int x = Convert.ToInt32(tbX.Text);
            int y = Convert.ToInt32(tbY.Text);

            pointX = Convert.ToInt32(tbPointX.Text);
            pointY = Convert.ToInt32(tbPointY.Text);

            ellipse = createPoint(x, y, radius, Brushes.Black, Brushes.BlueViolet);
            obvod = 2 * Math.PI * radius;
            angleStep = 360 / obvod;

            point = createPoint(pointX, pointY, 5, null, null);

            canvas.Children.Add(ellipse);
            canvas.Children.Add(point);
            btnRun.IsEnabled = true;
        }

        SimpleCycloid sc;
        private void btnRun_onClick(object sender, RoutedEventArgs e)
        {
            sc ??= new SimpleCycloid(radius, pointX, pointY);

            btnCreate.IsEnabled = false;
            gameTimer.Interval = TimeSpan.FromMilliseconds(5);
            gameTimer.Tick += new EventHandler((object? sender, EventArgs e) =>
            {
                if (IsUserVisible(ellipse, this))
                {
                    var transform = ellipse.RenderTransform as TranslateTransform ?? new TranslateTransform();
                    transform.X += 1;
                    ellipse.RenderTransform = transform;
                    
                    var transform2 = point.RenderTransform as TranslateTransform ?? new TranslateTransform();

                    sc.Calculate();
                    transform2.X = sc.x;
                    transform2.Y = sc.y;
                    point.RenderTransform = transform2;
                }
                else
                {
                    gameTimer.Stop();
                    btnCreate.IsEnabled = true;
                }
            });
            gameTimer.Start();

            btnRun.IsEnabled = false;
        }

        private Ellipse createPoint(int x, int y, int radius, Brush? stroke, Brush? fill)
        {
            stroke ??= Brushes.Red;
            fill ??= Brushes.Red;
            Ellipse el = new()
            {
                Width = radius * 2,
                Height = radius * 2,
                StrokeThickness = 3,
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
