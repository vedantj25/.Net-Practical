class Q2 {  
        
    public static void Main(String[] args) {
        string input, fullName;
        string[] name;

        do
        {
            Console.WriteLine("Please enter a string:");
            input = Console.ReadLine();
    
            input = input.Trim();
            if (String.IsNullOrEmpty(input))
            {
                Console.WriteLine("Enter a valid string");
            }
        } while (String.IsNullOrEmpty(input));


        Console.WriteLine($"The length of the string \"{input}\" is {input.Length}");

        char lastChar = input[input.Length - 1];

        switch (lastChar)
        {
            case '.':
                Console.WriteLine("The sentence represents a declarative sentence.");
                break;
            case '!':
                Console.WriteLine("The sentence represents exclamation");
                break;
            case '?':
                Console.WriteLine("The sentence represents an interrogatory sentence");
                break;
            default:
                Console.WriteLine("The sentence is a normal sentence");
                break;
        }

        do
        {
            Console.WriteLine("\n\nEnter your full name:");
            fullName = Console.ReadLine();
            fullName = fullName.Trim();
            if (String.IsNullOrEmpty(fullName))
            {
                Console.WriteLine("Enter a valid name");
            }
        } while (String.IsNullOrEmpty(fullName));




        name = fullName.Split(' ');

        if (name.Length >= 2)
        {
            Console.WriteLine($"Name: {name[1]}, {name[0]}");
        }
        else if (name.Length == 1)
        {
            Console.WriteLine($"Name: {name[0]}");
        }
  }
}