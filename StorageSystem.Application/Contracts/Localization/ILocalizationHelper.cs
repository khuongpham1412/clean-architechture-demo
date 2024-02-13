using StorageSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Contracts.Localization
{
    public interface ILocalizationHelper
    {
        ErrorMessageOutDto LocalizeError(LocalizationErrorMessageOutDto error);

        string GetLocalizeErrorMessage(LocalizationErrorMessageOutDto errorMessageDto);
    }
}
