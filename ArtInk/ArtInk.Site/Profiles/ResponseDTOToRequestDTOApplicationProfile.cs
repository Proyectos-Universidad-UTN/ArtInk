using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using AutoMapper;

namespace ArtInk.Site.Profiles;

public class ResponseDTOToRequestDTOApplicationProfile: Profile
{
    public ResponseDTOToRequestDTOApplicationProfile()
    {
        CreateMap<SucursalResponseDTO, SucursalRequestDTO>();
    }
}