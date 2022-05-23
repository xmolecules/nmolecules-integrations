using Microsoft.CodeAnalysis;

namespace NMolecules.Analyzers.EntityAnalyzers
{
    public static class Rules
    {
        private const string Category = "Design";
        public const string EntitiesMustNotUseRepositoriesId = "EntitiesMustNotUseRepositories";
        public const string EntitiesMustNotUseAggregateRootsId = "EntitiesMustNotUseAggregateRoots";
        public const string EntitiesMustNotUseServicesId = "EntitiesMustNotUseServices";

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

        public static readonly DiagnosticDescriptor EntitiesMustNotUseAggregateRootsRule = new(
            EntitiesMustNotUseAggregateRootsId,
            new LocalizableResourceString(nameof(Resources.EntityMustNotUseAggregateRootTitle),
                Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.EntityMustNotUseAggregateRootFormat),
                Resources.ResourceManager,
                typeof(Resources)),
            Category,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.EntityMustNotUseAggregateRootDescription),
                Resources.ResourceManager,
                typeof(Resources)));
        
        public static readonly DiagnosticDescriptor EntitiesMustNotUseServicesRule = new(
            EntitiesMustNotUseServicesId,
            new LocalizableResourceString(nameof(Resources.EntityMustNotUseServiceTitle),
                Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.EntityMustNotUseServiceFormat),
                Resources.ResourceManager,
                typeof(Resources)),
            Category,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.EntityMustNotUseServiceDescription),
                Resources.ResourceManager,
                typeof(Resources)));
    }
}