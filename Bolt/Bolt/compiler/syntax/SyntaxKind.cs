using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolt.compiler.syntax
{
    public enum SyntaxKind
    {
        Null,
        Whitespace,
        SByte,
        Byte,
        Short,
        UShort,
        Integer,
        UInteger,
        Long,
        ULong,
        Float,
        Identifier,
        Boolean,
        BadToken,
    }
}
