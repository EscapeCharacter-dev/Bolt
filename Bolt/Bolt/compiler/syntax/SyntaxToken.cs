using Bolt.compiler.syntax.tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolt.compiler.syntax
{
    public class SyntaxToken : SNode
    {
        public SyntaxToken(SyntaxKind kind, int position, string text, object value)
        {
            Kind = kind;
            Position = position;
            Text = text;
            Value = value;
        }

        public override SyntaxKind Kind { get; }
        public int Position { get; }
        public string Text { get; }
        public object Value { get; }
        public override IEnumerable<SNode> GetChildrens()
        {
            return Enumerable.Empty<SNode>();
        }
    }
}
