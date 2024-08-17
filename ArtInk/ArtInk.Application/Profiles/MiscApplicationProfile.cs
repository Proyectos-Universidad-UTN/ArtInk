using App = ArtInk.Application.DTOs.Enums;
using AutoMapper;
using Infra = ArtInk.Infraestructure.Enums;
using ArtInk.Application.DTOs;
using ArtInk.Infraestructure.Models;
using ArtInk.Application.DTOs.Base;
using ArtInk.Application.ValueResolvers;

namespace ArtInk.Application.Profiles;

public class MiscApplicationProfile : Profile
{
    public MiscApplicationProfile()
    {
        CreateMap<App.DiaSemana, Infra.DiaSemana>().ReverseMap();

        CreateMap<BaseEntity, BaseModel>()
            .ForMember(m => m.UsuarioCreacion, opts =>
            {
                opts.MapFrom<CurrentUserIdResolverBaseEntityAdd>();
            })
            .ForMember(m => m.UsuarioModificacion, opts =>
            {
                opts.MapFrom<CurrentUserIdResolverBaseEntityModify>();
            });

        CreateMap<ReservaDto, Reserva>()
            .IncludeBase<BaseEntity, BaseModel>();

        CreateMap<ReservaPreguntaDto, ReservaPregunta>()
            .IncludeBase<BaseEntity, BaseModel>();

        CreateMap<ReservaServicioDto, ReservaServicio>();

        CreateMap<PedidoDto, Pedido>()
            .IncludeBase<BaseEntity, BaseModel>();

        CreateMap<DetallePedidoDto, DetallePedido>();

        CreateMap<ClienteDto, Cliente>()
            .IncludeBase<BaseEntity, BaseModel>();

        CreateMap<ImpuestoDto, Impuesto>();
        CreateMap<TipoPagoDto, TipoPago>();

        CreateMap<SucursalDto, Sucursal>()
            .IncludeBase<BaseEntity, BaseModel>();
    }
}
