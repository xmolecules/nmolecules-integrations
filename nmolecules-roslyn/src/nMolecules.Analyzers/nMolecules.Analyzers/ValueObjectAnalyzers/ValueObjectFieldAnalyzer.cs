using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using NMolecules.Analyzers.Common;

namespace NMolecules.Analyzers.ValueObjectAnalyzers
{
    public class ValueObjectFieldAnalyzer : FieldAnalyzer
    {
        public ValueObjectFieldAnalyzer()
            : base(AnalyzeField)
        {
        }

        private static IEnumerable<Diagnostic> AnalyzeField(IFieldSymbol symbol, ITypeSymbol type)
        {
            return Diagnostics.AnalyzeTypeUsageInSymbol(symbol, type).Concat(EnsureFieldIsReadonly(symbol));
        }

        private static IEnumerable<Diagnostic> EnsureFieldIsReadonly(IFieldSymbol fieldSymbol)
        {
            if (!(fieldSymbol.IsReadOnly || fieldSymbol.IsConst))
            {
                yield return fieldSymbol.ViolatesImmutability();
            }
        }
    }
}