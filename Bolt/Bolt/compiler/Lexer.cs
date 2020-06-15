using Bolt.compiler.syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolt.compiler
{
    public sealed class Lexer
    {
        public Lexer(string input)
        {
            _text = input;
        }

        private string _text;
        private int _position = 0;
        private char Current => Peek(0);
        private char Lookahead => Peek(1);
        private char Peek(int offset)
        {
            int peekage = _position + offset;
            if (peekage < _text.Length)
                return _text[peekage];
            else
                return '\0';
        }

        public SyntaxToken Lex()
        {
            var start = _position;

            if (char.IsWhiteSpace(Current))
            {
                while (char.IsWhiteSpace(Current))
                    _position++;

                return new SyntaxToken(SyntaxKind.Whitespace, _position, " ", null);
            }

            if (char.IsDigit(Current))
            {
                while (char.IsDigit(Current))
                    _position++;

                var length = _position - start;
                var text = _text.Substring(start, length);
                if (sbyte.TryParse(text, out sbyte sbresult))
                    return new SyntaxToken(SyntaxKind.SByte, _position, text, sbresult);
                if (byte.TryParse(text, out byte bresult))
                    return new SyntaxToken(SyntaxKind.Byte, _position, text, bresult);
                if (short.TryParse(text, out short sresult))
                    return new SyntaxToken(SyntaxKind.Short, _position, text, sresult);
                if (ushort.TryParse(text, out ushort usresult))
                    return new SyntaxToken(SyntaxKind.UShort, _position, text, usresult);
                if (int.TryParse(text, out int iresult))
                    return new SyntaxToken(SyntaxKind.Integer, _position, text, iresult);
                if (uint.TryParse(text, out uint uiresult))
                    return new SyntaxToken(SyntaxKind.UInteger, _position, text, uiresult);
                if (long.TryParse(text, out long lresult))
                    return new SyntaxToken(SyntaxKind.Long, _position, text, lresult);
                if (ulong.TryParse(text, out ulong ulresult))
                    return new SyntaxToken(SyntaxKind.ULong, _position, text, ulresult);
            }

            if (char.IsLetter(Current))
            {
                while (char.IsLetter(Current))
                    _position++;

                var length = _position - start;
                var text = _text.Substring(start, length);
                if (bool.TryParse(text, out bool bresult))
                    return new SyntaxToken(SyntaxKind.Boolean, _position, text, bresult);
            }

            return new SyntaxToken(SyntaxKind.BadToken, _position, null, null);
        }
    }
}
