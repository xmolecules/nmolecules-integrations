using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using NMolecules.DDD;

namespace NMolecules.Analyzers
{
    public static class SymbolExtensions
    {
        public static bool Is<TAttribute>(this ITypeSymbol type) where TAttribute : Attribute
        {
            var attributes = type.GetAttributes();
            return attributes.Any(it => it.AttributeClass!.Name.Equals(typeof(TAttribute).Name));
        }
        
        public static bool IsEntity(this ITypeSymbol type)
        {
            var attributes = type.GetAttributes().ToArray();
            return attributes.Any(it => it.AttributeClass!.Name.Equals(nameof(EntityAttribute)));
        }

        public static bool IsService(this ITypeSymbol type)
        {
            var attributes = type.GetAttributes().ToArray();
            return attributes.Any(it => it.AttributeClass!.Name.Equals(nameof(ServiceAttribute)));
        }

        public static bool IsRepository(this ITypeSymbol type)
        {
            var attributes = type.GetAttributes().ToArray();
            return attributes.Any(it => it.AttributeClass!.Name.Equals(nameof(RepositoryAttribute)));
        }

        public static bool IsAggregateRoot(this ITypeSymbol type)
        {
            var attributes = type.GetAttributes().ToArray();
            return attributes.Any(it => it.AttributeClass!.Name.Equals(nameof(AggregateRootAttribute)));
        }

        public static bool IsEnum(this ITypeSymbol symbol) => symbol.TypeKind == TypeKind.Enum;

        public static Diagnostic Diagnostic(
            this ISymbol symbol,
            DiagnosticDescriptor descriptor,
            params object[] parameters) =>
            Microsoft.CodeAnalysis.Diagnostic.Create(descriptor, symbol.Locations[0], parameters);
    }
}