using Microsoft.CodeAnalysis;

namespace NMolecules.Analyzers.AggregateRootAnalyzers
{
    public static class Rules
    {
        public const string AggregateRootsMustNotUseRepositoriesRuleId = "XMoleculesAggregateRoot0001";
        public const string AggregateRootsMustNotUseServicesRuleId = "XMoleculesAggregateRoot0002";
        public const string AggregateRootsShouldHaveIdRuleId = "XMoleculesAggregateRoot0003";

        public static readonly DiagnosticDescriptor AggregateRootsMustNotUseRepositoriesRule = new(
            AggregateRootsMustNotUseRepositoriesRuleId,
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
            AggregateRootsMustNotUseServicesRuleId,
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