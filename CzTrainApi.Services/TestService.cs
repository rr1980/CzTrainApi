using CzTrainApi.Common.Exceptions;
using CzTrainApi.Db;
using CzTrainApi.Entities;
using CzTrainApi.Services.Contracts;
using CzTrainApi.ViewModels.Test;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class TestService : ITestService
{
    private readonly DatenbankContext _datenbankContext;
    public TestService(DatenbankContext datenbankContext)
    {
        _datenbankContext = datenbankContext;
    }

    public Task Delete(long id)
    {
        var anrede = _datenbankContext.Anreden.Find(id);
        if(anrede == null)
        {
            throw new IdNotFoundException<Anrede>(id);
        }

        _datenbankContext.Remove(anrede);
        return _datenbankContext.SaveChangesAsync();
    }

    public Task<List<TestAnredeResponseVM>> GetAllAnrede()
    {
        return _datenbankContext.Anreden.AsNoTracking().Include(x=> x.Personen).Select(a => new TestAnredeResponseVM
        {
            Id = a.Id,
            Bezeichnung = a.Bezeichnung,
            Personen = a.Personen.Select(p => new TestAnredePersonResponseVM
            {
                Id = p.Id,
                FullName = p.Vorname + " " + p.Nachname,
                Benutzername = p.Benutzer.FirstOrDefault().Benutzername,
                Titel = p.Titel.Bezeichnung
            }).ToList()
        }).ToListAsync();
    }

    public Task<List<TestKatalogObjekteResponseVM>> GetAllKatalogObekte()
    {
        return _datenbankContext.KatlogObjekte.AsNoTracking().Select(x => new TestKatalogObjekteResponseVM
        {
            Id = x.Id,
            Discriminator = x.Discriminator,
            Bezeichnung = x.Bezeichnung,
            Geloescht = x.Geloescht,
            Erstellungsdatum = x.Erstellungsdatum,
            Aenderungsdatum = x.Aenderungsdatum
        }).ToListAsync();
    }

    public  Task<List<TestKatalogObjekteResponseVM>> GetAllKatalogObekteWithDeleted()
    {
        return _datenbankContext.KatlogObjekte.AsNoTracking().IgnoreQueryFilters().Select(x => new TestKatalogObjekteResponseVM
        {
            Id = x.Id,
            Discriminator = x.Discriminator,
            Bezeichnung = x.Bezeichnung,
            Geloescht = x.Geloescht,
            Erstellungsdatum = x.Erstellungsdatum,
            Aenderungsdatum = x.Aenderungsdatum
        }).ToListAsync();
    }
}
