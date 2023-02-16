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
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
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


            for (int row = 0; row < listView1.Items.Count; row++)
            {
                for (int column = 1; column <= 3; column++)
                {
                    listView1.Items[row].SubItems.Add("nothing");
                }
            }
            listView1.Items[0].SubItems[1].Text = util.Zassou_Results.DisZassou.ToString();
            listView1.Items[0].SubItems[2].Text = util.Zassou_Results.HomZassou.ToString();
            listView1.Items[0].SubItems[3].Text = util.Zassou_Results.ASMZassou.ToString();
            listView1.Items[1].SubItems[1].Text = util.Bokusou_Results.DisBokusou.ToString();
            listView1.Items[1].SubItems[2].Text = util.Bokusou_Results.HomBokusou.ToString();
            listView1.Items[1].SubItems[3].Text = util.Bokusou_Results.ASMBokusou.ToString();

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
            listView1.Items[2].SubItems[1].Text = util.PochiPochi(x, y).DisResult.dis.ToString();
            listView1.Items[2].SubItems[2].Text = util.PochiPochi(x, y).HomResult.hom.ToString();
            listView1.Items[2].SubItems[3].Text = util.PochiPochi(x, y).ASMResult.ASM.ToString();
            listView1.Items[3].SubItems[1].Text = util.PochiPochi(x, y).DisResult.dis_time.ToString();
            listView1.Items[3].SubItems[2].Text = util.PochiPochi(x, y).HomResult.hom_time.ToString();
            listView1.Items[3].SubItems[3].Text = util.PochiPochi(x, y).ASMResult.ASM_time.ToString();

            labelIsZassou.Text = util.IsZassou(x, y) ? "Yes" : "No";
        }

        private void buttonBinarizeZassou_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = util.BinarizeZassou();
        }
    }
}