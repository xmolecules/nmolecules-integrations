using Microsoft.CodeAnalysis;

namespace NMolecules.Analyzers.RepositoryAnalyzers
{
    public static class Rules
    {
        public const string RepositoriesMustNotUseServicesId = "XMoleculesRepository0001";
        
        public static readonly DiagnosticDescriptor RepositoriesMustNotUseServicesRule = new(
            RepositoriesMustNotUseServicesId,
            new LocalizableResourceString(nameof(Resources.RepositoryMustNotUseServiceTitle),
                Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.RepositoryMustNotUseServiceFormat),
                Resources.ResourceManager,
                typeof(Resources)),
            Category.DDD,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.RepositoryMustNotUseServiceDescription),
                Resources.ResourceManager,
                typeof(Resources)));
    }
}