using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TBlockSharer.Models
{
    public class Index
    {
        public IEnumerable<string> BlockedUsers { get; set; }
        public IEnumerable<string> SharedWithUsers { get; set; }
        public IEnumerable<string> ImportedUsers { get; set; }
    }
}