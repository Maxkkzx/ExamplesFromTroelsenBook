static void SwitchOnEnumExample()
{
    Console.Write("Enter your favorite day of the week: ");
    DayOfWeek favDay;
    try
    {
        favDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), Console.ReadLine());
    }
    catch
    {
        Console.WriteLine("Bad input!");
        return;
    }

    switch (favDay)
    {
        case DayOfWeek.Sunday:
            Console.WriteLine("Football!");
            break;

        case DayOfWeek.Monday:
            Console.WriteLine("Another day, another dollar.");
            break;

        case DayOfWeek.Tuesday:
            Console.WriteLine("At least it is not Monaday.");
            break;

        case DayOfWeek.Wednesday:
            Console.WriteLine("A fine day.");
            break;

        case DayOfWeek.Thursday:
            Console.WriteLine("Almost Friday...");
            break;

        case DayOfWeek.Friday:
            Console.WriteLine("Yes, Friday rules!");
            break;

        case DayOfWeek.Saturday:
            Console.WriteLine("Great day indeed.");
            break;

    }
}


SwitchOnEnumExample();
Console.WriteLine();