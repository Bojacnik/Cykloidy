using System;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CykloidyWPF
{
    class SimpleCycloid
    {
        public double X, Y;       // x and y coordinates of point on cycloid
        public readonly double xOffset, yOffset;
        public readonly double Radius;
        public readonly double AngleDifference;
        public double Angle;
        public readonly double StrokeWidth;
        public readonly Brush StrokeBrush;
        public readonly Brush FillBrush;
        public SimpleCycloid? Child;

        public double Width => Radius * 2;
        public double Height => Radius * 2;


        public SimpleCycloid(double X, double Y, double xOffset, double yOffset, double Radius, double AngleDifference, double Stroke, SimpleCycloid Child)
        {
            this.X = X;
            this.Y = Y;
            this.xOffset = xOffset;
            this.yOffset = yOffset;
            this.Radius = Radius;
            this.AngleDifference = AngleDifference;
            this.StrokeWidth = Stroke;
            this.Child = Child;
        }

        public SimpleCycloid(double x, double y, double xOffset, double yOffset, double radius, double angleDifference, double strokeWidth, Brush strokeBrush, Brush fillBrush, double angle, SimpleCycloid? child)
        {
            X = x;
            Y = y;
            this.xOffset = xOffset;
            this.yOffset = yOffset;
            Radius = radius;
            AngleDifference = angleDifference;
            StrokeWidth = strokeWidth;
            StrokeBrush = strokeBrush;
            FillBrush = fillBrush;
            Angle = angle;
            Child = child;
        }

        void Update()
        {
            Angle += AngleDifference;
            X += Angle * Radius;
        }

        void Update(double ParentRadius, double ParentAngle)
        {

            X = xOffset - Radius + Math.Cos(ParentAngle) * (ParentRadius + xOffset) + ParentAngle * ParentRadius;
            Y = yOffset - Radius + Math.Sin(-ParentAngle) * (ParentRadius + yOffset);
        }

    }
}
