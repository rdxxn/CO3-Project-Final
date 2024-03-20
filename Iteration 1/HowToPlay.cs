using System;
using System.Drawing;
using System.Windows.Forms;

namespace Iteration_1
{
    public partial class HowToPlay : Form
    {
        public HowToPlay()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); //Exits the program fully when pressing x button
        }

        //goes back to the main menu, preserving size and properties of the HowToPlay form
        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            mainMenu.Size = new Size(Convert.ToInt32(this.Width), Convert.ToInt32(this.Height));
            if (this.WindowState == FormWindowState.Maximized) { mainMenu.WindowState = FormWindowState.Maximized; }
            mainMenu.DesktopLocation = new Point(Convert.ToInt32(this.DesktopLocation.X), Convert.ToInt32(this.DesktopLocation.Y));
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}