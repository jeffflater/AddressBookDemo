using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace AddressBook.Lib.Extenstions
{
    public static class ImageExtensions
    {
        public static string ToBase64StringAsBmp(this Image image)
        {
            return ImageToBase64(image, ImageFormat.Bmp);
        }

        public static string ToBase64StringAsGif(this Image image)
        {
            return ImageToBase64(image, ImageFormat.Gif);
        }

        public static string ToBase64StringAsIcon(this Image image)
        {
            return ImageToBase64(image, ImageFormat.Icon);
        }

        public static string ToBase64StringAsJpeg(this Image image)
        {
            return ImageToBase64(image, ImageFormat.Jpeg);
        }

        public static string ToBase64StringAsPng(this Image image)
        {
            return ImageToBase64(image, ImageFormat.Png);
        }

        public static string ToBase64StringAsTiff(this Image image)
        {
            return ImageToBase64(image, ImageFormat.Tiff);
        }

        public static string ToBase64StringAsEmf(this Image image)
        {
            return ImageToBase64(image, ImageFormat.Emf);
        }

        public static string ToBase64StringAsExif(this Image image)
        {
            return ImageToBase64(image, ImageFormat.Exif);
        }

        public static string ToBase64StringAsWmf(this Image image)
        {
            return ImageToBase64(image, ImageFormat.Wmf);
        }

        private static string ImageToBase64(Image image, ImageFormat format)
        {
            using (var ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                var imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                var base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }
    }
}
