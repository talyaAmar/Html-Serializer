using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace p2
{
    internal class HtmlElement
    {
        //מאפיינים
        public String Id { get; set; }
        public string Name { get; set; }
        public List<string> Attributes { get; set; }
        public string[] Classes { get; set; }
        public string InnerHtml { get; set; }

        public HtmlElement Parent { get; set; }
        public List<HtmlElement> Children { get; set; }

        //פעולה בונה
        public HtmlElement(string name)
        {
            this.Name = name;
            this.Id = null;
            this.Attributes = new List<string>();
            this.Classes = new string[20];
            this.InnerHtml = null;
            this.Children = new List<HtmlElement>();
            this.Parent = null;
        }
        public HtmlElement(string name, String id, string innerHtml, HtmlElement parent)
        {
            this.Name = name;
            this.Id = id;
            this.InnerHtml = innerHtml;
            this.Parent = parent;
            Attributes = new List<string>();
            Classes = new string[20];



            // אם יש Parent, נוסיף את התגית הזו כילד של ה-Parent
            if (parent != null)
                Parent.AddChild(this);

        }

        // הוספת ילד לתגית
        public void AddChild(HtmlElement child)
        {
            child.Parent = this;
            Children.Add(child);
        }

        public void print(HtmlElement root)
        {
            Console.WriteLine(root.Name);
            //     foreach (HtmlElement child in Children)
            //      print(child);
        }

        public IEnumerable<HtmlElement> Descendants()
        {
            Queue<HtmlElement> q = new Queue<HtmlElement>();
            List<HtmlElement> cost = new List<HtmlElement>();
            q.Enqueue(this);
            while (q.Count > 0)
            {
                HtmlElement head = q.Dequeue();
                // cost.Add(head); // הוספת כל איבר לרשימה
                yield return head;
                for (int i = 0; i < head.Children.Count; i++)
                {
                    q.Enqueue(head.Children[i]);
                }
            }
        }
        public List<HtmlElement> Ancestors()
        {
            List<HtmlElement> parentList = new List<HtmlElement>();
            HtmlElement h = this;
            while (h.Parent != null)
            {
                parentList.Add(h.Parent);
                h = h.Parent;
            }
            return parentList;
        }

        public void  findElement(Selector s, HtmlElement h, HashSet<HtmlElement> result)
        {
            if (result == null)
                result = new HashSet<HtmlElement> ();
            IEnumerable<HtmlElement> childOfElementList  = h.Descendants();
            List<HtmlElement> filter = new List<HtmlElement>();
            bool match = true;
            foreach (HtmlElement item in childOfElementList)
            {
                if (s.TagName != "" && item.Name != s.TagName)
                    match = false;
                if (s.Id != "" && item.Id != s.Id)
                    match = false;
                if (s.Classes != null && s.Classes.Any() && !s.Classes.All(c => item.Classes.Contains(c)))
                    match = false;
            
                if (match)
                {
                    filter.Add(item);

                    if(s.Child==null)
                        result.Add(item);
                }

                if(!match)
                    foreach (HtmlElement child in item.Children)
                        findElement(s, child, result);

                if (s.Child != null)
                {
                    foreach (HtmlElement i in filter)
                    {
                        foreach (HtmlElement child in i.Children)
                            findElement(s.Child, child, result);
                    }
                }
            }
         
        }

    }

}

