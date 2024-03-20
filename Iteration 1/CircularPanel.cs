using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Iteration_1
{
    public partial class CircularPanel : Panel
    {
        public CircularPanel()
        {
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            GraphicsPath g = new GraphicsPath();
            g.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new Region(g);
        }
    }
}