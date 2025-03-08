﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAppData
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }  
    }
}
