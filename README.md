# Project 2 | HTML Query Engine in .NET

## Project Description
A .NET-based engine for loading, parsing, and querying HTML trees using simplified CSS selector syntax.  
The project includes a custom DOM tree model, a query parsing mechanism, and advanced functions for navigating and matching elements against selector trees.

## Technologies Used
- **Programming Language:** ‎C#‎  
- **Development Environment:** ‎.NET 8  
- **Development Tools:** Visual Studio, LINQPad  
- **HTML Parsing:** HtmlAgilityPack (or custom implementation for parsing HTML)

## Key Features
- **HTML Loading** – Support for loading HTML from files or URLs and generating the DOM structure.
- **Custom Element Model** – Includes TagName, Id, Classes, Children, and Parent references.
- **Selector Parsing** – Support for




# פרויקט 3 | מנוע שאילתות לעץ HTML ב־.NET

## תיאור הפרויקט
מנוע מבוסס .NET לטעינה, ניתוח ותשאול של עץ HTML באמצעות תחביר CSS Selector פשוט.  
המערכת כוללת מודל ייחודי לעץ DOM, מנגנון לפירוק סלקטורים, ופונקציות מתקדמות לניווט והתאמה בין עץ האלמנטים לעץ הסלקטורים.

## טכנולוגיות בשימוש
- **שפת תכנות:** ‎C#‎  
- **סביבת עבודה:** ‎.NET 8  
- **כלי פיתוח:** Visual Studio, LINQPad  
- **ניתוח HTML:** ספריית HtmlAgilityPack *(או מימוש עצמאי לפירוק HTML)*

## תכונות עיקריות
- **טעינת HTML** – תמיכה בטעינה מקובץ או כתובת URL ויצירת מבנה DOM.
- **מודל אלמנט מותאם** – כולל TagName, Id, רשימת מחלקות (Classes), רשימת ילדים והפניה לאלמנט האב.
- **פירוק סלקטורים** – תמיכה בסלקטורים מבוססי תגית, מזהה (`#id`), מחלקה (`.class`), וסלקטורים משולבים כמו `div#main.card`.
- **תמיכה בסלקטורים היררכיים** – ביצוע חיפושים בעומק, לדוגמה: `div #section .highlight`.
- **פונקציות ניווט ב-DOM**:
  - `Descendants()` – החזרת רשימת כל הצאצאים בעזרת תור (Queue), למניעת עומק רקורסיה.
  - `Ancestors()` – החזרת כל האבות על בסיס שרשרת ההורים.
- **מנוע התאמה ריקורסיבי** – איתור אלמנטים בהתאם למבנה היררכי של הסלקטור.
- **מניעת כפילויות** – שימוש ב-`HashSet<HtmlElement>` כדי להבטיח תוצאה ייחודית.

## התקנה והרצה

### טעינת HTML
ניתן להשתמש במחלקת `HtmlLoader` לטעינת HTML מקובץ מקומי או כתובת URL:

```csharp
var html = await HtmlLoader.Load("https://example.com");
var root = HtmlParser.Parse(html);

