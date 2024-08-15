using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryTokenMaster
{
    Task<TokenMaster> CreateTokenMasterAsync(TokenMaster tokenMaster);

    Task<TokenMaster> UpdateTokenMasterAsync(TokenMaster tokenMaster);

    Task<TokenMaster?> GetTokenMasterAsync(long id);

    Task<TokenMaster?> GetTokenMasterAsync(string token);

    Task<bool> ExisteTokenMaster(string token);
}