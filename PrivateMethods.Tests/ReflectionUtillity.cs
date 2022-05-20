using System;
using System.Linq;
using System.Reflection;

namespace PrivateMethods.Tests
{
    public class ReflectionUtillity
    {
        public static BindingFlags DefaultBindingFlags => BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance;

        public static Type GetTypeInNamespace(string typeName, string nameSpace)
        {
            return Assembly.GetAssembly(typeof(SomePublicDummyType)).GetTypes()
                        .Where(t => string.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                        .ToList().FindAll(t => t.Name == typeName)
                        .SingleOrDefault();
        }

        public static ConstructorInfo GetConstructorInfoByParameters(Type type, object[] parameters)
        {
            ConstructorInfo[] constructorInfos = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (ConstructorInfo constructorInfo in constructorInfos)
            {
                if (ConstructorMatchParsedParameters(constructorInfo, parameters))
                {
                    return constructorInfo;
                }
            }
            return null;
        }

        private static bool ConstructorMatchParsedParameters(ConstructorInfo constructorInfo, object[] parameters)
        {
            ParameterInfo[] constructorParameters = constructorInfo.GetParameters();
            if (constructorParameters.Length != parameters.Length)
            {
                return false;
            }

            for (int i = 0; i < constructorParameters.Length; i++)
            {
                if (parameters[i].GetType() != constructorParameters[i].ParameterType)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
