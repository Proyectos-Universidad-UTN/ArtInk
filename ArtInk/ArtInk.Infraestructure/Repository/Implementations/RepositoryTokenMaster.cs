using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Repository.Implementations;

public class RepositoryTokenMaster(ArtInkContext context) : IRepositoryTokenMaster
{
    public async Task<TokenMaster> CreateTokenMasterAsync(TokenMaster tokenMaster)
    {
        var result = context.TokenMasters.Add(tokenMaster);
        await context.SaveChangesAsync();
        
        return result.Entity;
    }

    public async Task<bool> ExisteTokenMaster(string token)
    {
        return await context.Set<TokenMaster>()
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Token == token) != null;
    }

    public async Task<TokenMaster?> GetTokenMasterAsync(long id)
    {
        var keyProperty = context.Model.FindEntityType(typeof(TokenMaster))!.FindPrimaryKey()!.Properties[0];

        return await context.Set<TokenMaster>()
            .AsNoTracking()
            .FirstOrDefaultAsync(a => EF.Property<long>(a, keyProperty.Name) == id);
    }

    public async Task<TokenMaster?> GetTokenMasterAsync(string token)
    {
        return await context.Set<TokenMaster>()
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Token == token);
    }

    public async Task<TokenMaster> UpdateTokenMasterAsync(TokenMaster tokenMaster)
    {
        context.TokenMasters.Update(tokenMaster);

        await context.SaveChangesAsync();

        var response = await GetTokenMasterAsync(tokenMaster.Id);
        return response!;
    }
}