using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdxDotNet
{
    public class Slicer
    {
        public List<ISet> Sets { get; set; } = new List<ISet>();
        public string Literal { get; set; }
        public Slicer Add(ISet set)
        {
            Sets.Add(set);
            return this;
        }
        public Slicer(string literal)
        {
            Literal = literal;
        }

        public Slicer(Tuple tuple)
        {
            Literal = tuple.ToString();
        }

        public override string ToString() => $"WHERE ({Literal})";
    }
}
