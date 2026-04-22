using Microsoft.VisualBasic.CompilerServices;

namespace Exercises;

public class Contact
{
    private int id = 0;
    private static int autoInc = 1;
    private string name = "";
    private string phoneNumber = ""; // private List<string> phoneNumbers = null;
    private string address = "";

    public Contact(string name, string phoneNumber, string address = "")
    {
        this.id = autoInc++;

        this.name = name;
        this.phoneNumber = phoneNumber;
        this.address = address;
    }

    public int GetId() {  return id; }

    public string GetName() { return name; }
    public void SetName(string name)
    {
        if (name.Trim().Length != 0)
        {
            this.name = name;
        }
    }

    public string GetAddress() { return address; }
    public void SetAddress(string address)
    {
        if (address.Trim().Length != 0)
        {
            this.address = address;
        }
    }
    
    public string GetPhoneNumber() { return phoneNumber; }

    public void SetPhoneNumber(string phoneNumber)
    {
        this.phoneNumber = phoneNumber;
    }
}

public class ContactBook
{
    private List<Contact> contacts = new List<Contact>();

    public void AddContact(Contact contact)
    {
        if (contact != null) 
            contacts.Add(contact);
    }

    public Contact GetContactById(int id)
    {
        if (id < 0 || id >= contacts.Count)
            return null;
        
        int index = Exercise4.BinarySearch(contacts, id);

        if (index >= 0) return contacts[index];
        return null;
    }

    public void RemoveContactById(int id)
    {
        if (id < 0 || id >= contacts.Count)
            return;
        
        int index = Exercise4.BinarySearch(contacts, id);

        if (index >= 0) contacts.RemoveAt(index);
    }

    public void EditContactById(int id, string name = null, string phoneNumber = null, string address = null)
    {
        int index = Exercise4.BinarySearch(contacts, id);
        if (index < 0) return;

        if (name != null)
        {
            contacts[index].SetName(name);
        }
        if (phoneNumber != null)
        {
            contacts[index].SetPhoneNumber(phoneNumber);
        }

        if (address != null)
        {
            contacts[index].SetAddress(address);
        }
    }

    public void EditContactByName(string name, string newName = null, string phoneNumber = null, string address = null)
    {
        for (int i = 0; i < contacts.Count; i++)
        {
            if (contacts[i].GetName() == name)
            {
                if (newName != null)
                {
                    contacts[i].SetName(newName);
                }
                if (phoneNumber != null)
                {
                    contacts[i].SetPhoneNumber(phoneNumber);
                }

                if (address != null)
                {
                    contacts[i].SetAddress(address);
                }
            }
        }
    }
    
    public Contact[] GetAllContacts()
    {
        return contacts.ToArray();
    }
    
    public Dictionary<int, Contact> FindContactByNameOrNumber(string value)
    {
        int counter = 0;
        Dictionary<int, Contact> dict = new Dictionary<int, Contact>();
        foreach (var contact in contacts)
        {
            if (
                contact.GetName().StartsWith(value) ||
                contact.GetPhoneNumber().StartsWith(value)
            )
            {
                dict.Add(counter, contact);
                counter++;
            }
        }
        return dict;
    }
}

public class Exercise4
{
    public static int BinarySearch(List<Contact> list, int target)
    {
        int left = 0;
        int right = list.Count - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (list[mid].GetId() == target)
                return mid;

            if (list[mid].GetId() < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }
    
    static void PrintContact(Contact contact)
    {
        Console.WriteLine("--------------------");
        Console.WriteLine("ID: " + contact.GetId());
        Console.WriteLine("Name: " + contact.GetName());
        Console.WriteLine("Phone: " + contact.GetPhoneNumber());
        Console.WriteLine("Address: " + contact.GetAddress());
    }
    
    public static void Main(string[] args)
    {
        ContactBook contactBook = new ContactBook();

        while (true)
        {
            Console.WriteLine("\n=== CONTACT BOOK ===");
            Console.WriteLine("1. Add contact");
            Console.WriteLine("2. Remove contact by ID");
            Console.WriteLine("3. Edit contact by ID");
            Console.WriteLine("4. Search");
            Console.WriteLine("5. Show all");
            Console.WriteLine("6. Get contact by ID");
            Console.WriteLine("7: Edit contact by name");
            Console.WriteLine("0. Exit");

            Console.Write("Choose: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Phone: ");
                    string phone = Console.ReadLine();

                    Console.Write("Address: ");
                    string address = Console.ReadLine();

                    contactBook.AddContact(new Contact(name, phone, address));
                    Console.WriteLine("✅ Added!");
                    break;

                case "2":
                    Console.Write("Enter ID: ");
                    int idToRemove = int.Parse(Console.ReadLine());

                    contactBook.RemoveContactById(idToRemove);
                    Console.WriteLine("🗑 Removed!");
                    break;

                case "3":
                    Console.Write("Enter ID: ");
                    int idToEdit = int.Parse(Console.ReadLine());

                    Console.Write("New name (or empty): ");
                    string newName = Console.ReadLine();

                    Console.Write("New phone (or empty): ");
                    string newPhone = Console.ReadLine();

                    Console.Write("New address (or empty): ");
                    string newAddr = Console.ReadLine();

                    contactBook.EditContactById(
                        idToEdit,
                        string.IsNullOrWhiteSpace(newName) ? null : newName,
                        string.IsNullOrWhiteSpace(newPhone) ? null : newPhone,
                        string.IsNullOrWhiteSpace(newAddr) ? null : newAddr
                    );

                    Console.WriteLine("✏️ Updated!");
                    break;

                case "4":
                    Console.Write("Search: ");
                    string value = Console.ReadLine();

                    var results = contactBook.FindContactByNameOrNumber(value);

                    foreach (var c in results.Values)
                    {
                        PrintContact(c);
                    }
                    break;

                case "5":
                    var all = contactBook.GetAllContacts();
                    foreach (var c in all)
                    {
                        PrintContact(c);
                    }
                    break;
                
                case "6": 
                    Console.Write("Enter ID: ");
                    string contactId = Console.ReadLine();
                    int id = int.Parse(contactId);
                    var contact = contactBook.GetContactById(id);
                    PrintContact(contact);
                    break;
                case "7": 
                    Console.Write("Enter Name: ");
                    string nameToSearch = Console.ReadLine();
                    
                    Console.Write("New name (or empty): ");
                    string newName1 = Console.ReadLine();

                    Console.Write("New phone (or empty): ");
                    string newPhone1 = Console.ReadLine();

                    Console.Write("New address (or empty): ");
                    string newAddr1 = Console.ReadLine();
                    contactBook.EditContactByName(
                        nameToSearch,
                        string.IsNullOrWhiteSpace(newName1) ? null : newName1,
                        string.IsNullOrWhiteSpace(newPhone1) ? null : newPhone1,
                        string.IsNullOrWhiteSpace(newAddr1) ? null : newAddr1
                    );

                    Console.WriteLine("✏️ Updated!");
                    break;
                case "0":
                    return;

                default:
                    Console.WriteLine("❌ Wrong choice");
                    break;
            }
        }
    }   
}