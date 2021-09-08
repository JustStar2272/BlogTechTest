using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogTechTest.Models
{
    public class Topic
    {
        public int Id { get; set; }

        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
        public string Tags { get; set; } = "";
        public string Category { get; set; } = "";


        public DateTime Created { get; set; } = DateTime.Now;
    }
}
