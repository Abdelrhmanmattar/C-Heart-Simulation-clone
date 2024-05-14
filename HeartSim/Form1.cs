using HeartSim.classes.DataAndTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;


namespace HeartSim
{


    public partial class Form1 : Form
    {
        public static object form_lock { get; private set; } = new object();
        private CancellationTokenSource _cancellationTokenSource;

        public Form1()
        {
            InitializeComponent();
            _cancellationTokenSource = new CancellationTokenSource();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void SetTextBox1(string text)
        {
            textBox1.Text = text;
        }
        public TextBox GetTextBox1()
        {
            return textBox1;
        }


        // Store the objects and their colors in variables
        public List<Position> points_loc { get; set; } = new List<Position>(); // List of points coordinates
        public List<(int, int)> lines_loc { get; set; } = new List<(int, int)>(); // List of lines start and end points indices
        public List<int> points_color { get; set; } = new List<int>(Data.NodeNames.Count); // List of points colors
        public List<Color> lines_color { get; set; } = new List<Color>(); // List of lines colors

        Point point = new Point(50, 50);
        Point lineStart = new Point(100, 100);
        Point lineEnd = new Point(200, 200);
        Color pointColor = Color.Yellow;
        Color lineColor = Color.Yellow;

        List<Color> point_colors_bruches { get; set; } = new List<Color> { Color.Lime, Color.Red, Color.Yellow };
        List<Color> line_colors_bruches { get; set; } = new List<Color> { Color.Blue, Color.Lime, Color.Yellow, Color.Black, Color.Red };
        public void RedrawPictureBox()
        {

            Image image = new Bitmap(pictureBox1.Image);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                for (int i = 0; i < points_loc.Count; i++)
                {
                    Color c = point_colors_bruches[points_color[i]];
                    using (SolidBrush pointBrush = new SolidBrush(c))
                    {
                        Position point = points_loc[i];
                        graphics.FillRectangle(pointBrush, (float)point.X, (float)(image.Height - point.Y), 7, 7);
                    }
                }
            }
            pictureBox1.Image.Dispose();
            pictureBox1.Image = image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pointColor = Color.Yellow;
            lineColor = Color.Yellow;
            RedrawPictureBox();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            pointColor = Color.Yellow;
            lineColor = Color.Yellow;
            RedrawPictureBox();
        }
        public CancellationToken GetCancellationToken()
        {
            return _cancellationTokenSource.Token;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _cancellationTokenSource.Cancel();
        }
    }
}
