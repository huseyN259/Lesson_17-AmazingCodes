using System.Net.Mail;
using System.Text.RegularExpressions;

// Regex

class HN
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;

        string pattern = "[a-z A-Z]";
        string text = "nhNH";

        string pattern2 = @"^Nuran(259|925)$";
        string text2 = "Huseyn259";
        string text3 = "Nuran925";

        string pattern3 = @"^Nuran.*(259|925)$";
        string text4 = "Nuran <3 Huseyn";

        string pattern4 = "(Mr\\.? |Mrs\\.? |Miss |Ms\\.? )";
        string[] names = { "Mr. Henry Hunt", "Ms. Sara Samuels",
                                  "Abraham Adams", "Ms. Huseyn Nuran" };

        foreach (string name in names)
            Console.WriteLine(Regex.Replace(name, pattern4, string.Empty));

        Regex regex = new Regex(pattern);
        Console.WriteLine(regex.IsMatch(text));
        Console.WriteLine(Regex.IsMatch(text2, pattern2));
        Console.WriteLine(Regex.IsMatch(text3, pattern2));
        Console.WriteLine(Regex.IsMatch(text4, pattern3));

        string pattern5 = @"[a-z0-9]+@[a-z]+\.[a-z]{2,3}";
        Console.WriteLine(Regex.IsMatch("dsadsfd@gmail.ru", pattern5));

        try
        {
            MailAddress mailAddress = new("hsynnrn@mail.ru");
            Console.WriteLine("True");
        }
        catch (Exception)
        {
            Console.WriteLine("False");
        }
    }
}