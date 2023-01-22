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

        private float _disThreshold; // dissimilality theshold
        private int _textureRadius; // 11x11のテクスチャなら5。
        private int level = 16; // GLCMを作るときのグレースケールのレベル
        private Color black = Color.FromArgb(0, 0, 0);
        private Color white = Color.FromArgb(255, 255, 255);

        public int DisZassou; // 雑草のdissimilality
        public int DisBokusou;  // 牧草のdissimilality

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

            DisZassou = CalcDis(zassouTexture);
            DisBokusou = CalcDis(bokusouTexture);
            _disThreshold = (DisZassou + DisBokusou) / 2;

            _sourceData = _source.LockBits(
                new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
        }

        ~MyUtil()
        {
            _source.UnlockBits(_sourceData);
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

            int[,] clipped = new int[_textureRadius * 2 + 1, _textureRadius * 2 + 1];
            int ic = 0;

            unsafe
            {
                byte* sourceDataPtr = (byte*)_sourceData.Scan0;
                for (int i = x - _textureRadius; i <= x + _textureRadius; i++)
                {
                    int jc = 0;
                    for (int j = y - _textureRadius; j <= y + _textureRadius; j++)
                    {
                        //clipped[ic, jc] = _sourceColors[i, j].G;
                        clipped[ic, jc] = *(sourceDataPtr + 3 * (i + j * width) + 1);
                        jc++;
                    }
                    ic++;
                }
            }
            int dis = CalcDis(clipped);

            return IsZassouDis(dis) ? true : false;
        }

        private bool IsZassouDis(int dis)
        {
            return (dis < _disThreshold) ? true : false;
        }

        private bool IsKusa(Color c)
        {
            int z = -441 * c.R + 811 * c.G - 385 * c.B;
            return z > 10000 ? true : false;
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

        private int CalcDisFromGLCM(int[,] source)
        {
            int res = 0;
            for (int i = 0; i < level; i++)
            {
                for (int j = 0; j < level; j++)
                {
                    res += source[i, j] * Math.Abs(i - j);
                }
            }
            return res;
        }

        private int CalcDis(Bitmap source)
        {
            int[,] sourceInt = Bitmap2GrayInt(source);
            int[,] normalizedSource = Normalize(sourceInt);
            int[,] glcm = CalcGLCM(normalizedSource);
            return CalcDisFromGLCM(glcm);
        }
        public int CalcDis(int x, int y)
        {
            int[,] clipped = new int[_textureRadius * 2 + 1, _textureRadius * 2 + 1];
            for (int i = x - _textureRadius; i <= x + _textureRadius; i++)
            {
                for (int j = y - _textureRadius; j <= y + _textureRadius; j++)
                {
                    clipped[i - (x - _textureRadius), j - (y - _textureRadius)] = _sourceColors[i, j].G;
                }
            }
            return CalcDis(clipped);
        }
        private int CalcDis(int[,] source)
        {
            int[,] normalizedSource = Normalize(source);
            int[,] glcm = CalcGLCM(normalizedSource);
            return CalcDisFromGLCM(glcm);
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
    }
}
