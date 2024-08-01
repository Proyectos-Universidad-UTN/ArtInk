using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using AutoMapper;

namespace ArtInk.Site.Profiles;

public class ResponseDtoToRequestDtoApplicationProfile: Profile
{
    public ResponseDtoToRequestDtoApplicationProfile()
    {
        CreateMap<SucursalResponseDto, SucursalRequestDto>();
        CreateMap<ProductoResponseDto, ProductoRequestDto>();
        CreateMap<FeriadoResponseDto, FeriadoRequestDto>();
        CreateMap<SucursalFeriadoResponseDto, SucursalFeriadoRequestDto>();
        CreateMap<ServicioResponseDto, ServicioRequestDto>();
        CreateMap<SucursalHorarioResponseDto, SucursalHorarioRequestDto>();
        CreateMap<HorarioResponseDto, HorarioRequestDto>();
        CreateMap<InventarioResponseDto, InventarioRequestDto>();
        CreateMap<FacturaResponseDto, FacturaRequestDto>();
        CreateMap<DetalleFacturaResponseDto, DetalleFacturaRequestDto>();
        CreateMap<ReservaServicioResponseDto, ReservaServicioRequestDto>();
        CreateMap<ReservaResponseDto, ReservaRequestDto>();
        CreateMap<PedidoResponseDto, PedidoRequestDto>();
        CreateMap<DetallePedidoResponseDto, DetallePedidoRequestDto>();
        
        CreateMap<InventarioProductoResponseDto, InventarioProductoRequestDto>();
    }
}