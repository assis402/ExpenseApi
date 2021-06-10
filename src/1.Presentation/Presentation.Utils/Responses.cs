using System;
using System.Collections.Generic;

namespace Presentation.Utils
{
    public class Responses
    {
        public static AppResult SuccessMessage(string message)
        {
            return new AppResult
            {
                Message = message,
                Success = true,
                Data = null
            };
        }
        
        public static AppResult SuccessMessage(dynamic data)
        {
            return new AppResult
            {
                Message = null,
                Success = true,
                Data = data
            };
        }

        public static AppResult SuccessMessage(string message, dynamic data)
        {
            return new AppResult
            {
                Message = message,
                Success = true,
                Data = data
            };
        }

        public static object SuccessMessage(object p, object clinicalUnit)
        {
            throw new NotImplementedException();
        }

        public static AppResult ApplicationErrorMessage()
        {
            return new AppResult
            {
                Message = "Ocorreu algum erro interno na aplicação, por favor tente novamente.",
                Success = false,
                Data = null
            };
        }

        public static AppResult ErrorMessage(string message)
        {
            return new AppResult
            {
                Message = message,
                Success = false,
                Data = null
            };
        }

        public static AppResult ErrorMessage(string message, IReadOnlyCollection<string> errors)
        {
            return new AppResult
            {
                Message = message,
                Success = false,
                Data = errors
            };
        }

        public static AppResult UnauthorizedErrorMessage()
        {
            return new AppResult
            {
                Message = "A combinação de login e senha está incorreta!",
                Success = false,
                Data = null
            };
        }
    }
}