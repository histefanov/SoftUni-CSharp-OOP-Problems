using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Manager : Employee
    {
        public Manager(string _name, ICollection<string> _documents)
            : base(_name)
        {
            this.Documents = new List<string>(_documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override string GetInfo()
        {
            var sb = new StringBuilder();
            sb
                .AppendLine(this.Name)
                .Append(string.Join(Environment.NewLine, this.Documents));

            return sb.ToString();
        }
    }
}
