using System;

namespace AddressBookSys
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book System");

            AddressBook newaddress = new AddressBook();
            newaddress.ContactDetails();
        }
    }
}