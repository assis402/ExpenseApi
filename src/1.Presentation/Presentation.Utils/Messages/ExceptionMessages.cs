using System;

namespace Presentation.Utils.Messages
{
    public static class ExceptionMessages
    {
        public static string EXC001()
        {
            return "The {0} entity cannot be empty.";
        }

        public static string EXC002()
        {
            return "The {0} entity cannot be null.";
        }

        public static string EXC003()
        {
            return "The {0} parameter cannot be empty.";
        }

        public static string EXC004()
        {
            return "The {0} parameter cannot be null.";
        }

        public static string EXC005()
        {
            return "The {0} parameter must be at least {1} characters long.";
        }

        public static string EXC006()
        {
            return "The {0} parameter must have a maximum of {1} characters.";
        }

        public static string EXC007()
        {
            return "The {0} parameter entered is not valid.";
        }

        public static string EXC008()
        {
            return "The {0} parameter entered is not valid.";
        }

        public static string EXC009()
        {
            return "The Post request cannot be empty";
        }

        public static string EXC010()
        {
            return "The Post request cannot be null";
        }

        public static string EXC011()
        {
            return "The request body cannot be empty.";
        }

        public static string EXC012()
        {
            return "The request body cannot be null.";
        }

        public static string EXC013()
        {
            return "The {0} parameter must be {1} characters.";
        }

        public static string EXC014()
        {
            return "The following parameters are invalid:";
        }

        public static string EXC015()
        {
            return "The TaxNumber parameter must have 11 (CPF) or 14 (CNPJ) characters";
        }

        public static string EXC016()
        {
            return "No {0} with this identifier was found";
        }
       
        public static string EXC017()
        {
            return "The {0} parameter is not encrypteds.";
        }
    }
}