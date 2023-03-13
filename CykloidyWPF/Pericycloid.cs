using System;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CykloidyWPF
{
    class Pericycloid
    {
        public double Width => Radius * 2;
        public double Height => Radius * 2;
        public double CenterX => X + Radius;
        public double CenterY => Y + Radius;
        public double Angle
        {
            get; private set;
        }

        public double X, Y;
        public readonly double Radius;
        public readonly double AngleDifference;
        public readonly double StrokeThickness;
        public readonly Brush StrokeBrush;
        public readonly Brush? FillBrush;
        public Pericycloid? Parent;

        public Pericycloid(
            double x,
            double y,
            double radius,
            double angle, double angleDifference,
            double strokeThickness,
            Brush strokeBrush, Brush? fillBrush = null,
            Pericycloid? parent = null
            )
        {
            X = x;
            Y = y;
            Radius = radius;
            Angle = angle;
            AngleDifference = angleDifference;
            StrokeThickness = strokeThickness;
            StrokeBrush = strokeBrush;
            FillBrush = fillBrush;
            Parent = parent;
        }

        public void Update()
        {
            Angle += AngleDifference;
            RecalculatePosition();
        }

        public void RecalculatePosition()
        {
            if (Parent == null) { return; }
            X = Parent.CenterX - Radius
                + Math.Cos(Parent.Angle) * Parent.Radius;
            Y = Parent.CenterY - Radius
                + Math.Sin(-Parent.Angle) * Parent.Radius;
        }

        public Ellipse ToEllipse(out TranslateTransform tt)
        {
            tt = new TranslateTransform()
            {
                X = this.X,
                Y = this.Y,
            };
            return new()
            {
                Width = this.Width,
                Height = this.Height,
                RenderTransform = tt,
                StrokeThickness = this.StrokeThickness,
                Stroke = this.StrokeBrush,
                Fill = this.FillBrush,
            };
        }
    }
}
