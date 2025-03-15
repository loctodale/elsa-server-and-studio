using AutoMapper;
using ElsaServer.Migrations;
using ElsaServer.Model;

namespace ElsaServer.Config;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<IdeaModel, Idea>().ReverseMap();
        CreateMap<IdeaRequestModel, IdeaRequest>().ReverseMap();
    }
}