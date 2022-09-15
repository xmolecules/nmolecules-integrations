using Microsoft.CodeAnalysis;

namespace NMolecules.Analyzers.RepositoryAnalyzers
{
    public static class Rules
    {
        public const string RepositoriesShouldNotUseServicesId = "XMoleculesRepository0001";
        
        public static readonly DiagnosticDescriptor RepositoriesShouldNotUseServicesRule = new(
            RepositoriesShouldNotUseServicesId,
            new LocalizableResourceString(nameof(Resources.RepositoryShouldNotUseServiceTitle),
                Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.RepositoryShouldNotUseServiceFormat),
                Resources.ResourceManager,
                typeof(Resources)),
            Category.DDD,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.RepositoryShouldNotUseServiceDescription),
                Resources.ResourceManager,
                typeof(Resources)));
    }
}