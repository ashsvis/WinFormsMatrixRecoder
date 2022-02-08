using WinFormsMatrixRecoder.Model;

namespace WinFormsMatrixRecoder
{
    public partial class MainForm : Form
    {
        Lattice lattice;

        public MainForm()
        {
            InitializeComponent();
            lattice = new Lattice(10);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            splitContainer2_Panel1_Resize(splitContainer2.Panel1, new EventArgs());
        }

        private void splitContainer2_Panel1_Resize(object sender, EventArgs e)
        {
            var splitterPanel = (SplitterPanel)sender;
            panelForMatrix.Size = new Size(splitterPanel.ClientSize.Width, splitterPanel.ClientSize.Width);
        }

        private void panelForMatrix_Paint(object sender, PaintEventArgs e)
        {
            var panel = (Panel)sender;
            var rect = new Rectangle(0,0,panel.ClientSize.Width, panel.ClientSize.Height);
            e.Graphics.FillRectangle(Brushes.Red, rect);
        }
    }
}