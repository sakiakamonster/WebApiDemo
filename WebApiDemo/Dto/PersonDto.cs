using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Dto
{
    public class PersonDto
    {

        public int id  { get; set; }
        public string name { get; set; }

        public int age { get; set; }

        public long mobile { get; set; }

        public string address { get; set; }
    }
}

