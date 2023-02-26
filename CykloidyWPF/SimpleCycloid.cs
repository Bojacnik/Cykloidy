using System;
using System.Windows.Shapes;

namespace CykloidyWPF
{
    class SimpleCycloid
    {
        public double X, Y;       // x and y coordinates of point on cycloid
        public readonly double xOffset, yOffset;
        public readonly double Radius;
        public readonly double AngleDifference;
        public double Width => Radius * 2;
        public double Height => Radius * 2;
        public readonly double Stroke;
        public double Angle;
        public readonly SimpleCycloid? Child;
        public readonly Line? Line;

        public SimpleCycloid(double X, double Y, double xOffset, double yOffset, double Radius, double Stroke)
        {
            this.X = X;
            this.Y = Y;
            this.xOffset = xOffset;
            this.yOffset = yOffset;
            this.Radius = Radius;
            this.Stroke = Stroke;
            Child = null;
            Line = null;
        }

        public SimpleCycloid(double X, double Y, double xOffset, double yOffset, double Radius, double AngleDifference, double Stroke, SimpleCycloid Child, Line Line)
        {
            this.X = X;
            this.Y = Y;
            this.xOffset = xOffset;
            this.yOffset = yOffset;
            this.Radius = Radius;
            this.AngleDifference = AngleDifference;
            this.Stroke = Stroke;
            this.Child = Child;
            this.Line = Line;
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
