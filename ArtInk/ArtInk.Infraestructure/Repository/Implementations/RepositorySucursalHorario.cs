using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Infraestructure.Repository.Implementations
{
    public class RepositorySucursalHorario(ArtInkContext context) : IRepositorySucursalHorario
    {
        public async Task<SucursalHorario> CreateSucursalHorarioAsync(SucursalHorario sucursalHorario)
        {
            var result = context.SucursalHorarios.Add(sucursalHorario);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<IEnumerable<SucursalHorario>> CreateSucursalHorarioAsync(byte idSucursal, IEnumerable<SucursalHorario> sucursalHorarios)
        {
            var sucursalHorariosExistentes = await GetSucursalHorarioBySucursalAsync(idSucursal);

            using var transaccion = context.Database.BeginTransaction();
            try
            {
                context.SucursalHorarios.RemoveRange(sucursalHorariosExistentes);
                await context.SaveChangesAsync();

                context.SucursalHorarios.AddRange(sucursalHorarios);
                await context.SaveChangesAsync();

                transaccion.Commit();
            }
            catch (Exception)
            {
                transaccion.Rollback();
                throw new Exception("No se pudo agregar los horarios a la sucursal.");
            }
           
            return sucursalHorarios;
        }

        public async Task<ICollection<SucursalHorario>> GetSucursalHorarioBySucursalAsync(byte idSucursal)
        {
            throw new NotImplementedException();
        }

        public async Task<SucursalHorario> UpdateSucursalHorarioAsync(SucursalHorario sucursalHorario)
        {
            throw new NotImplementedException();
        }
    }
}
