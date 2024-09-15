using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data.Extensions;
public static class ModelBuilderExtension
{
    public static void ApplyVarcharConvention(this ModelBuilder modelBuilder)
    {
        foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (IMutableProperty property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(string) || property.DeclaringEntityType.ClrType == typeof(string))
                    property.SetIsUnicode(new bool?(false));
            }
        }
    }

    public static void ApplyDateTimeConvention(this ModelBuilder modelBuilder)
    {
        foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (IMutableProperty property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTime) || property.DeclaringEntityType.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?) || property.DeclaringEntityType.ClrType == typeof(DateTime?))
                    property.SetColumnType("datetime2");
            }
        }
    }

    public static void ApplyMappings(this ModelBuilder modelBuilder, Assembly assembly)
    {
        MethodInfo methodInfo1 = ((IEnumerable<MethodInfo>)typeof(ModelBuilder).GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy)).Where<MethodInfo>((Func<MethodInfo, bool>)(m => m.IsGenericMethod && m.Name.Equals("ApplyConfiguration", StringComparison.OrdinalIgnoreCase))).FirstOrDefault<MethodInfo>((Func<MethodInfo, bool>)(m => ((IEnumerable<ParameterInfo>)m.GetParameters()).FirstOrDefault<ParameterInfo>()?.ParameterType.Name == "IEntityTypeConfiguration`1"));
        foreach (Type type1 in ((IEnumerable<Type>)assembly.GetTypes()).Where<Type>((Func<Type, bool>)(c => c.IsClass && !c.IsAbstract && !c.ContainsGenericParameters && ((IEnumerable<Type>)c.GetInterfaces()).Any<Type>((Func<Type, bool>)(i => i.IsConstructedGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))))).ToList<Type>())
        {
            Type type2 = ((IEnumerable<Type>)type1.GetInterfaces()).FirstOrDefault<Type>((Func<Type, bool>)(i => i.IsConstructedGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));
            if (!(type2 == (Type)null))
            {
                MethodInfo methodInfo2;
                if ((object)methodInfo1 == null)
                    methodInfo2 = (MethodInfo)null;
                else
                    methodInfo2 = methodInfo1.MakeGenericMethod(type2.GenericTypeArguments[0]);
                methodInfo2?.Invoke((object)modelBuilder, new object[1]
                {
        Activator.CreateInstance(type1)
                });
            }
        }
    }
}
