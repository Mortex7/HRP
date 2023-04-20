using System.Reflection;
using AutoMapper;

namespace HRP.Application.Tools.Mapping;

public class AssemblyMappingProfile : Profile
{
    private static readonly Dictionary<string, Type> SupportedInterfaces = new()
    {
        { typeof(IMapWith<>).Name, typeof(IMapWith<>) },
        { typeof(IMapWith<,>).Name, typeof(IMapWith<,>) }
    };

    private readonly Assembly _assembly;

    public AssemblyMappingProfile(Assembly assembly)
    {
        _assembly = assembly;
        ApplyMapping();
    }

    private void ApplyMapping()
    {
        var types = _assembly.GetExportedTypes().Where(type => type.GetInterfaces()
                .Any(i => i.IsGenericType && SupportedInterfaces.ContainsKey(i.Name)))
            .ToList();

        types.ForEach(type =>
        {
            var mapInterface = type.GetInterfaces().First(i => SupportedInterfaces.ContainsKey(i.Name));
            var instance = Activator.CreateInstance(type);
            var mapType = SupportedInterfaces[mapInterface.Name].MakeGenericType(mapInterface.GenericTypeArguments);
            var methodInfo = mapType.GetMethod("Mapping");
            methodInfo?.Invoke(instance, new object[] { this });
        });
    }
}