using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB
{
    public static class PasswordValidator
    {
        public const int MIN_PASSWORD_LENGTH = 8;

        public static bool IsValidPassword(string password, int minimumLength = MIN_PASSWORD_LENGTH)
        {
            if (!password.HasValue()) { return false; }
            if (!HasMinimumCharacters(password, minimumLength)) { return false; }

            return true;
        }

        public static bool HasMinimumCharacters(string password, int length = MIN_PASSWORD_LENGTH)
        {
            return password.Length >= length;
        }

        public static bool PasswordsMatch(string password, string confirmPassword)
        {
            return password.Equals(confirmPassword);
        }
    }
}
