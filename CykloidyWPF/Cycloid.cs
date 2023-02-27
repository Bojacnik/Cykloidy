using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace CykloidyWPF
{
    class CycloidCircle
    {
        public double Width => Radius * 2;
        public double Height => Radius * 2;

        public readonly double xOffset, yOffset;
        public readonly double Radius;
        public readonly double AngleDifference;
        public readonly double StrokeThickness;
        public readonly Brush StrokeBrush;
        public readonly Brush? FillBrush;
        public CycloidCircle? Parent;

        public double X, Y;       // x and y coordinates of point on cycloid
        public double Angle
        {
            get; private set;
        }

        public CycloidCircle(
            double x,
            double y,
            double xOffset, double yOffset,
            double radius,
            double angle, double angleDifference,
            double strokeThickness,
            Brush strokeBrush, Brush? fillBrush,
            CycloidCircle? parent)
        {
            X = x;
            Y = y;
            this.xOffset = xOffset;
            this.yOffset = yOffset;
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
            if (Parent == null)
            {
                Angle += AngleDifference;
                X = xOffset - Radius + Angle * Radius;
            }
            else
            {
                X = Parent.xOffset - Radius
                    + Math.Cos(Parent.Angle) * (Parent.Radius + Math.Abs(xOffset))
                    + Parent.Angle * Parent.Radius;
                Y = Parent.yOffset - Radius
                    + Math.Sin(-Parent.Angle) * (Parent.Radius + Math.Abs(yOffset));
            }
        }
    }
}
