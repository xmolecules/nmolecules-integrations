using Microsoft.CodeAnalysis;

namespace NMolecules.Analyzers.AggregateRootAnalyzers
{
    public static class Rules
    {
        public const string AggregateRootsShouldNotUseRepositoriesRuleId = "XMoleculesAggregateRoot0001";
        public const string AggregateRootsShouldNotUseServicesRuleId = "XMoleculesAggregateRoot0002";
        public const string AggregateRootsShouldHaveIdRuleId = "XMoleculesAggregateRoot0003";

        public static readonly DiagnosticDescriptor AggregateRootsShouldNotUseRepositoriesRule = new(
            AggregateRootsShouldNotUseRepositoriesRuleId,
            new LocalizableResourceString(nameof(Resources.AggregateRootShouldNotUseRepositoryTitle),
                Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.AggregateRootShouldNotUseRepositoryFormat),
                Resources.ResourceManager,
                typeof(Resources)),
            Category.DDD,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.AggregateRootShouldNotUseRepositoryDescription),
                Resources.ResourceManager,
                typeof(Resources)));
        
        public static readonly DiagnosticDescriptor AggregateRootsShouldNotUseServicesRule = new(
            AggregateRootsShouldNotUseServicesRuleId,
            new LocalizableResourceString(nameof(Resources.AggregateRootShouldNotUseServiceTitle),
                Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.AggregateRootShouldNotUseServiceFormat),
                Resources.ResourceManager,
                typeof(Resources)),
            Category.DDD,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.AggregateRootShouldNotUseServiceDescription),
                Resources.ResourceManager,
                typeof(Resources)));
        
        public static readonly DiagnosticDescriptor AggregateRootsShouldHaveIdRule = new(
            AggregateRootsShouldHaveIdRuleId,
            new LocalizableResourceString(nameof(Resources.AggregateRootShouldHaveIdTitle),
                Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.AggregateRootShouldHaveIdFormat),
                Resources.ResourceManager,
                typeof(Resources)),
            Category.DDD,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.AggregateRootShouldHaveIdDescription),
                Resources.ResourceManager,
                typeof(Resources)));
    }
}