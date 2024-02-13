using StorageSystem.Application.Models.Unit.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Models.Unit.Ins
{
    public class CreateUnitInsDto : CreateOrUpdateUnitDto
    {
        public string Name { get; set; }
    }
}
