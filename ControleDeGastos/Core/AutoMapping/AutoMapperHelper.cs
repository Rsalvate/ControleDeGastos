using AutoMapper;
using System.Reflection;

namespace Core.AutoMapping;
public static class AutoMapperHelper
{
    public static void ApplyAutoMappings(this Profile profile, params Assembly[] assemblies)
    {
        profile.ApplyExplicityMappingsFor(assemblies);
    }

    private static void ApplyExplicityMappingsFor(this Profile profile, params Assembly[] assemblies)
    {
        var types = assemblies
            .SelectMany(x => x.GetTypes())
            .Where(t => (t.IsClass
                        && !t.IsAbstract || t.IsStructure())
                        && t.HasMappableInterface())
            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);

            var methodInfo = type.GetMethod("Mapping")
                             ?? type.GetInterface("IMapWith`1")?.GetMethod("Mapping");

            methodInfo?.Invoke(instance, new object[] { profile });
        }
    }

    private static bool IsStructure(this Type localType)
    {
        bool result = false;
        if (localType.IsValueType)
        {
            //Is Value Type
            if (!localType.IsPrimitive)
            {
                /* Is not primitive. Remember that primitives are:
                Boolean, Byte, SByte, Int16, UInt16, Int32, UInt32,
                Int64, UInt64, IntPtr, UIntPtr, Char, Double, Single.
                This way, could still be Decimal, Date or Enum. */
                if (localType != typeof(decimal))
                {
                    //Is not Decimal
                    if (localType != typeof(DateTime))
                    {
                        //Is not Date
                        if (!localType.IsEnum)
                        {
                            //Is not Enum. Consequently it is a structure.
                            result = true;
                        }
                    }
                }
            }
        }

        return result;
    }

    private static bool HasMappableInterface(this Type type)
    {
        return type.GetInterfaces().Any(i => i.IsMappableInterface());
    }

    private static bool IsMappableInterface(this Type type)
    {
        return type.IsInterface
               && type.IsGenericType
               && type.GetGenericTypeDefinition() == typeof(IMapWith<>);
    }
}
