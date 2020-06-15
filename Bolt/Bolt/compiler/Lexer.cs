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
                if (int.TryParse(text, out int iresult))
                    return new SyntaxToken(SyntaxKind.Integer, _position, text, iresult);
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
