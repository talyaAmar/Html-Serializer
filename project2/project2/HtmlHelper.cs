using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;


namespace p2
{
    internal class HtmlHelper
    { 
        private readonly static HtmlHelper _instance = new HtmlHelper();//משתנה סטטי מסוג המחלקה שהוא גם פרטי וגם אא לערוך אותו, ואיתחלנו אותו
        public static HtmlHelper Instance => _instance;//משתנה סטטי שמחזיר את המשתנה למעלה
        public string[] Arr1 { get; set; }
        public string[] Arr2 { get; set; }
        private HtmlHelper()
        {

            var a = File.ReadAllText("C:\\Users\\user\\Desktop\\myProj\\project2\\project2\\HtmlTags.json");
            Arr1 = JsonSerializer.Deserialize<string[]>(a);
            var b = File.ReadAllText("C:\\Users\\user\\Desktop\\myProj\\project2\\project2\\HtmlVoidTags.json");
            Arr2 = JsonSerializer.Deserialize<string[]>(b);
            // arr1 = new string[144];
            // arr2 = new string[14];
            // int i = 0;
            //foreach (var line in File.ReadLines("HtmlTags.json"))
            // {
            //     arr1[i++]=Regex.Replace(line, @"[^A-Za-z]+", String.Empty);
            // }

            // int j = 0;
            // foreach (var line in File.ReadLines("HtmlTags.json"))
            // {
            //     arr2[j++]=Regex.Replace(line, @"[^A-Za-z]+", String.Empty);
            // }

            // Console.WriteLine(arr1);



        }
    }
}

               
