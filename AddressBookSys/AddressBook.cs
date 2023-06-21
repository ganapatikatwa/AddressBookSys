using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSys
{
    public class AddressBook
    {

        public static List<Contact> contacts = new List<Contact>();
        public static Dictionary<string, List<Contact>> dictobj = new Dictionary<string, List<Contact>>();

        /// <summary>
        /// Adds the specified dictobj.
        /// </summary>
        /// <param name="dictobj">The dictobj.</param>
        public void Add(Dictionary<string, List<Contact>> dictobj)
        {
            Console.WriteLine("How Many Contacts Wants to Add Please Enter Here");
            int number = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                List<Contact> contacts = new List<Contact>();
                Contact addressBook = new Contact();
                Console.WriteLine("Enter First Name :");

                addressBook.FirstName = Console.ReadLine();

                var address = dictobj.Any(x => x.Key.Equals(addressBook.FirstName));

                if (address == false)
                {
                    Console.WriteLine("Enter Last Name");
                    addressBook.LastName = Console.ReadLine();

                    Console.WriteLine("Enter Address");
                    addressBook.Address = Console.ReadLine();

                    Console.WriteLine("Enter City");
                    addressBook.City = Console.ReadLine();

                    Console.WriteLine("Enter State");
                    addressBook.State = Console.ReadLine();

                    Console.WriteLine("Enter Phone Number");
                    addressBook.PhNumber = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter Zip Code");
                    addressBook.ZipCode = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter Email");
                    addressBook.Email = Console.ReadLine();

                    Console.WriteLine("Current Persons Details Added ->");
                    //Store addressBook object in contacts object

                    contacts.Add(addressBook);

                    dictobj.Add(addressBook.FirstName, contacts);

                }
                else
                {
                    Console.WriteLine("Details of Person Already Exist=>");
                }
            }
        }

        public void Display(Dictionary<string, List<Contact>> dictobj)
        {
            int count = 1;
            if (dictobj.Count > 0)
            {
                foreach (KeyValuePair<string, List<Contact>> pair in dictobj)
                {
                    foreach (Contact contacts in pair.Value)
                    {
                        Console.WriteLine("Contact of Person");
                        Console.WriteLine(pair.Key);

                        Console.WriteLine("First name :" + contacts.FirstName);

                        Console.WriteLine("Last name :" + contacts.LastName);

                        Console.WriteLine("Address :" + contacts.Address);

                        Console.WriteLine("City :" + contacts.City);

                        Console.WriteLine("State :" + contacts.State);

                        Console.WriteLine("ZipCode :" + contacts.ZipCode);

                        Console.WriteLine("Phone Number :" + contacts.PhNumber);

                        Console.WriteLine("Email :" + contacts.Email);
                        Console.WriteLine(":::::::::::::::::::::::::::::::::::::::");
                        count++;
                    }
                }
            }
        }


        public static void Edit(Dictionary<string, List<Contact>> dictobj)
        {

            List<Contact> contacts = new List<Contact>();
            Contact addressBook = new Contact();
            Console.WriteLine("To Edit Person Name Please Enter First Name:");

            string name = Console.ReadLine();

            if (dictobj.ContainsKey(name))
            {

                Console.WriteLine("Please Follow the Following Sequences to Edit:\n" +
                    "1)First Name\n" + "2)Last Name\n" + "3)Address\n" +
                   "4)City\n" + "5)State\n" + "6)Phone Number\n" + "7)Zip Code\n" +
                   "8)Email\n");

                int take = 1;

                if (take == 1)
                {
                    Console.WriteLine("Editing First Name:-");
                    addressBook.FirstName = Console.ReadLine().ToLower();

                    Console.WriteLine("Editing Last Name:-");
                    addressBook.LastName = Console.ReadLine();

                    Console.WriteLine("Editing Address:-");
                    addressBook.Address = Console.ReadLine();

                    Console.WriteLine("Editing City Name:-");
                    addressBook.City = Console.ReadLine();

                    Console.WriteLine("Editing State:-");
                    addressBook.State = Console.ReadLine();

                    Console.WriteLine("Editing Phone Number:-");
                    addressBook.PhNumber = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Editing Zip Code:-");
                    addressBook.ZipCode = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Editing Email:-");
                    addressBook.Email = Console.ReadLine();

                }
                else
                {
                    Console.WriteLine("Wrong input");
                }

                Console.WriteLine("Details Updated");
                //store again in Contact
                contacts.Add(addressBook);
                dictobj.Add(addressBook.FirstName, contacts);

            }
        }

        //search person using City or State

        public void SearchusingCityorState(Dictionary<string, List<Contact>> dictobj)
        {

            Console.WriteLine("To search Person Enter City or State:\n" +
                "1)Select City\n" + "2)Select State\n");

            //List<Contact> store = new List<Contact>();
            int Search = Convert.ToInt32(Console.ReadLine());

            switch (Search)
            {
                case 1:
                    Console.WriteLine("Enter City Name:");
                    string city = Console.ReadLine();

                    foreach (KeyValuePair<string, List<Contact>> person in dictobj)
                    {
                        contacts = person.Value;
                    }

                    var result = contacts.Any(x => x.City.Equals(city));

                    if (result)
                    {
                        var check = contacts.Where(x => x.City.Contains(city));
                        foreach (var item in check)
                        {
                            Console.WriteLine("The Persons First Name: => " + item.FirstName);
                            Console.WriteLine("City Name: => " + item.City);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Such City Found try Another City Name");
                    }
                    break;

                case 2:
                    Console.WriteLine("Enter State:");
                    string state = Console.ReadLine();

                    foreach (KeyValuePair<string, List<Contact>> persons in dictobj)
                    {
                        contacts = persons.Value;
                    }

                    var result1 = contacts.Any(x => x.State.Equals(state));
                    if (result1)
                    {
                        var check = contacts.Where(x => x.State.Contains(state));
                        foreach (var item in check)
                        {
                            Console.WriteLine("The Persons First Name: => " + item.FirstName);
                            Console.WriteLine("State Name: => " + item.State);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Such State Found try Another State");
                    }
                    break;

                default:
                    Console.WriteLine("No correct Option");
                    break;
            }
        }

        //Creating Details Method to Edit Add and Display

        public void ContactDetails()
        {
        Start:
            Console.WriteLine("Select Method Which you Want Check :\n" +
                "1)Add\n" + "2)Edit\n" + "3)SearchusingCityorState\n" + "4)Display\n");

            int check = Convert.ToInt32(Console.ReadLine());

            switch (check)
            {
                case 1:
                    Add(dictobj);
                    break;
                case 2:
                    Edit(dictobj);
                    break;
                case 3:
                    SearchusingCityorState(dictobj);
                    break;
                case 4:
                    Display(dictobj);
                    break;
                default:
                    Console.WriteLine("Wrong Input");
                    break;
            }
            goto Start;
        }
    }
}
