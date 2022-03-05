using System;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NMolecules.Analyzers.ValueObjectAnalyzers;

namespace NMolecules.Analyzers.ValueObjectCodeFixProvider
{
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(ValueObjectMustBeSealedCodeFixProvider))]
    [Shared]
    public class ValueObjectMustBeSealedCodeFixProvider : CodeFixProvider
    {
        private const string Title = "Make value object sealed";

        public sealed override ImmutableArray<string> FixableDiagnosticIds =>
            ImmutableArray.Create(Rules.ValueObjectsMustBeSealedId);

        public sealed override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

        public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);

            var diagnostic = context.Diagnostics.First(it => it.Id.Equals(Rules.ValueObjectsMustBeSealedId));
            var diagnosticSpan = diagnostic.Location.SourceSpan;
            var declaration = root!.FindToken(diagnosticSpan.Start).Parent!
                .AncestorsAndSelf()
                .OfType<TypeDeclarationSyntax>()
                .First();

            var makeClassSealed = CodeAction.Create(Title, it => MakeClassSealed(context.Document, declaration, it), Title);
            context.RegisterCodeFix(makeClassSealed, diagnostic);
            var implementedIEquatable = CodeAction.Create(Title, it => ImplementIEquatable(context.Document, declaration, it), Title);
            context.RegisterCodeFix(implementedIEquatable, diagnostic);
        }

        private Task<Document> ImplementIEquatable(
            Document contextDocument,
            TypeDeclarationSyntax declaration,
            CancellationToken it) =>
            throw new NotImplementedException();

        private static async Task<Document> MakeClassSealed(
            Document document,
            TypeDeclarationSyntax typeDecl,
            CancellationToken cancellationToken)
        {
            var newModifiers = typeDecl.AddModifiers(SyntaxFactory.Token(SyntaxKind.SealedKeyword));
            var syntaxRoot = await document.GetSyntaxRootAsync(cancellationToken);
            var syntaxRootWithReplacedModifiers = syntaxRoot!.ReplaceNode(typeDecl, newModifiers);
            return document.WithSyntaxRoot(syntaxRootWithReplacedModifiers);
        }
    }
}