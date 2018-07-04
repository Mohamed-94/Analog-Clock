using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace Mohamed.Programming.CSharp.Clocks
{
    class ClockControl : UserControl
    {
        DateTime dt;
       

        public ClockControl()
        {
            ResizeRedraw = true;
            Enabled = false;
            
        } 

        public DateTime Time
        {
            get
            {
                return dt;
            }
            set
            {
                Graphics graf = CreateGraphics();
                InitializeCoordinates(graf);

                Pen pen = new Pen(BackColor);

                if (dt.Hour != value.Hour)
                {
                    DrawHand(graf,pen);
                }
                if (dt.Minute != value.Minute)
                {
                    DrawHand(graf, pen);
                    DrawMiniteHand(graf, pen);

                }
                if (dt.Second != value.Second)
                {
                    DrawMiniteHand(graf, pen);
                    DrawSecondHand(graf, pen);

                }
                if (dt.Millisecond != value.Millisecond)
                {
                    DrawSecondHand(graf, pen);
                }
                dt = value;
                pen = new Pen(ForeColor);

                DrawHand(graf, pen);
                DrawMiniteHand(graf, pen);
                DrawSecondHand(graf, pen);

                graf.Dispose();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graf = e.Graphics;
            Pen pen = new Pen(ForeColor);
            Brush brush = new SolidBrush(ForeColor);

            InitializeCoordinates(graf);
            DrawDots(graf ,brush);
            DrawHand(graf, pen);
            DrawMiniteHand(graf, pen);
            DrawSecondHand(graf, pen);
        }

        void InitializeCoordinates(Graphics graf)
        {
            if (Width == 0 || Height == 0)
                return;

            graf .TranslateTransform (Width /2,Height /2);
            float finshs = Math.Min(Width / graf.DpiX, Height / graf.DpiY);
            graf.ScaleTransform(finshs * graf.DpiX / 2000, finshs * graf.DpiY / 2000);
        }

        void DrawDots(Graphics graf, Brush brush)
        {
            for (int i = 0; i < 60; i++)
            {
                int iSize = i % 5 == 0 ? 100 : 30;
                graf.FillEllipse(brush, 0 - iSize / 2, -900 - iSize / 2, iSize, iSize);
                graf.RotateTransform(6);
            }
        }

        protected virtual void DrawHand(Graphics graf, Pen pen)
        {
            GraphicsState gs = graf.Save();
            graf.RotateTransform(360f * Time.Hour / 12 + 30f * Time.Minute / 60);
            graf.DrawPolygon(pen, new Point[]{
                new Point (0,150),new Point (100,0),new Point (0,-600),new Point (-100,0)
            });
            graf.Restore(gs);
        }

        protected virtual void DrawMiniteHand(Graphics graf, Pen pen)
        {
            GraphicsState gs = graf.Save();
            graf.RotateTransform(360f * Time.Minute / 60 + 6f * Time.Second / 60);
            graf.DrawPolygon(pen, new Point[]{
                new Point (0,200),new Point (50,0),new Point (0,-800),new Point (-50,0)
            });
            graf.Restore(gs);
        }

        protected virtual void DrawSecondHand(Graphics graf, Pen pen)
        {
            GraphicsState gs = graf.Save();
            graf.RotateTransform(360f * Time.Second / 60 + 6f * Time.Millisecond / 1000);
            graf.DrawLine(pen, 0, 0, 0, -800);
            graf.Restore(gs);
        }

        
    }
}
