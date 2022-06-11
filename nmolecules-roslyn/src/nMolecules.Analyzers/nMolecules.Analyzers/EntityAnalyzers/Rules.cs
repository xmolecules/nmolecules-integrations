using Microsoft.CodeAnalysis;

namespace NMolecules.Analyzers.EntityAnalyzers
{
    public static class Rules
    {
        public const string EntitiesMustNotUseRepositoriesId = "XMoleculesEntity0001";
        public const string EntitiesMustNotUseAggregateRootsId = "XMoleculesEntity0002";
        public const string EntitiesMustNotUseServicesId = "XMoleculesEntity0003";
        public const string EntitiesShouldHaveIdRuleId = "XMoleculesEntity0004";

        public static readonly DiagnosticDescriptor EntitiesMustNotUseRepositoriesRule = new(
            EntitiesMustNotUseRepositoriesId,
            new LocalizableResourceString(nameof(Resources.EntityMustNotUseRepositoryTitle),
                Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.EntityMustNotUseRepositoryFormat),
                Resources.ResourceManager,
                typeof(Resources)),
            Category.DDD,
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
            Category.DDD,
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
            Category.DDD,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.EntityMustNotUseServiceDescription),
                Resources.ResourceManager,
                typeof(Resources)));
        
        public static readonly DiagnosticDescriptor EntitiesShouldHaveIdRule = new(
            EntitiesShouldHaveIdRuleId,
            new LocalizableResourceString(nameof(Resources.EntityShouldHaveIdTitle),
                Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.EntityShouldHaveIdFormat),
                Resources.ResourceManager,
                typeof(Resources)),
            Category.DDD,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.EntityShouldHaveIdDescription),
                Resources.ResourceManager,
                typeof(Resources)));
    }
}