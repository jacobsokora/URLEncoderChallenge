using System;
using System.Collections.Generic;

namespace URLEncoder
{
    class Program
    {
        static Dictionary<string, string> conversions = new Dictionary<string, string>
        {
            {" ", "%20"},
            {"<", "%3C"},
            {">", "%3E"},
            {"#", "%23"},
            {"\"", "%22"},
            {";", "%3B"},
            {"/", "%2F"},
            {"?", "%3F"},
            {":", "%3A"},
            {"@", "%40"},
            {"&", "%26"},
            {"=", "%3D"},
            {"+", "%2B"},
            {"$", "%24"},
            {",", "%2C"},
            {"{", "%7B"},
            {"}", "%7D"},
            {"|", "%7C"},
            {"\\", "%5C"},
            {"^", "%5E"},
            {"[", "%5B"},
            {"]", "%5D"},
            {"`", "%60"}
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the URL Encoder!");

            do
            {
                Console.Write("Please enter the project name: ");
                string projectName = encode(getValidInput());
                Console.Write("Please neter the activity name: ");
                string activityName = encode(getValidInput());
                Console.WriteLine("https://companyserver.com/content/{0}/files/{1}/{1}Report.pdf", projectName, activityName);
                Console.Write("Would you like to encode another url? (y/n): ");
            } while (Console.ReadLine().ToLower().Equals("y"));
        }

        static string getValidInput() {
            bool valid = false;
            string input = null;
            while(!valid) 
            {
                input = Console.ReadLine();
                valid = true;
                foreach (char c in input.ToCharArray())
                {
                    if (Char.IsControl(c) || c == 0x7F)
                    {
                        Console.WriteLine("Input contained an invalid character, please re-enter: ");
                        valid = false;
                    }
                }
            }
            return input;
        }

        static string encode(string value)
        {
            value = value.Replace("%", "%25");
            foreach (var conversion in conversions)
            {
                value = value.Replace(conversion.Key, conversion.Value);
            }
            return value
        }
    }
}
