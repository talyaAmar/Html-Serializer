# Project 2 | HTML DOM Query Engine in .NET

## Project Description
A .NET-based engine for loading, parsing, and querying HTML DOM trees using simplified CSS selector syntax.  
The system includes a custom DOM tree model, selector parser, and advanced functions for DOM traversal and matching between elements and selector trees.

## Technologies Used
- **Programming Language:** C#
- **Framework:** .NET 8
- **Development Tools:** Visual Studio, LINQPad
- **HTML Parsing:** Custom DOM parser implementation (no external libraries)

## Key Features
- **HTML Loading** – Supports loading HTML from a file or URL and building a structured DOM tree.
- **Custom HTML Element Model** – Each node includes `TagName`, `Id`, a list of `Classes`, child elements, and a reference to its parent.
- **Selector Parsing** – Supports selectors by tag, `#id`, `.class`, and compound selectors like `div#main.card`.
- **Hierarchical Selectors** – Allows deep descendant queries, e.g., `div #section .highlight`.
- **DOM Navigation Functions**:
  - `Descendants()` – Returns all descendant elements using a **queue-based** breadth-first search (to avoid recursion depth issues).
  - `Ancestors()` – Collects all ancestors by following the parent chain.
- **Recursive Matching Engine** – Matches elements against selector tree structure recursively with clear stop conditions at each level.
- **Duplicate Prevention** – Uses `HashSet<HtmlElement>` to ensure unique query results.

## Additional Notes
- The descendant traversal uses a queue instead of recursion to avoid stack overflows with deep HTML trees.
- The matching algorithm between the selector tree and the element tree is recursive, with explicit stop conditions at every level for safety and correctness.

## Getting Started

### HTML Loading
You can use the `HtmlLoader` class to load HTML content from a URL or file:

```csharp
var html = await HtmlLoader.Load("https://example.com");
var root = HtmlParser.Parse(html);
```








# פרויקט 2 | מנוע שאילתות לעץ HTML ב־.NET

## תיאור הפרויקט
מנוע מבוסס .NET לטעינה, ניתוח ותשאול של עץ HTML באמצעות תחביר CSS Selector פשוט.  
המערכת כוללת מודל ייחודי לעץ DOM, מנגנון לפירוק סלקטורים, ופונקציות מתקדמות לניווט והתאמה בין עץ האלמנטים לעץ הסלקטורים.

## טכנולוגיות בשימוש
- **שפת תכנות:** ‎C#‎  
- **סביבת עבודה:** ‎.NET 8  
- **כלי פיתוח:** Visual Studio, LINQPad  
- **ניתוח HTML:** מימוש עצמאי לפירוק HTML

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


## הערות נוספות
- מנגנון החיפוש על הצאצאים משתמש בתור ולא ברקורסיה, למניעת קריסות stack בעת עצים עמוקים.
- מנגנון ההתאמה בין הסלקטור לעץ האלמנטים מבוסס על רקורסיה עם תנאי עצירה ברור בכל רמה.


## התקנה והרצה

### טעינת HTML
ניתן להשתמש במחלקת `HtmlLoader` לטעינת HTML מקובץ מקומי או כתובת URL:

```csharp
var html = await HtmlLoader.Load("https://example.com");
var root = HtmlParser.Parse(html);
```


