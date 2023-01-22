namespace ImageM1
{
    public partial class Form1 : Form
    {
        private Bitmap zassouTexture;
        private Bitmap bokusouTexture;
        private MyUtil util;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxZassou.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxBokusou.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxGLCMZassou.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxGLCMBokusou.SizeMode = PictureBoxSizeMode.StretchImage;

            zassouTexture = new Bitmap(Properties.Resources.Zassou);
            bokusouTexture = new Bitmap(Properties.Resources.Bokusou);
            
            pictureBoxZassou.Image = zassouTexture;
            pictureBoxBokusou.Image = bokusouTexture;

            pictureBox1.Image = new Bitmap(Properties.Resources.gici);
            util = new MyUtil(new Bitmap(pictureBox1.Image), zassouTexture, bokusouTexture);

            pictureBoxGLCMZassou.Image = util.CalcGLCM(zassouTexture);
            pictureBoxGLCMBokusou.Image = util.CalcGLCM(bokusouTexture);

            labelDisZassou.Text = util.DisZassou.ToString();
            labelDisBokusou.Text = util.DisBokusou.ToString();
        }

        private void buttonOpenImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "jpg files (*.jpg)|*.jpg";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(dlg.FileName);
                    util.SetSourceBitmap(new Bitmap(pictureBox1.Image));
                }
            }
        }
               
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X * pictureBox1.Image.Width / pictureBox1.Width;
            int y = e.Y * pictureBox1.Image.Height / pictureBox1.Height;
            labelX.Text = x.ToString();
            labelY.Text = y.ToString();
            labelDis.Text = util.CalcDis(x, y).ToString();
            labelIsZassou.Text = util.IsZassou(x, y) ? "Yes" : "No";
        }

    }
}