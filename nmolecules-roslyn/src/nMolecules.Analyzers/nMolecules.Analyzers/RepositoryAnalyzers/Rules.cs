using Microsoft.CodeAnalysis;

namespace NMolecules.Analyzers.RepositoryAnalyzers
{
    public static class Rules
    {
        private const string Category = "Design";
        public const string RepositoriesMustNotUseServicesId = "RepositoriesMustNotUseServices";
        
        public static readonly DiagnosticDescriptor RepositoriesMustNotUseServicesRule = new(
            RepositoriesMustNotUseServicesId,
            new LocalizableResourceString(nameof(Resources.RepositoryMustNotUseServiceTitle),
                Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.RepositoryMustNotUseServiceFormat),
                Resources.ResourceManager,
                typeof(Resources)),
            Category,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.RepositoryMustNotUseServiceDescription),
                Resources.ResourceManager,
                typeof(Resources)));
    }
}