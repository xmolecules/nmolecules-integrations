using Microsoft.CodeAnalysis;

namespace NMolecules.Analyzers.EntityAnalyzers
{
    public static class Rules
    {
        private const string Category = "Design";
        public const string EntitiesMustNotUseRepositoriesId = nameof(EntitiesMustNotUseRepositoriesId);

        public static readonly DiagnosticDescriptor EntitiesMustNotUseRepositoriesRule = new(
            EntitiesMustNotUseRepositoriesId,
            new LocalizableResourceString(nameof(Resources.EntityMustNotUseRepositoryTitle),
                Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.EntityMustNotUseRepositoryFormat),
                Resources.ResourceManager,
                typeof(Resources)),
            Category,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.EntityMustNotUseRepositoryDescription),
                Resources.ResourceManager,
                typeof(Resources)));
    }
}