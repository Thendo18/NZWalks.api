﻿using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IwalkRepository
    {
        Task<Walks> CreateAsync(Walks walk);
        Task<Walks> DeleteAsync(Guid id);
        Task<List<Walks>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize =  1000);

        Task<Walks> GetByIdAsync(Guid id);

        Task<Walks> UpdateAsync(Guid id, Walks walk);
    }
}
