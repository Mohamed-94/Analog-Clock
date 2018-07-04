using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Mohamed.Programming.CSharp.Clocks.BezierClock
{
    class BezierClockControl : ClockControl 
    {
        protected override void DrawHand(Graphics graf, Pen pen)
        {
            GraphicsState gs = graf.Save();
            graf.RotateTransform(360f * Time.Hour / 12 + 30f * Time.Minute / 60);

            graf .DrawBeziers (pen ,new Point[]{ new Point (0,-600),new Point (0,-300),
            new Point (200,-300),new Point (50,-200),new Point (50,-200),new Point (50,0),new Point (50,0),new Point (50,75),
            new Point (-50,75),new Point (-50,0),new Point (-50,0),new Point (-50,-200),new Point (-50,-200),new Point (-200,-300),
            new Point (0,-300),new Point (0,-600)});
            graf .Restore (gs);
        }
        protected override void DrawMiniteHand(Graphics graf, Pen pen)
        {
            GraphicsState gs = graf.Save();
            graf.RotateTransform(360f * Time.Minute  / 60 + 6f * Time.Second  / 60);

            graf.DrawBeziers(pen, new Point[]{ new Point (0,-800),new Point (0,-750),
            new Point (0,-700),new Point (25,-600),new Point (25,-600),new Point (25,0),new Point (25,0),new Point (25,50),
            new Point (-25,50),new Point (-25,0),new Point (-25,0),new Point (-25,-600),new Point (-25,-600),new Point (0,-700),
            new Point (0,-750),new Point (0,-800)});
            graf.Restore(gs);
        }
 
        }
    
    }

