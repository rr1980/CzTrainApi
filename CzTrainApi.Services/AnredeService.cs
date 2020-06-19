using CzTrainApi.Entities;
using CzTrainApi.Repository.Contracts;
using CzTrainApi.Services.Contracts;
using CzTrainApi.ViewModels.Test;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

public class AnredeService : IAnredeService
{
    private readonly IDbRepository _dbRepository;
    public AnredeService(IDbRepository dbRepository)
    {
        _dbRepository = dbRepository;
    }

    public Task Delete(long id)
    {
        return _dbRepository.Delete<Anrede>(id);
    }

    public async Task<IList<TestAnredeResponseVM>> GetAll()
    {
        return (await _dbRepository.GetAll<Anrede>(null, new List<Expression<Func<Anrede, object>>>()
        {
            x=>x.Personen
        })
            ).Select(a => new TestAnredeResponseVM
            {
                Id = a.Id,
                Bezeichnung = a.Bezeichnung,
                Personen = a.Personen.Select(p => new TestAnredePersonResponseVM
                {
                    Id = p.Id,
                    FullName = p.Vorname + " " + p.Nachname
                }).ToList()
            }).ToList();
    }
}
