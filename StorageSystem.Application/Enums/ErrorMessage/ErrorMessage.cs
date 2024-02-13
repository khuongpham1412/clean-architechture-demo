using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Enums.ErrorMessage
{
    public enum ErrorMessage
    {
        [Description("000000")] ValidationFailure = 0000,
        [Description("999999")] InternalServerError = 9999,
        [Description("200001")] Success = 200001,
        [Description("200002")] UnauthorizedAccess = 2000002,
        [Description("200003")] Forbidden = 2000003,
        [Description("200004")] UnsupportedMethod = 2000004,
        [Description("200005")] ReachedOutRateLimit = 2000005,
    }
}
