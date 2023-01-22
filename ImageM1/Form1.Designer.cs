namespace ImageM1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonOpenImage = new System.Windows.Forms.Button();
            this.pictureBoxZassou = new System.Windows.Forms.PictureBox();
            this.pictureBoxBokusou = new System.Windows.Forms.PictureBox();
            this.labelDisZassou = new System.Windows.Forms.Label();
            this.labelDisBokusou = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelIsZassou = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxGLCMBokusou = new System.Windows.Forms.PictureBox();
            this.pictureBoxGLCMZassou = new System.Windows.Forms.PictureBox();
            this.labelDis = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxZassou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBokusou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGLCMBokusou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGLCMZassou)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(20, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 375);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // buttonOpenImage
            // 
            this.buttonOpenImage.Location = new System.Drawing.Point(20, 410);
            this.buttonOpenImage.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpenImage.Name = "buttonOpenImage";
            this.buttonOpenImage.Size = new System.Drawing.Size(202, 36);
            this.buttonOpenImage.TabIndex = 2;
            this.buttonOpenImage.Text = "画像ファイル読み込み";
            this.buttonOpenImage.UseVisualStyleBackColor = true;
            this.buttonOpenImage.Click += new System.EventHandler(this.buttonOpenImage_Click);
            // 
            // pictureBoxZassou
            // 
            this.pictureBoxZassou.Location = new System.Drawing.Point(142, 494);
            this.pictureBoxZassou.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxZassou.Name = "pictureBoxZassou";
            this.pictureBoxZassou.Size = new System.Drawing.Size(80, 80);
            this.pictureBoxZassou.TabIndex = 5;
            this.pictureBoxZassou.TabStop = false;
            // 
            // pictureBoxBokusou
            // 
            this.pictureBoxBokusou.Location = new System.Drawing.Point(254, 494);
            this.pictureBoxBokusou.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxBokusou.Name = "pictureBoxBokusou";
            this.pictureBoxBokusou.Size = new System.Drawing.Size(80, 80);
            this.pictureBoxBokusou.TabIndex = 6;
            this.pictureBoxBokusou.TabStop = false;
            // 
            // labelDisZassou
            // 
            this.labelDisZassou.AutoSize = true;
            this.labelDisZassou.Location = new System.Drawing.Point(142, 675);
            this.labelDisZassou.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDisZassou.Name = "labelDisZassou";
            this.labelDisZassou.Size = new System.Drawing.Size(130, 25);
            this.labelDisZassou.TabIndex = 8;
            this.labelDisZassou.Text = "labelDisZassou";
            // 
            // labelDisBokusou
            // 
            this.labelDisBokusou.AutoSize = true;
            this.labelDisBokusou.Location = new System.Drawing.Point(244, 675);
            this.labelDisBokusou.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDisBokusou.Name = "labelDisBokusou";
            this.labelDisBokusou.Size = new System.Drawing.Size(143, 25);
            this.labelDisBokusou.TabIndex = 9;
            this.labelDisBokusou.Text = "labelDisBokusou";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 675);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Dissimilarity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(142, 455);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "雑草";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(254, 455);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "牧草";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 524);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "テクスチャ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(481, 438);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 25);
            this.label7.TabIndex = 27;
            this.label7.Text = "クリックしたとこ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(510, 515);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 25);
            this.label8.TabIndex = 28;
            this.label8.Text = "x";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(510, 545);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 25);
            this.label9.TabIndex = 29;
            this.label9.Text = "y";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(459, 570);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 25);
            this.label10.TabIndex = 30;
            this.label10.Text = "雑草？";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(538, 515);
            this.labelX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(60, 25);
            this.labelX.TabIndex = 31;
            this.labelX.Text = "labelX";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(538, 545);
            this.labelY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(59, 25);
            this.labelY.TabIndex = 32;
            this.labelY.Text = "labelY";
            // 
            // labelIsZassou
            // 
            this.labelIsZassou.AutoSize = true;
            this.labelIsZassou.Location = new System.Drawing.Point(535, 570);
            this.labelIsZassou.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelIsZassou.Name = "labelIsZassou";
            this.labelIsZassou.Size = new System.Drawing.Size(118, 25);
            this.labelIsZassou.TabIndex = 33;
            this.labelIsZassou.Text = "labelIsZassou";
            this.labelIsZassou.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 586);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 35;
            this.label1.Text = "GLCM";
            // 
            // pictureBoxGLCMBokusou
            // 
            this.pictureBoxGLCMBokusou.Location = new System.Drawing.Point(254, 586);
            this.pictureBoxGLCMBokusou.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxGLCMBokusou.Name = "pictureBoxGLCMBokusou";
            this.pictureBoxGLCMBokusou.Size = new System.Drawing.Size(80, 80);
            this.pictureBoxGLCMBokusou.TabIndex = 37;
            this.pictureBoxGLCMBokusou.TabStop = false;
            // 
            // pictureBoxGLCMZassou
            // 
            this.pictureBoxGLCMZassou.Location = new System.Drawing.Point(142, 586);
            this.pictureBoxGLCMZassou.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxGLCMZassou.Name = "pictureBoxGLCMZassou";
            this.pictureBoxGLCMZassou.Size = new System.Drawing.Size(80, 80);
            this.pictureBoxGLCMZassou.TabIndex = 36;
            this.pictureBoxGLCMZassou.TabStop = false;
            // 
            // labelDis
            // 
            this.labelDis.AutoSize = true;
            this.labelDis.Location = new System.Drawing.Point(538, 490);
            this.labelDis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDis.Name = "labelDis";
            this.labelDis.Size = new System.Drawing.Size(74, 25);
            this.labelDis.TabIndex = 39;
            this.labelDis.Text = "labelDis";
            this.labelDis.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(418, 490);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 25);
            this.label2.TabIndex = 40;
            this.label2.Text = "Dissimilarity";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 812);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelDis);
            this.Controls.Add(this.pictureBoxGLCMBokusou);
            this.Controls.Add(this.pictureBoxGLCMZassou);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelIsZassou);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelDisBokusou);
            this.Controls.Add(this.labelDisZassou);
            this.Controls.Add(this.pictureBoxBokusou);
            this.Controls.Add(this.pictureBoxZassou);
            this.Controls.Add(this.buttonOpenImage);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxZassou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBokusou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGLCMBokusou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGLCMZassou)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Button buttonOpenImage;
        private PictureBox pictureBoxZassou;
        private PictureBox pictureBoxBokusou;
        private Label labelDisZassou;
        private Label labelDisBokusou;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ColorDialog colorDialog1;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label labelX;
        private Label labelY;
        private Label labelIsZassou;
        private Label label1;
        private PictureBox pictureBoxGLCMBokusou;
        private PictureBox pictureBoxGLCMZassou;
        private Label labelDis;
        private Button buttonDis;
        private Label label2;
    }
}