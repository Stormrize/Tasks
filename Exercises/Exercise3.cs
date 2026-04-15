namespace Exercises;

public class Exercise3
{
    // 1
    public static List<string> ArrOfWords(string text)
    {
        return text.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    public static void Main(string[] args)
    {
        string text = "Hello world this is   a  test";
        List<string> arr = ArrOfWords(text);
        PhoneNumbers phoneNumbers = new PhoneNumbers();
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1: Add a phone number");
            Console.WriteLine("2: Remove a phone number");
            Console.WriteLine("3: Edit yout phone number");
            Console.WriteLine("4: Find a number");
            Console.WriteLine("5: Display phone numbers");
            Console.WriteLine("6: Exit");
            string option = Console.ReadLine();
            while (!int.TryParse(option, out int result))
            {
                Console.WriteLine("Wrong option");
                option = Console.ReadLine();
            }
            if (option == "6") break;
            phoneNumbers.ValidateAndExecute(option);
        }
    }
}
// 2
class PhoneNumbers
{
    private Dictionary<string, string> phoneNumbers;

    public PhoneNumbers()
    {
        phoneNumbers = new Dictionary<string, string>();
    }

    public void AddPhoneNumber(string name, string phoneNumber)
    {
        if (phoneNumbers.ContainsKey(name))
        {
            Console.WriteLine("Name already exists");
            return;
        }
        int phoneNumberLength = phoneNumber.Length;
        if (name.Length > 2 && phoneNumberLength > 9 && phoneNumberLength < 12 && phoneNumber.All(char.IsDigit))
        {
            phoneNumbers.Add(name, phoneNumber);
        }
        else
        {
            Console.WriteLine("Invalid name or phone number");
        }
    }
    public void RemovePhoneNumber(string name)
    {
        phoneNumbers.Remove(name);
    }
    public void EditPhoneNumber(string name, string newPhoneNumber)
    {
        int phoneNumberLength = newPhoneNumber.Length;
        if (!phoneNumbers.ContainsKey(name))
        {
            Console.WriteLine("Name not found");
            return;
        }
        if (phoneNumberLength > 9 && phoneNumberLength < 12)
        {
            phoneNumbers[name] = newPhoneNumber;
        }
        else
        {
            Console.WriteLine("Invalid phone number");
        }
    }

    public void FindPhoneNumber(string name)
    {
        bool flag = false;
        foreach (var entry in phoneNumbers)
        {
            if (entry.Key.StartsWith(name))
            {
                Console.WriteLine($"Name: {entry.Key}, Phone Number: {entry.Value}");
                flag = true;
            }
        }
        if (!flag)
            Console.WriteLine("Name not found");
    }

    public void DisplayPhoneNumbers()
    {
        foreach (var entry in phoneNumbers)
        {
            Console.WriteLine($"Name: {entry.Key}, Phone Number: {entry.Value}");
        }
    }

    public void ValidateAndExecute(string option)
    {
        switch (option)
        {
            case "1":
                Console.WriteLine("Enter a name:");
                string nameToAdd = Console.ReadLine();
                Console.WriteLine("Enter a phone number:");
                string phoneNumberToAdd = Console.ReadLine();
                AddPhoneNumber(nameToAdd, phoneNumberToAdd);
                break;
            case "2":
                Console.WriteLine("Enter a name:");
                string nameToRemove = Console.ReadLine();
                RemovePhoneNumber(nameToRemove);
                break;
            case "3":
                Console.WriteLine("Enter a name:");
                string nameToEdit = Console.ReadLine();
                Console.WriteLine("Enter a phone number:");
                string newPhoneNumber = Console.ReadLine();
                EditPhoneNumber(nameToEdit, newPhoneNumber);
                break;
            case "4":
                Console.WriteLine("Enter a name :");
                string nameToFind = Console.ReadLine();
                FindPhoneNumber(nameToFind);
                break;
            case "5":
                DisplayPhoneNumbers();
                break;
            default:
                Console.WriteLine("Wrong option");
                break;
        }
    }
}