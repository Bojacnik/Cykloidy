using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CykloidyWPF
{
    internal class Epicycloid
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
        public Epicycloid? Parent;
        public readonly bool Last;
        public readonly bool IsHypocycloid;
        public Epicycloid(
            double x,
            double y,
            double radius,
            double angle, double angleDifference,
            double strokeThickness,
            Brush strokeBrush, Brush? fillBrush = null,
            Epicycloid? parent = null,
            bool last = false,
            bool isHypocycloid = false
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
            Last = last;
            IsHypocycloid = isHypocycloid;
        }

        public void Update()
        {
            // Přičti úhel a přepočítej pozici
            Angle += AngleDifference;
            RecalculatePosition();
        }

        public void RecalculatePosition()
        {
            //Jedná se o statickou kružnici
            if (Parent == null) { return; }

            //Jedná se o bod cykloidy
            if (Last)
            {
                X = Parent.CenterX - Radius
                    + Math.Cos(Parent.Angle) * (Parent.Radius);
                Y = Parent.CenterY - Radius
                    + Math.Sin(-Parent.Angle) * (Parent.Radius);
            }
            else
            {
                //Jedná se o Epicykloidu
                if (!IsHypocycloid)
                {
                    X = Parent.CenterX - Radius
                        + Math.Cos(Parent.Angle) * (Parent.Radius + Radius);
                    Y = Parent.CenterY - Radius
                        + Math.Sin(-Parent.Angle) * (Parent.Radius + Radius);
                }
                //jedná se o Hypocykloidu
                else
                {
                    X = Parent.CenterX - Radius
                        + Math.Cos(Parent.Angle) * (Parent.Radius - Radius);
                    Y = Parent.CenterY - Radius
                        + Math.Sin(-Parent.Angle) * (Parent.Radius - Radius);
                }
            }
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

        enum CycloidType
        {
            Epicycloid = 0,
            Hypocycloid = 1
        }
    }
}
