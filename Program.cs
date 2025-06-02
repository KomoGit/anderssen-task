bool app_run = true;
List<int> array_of_input = [];


while (app_run)
{
    StartupMenu();

    try
    {
        string? user_input = Console.ReadLine();
        string parsed_input = user_input.ToLower();

        switch (parsed_input)
        {
            case "1":
                FirstTest();
                Console.WriteLine("Press any key to continue.");
                user_input = Console.ReadLine();
                break;
            case "2":
                SecondTest();
                Console.WriteLine("Press any key to continue.");
                user_input = Console.ReadLine();
                break;
            case "3":
                ThirdTest();
                Console.WriteLine("Press any key to continue.");
                user_input = Console.ReadLine();
                break;
            case "quit":
                Shutdown();
                break;
            case "q":
                Shutdown();
                break;
            default:
                Console.WriteLine("Unknown input detected, try again");
                break;
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void FirstTest()
{
    Console.WriteLine("Insert a number: ");
    var user_input = Console.ReadLine();

    var is_num = int.TryParse(user_input, out int num);
    if (!is_num)
    {
        Console.WriteLine("Not a number.");
        return;
    }

    switch (num)
    {
        case > 7:
            Console.WriteLine("Hello");
            break;
        default:
            Console.WriteLine("Goodbye!");
            break;
    }
}

void SecondTest()
{
    Console.WriteLine("Insert a name: ");
    var user_input = Console.ReadLine();
    var parsed_input = user_input.ToLower();

    switch (parsed_input)
    {
        case "john":
            Console.WriteLine("Hello, John");
            break;
        default:
            Console.WriteLine("There is no such name");
            break;
    }
}

void ThirdTest()
{
    bool input_incomplete = true;

    Console.WriteLine("Insert an array of numbers: ");
    Console.WriteLine("Write \"stop\" to complete the insertion.");

    while (input_incomplete)
    {
        var user_input = Console.ReadLine();
        var parsed_input = user_input.ToLower();

        if (parsed_input == "stop")
        {
            input_incomplete = false;
            break;
        }

        var is_num = int.TryParse(user_input, out int num);
        if (!is_num)
        {
            Console.WriteLine("Not a number.");
        }
        else
        {
            if (!string.IsNullOrEmpty(parsed_input))
            {
                if (!array_of_input.Contains(num))
                {
                    array_of_input.Add(num);
                }
                else
                {
                    Console.WriteLine("The number is already present in the list.");
                }
            }
            else if (num == 0 || num < 0)
            {
                Console.WriteLine("Must be above 0.");
                return;
            }
            else
            {
                Console.WriteLine("Invalid input");
                return;
            }
        }
    }
    PrintOutNumbers();
}

void PrintOutNumbers()
{
    if (array_of_input.Count == 0)
    {
        Console.WriteLine("Atleast 1 number must be inserted in the list!");
    }
    else
    {
        foreach (var item in array_of_input)
        {
            if (item % 3 == 0)
            {
                Console.WriteLine($"{item} is a multiple of three");
            }
        }
        array_of_input.Clear();
    }
}

void Shutdown()
{
    Console.WriteLine("Goodbye!");
    app_run = false;
}

void StartupMenu()
{
    Console.Clear();
    Console.WriteLine("Please select one of the following below: or press q or quit to leave");
    Console.WriteLine("1) If the entered number is greater than 7, then print \"Hello\"");
    Console.WriteLine("2) If the entered name matches John, then print \"Hello, John\" if not, then output \"There is no such name.\"");
    Console.WriteLine("3) There is numeric array at the input, it is necessary to output array elements that are multiples of 3");
}