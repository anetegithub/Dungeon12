﻿using System.Collections.Generic;
using System.Reflection;

namespace Dungeon
{
    public static class StringPathExtensions
    {
        public static string Embedded(this string path) => path.Replace(@"\", ".").Replace(@"/", ".");

        public static string PathImage(this string path) => Global.GameAssemblyName + ".Resources.Images." + path.Embedded();
        
        public static string PathPng(this string path) => path + ".png";


        private static Dictionary<string, string> imgPathCache = new Dictionary<string, string>();

        public static string ImgPath(this string img,string callingAsmName=default)
        {
            if(!imgPathCache.TryGetValue(img,out var imgPath))
            {
                imgPath = $"{callingAsmName ?? Assembly.GetCallingAssembly().GetName().Name}.Images.{img.Embedded()}";
                imgPathCache.Add(img, imgPath);                
            }

            return imgPath;
        }

        /// <summary>
        /// Алиас <see cref="ImgPath(string)"/> т.к. название неудачное
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static string PathAsmImg(this string img) => ImgPath(img, Assembly.GetCallingAssembly().GetName().Name);


        /// <summary>
        /// Вернёт имя сборки + строка
        /// <returns></returns>
        public static string AsmName(this string img, string between = "") => Assembly.GetCallingAssembly().GetName().Name + between.Embedded() + img.Embedded();

        /// <summary>
        /// Вернёт имя сборки + Resources + строка
        /// <returns></returns>
        public static string AsmNameRes(this string img, string between = "") => Assembly.GetCallingAssembly().GetName().Name + ".Resources." + between.Embedded() + img.Embedded();


        /// <summary>
        /// Assembly.Resources.Images.Path
        /// <returns></returns>
        public static string AsmImgRes(this string img, string between = "") => Assembly.GetCallingAssembly().GetName().Name + ".Resources.Images." + between.Embedded() + img.Embedded();

        public static string ImgRes(this string img) => ".Resources.Images." + img.Embedded();

        public static string AudioPathMusic(this string img, string between = "") => Assembly.GetCallingAssembly().GetName().Name + ".Resources.Audio.Music." + between.Embedded() + img.Embedded();

        public static string AudioPathSound(this string img, string between = "") => Assembly.GetCallingAssembly().GetName().Name + ".Resources.Audio.Sound." + between.Embedded() + img.Embedded();
    }
}