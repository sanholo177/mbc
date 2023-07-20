using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MYB101.Logic
{
    public static class ImageResizer
    {
        public static string Resize(string image, int height, int width, ResizeType mode)
        {
            var path = string.Format("/ImageGen.ashx?image={0}&width={1}&height={2}", image, width, height);

            switch (mode)
            {
                case ResizeType.Constrain:
                    path += "&constrain=true";
                    break;
                case ResizeType.Crop:
                    path += "&crop=resize";
                    break;
            }
            return path;
        }
    }

    public enum ResizeType
    {
        Crop = 1,
        Constrain = 2
    }
}