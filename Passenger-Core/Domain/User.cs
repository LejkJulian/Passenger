
using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.Domain
{//
    public class User
    {
        public Guid ID { get; protected set; }
        public string Email { get;protected set; }
        public string UserName { get; protected set; }
        public string LastName { get; protected set; }
        public string Password { get; protected set; }
        public string Role { get; protected set; }
        public string Salt { get; protected set; }
        public string Name { get; protected set; }      
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdateAt { get; protected set; }


        protected User()
        {

        }
        public User(string email,string username, string password, string salt)
        {//zrobic walidacje danych
            ID = Guid.NewGuid();
            //EmailValidation(email);
            Email = email;
            //IsNullOrWhiteSpaceOrEmpty(username);
            UserName = username;
          //  if (!PasswordValidation(password))
          //      throw new Exception("Password is invalid.");
            Password = password;
            Salt = salt;
            CreatedAt = DateTime.UtcNow;

        }

        public static string IsNullOrWhiteSpaceOrEmpty( string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                throw new Exception($"{word}is null or have white space");
            }
            if (string.IsNullOrEmpty(word))
            {
                throw new Exception($"{word}is null or empty");
            }
            return word;
        }
        public string EmailValidation(string email)
        {

            if (email == null)
                throw new ArgumentNullException($" Email is null.");
            if (!email.Contains("@"))
                throw new FormatException($"Email is wrong, must contain @");
            return email;
        }
        public bool PasswordValidation(string password)
        {
            const int MIN_LENGTH = 4;
            const int MAX_LENGTH = 15;

            if (password == null)
            {
                throw new ArgumentNullException();


            }
            bool meetsLengthRequirements = password.Length >= MIN_LENGTH && password.Length <= MAX_LENGTH;
            bool hasUpperCaseLetter = false;
            bool hasLowerCaseLetter = false;
            bool hasDecimalDigit = false;


            if (meetsLengthRequirements)
            {
                foreach (char c in password)
                {
                    if (char.IsUpper(c)) hasUpperCaseLetter = true;
                    else if (char.IsLower(c)) hasLowerCaseLetter = true;
                    else if (char.IsDigit(c)) hasDecimalDigit = true;
                }
            }

            bool isValid = meetsLengthRequirements
                        && hasUpperCaseLetter
                        && hasLowerCaseLetter
                        && hasDecimalDigit
                        ;
            return isValid;
        }
    }
}
