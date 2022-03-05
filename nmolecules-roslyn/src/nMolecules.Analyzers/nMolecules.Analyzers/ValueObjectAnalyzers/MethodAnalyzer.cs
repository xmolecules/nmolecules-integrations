using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using static NMolecules.Analyzers.ValueObjectAnalyzers.Diagnostics;

namespace NMolecules.Analyzers.ValueObjectAnalyzers
{
    public static class MethodAnalyzer
    {
        public static void AnalyzeMethod(SymbolAnalysisContext context)
        {
            var method = (IMethodSymbol) context.Symbol;
            if (IsProperty(method)) return;

            EnsureOnlyAllowedTypesAsParameters(context, method);
            EnsureOnlyAllowedTypesAsReturnValue(context, method);
        }

        private static bool IsProperty(IMethodSymbol method)
        {
            return method.MethodKind == MethodKind.PropertyGet || method.MethodKind == MethodKind.PropertySet;
        }

        private static void EnsureOnlyAllowedTypesAsReturnValue(SymbolAnalysisContext context, IMethodSymbol method)
        {
            if (!method.ReturnsVoid)
            {
                var type = method.ReturnType;
                EnsureTypeIsAllowed(context, method, type);
            }
        }

        private static void EnsureOnlyAllowedTypesAsParameters(SymbolAnalysisContext context, IMethodSymbol method)
        {
            foreach (var parameter in method.Parameters)
            {
                var parameterType = parameter.Type;
                EnsureTypeIsAllowed(context, parameter, parameterType);
            }
        }

        public static void AnalyzeDeclarations(SyntaxNodeAnalysisContext context)
        {
            var localDeclaration = (LocalDeclarationStatementSyntax) context.Node;
            var variable = localDeclaration.Declaration.Variables.Single();
            var declaredSymbol = (ILocalSymbol) context.SemanticModel.GetDeclaredSymbol(variable)!;
            EnsureTypeIsAllowed(context, declaredSymbol, declaredSymbol.Type);
        }
    }
}