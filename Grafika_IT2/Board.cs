using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Grafika_IT2
{
  public class Board
  {
    private List<Point> points;

    public Board()
    {
      points = new List<Point>();
    }

    public void Clear()
    {
      points.Clear();
    }

    public void Add(Point point)
    {
      points.Add(point);
    }

    public void Draw(Canvas canvas)
    {
      canvas.Children.Clear();
      foreach (var point in points)
      {
        Ellipse ellipse = new Ellipse();
        ellipse.Width = 10;
        ellipse.Height = 10;
        ellipse.Fill = Brushes.Blue;
        Canvas.SetLeft(ellipse, point.X - (ellipse.Width / 2));
        Canvas.SetTop(ellipse, point.Y - (ellipse.Height / 2));
        canvas.Children.Add(ellipse);
      }
    }

    public override string ToString()
    {
      string text = "";
      foreach(var point in points)
      {
        text += $"{point.X};{point.Y}\r\n";
      }
      return text;
    }

    public void FromString(string text)
    {
      points.Clear();
      foreach(var line in text.Split("\r\n"))
      {
        var parts = line.Split(";");
        if(parts.Length == 2)
        {
          if (!double.TryParse(parts[0], out var x))
          {
            continue;
          }
          if(!double.TryParse(parts[1], out var y))
          {
            continue;
          }
          points.Add(new Point(x, y));
        }        
      }
    }
    
  }
}
