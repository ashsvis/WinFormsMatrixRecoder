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
            int side = panel.ClientSize.Width / lattice.Side;
            for (int i = 0; i < lattice.Side; i++)
            {
                for (int j = 0; j < lattice.Side; j++)
                {
                    var rect = new Rectangle(i * side, j * side, side, side);
                    if (lattice[j, i] == 0)
                        e.Graphics.FillRectangle(Brushes.Red, rect);
                    e.Graphics.DrawRectangle(Pens.Gray, rect);
                }
            }
        }
    }
}