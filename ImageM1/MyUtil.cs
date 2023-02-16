using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace ImageM1
{
    internal class MyUtil
    {
        private Bitmap _source;  // 処理対象の画像
        private BitmapData _sourceData;  // 処理対象の画像のBitmapData
        private Color[,] _sourceColors;  // 処理対象の画像をColorの二次元配列に変換したもの

        //private float _disThreshold; // dissimilality theshold
        private float _homThreshold; // homogeneity theshold
        private int _textureRadius; // 11x11のテクスチャなら5。
        private int level = 16; // GLCMを作るときのグレースケールのレベル
        private Color black = Color.FromArgb(0, 0, 0);
        private Color white = Color.FromArgb(255, 255, 255);

        public (int DisZassou, int HomZassou, int ASMZassou) Zassou_Results; // 雑草のテクスチャ指標
        public (int DisBokusou, int HomBokusou, int ASMBokusou) Bokusou_Results;  // 牧草のdissimilality
        public struct IndexResults
        {
            public (string dis_time, int dis) DisResult { get; internal set; }
            public (string hom_time, int hom) HomResult { get; internal set; }
            public (string ASM_time, int ASM) ASMResult { get; internal set; }

        }
        public MyUtil(Bitmap original, Bitmap zassouTexture, Bitmap bokusouTexture)
        {
            _source = original;
            _textureRadius = zassouTexture.Width / 2;
            int width = _source.Width;
            int height = _source.Height;

            _sourceColors = new Color[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    _sourceColors[i, j] = _source.GetPixel(i, j);
                }
            }
            Zassou_Results = Get_Ref_Value(zassouTexture);
            Bokusou_Results = Get_Ref_Value(bokusouTexture);
            _homThreshold = (Zassou_Results.HomZassou + Bokusou_Results.HomBokusou) / 2;

            _sourceData = _source.LockBits(
                new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
        }



        // 入力画像を入れ替える時に呼ばれる
        public void SetSourceBitmap(Bitmap originalBitmap)
        {
            _source.UnlockBits(_sourceData);

            _source = originalBitmap;
            int width = _source.Width;
            int height = _source.Height;
            _sourceColors = new Color[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    _sourceColors[i, j] = _source.GetPixel(i, j);
                }
            }

            _sourceData = _source.LockBits(
                new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
        }
        
        public bool IsZassou(int x, int y)
        {
            int width = _source.Width;
            int height = _source.Height;

            if (x < _textureRadius || x >= width - _textureRadius) return false;
            if (y < _textureRadius || y >= height - _textureRadius) return false;

            if (!IsKusa(_sourceColors[x, y])) return false;

            int[,] clipped = Clipping(x, y);
            int[,] GLCM_img = GLCM(clipped);
            //(string time, int value)dis_result = CalcDisFromGLCM(GLCM_img);
            //int dis = dis_result.value;
            //return IsZassoufromDis(dis) ? true : false;
            (string time, int value) hom_result = CalcHomFromGLCM(GLCM_img);
            int hom = hom_result.value;
            return IsZassoufromHom(hom) ? true : false;
        }
        private bool IsKusa(Color c)
        {
            int z = -441 * c.R + 811 * c.G - 385 * c.B;
            return z > 10000 ? true : false;
        }
        //private bool IsZassoufromDis(int dis)
        //{
        //    return (dis < _disThreshold) ? true : false;
        //}
        private bool IsZassoufromHom(int hom)
        {
            return (hom > _homThreshold) ? true : false;
        }

        private int[,] GLCM(int[,] source)
        {
            int[,] normalizedSource = Normalize(source);
            int[,] target = CalcGLCM(normalizedSource);
            return target;
        }

        private int[,] Normalize(int[,] source)
        {
            int li = source.GetLength(0);
            int lj = source.GetLength(1);
            int[,] target = new int[li, lj];
            for (int i = 0; i < li; i++)
            {
                for (int j = 0; j < lj; j++)
                {
                    target[i, j] = (int)(source[i, j] * level / 256);
                }
            }
            return target;
        }

        private int[,] CalcGLCM(int[,] source)
        {
            int[,] target = new int[level, level];
            int li = source.GetLength(0);
            int lj = source.GetLength(1);

            // 小さいループを外に持っていくことで高速化
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx == 0 && dy == 0) continue;
                    for (int i = 1; i < li - 1; i++)
                    {
                        for (int j = 1; j < lj - 1; j++)
                        {
                            target[source[i, j], source[i + dx, j + dy]]++;
                        }
                    }

                }
            }
            return target;
        }

        private (string, int) CalcDisFromGLCM(int[,] source)
        {
            string time;
            int res = 0;
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < level; i++)
            {
                for (int j = 0; j < level; j++)
                {
                    res += source[i, j] * Math.Abs(i - j);
                }
            }
            sw.Stop();           
            time= sw.Elapsed.ToString();        
            return (time, res);
        }

        private (string, int) CalcHomFromGLCM(int[,] source)
        {
            string time;
            int res = 0;
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < level; i++)
            {
                for (int j = 0; j < level; j++)
                {
                    res += source[i, j] / (1 + (i - j) * (i - j));
                }
            }
            sw.Stop();
            time = sw.Elapsed.ToString();
            return (time, res);
        }

        private (string, int) CalcASMFromGLCM(int[,] source)
        {
            string time;
            int res = 0;
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < level; i++)
            {
                for (int j = 0; j < level; j++)
                {
                    res += source[i, j] * source[i, j];
                }
            }
            sw.Stop();
            time = sw.Elapsed.ToString();
            return (time, res);
        }

        private (int, int, int) Get_Ref_Value(Bitmap source)
        {
            int[,] sourceInt = Bitmap2GrayInt(source);
            int[,] glcm = GLCM(sourceInt);
            (string time, int value)dis_result = CalcDisFromGLCM(glcm);
            (string time, int value) hom_result = CalcHomFromGLCM(glcm);
            (string time, int value) ASM_result = CalcASMFromGLCM(glcm);
            return (dis_result.value, hom_result.value, ASM_result.value);
        }
        public IndexResults PochiPochi(int x, int y)
        {
            IndexResults res = new IndexResults();
            int[,] clip_img = Clipping(x, y);
            int[,] GLCM_texture = GLCM(clip_img);
            (string time, int value)dis_result = CalcDisFromGLCM(GLCM_texture);
            (string time, int value) hom_result = CalcHomFromGLCM(GLCM_texture);
            (string time, int value) ASM_result = CalcASMFromGLCM(GLCM_texture);
            res.DisResult = dis_result;
            res.HomResult = hom_result;
            res.ASMResult = ASM_result;
            return res;
        }

        public int[,] Clipping(int x, int y)
        {
            int[,] target = new int[_textureRadius * 2 + 1, _textureRadius * 2 + 1];
            for (int i = x - _textureRadius; i <= x + _textureRadius; i++)
            {
                for (int j = y - _textureRadius; j <= y + _textureRadius; j++)
                {
                    target[i - (x - _textureRadius), j - (y - _textureRadius)] = _sourceColors[i, j].G;
                }
            }
            return target;
        }

        private int[,] Bitmap2GrayInt(Bitmap source)
        {
            int width = source.Width;
            int height = source.Height;
            int[,] res = new int[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    res[x, y] = source.GetPixel(x, y).G;
                }
            }
            return res;
        }

        private Bitmap GrayInt2Bitmap(int[,] source)
        {
            int li = source.GetLength(0);
            int lj = source.GetLength(1);
            Bitmap res = new Bitmap(li, lj);
            for (int i = 0; i < li; i++)
            {
                for (int j = 0; j < lj; j++)
                {
                    int gray = Math.Min((int)255, source[i, j]);
                    res.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }
            return res;
        }

        public Bitmap CalcGLCM(Bitmap source)
        {
            int[,] sourceInt = Bitmap2GrayInt(source);
            int[,] normalizedSource = Normalize(sourceInt);
            int[,] glcm = CalcGLCM(normalizedSource);
            return GrayInt2Bitmap(glcm);
        }

        public Bitmap BinarizeZassou()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int width = _source.Width;
            int height = _source.Height;
            Bitmap target = new Bitmap(width, height);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Color c = IsZassou(i, j) ? white : black;
                    target.SetPixel(i, j, c);
                }
            }

            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            return target;
        }
    }
}
