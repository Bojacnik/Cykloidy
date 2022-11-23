
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Domain.Basic.Implementations;
using Domain.Basic.Interfaces;
using Domain.Primitives.Implementations;

namespace Cykloidy
{
    public class BasicSimManager : ISimManager
    {
        Canvas canvas;
        BasicStorage basicStorage;
        BasicTimer basicTimer;
        BasicPusher basicPusher;
        Vector2 offsets;

        public BasicSimManager(Canvas canvas, Vector2 offsetts, Circle circle)
        {
            this.canvas = canvas;
            this.basicStorage = new BasicStorage();
            this.basicPusher = new BasicPusher(basicStorage.geometries, 1);
            this.basicTimer = new BasicTimer(16.6, () => { basicPusher.Step(); DrawScenery();  });
            this.offsets = offsetts;

            basicStorage.AddGeometry(circle);
        }


        public void DrawSetup()
        {
            foreach (Domain.Primitives.Abstractions.Geometry l in basicStorage.geometries)
            {
                if (l is Domain.Primitives.Implementations.Line)
                    basicStorage.geometries.Remove(l);
            }

            System.Windows.Shapes.Line lineX = new System.Windows.Shapes.Line
            {
                X1 = 0 + offsets.x,
                Y1 = 0 + offsets.y,
                X2 = 0 + offsets.x,
                Y2 = canvas.ActualHeight,
                Stroke = Brushes.Black,
                StrokeThickness = 5,
            };
            System.Windows.Shapes.Line lineY = new System.Windows.Shapes.Line
            {
                X1 = 0 + offsets.x,
                Y1 = 0 + offsets.y,
                X2 = canvas.ActualWidth,
                Y2 = 0 + offsets.y,
                Stroke = Brushes.Black,
                StrokeThickness = 5,
            };

            canvas.Children.Add(lineX);
            canvas.Children.Add(lineY);
        }
        public void DrawScenery()
        {
            //Remove old elements
            canvas.Dispatcher.Invoke(() =>
            {
                List<Ellipse> toRemove = new List<Ellipse>();
                foreach (Shape s in canvas.Children)
                {
                    if (s is Ellipse e)
                        toRemove.Add(e);
                }

                for (int i = 0; i < toRemove.Count; i++)
                {
                    canvas.Children.Remove(toRemove[i]);
                }

               
            });

            //Add new elements
            canvas.Dispatcher.Invoke(() =>
            {
                foreach (Domain.Primitives.Abstractions.Geometry g in basicStorage.geometries)
                {
                    if (g is Circle c)
                    {
                        canvas.Children.Add(MapCircleToEllipse(c));
                    }
                }
            });

        }
        public void Start()
        {
            basicTimer.Start();
        }

        private Ellipse MapCircleToEllipse(Circle c)
        {
            Ellipse e = new Ellipse();
            e.Height = c.Radius * 2;
            e.Width = c.Radius * 2;
            e.StrokeThickness = 5;
            e.Stroke = Brushes.Black;
            e.RenderTransform = new TranslateTransform(c.Center.x, c.Center.y);
            return e;
        }

        
    }
}
