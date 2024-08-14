using AutoMapper;
using System.Reflection;

namespace Core.AutoMapping;
public abstract class AutoMapperProfileBase : Profile
{
    protected AutoMapperProfileBase()
    {
        Apply();
    }

    protected void Apply()
    {
        this.ApplyAutoMappings(GetAssembliesForAutomation());
    }

    protected abstract Assembly[] GetAssembliesForAutomation();

    protected abstract void Configure();
}
