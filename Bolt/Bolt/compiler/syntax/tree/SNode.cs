using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolt.compiler.syntax.tree
{
    public abstract class SNode
    {
        public abstract SyntaxKind Kind { get; }
        public abstract IEnumerable<SNode> GetChildrens();
    }
}
