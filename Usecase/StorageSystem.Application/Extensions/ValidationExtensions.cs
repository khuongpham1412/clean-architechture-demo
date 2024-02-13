//using Microsoft.Extensions.Localization;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace StorageSystem.Application.Extensions
//{
//    public static class ValidationExtensions
//    {
//        private static string GetErrorMessage(string errorCode,
//            IStringLocalizer messageLocalizer,
//            IStringLocalizer placeholderLocalizer,
//            List<Tuple<object, object>>? arguments = null)
//        {
//            var message = messageLocalizer[errorCode].Value == errorCode
//                ? messageLocalizer[errorCode].Value
//                : placeholderLocalizer[errorCode].Value;
//            var parameters = new List<string>();

//            if(arguments is null || !arguments.Any()) return message;

//            foreach( var arg in arguments)
//            {
//                var parseExceptionType = Enum.Parse<ExceptionArgumentsType>(arg.Item2.ToString());
//            }
//        }
//    }
//}
