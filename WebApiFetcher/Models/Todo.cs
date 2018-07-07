using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiFetcher.Models
{
    public class Todo : IComparable
    {
        public int id { get; set; }
        public DateTime createdAt { get; set; }
        public string name { get; set; }
        public bool isComplete { get; set; }
        public int userId { get; set; }

        public int CompareTo(object obj)
        {
            return name.Length.CompareTo(obj.ToString().Length);
        }
    }
}
