using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    public static class StringBulderExtensions
    {
        public static StringBuilder AppendFormattedLine(this StringBuilder @this, string format, params object[] args)
            => @this.AppendFormat(format, args).AppendLine();

        public static StringBuilder AppendLineWhen(this StringBuilder @this, Func<bool> predicate, string value)
            => predicate()
            ? @this.AppendLine(value)
            : @this;

        public static StringBuilder AppendWhen(this StringBuilder @this, Func<bool> predicate, Func<StringBuilder, StringBuilder> operationToDo)
           => predicate()
           ? operationToDo(@this)
           : @this;

        public static StringBuilder AppendSequence<T>(this StringBuilder @this, IEnumerable<T> options, Func<StringBuilder, T, StringBuilder> operationToDo)
           => options.Aggregate(@this, operationToDo);
    }
}
