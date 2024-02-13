using StorageSystem.Application.Contracts.Localization;
using StorageSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Features.Localization
{
    public class LocalizationHelper : ILocalizationHelper
    {
        public string GetLocalizeErrorMessage(LocalizationErrorMessageOutDto errorMessageDto)
        {
            throw new NotImplementedException();
        }

        public ErrorMessageOutDto LocalizeError(LocalizationErrorMessageOutDto error)
        {
            throw new NotImplementedException();
        }
    }
}
