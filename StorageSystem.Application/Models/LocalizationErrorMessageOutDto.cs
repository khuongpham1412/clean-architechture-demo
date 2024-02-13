using StorageSystem.Application.Enums;
using StorageSystem.Application.Enums.ErrorMessage;
using StorageSystem.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Models
{
    public class LocalizationErrorMessageOutDto
    {
        public string ErrorCode { get; set; }
        public List<Tuple<object, LocalizationErrorMessageOutType>> ErrorObjects { get; set; }
        public string? DynamicCode { get; set; }

        public LocalizationErrorMessageOutDto() 
        {
            this.ErrorCode = string.Empty;
            this.ErrorObjects = new List<Tuple<object, LocalizationErrorMessageOutType>>();
        }

        public LocalizationErrorMessageOutDto(ErrorMessage errorMessage)
        {
            this.ErrorCode = errorMessage.ToCode();
            this.ErrorObjects = new List<Tuple<object, LocalizationErrorMessageOutType>>();
        }

        public LocalizationErrorMessageOutDto(string errorCode)
        {
            this.ErrorCode = errorCode;
            this.ErrorObjects = new List<Tuple<object, LocalizationErrorMessageOutType>>();
        }

        public LocalizationErrorMessageOutDto(ErrorMessage errorMessage,
            List<Tuple<object, LocalizationErrorMessageOutType>> arguments)
        {
            this.ErrorCode = errorMessage.ToCode();
            this.ErrorObjects = arguments;
        }

        public LocalizationErrorMessageOutDto(string errorCode,
            List<Tuple<object, LocalizationErrorMessageOutType>> arguments)
        {
            this.ErrorCode = errorCode;
            this.ErrorObjects = arguments;
        }
    }
}
