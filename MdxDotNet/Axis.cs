using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdxDotNet
{
    public class Axis
    {
        public int Ordinal { get; set; }
        public string LiteralSelector { get; set; }
        public bool NonEmpty { get; set; }

        public Axis(int ordinal, string literalSelector, bool nonEmpty = false)
        {
            Ordinal = ordinal;
            LiteralSelector = literalSelector;
            NonEmpty = nonEmpty;
        }
        public Axis(int ordinal, ISet set, bool nonEmpty = false)
        {
            Ordinal = ordinal;
            LiteralSelector = set.ToString();
            NonEmpty = nonEmpty;
        }
        public override string ToString()
        {
            return $"{(NonEmpty ? "NON EMPTY " : "")}{LiteralSelector} on {Ordinal}";
        }
    }
}
