using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Utilities
{
    public class Generate
    {
        /// <summary>
        /// Store Global Staff ID
        /// </summary>
        public static string StaffID = "";

        /// <summary>
        /// Store Global Staff Name
        /// </summary>
        public static string StaffName = "";

        /// <summary>
        /// Store Global Staff Role
        /// </summary>
        public static string StaffRole = "";

        /// <summary>
        /// Generate ID
        /// </summary>
        /// <param name="_base"></param>
        /// <returns></returns>
        public static string GenerateID(string _base)
        {
            string id = "";

            switch (_base)
            {
                case "OD":
                case "INV":
                    id = _base + new Random().Next(100000).ToString("D5");
                    break;
                case "A":
                case "O":
                case "AVT":
                case "KH":
                case "NV":
                    id = _base + new Random().Next(1000).ToString("D3");
                    break;
            }

            return id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GeneratePassword(int length)
        {
            if (length <= 4)
                length = 5;
            
            Random random = new Random();

            // Base case
            const string UPPERCASE_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUYWXYZ";
            const string LOWERCASE_CHARACTERS = "abcdefhijklmnopqrstuywxyz";
            const string SPECIAL_CHARACTERS = "!@#$%^&*";
            const string NUMBERS = "0123456789";

            string result = "";

            result += UPPERCASE_CHARACTERS[random.Next(UPPERCASE_CHARACTERS.Length)];
            result += LOWERCASE_CHARACTERS[random.Next(LOWERCASE_CHARACTERS.Length)];
            result += SPECIAL_CHARACTERS[random.Next(SPECIAL_CHARACTERS.Length)];
            result += NUMBERS[random.Next(NUMBERS.Length)];

            string allCharacters = UPPERCASE_CHARACTERS + LOWERCASE_CHARACTERS + SPECIAL_CHARACTERS + NUMBERS;
            for (int i = 4; i < length; i++)
            {
                result += allCharacters[random.Next(allCharacters.Length)];
            }

            return result;
        }

        /// <summary>
        /// Generate Username Account
        /// </summary>
        /// <param name="fullname"></param>
        /// <returns></returns>
        public static string GenerateUsername(string fullname)
        {
            string result = "";

            string[] parts = fullname.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            result += parts[parts.Count() - 1];

            for (int i = 0; i < parts.Count() - 1; i++)
            {
                result += parts[i][0];
            }

            result = result.ToLower() + new Random().Next(100).ToString();

            return result;
        }

        /// <summary>
        /// Generate Email
        /// </summary>
        /// <returns></returns>
        public static string GenerateEmail(string fullname)
        {
            return GenerateUsername(fullname) + AppConst.EMAIL_ADDRESS;
        }
    }
}
