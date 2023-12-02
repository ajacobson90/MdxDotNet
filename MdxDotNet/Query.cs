using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdxDotNet
{
    public class Query
    {
        public List<Axis> Axes { get; set; } = new List<Axis>();
        public Slicer Slicer { get;set; }
        public string DataSource { get; set; }
        public Query SubQuery { get; set; }
        public Query(string dataSource)
        {
            DataSource = dataSource;
        }
        public Query(Query subquery)
        {
            SubQuery = subquery;
        }
        public Query Axis(int ordinal, string literal, bool nonEmpty = false)
        {
            Axes.Add(new Axis(ordinal, literal, nonEmpty));
            return this;
        }
        public Query Axis(int ordinal, ISet set, bool nonEmpty = false)
        {
            Axes.Add(new Axis(ordinal, set, nonEmpty));
            return this;
        }
        public Query Where(string literal)
        {
            Slicer = new Slicer(literal);
            return this;
        }
        public Query Where(Tuple tuple)
        {
            Slicer = new Slicer(tuple);
            return this;
        }
        public override string ToString()
        {
            string source = SubQuery == null ? $"[{DataSource}]" : $"({SubQuery})";
            return $"SELECT\r\n" + string.Join(",\r\n", Axes.OrderBy(a => a.Ordinal).Select(a => a.ToString()))
                + $"\r\nFROM {source}\r\n{Slicer}";
        }
    }
}
