using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace NMolecules.Analyzers.Common
{
    public class MethodAnalyzer
    {
        private readonly Func<ISymbol, ITypeSymbol, IEnumerable<Diagnostic>> analyzeTypeUsageInSymbol;

        public MethodAnalyzer(Func<ISymbol, ITypeSymbol, IEnumerable<Diagnostic>> analyzeTypeUsageInSymbol)
        {
            this.analyzeTypeUsageInSymbol = analyzeTypeUsageInSymbol;
        }

        public void AnalyzeMethod(SymbolAnalysisContext context)
        {
            var method = (IMethodSymbol)context.Symbol;
            if (IsProperty(method))
            {
                return;
            }

            EnsureOnlyAllowedTypesAsParameters(context, method);
            EnsureOnlyAllowedTypesAsReturnValue(context, method);
        }

        private static bool IsProperty(IMethodSymbol method) => method.MethodKind is MethodKind.PropertyGet or MethodKind.PropertySet;

        private void EnsureOnlyAllowedTypesAsReturnValue(SymbolAnalysisContext context, IMethodSymbol method)
        {
            if (!method.ReturnsVoid)
            {
                var type = method.ReturnType;
                var violations = analyzeTypeUsageInSymbol(method, type);
                context.ReportDiagnostics(violations);
            }
        }

        private void EnsureOnlyAllowedTypesAsParameters(SymbolAnalysisContext context, IMethodSymbol method)
        {
            foreach (var parameter in method.Parameters)
            {
                var parameterType = parameter.Type;
                var violations = analyzeTypeUsageInSymbol(parameter, parameterType);
                context.ReportDiagnostics(violations);
            }
        }

        public void AnalyzeDeclarations(SyntaxNodeAnalysisContext context)
        {
            var localDeclaration = (LocalDeclarationStatementSyntax)context.Node;
            var variable = localDeclaration.Declaration.Variables.Single();
            var declaredSymbol = (ILocalSymbol)context.SemanticModel.GetDeclaredSymbol(variable)!;
            var violations = analyzeTypeUsageInSymbol(declaredSymbol, declaredSymbol.Type);
            context.ReportDiagnostics(violations);
        }
    }
}