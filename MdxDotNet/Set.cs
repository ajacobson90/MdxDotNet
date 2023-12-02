namespace MdxDotNet
{
    public class Set : ISet
    {
        public List<string> Members { get; set; }
        public Set(params string[] members)
        {
            Members = members.ToList();
        }

        public Set Add(string member)
        {
            Members.Add(member);
            return this;
        }

        public override string ToString() => "{" + string.Join(", ", Members) + "}";
    }

    public class CrossJoinedSet : ISet
    {
        public List<Set> Sets { get; set; }
        public CrossJoinedSet(params Set[] sets)
        {
            Sets = sets.ToList();
        }
        public CrossJoinedSet Add(Set set)
        {
            Sets.Add(set);
            return this;
        }

        public override string ToString() => string.Join("\r\n* ", Sets.Select(s => s.ToString()));
    }
}