using AutoMapper;

namespace HRP.Application.Tools.Mapping;

public interface IMapWith<T>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap(typeof(T), GetType()).ReverseMap();
    }
}

public interface IMapWith<T1, T2>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap(typeof(T1), GetType());
        profile.CreateMap(GetType(), typeof(T2)).ReverseMap();
    }
}