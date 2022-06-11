using Microsoft.CodeAnalysis;

namespace NMolecules.Analyzers.AggregateRootAnalyzers
{
    public static class Rules
    {
        public const string AggregateRootsMustNotUseRepositoriesId = "AggregateRootsMustNotUseRepositories";
        public const string AggregateRootsMustNotUseServicesId = "AggregateRootsMustNotUseServices";

        public static readonly DiagnosticDescriptor AggregateRootsMustNotUseRepositoriesRule = new(
            AggregateRootsMustNotUseRepositoriesId,
            new LocalizableResourceString(nameof(Resources.AggregateRootMustNotUseRepositoryTitle),
                Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.AggregateRootMustNotUseRepositoryFormat),
                Resources.ResourceManager,
                typeof(Resources)),
            Category.DDD,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.AggregateRootMustNotUseRepositoryDescription),
                Resources.ResourceManager,
                typeof(Resources)));
        
        public static readonly DiagnosticDescriptor AggregateRootsMustNotUseServicesRule = new(
            AggregateRootsMustNotUseServicesId,
            new LocalizableResourceString(nameof(Resources.AggregateRootMustNotUseServiceTitle),
                Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.AggregateRootMustNotUseServiceFormat),
                Resources.ResourceManager,
                typeof(Resources)),
            Category.DDD,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.AggregateRootMustNotUseServiceDescription),
                Resources.ResourceManager,
                typeof(Resources)));
    }
}