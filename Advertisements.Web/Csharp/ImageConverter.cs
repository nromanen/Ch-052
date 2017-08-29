using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;

namespace Advertisements.Web.Csharp
{
    public static class ImageConverter
    {
        private const int WIDTH = 64;
        private const int HEIGHT = 64;
        public static Image ImgFromBytes(byte[] arrBytes)
        {
            Image img;
            using (MemoryStream stream = new MemoryStream(arrBytes))
            {
                img = Image.FromStream(stream);       
            }
            if (img.Height > HEIGHT || img.Width > WIDTH)
            {
                img = SqueezeImg(img);
            }
            return img;
        }
        public static byte[] BytesFromImg(Image img)
        {
            byte[] result;
            if (img.Height > HEIGHT || img.Width > WIDTH)
            {
                img = SqueezeImg(img);
            }
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                result = stream.ToArray();
            }
            return result;
        }

        public static Image SqueezeImg(Image img)
        {
            Image temp = new Bitmap(WIDTH, HEIGHT);
            using (Graphics graph = Graphics.FromImage(temp))
            {
                graph.FillRectangle(Brushes.Black, 0, 0, WIDTH, HEIGHT);
                graph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;

                float srcWidth = img.Width;
                float srcHeight = img.Height;

                if (srcWidth <= WIDTH && srcHeight <= HEIGHT)
                {
                    float left = (WIDTH - srcWidth) / 2;
                    float top = (HEIGHT - srcHeight) / 2;
                    graph.DrawImage(img, left, top, srcWidth, srcHeight);
                }
                else if ((srcWidth / srcHeight) > (WIDTH / HEIGHT))
                {
                    float cy = srcHeight / srcWidth * WIDTH;
                    float top = (HEIGHT - cy) / 2.0f;
                    if (top < 1.0f)
                        top = 0;
                    graph.DrawImage(img, 0, top, WIDTH, cy);
                }
                else
                {
                    float cx = srcWidth / srcHeight * HEIGHT;
                    float left = (WIDTH - cx) / 2.0f;
                    if (left < 1.0f)
                        left = 0;
                    graph.DrawImage(img, left, 0, cx, HEIGHT);
                }
                return temp;
            }           
        }

    }
}