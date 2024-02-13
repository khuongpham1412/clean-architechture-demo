﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Models.Bases
{
    public class Paging
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }
        
        public Paging()
        {
            PageNumber = 1;
            PageSize = 10;
        }
        public Paging(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
