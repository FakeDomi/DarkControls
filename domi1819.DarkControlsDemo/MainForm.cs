using domi1819.DarkControls;

namespace domi1819.DarkControlsDemo
{
    public partial class MainForm : DarkForm
    {
        public MainForm()
        {
            this.InitializeComponent();

            this.UpdateColors(null, null);
        }
        
        private void UpdateColors(object sender, ColorSelectedEventArgs e)
        {
            this.coloredBox1.BackColor = this.darkColorView1.Color;
            this.coloredBox1.BorderColor = this.darkColorView2.Color;
        }
    }
}
