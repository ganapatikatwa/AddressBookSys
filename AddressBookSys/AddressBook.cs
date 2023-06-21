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
        /// <summary>
        /// Displays the specified dictobj.
        /// </summary>
        /// <param name="dictobj">The dictobj.</param>
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

        //
        public static void Edit(Dictionary<string, List<Contact>> dictobj)
        {
            Contact addressBook = new Contact();
            List<Contact> contacts = new List<Contact>();

            Console.WriteLine("To Edit Person Name Please Enter First Name:");

            string name = Console.ReadLine();
            if (dictobj.ContainsKey(name))
            {
                Console.WriteLine("Please Select Options to Edit Details:\n" +
                    "1)First Name\n" + "2)Last Name\n" + "3)Address\n" +
                    "4)City\n" + "5)State\n" + "6)Phone Number\n" + "7)Zip Code\n" +
                    "8)Email\n");

                int take = Convert.ToInt32(Console.ReadLine());

                switch (take)
                {
                    case 1:
                        Console.WriteLine("Editing First Name:-");
                        addressBook.FirstName = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Editing Last Name:-");
                        addressBook.LastName = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Editing Address:-");
                        addressBook.Address = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Editing City Name:-");
                        addressBook.City = Console.ReadLine();
                        break;
                    case 5:
                        Console.WriteLine("Editing State:-");
                        addressBook.State = Console.ReadLine();
                        break;
                    case 6:
                        Console.WriteLine("Editing Phone Number:-");
                        addressBook.PhNumber = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 7:
                        Console.WriteLine("Editing Zip Code:-");
                        addressBook.ZipCode = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 8:
                        Console.WriteLine("Editing Email:-");
                        addressBook.Email = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Wrong Input!!Try Again");
                        break;


                }
                Console.WriteLine("Details Updated");
                //store again in Contact
                contacts.Add(addressBook);
                dictobj.Add(addressBook.FirstName, contacts);

            }

        }

        //Creating Details Method to Edit Add and Display

        public void ContactDetails()
        {
            Console.WriteLine("Select Method Which you Want Check :\n" +
                "1)Add\n" + "2)Edit\n" + "3)Display\n");

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
                    Display(dictobj);
                    break;
                default:
                    Console.WriteLine("Wrong Input");
                    break;


            }

        }

    }
}
