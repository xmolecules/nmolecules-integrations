using Microsoft.CodeAnalysis;

namespace NMolecules.Analyzers.ValueObjectAnalyzers
{
    public static class Rules
    {
        public const string NoEntitiesInValueObjectsId = "XMoleculesValueObject0001";
        public const string NoServicesInValueObjectsId = "XMoleculesValueObject0002";
        public const string NoRepositoriesInValueObjectsId = "XMoleculesValueObject0003";
        public const string NoAggregateRootsInValueObjectsId = "XMoleculesValueObject0004";
        public const string ValueObjectsShouldBeImmutableId = "XMoleculesValueObject0005";
        public const string ValueObjectsMustImplementIEquatableId = "XMoleculesValueObject1001";
        public const string ValueObjectsShouldBeSealedId = "XMoleculesValueObject1002";

        public static readonly DiagnosticDescriptor ValueObjectMustNotUseEntityRule = new(NoEntitiesInValueObjectsId,
            new LocalizableResourceString(nameof(Resources.ValueObjectUsesEntityTitle),
                Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.ValueObjectUsesEntityMessageFormat),
                Resources.ResourceManager,
                typeof(Resources)),
            Category.DDD,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.ValueObjectUsesEntityDescription),
                Resources.ResourceManager,
                typeof(Resources)));

        public static readonly DiagnosticDescriptor ValueObjectMustNotUseServiceRule = new(NoServicesInValueObjectsId,
            new LocalizableResourceString(nameof(Resources.ValueObjectUsesServiceTitle),
                Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.ValueObjectUsesServiceMessageFormat),
                Resources.ResourceManager,
                typeof(Resources)),
            Category.DDD,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.ValueObjectUsesServiceDescription),
                Resources.ResourceManager,
                typeof(Resources)));

        public static readonly DiagnosticDescriptor ValueObjectMustNotUseRepositoryRule = new(NoRepositoriesInValueObjectsId,
            new LocalizableResourceString(nameof(Resources.ValueObjectUsesRepositoryTitle),
                Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.ValueObjectUsesRepositoryMessageFormat),
                Resources.ResourceManager,
                typeof(Resources)),
            Category.DDD,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.ValueObjectUsesRepositoryDescription),
                Resources.ResourceManager,
                typeof(Resources)));

        public static readonly DiagnosticDescriptor ValueObjectMustNotUseAggregateRootRule = new(NoAggregateRootsInValueObjectsId,
            new LocalizableResourceString(nameof(Resources.ValueObjectUsesAggregateRootTitle),
                Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.ValueObjectUsesAggregateRootMessageFormat),
                Resources.ResourceManager,
                typeof(Resources)),
            Category.DDD,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.ValueObjectUsesAggregateRootDescription),
                Resources.ResourceManager,
                typeof(Resources)));

        public static readonly DiagnosticDescriptor ValueObjectShouldBeImmutableRule = new(ValueObjectsShouldBeImmutableId,
            new LocalizableResourceString(nameof(Resources.ValueObjectShouldBeImmutableTitle),
                Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.ValueObjectShouldBeImmutableMessageFormat),
                Resources.ResourceManager,
                typeof(Resources)),
            Category.DDD,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.ValueObjectShouldBeImmutableDescription),
                Resources.ResourceManager,
                typeof(Resources)));

        public static readonly DiagnosticDescriptor ValueObjectMustImplementIEquatableRule = new(ValueObjectsMustImplementIEquatableId,
            new LocalizableResourceString(nameof(Resources.ValueObjectMustImplementIEquatableTitle),
                Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.ValueObjectMustImplementIEquatableMessageFormat),
                Resources.ResourceManager,
                typeof(Resources)),
            Category.DDD,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.ValueObjectMustImplementIEquatableDescription),
                Resources.ResourceManager,
                typeof(Resources)));

        public static readonly DiagnosticDescriptor ValueObjectShouldBeSealedRule = new(ValueObjectsShouldBeSealedId,
            new LocalizableResourceString(nameof(Resources.ValueObjectShouldBeSealedTitle),
                Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.ValueObjectShouldBeSealedMessageFormat),
                Resources.ResourceManager,
                typeof(Resources)),
            Category.DDD,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.ValueObjectShouldBeSealedDescription),
                Resources.ResourceManager,
                typeof(Resources)));
    }
}