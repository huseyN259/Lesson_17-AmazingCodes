#define Debug

namespace lesson_17_4;

using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Reflection and Attribute
// Pre-defined attributes
// User defined -> Custom

// [Obsolete]
// [Conditional]
// [CallerMemberName] ( C# 10 )
// [CallerArgumentExpression]


[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
class ColumnNameAttribute : Attribute
{
    public string? PropertyName { get; }

    public ColumnNameAttribute(string? propertyName)
    {
        PropertyName = propertyName;
    }
}

//[Obsolete("Kohnelmish, bunun evezine...", error: true)] // error in Main
[Obsolete("Kohnelmish, bunun evezine...", error: false)] // warning in Main
class Student
{
    [Obsolete("Kohnelmish, bunun evezine...", error: true)]
    [ColumnName("Identification")]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }

    public Student(int ıd, string? name, string? surname)
    {
        Console.WriteLine("Ctor");
    }
}

//[ColumnName("Identification")] // error
struct Location
{
    //[ColumnName("Identification")]
    public double Longitude { get; set; }
    public double Latitude { get; set; }

    [Conditional("Debug")]
    public void Display()
    {
        Console.WriteLine(Longitude);
        Console.WriteLine(Latitude);
    }
}

class HN
{
    static void Write(object obj, [CallerArgumentExpression("object")] string? msg = null) => Console.WriteLine($"Expression : {obj}");

    static void Main()
    {
        #region Reflection
        Assembly assembly = Assembly.GetExecutingAssembly();

        var types = assembly.GetTypes();

        //assembly.CreateInstance(types[0].FullName);

        foreach (var type in types)
        {
            Console.WriteLine(type.Name);
            //Console.WriteLine(type.FullName);

            foreach (var propInfo in type.GetProperties())
                Console.WriteLine(propInfo.Name);
        }
        #endregion



        #region Pre-defined attributes
        // Obsolete
        //Student student = new Student() { };

        // Conditional
        /*Location location = new Location();
        location.Display();*/

        // CallerMemberName, CallerArgumentExpression
        Console.WriteLine();
        Write(new object());
        Write("HUSEYNNURAN");
        Write(259 + 925);
        Write(() => { });
        int hn = 259;
        Write(hn);
        #endregion



        #region Custom attribute
        Console.WriteLine();
        var properties = typeof(Student).GetProperties();

        foreach (var property in properties)
        {
            if (Attribute.IsDefined(property, typeof(ColumnNameAttribute)))
                Console.WriteLine(property?.GetCustomAttribute<ColumnNameAttribute>()?.PropertyName);
            else
                Console.WriteLine(property.Name);
        }
        #endregion
    }
}