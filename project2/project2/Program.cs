// See https://aka.ms/new-console-template for more information

using p2;
using System.Diagnostics;
using System.Text.RegularExpressions;

//פונקציה שמבצעת קריאה לדף אינטרנט, ומחזירה את ה-HTML שלו
async Task<string> Load(string url)
{
    HttpClient client = new HttpClient();
    var response = await client.GetAsync(url);
    var html = await response.Content.ReadAsStringAsync();
    return html;

}
var html = await Load("http://127.0.0.1:5500/homePage.html");// את ה-HTML של האתר מחזיר 

var cleanHtml = new Regex("\\s").Replace(html, " ");//מנקה את כל סוגי הרווחים הקיימים, ונחליף אותם במחרוזת ריקה.
var htmlLines = new Regex("<(.*?)>").Split(cleanHtml).Where(s => s.Length > 0).ToList();//חותכת את הקוד לפי הביטוי הרגולרי, לשורות נפרדות, רק למי שיש לו ערך מסוים.סימן שאלה הופך תביטוי ללא חמדן

var htmlElement = "<div id=\"my-id\" class=\"myclass1 myclass2\" width=\"100%\" >text</div>";//יוצרת אוביקט לשם הדוגמא:
var attributes = new Regex("([^\\s]*?)=\"(.*?)\"").Matches(htmlElement);// חותכת אותו בביטוי רגולרי , הפונציה מאצ-כל ההתאמות שמתאימות לביטוי הזה  
//([^\\s]*?)-הכל חוץ מרווח

HtmlElement myElement;
HtmlElement myRoot = null;
HtmlElement corrent = null;
string[] arrClasses;

for (int i=0; i<htmlLines.Count; i++)
{
    if (string.IsNullOrWhiteSpace(htmlLines[i]))
    {
        htmlLines.Remove(htmlLines[i]);
        i--;
    }
}
//Console.WriteLine(html);

//for(int i = 0; i < htmlLines.Count; i++)
//{
//    Console.WriteLine("thank you!!");
//}

for (int i = 1; i < htmlLines.Count; i++)
{
    //Console.WriteLine("talya");
    string firstWord = htmlLines[i].Split(" ")[0];

if (HtmlHelper.Instance.Arr1.Contains(firstWord) || HtmlHelper.Instance.Arr2.Contains(firstWord))
   {
        if (firstWord.Equals("html"))
        {
            myElement = new HtmlElement(firstWord);
            corrent = myElement;
            myRoot = myElement;
        }
        else
        {
            myElement = new HtmlElement(firstWord);
        }


        var myAttributes = new Regex(@"\b(?!class|id)\w+\s*=\s*""(.*?)""").Matches(htmlLines[i]);
        List<string> atr = new List<string>();
        foreach (Match item in myAttributes)
        {
            atr.Add(item.Value);
        }
        myElement.Attributes = atr;

        
        var myClasses = new Regex(@"class\s*=\s*""(.*?)""").Match(htmlLines[i]);
        if (myClasses.Success)
        {
            arrClasses = myClasses.Groups[1].Value.Split(' ');
            myElement.Classes = arrClasses;
        }

        var myDiv = new Regex(@"id\s*=\s*""(.*?)""").Match(htmlLines[i]);
        if (myDiv.Success)
        {
            myElement.Id = myDiv.Groups[1].Value;
        }

        bool flagg = false;
        for (int j = 0; j < HtmlHelper.Instance.Arr2.Length; j++)
        {
            if (HtmlHelper.Instance.Arr2[j] == firstWord)
            {
                flagg = true;
                break;
            }
        }
        if (!flagg)
        {
            string firstWordInLine = htmlLines[i + 1].Split(" ")[0];
            if (!firstWordInLine.StartsWith("/"))
                if (!HtmlHelper.Instance.Arr1.Contains(firstWordInLine) && !HtmlHelper.Instance.Arr2.Contains(firstWordInLine))
                {
                    myElement.InnerHtml = htmlLines[i+1].Trim();
                }
        }
        if (i != 1)
        {
            corrent.AddChild(myElement);
            corrent = myElement;
            if (HtmlHelper.Instance.Arr2.Contains(firstWord))
                corrent = corrent.Parent;
        }

    }
    else if (firstWord.StartsWith("/"))
        corrent = corrent.Parent;
    //myRoot.print(myRoot);

}//גמרנו את העץ


HashSet<HtmlElement> result=new HashSet<HtmlElement>();
Selector s = Selector.Toconvert("div #tali");

 myRoot.findElement(s, myRoot, result);
foreach (HtmlElement element in result)
{
    Console.WriteLine(element.Name);
}


Selector temp = s;








