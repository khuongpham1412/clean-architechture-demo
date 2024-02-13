using StorageSystem.Application.Models.Category.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Models.Category.Ins
{
    public class CreateCategoryInsDto : CreateOrUpdateCategoryInsDto
    {
        public string Name { get; set; }
    }
}
