﻿using Microsoft.CodeAnalysis;

namespace NMolecules.Analyzers.ValueObjectAnalyzers
{
    public static class Rules
    {
        public const string ValueObjectsMustImplementIEquatableId = nameof(ValueObjectsMustImplementIEquatableId);
        public const string ValueObjectsMustBeSealedId = nameof(ValueObjectsMustBeSealedId);
        public const string NoEntitiesInValueObjectsId = nameof(NoEntitiesInValueObjectsId);
        public const string NoServicesInValueObjectsId = nameof(NoServicesInValueObjectsId);
        public const string NoFactoriesInValueObjectsId = nameof(NoFactoriesInValueObjectsId);
        public const string NoRepositoriesInValueObjectsId = nameof(NoRepositoriesInValueObjectsId);
        public const string NoAggregateRootsInValueObjectsId = nameof(NoAggregateRootsInValueObjectsId);
        public const string ValueObjectsMustBeImmutableId = nameof(ValueObjectsMustBeImmutableId);
        private const string Category = "Design";

        public static readonly DiagnosticDescriptor ValueObjectMustNotUseEntityRule = new(NoEntitiesInValueObjectsId,
            new LocalizableResourceString(nameof(Resources.ValueObjectUsesEntityTitle), Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.ValueObjectUsesEntityMessageFormat),
                Resources.ResourceManager, typeof(Resources)), Category,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.ValueObjectUsesEntityDescription), Resources.ResourceManager,
                typeof(Resources)));

        public static readonly DiagnosticDescriptor ValueObjectMustNotUseServiceRule = new(NoServicesInValueObjectsId,
            new LocalizableResourceString(nameof(Resources.ValueObjectUsesServiceTitle), Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.ValueObjectUsesServiceMessageFormat),
                Resources.ResourceManager, typeof(Resources)), Category,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.ValueObjectUsesServiceDescription),
                Resources.ResourceManager,
                typeof(Resources)));

        public static readonly DiagnosticDescriptor ValueObjectMustNotUseRepositoryRule = new(NoRepositoriesInValueObjectsId,
            new LocalizableResourceString(nameof(Resources.ValueObjectUsesRepositoryTitle), Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.ValueObjectUsesRepositoryMessageFormat),
                Resources.ResourceManager, typeof(Resources)), Category,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.ValueObjectUsesRepositoryDescription),
                Resources.ResourceManager,
                typeof(Resources)));

        public static readonly DiagnosticDescriptor ValueObjectMustNotUseAggregateRootRule = new(NoAggregateRootsInValueObjectsId,
            new LocalizableResourceString(nameof(Resources.ValueObjectUsesAggregateRootTitle), Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.ValueObjectUsesAggregateRootMessageFormat),
                Resources.ResourceManager, typeof(Resources)), Category,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.ValueObjectUsesAggregateRootDescription),
                Resources.ResourceManager,
                typeof(Resources)));

        public static readonly DiagnosticDescriptor ValueObjectMustBeImmutableRule = new(ValueObjectsMustBeImmutableId,
            new LocalizableResourceString(nameof(Resources.ValueObjectMustBeImmutableTitle), Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.ValueObjectMustBeImmutableMessageFormat),
                Resources.ResourceManager, typeof(Resources)), Category,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.ValueObjectMustBeImmutableDescription),
                Resources.ResourceManager, typeof(Resources)));

        public static readonly DiagnosticDescriptor ValueObjectMustImplementIEquatableRule = new(ValueObjectsMustImplementIEquatableId,
            new LocalizableResourceString(nameof(Resources.ValueObjectMustImplementIEquatableTitle),
                Resources.ResourceManager, typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.ValueObjectMustImplementIEquatableMessageFormat),
                Resources.ResourceManager, typeof(Resources)), Category,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.ValueObjectMustImplementIEquatableDescription),
                Resources.ResourceManager, typeof(Resources)));

        public static readonly DiagnosticDescriptor ValueObjectMustBeSealedRule = new(ValueObjectsMustBeSealedId,
            new LocalizableResourceString(nameof(Resources.ValueObjectMustBeSealedTitle), Resources.ResourceManager,
                typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.ValueObjectMustBeSealedMessageFormat),
                Resources.ResourceManager, typeof(Resources)), Category,
            DiagnosticSeverity.Error,
            true,
            new LocalizableResourceString(nameof(Resources.ValueObjectMustBeSealedDescription),
                Resources.ResourceManager, typeof(Resources)));
    }
}