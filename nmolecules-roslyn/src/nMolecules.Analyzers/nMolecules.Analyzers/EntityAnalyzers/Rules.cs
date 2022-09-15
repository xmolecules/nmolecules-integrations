using Microsoft.CodeAnalysis;

namespace NMolecules.Analyzers.EntityAnalyzers
{
    public static class Rules
    {
        public const string EntitiesShouldNotUseRepositoriesId = "XMoleculesEntity0001";
        public const string EntitiesShouldNotUseAggregateRootsId = "XMoleculesEntity0002";
        public const string EntitiesShouldNotUseServicesId = "XMoleculesEntity0003";
        public const string EntitiesShouldHaveIdRuleId = "XMoleculesEntity0004";

        public static readonly DiagnosticDescriptor EntitiesShouldNotUseRepositoriesRule = new(
            EntitiesShouldNotUseRepositoriesId,
            new LocalizableResourceString(nameof(Resources.EntityShouldNotUseRepositoryTitle),
                Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.EntityShouldNotUseRepositoryFormat),
                Resources.ResourceManager,
                typeof(Resources)),
            Category.DDD,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.EntityShouldNotUseRepositoryDescription),
                Resources.ResourceManager,
                typeof(Resources)));

        public static readonly DiagnosticDescriptor EntitiesShouldNotUseAggregateRootsRule = new(
            EntitiesShouldNotUseAggregateRootsId,
            new LocalizableResourceString(nameof(Resources.EntityShouldNotUseAggregateRootTitle),
                Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.EntityShouldNotUseAggregateRootFormat),
                Resources.ResourceManager,
                typeof(Resources)),
            Category.DDD,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.EntityShouldNotUseAggregateRootDescription),
                Resources.ResourceManager,
                typeof(Resources)));
        
        public static readonly DiagnosticDescriptor EntitiesShouldNotUseServicesRule = new(
            EntitiesShouldNotUseServicesId,
            new LocalizableResourceString(nameof(Resources.EntityShouldNotUseServiceTitle),
                Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.EntityShouldNotUseServiceFormat),
                Resources.ResourceManager,
                typeof(Resources)),
            Category.DDD,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.EntityShouldNotUseServiceDescription),
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