using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace NMolecules.Analyzers.Test
{
    public static class SampleDataLoader
    {
        private static readonly Lazy<IEnumerable<(string filename, string content)>>
            Attributes = new(LoadAllAttributes);

        private static IEnumerable<(string filename, string content)> LoadAllAttributes()
        {
            var type = typeof(SampleDataLoader);
            var assembly = type.Assembly;
            yield return LoadAttributes("AggregateRootAttribute");
            yield return LoadAttributes("BoundedContextAttribute");
            yield return LoadAttributes("EntityAttribute");
            yield return LoadAttributes("FactoryAttribute");
            yield return LoadAttributes("Identity");
            yield return LoadAttributes("ModuleAttribute");
            yield return LoadAttributes("RepositoryAttribute");
            yield return LoadAttributes("ServiceAttribute");
            yield return LoadAttributes("ValueObjectAttribute");


            (string filename, string content) LoadAttributes(string filename)
            {
                var resourcePath = $"{type.Namespace}.Attributes.{filename}.cs";
                var attributes = LoadResource(assembly, resourcePath);
                return (filename, attributes);
            }
        }

        public static IEnumerable<(string filename, string content)> GetAttributes() => Attributes.Value;

        public static string LoadFromNamespaceOf<T>(string sampleName)
        {
            var stringBuilder = new StringBuilder();
            var type = typeof(T);
            var resourcePath = $"{type.Namespace!}.SampleData.{sampleName}";
            var assembly = type.Assembly;
            var sampleData = LoadResource(assembly!, resourcePath!);
            stringBuilder.AppendLine(sampleData);
            return stringBuilder.ToString();
        }

        private static string LoadResource(Assembly assembly, string resourcePath)
        {
            var manifestResourceStream = assembly.GetManifestResourceStream(resourcePath)!;
            using var sr = new StreamReader(manifestResourceStream);
            return sr.ReadToEnd();
        }
    }
}