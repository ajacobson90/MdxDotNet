using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdxDotNet
{
    public class Tuple
    {
        public List<string> Members { get; set; }
        public Tuple(params string[] members)
        {
            Members = members.ToList();
        }
        public Tuple Add(params string[] members)
        {
            foreach (var member in members)
                Members.Add(member);
            return this;
        }

        public Tuple Add(ISet set)
        {
            Members.Add(set.ToString());
            return this;
        }

        public override string ToString() => $"({string.Join(",", Members)})";
    }
}
