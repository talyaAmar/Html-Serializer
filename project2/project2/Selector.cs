using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace p2
{
    internal class Selector
    {
        public string TagName { get; set; }
        public String Id { get; set; }
        public List<string> Classes { get; set; }
        public Selector Parent { get; set; }
        public Selector Child { get; set; }

        public Selector()
        {
            TagName = "";
            Id = "";
            Classes = new List<string>();
            Parent = null;
            Child = null;
        }
        public static Selector Toconvert(String str)
        {
            string[] arr = str.Split(" ");
            Selector root = new Selector();
            Selector correntSelctor = new Selector();
            //string pattern = @"([^#\.]+|[#\.])";

            for (int i = 0; i < arr.Length; i++)
            {
                string word=arr[i];
                string classi = "";
                for (int j = 0; j < word.Length; j++)
                {
                 
                    if (word[j]=='#')
                    {
                        int k;
                        for(k = j+1; k < word.Length && word[k]!='.';k++)
                        correntSelctor.Id += word[k];
                        j = k - 1;
                    }
                    else if (word[j]=='.')
                    {
                        int k=j;
                             classi+= word.Substring(k+1);
                        string[]classes= classi.Split(',');
                        for(int t=0; t < classes.Length;t++)
                            correntSelctor.Classes.Add(classes[t]);
                        j = str.Length;
                    }
                    else
                    {
                        int k;
                        string newTagName = "";
                        for (k = j ; k < word.Length && word[k] != '.' && word[k]!='#'; k++)
                            newTagName+= word[k];
           
                        if (HtmlHelper.Instance.Arr1.Contains(newTagName) || HtmlHelper.Instance.Arr2.Contains(newTagName))
                        {
                            correntSelctor.TagName = newTagName;
                        }
                        j = k - 1;
                    }
                    if (i == 0)// אם הוא הראשון והיחיד , השורש שווה לנוכחי.
                        root = correntSelctor;
                    if (i <arr.Length-1)//אם יהיה לו עוד ילדים, אני מגדירה סלקטור חדש, הילד של הנוכחי יהיה החדש,ואם הוא הראשון במערך אחרי שהוספתי לו ילד אני מגדירה את השורש
                    {
                    Selector s=new Selector();
                        correntSelctor.Child = s;
                        s.Parent = correntSelctor;
                        if (i == 0)
                            root = correntSelctor;
                        //root.Child = s;
                        correntSelctor = s;
                        
                    }
                    
                
                }
            }
            return root;
        }

        //public void print()
        //{
        //    Console.WriteLine("selector:  ");
        //    if (!string.IsNullOrEmpty(TagName))
        //        Console.WriteLine("tagNmae:" + this.TagName);
        //    if (!string.IsNullOrEmpty(Id))
        //        Console.WriteLine("id:" + this.Id);
        //    if (Classes != null)
        //        Console.WriteLine("class:");
        //    for (int i = 0; i < this.Classes.Count; i++)
        //    {
        //        Console.Write(this.Classes[i] + ' ');
        //    }
        //    if (this.Child != null)
        //        this.Child.print();
        //}


    }
}
