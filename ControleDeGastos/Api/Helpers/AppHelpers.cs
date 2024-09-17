using System.Reflection;

namespace Api.Helpers;

public static class AppHelpers
{
    public static Assembly[] Assemblies =>
    [
        Assembly.GetExecutingAssembly(),
        Assembly.GetAssembly(typeof(Core.IAmCoreAssembly))!,
        Assembly.GetAssembly(typeof(Application.IAmApplicationAssembly))!,
        Assembly.GetAssembly(typeof(Domain.IAmDomainAssembly))!,
        Assembly.GetAssembly(typeof(Data.IAmDataAssembly))!,
    ];
}
