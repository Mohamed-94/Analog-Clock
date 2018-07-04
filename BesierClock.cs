using System;
using Mohamed.Programming.CSharp.Clocks.BezierClock;
using System.Drawing;
using System.Windows.Forms;

class BezierClock : Form
{
    BezierClockControl bclok;

    public static void Main()
    {
        Application.Run(new BezierClock());
    }

    public BezierClock()
    {
        Text = "BezierClock";

        bclok = new BezierClockControl();
        bclok.Parent = this;
        bclok.Time = DateTime.Now;
        bclok.Dock = DockStyle.Fill;
        bclok.BackColor = Color.Black;
        bclok.ForeColor = Color.White;

        Timer timer = new Timer();
        timer.Interval = 1000;
        timer.Tick += new EventHandler(TimerOnTick);
        timer.Start();

    }
    void TimerOnTick(object obj, EventArgs ea)
    {
        bclok.Time = DateTime.Now;
    }
}
