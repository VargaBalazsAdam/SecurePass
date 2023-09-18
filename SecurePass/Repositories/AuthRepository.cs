using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SecurePass.Models
{
  public class AuthRepository
  {
    private readonly AuthDbContext _dbContext;

    public AuthRepository()
    {
      _dbContext = new AuthDbContext();
      _dbContext.Database.EnsureCreated();
    }

    public IEnumerable<Auth> GetAll()
    {
      return _dbContext.Auths.ToList();
    }

    public Auth GetById(int id)
    {
      return _dbContext.Auths.FirstOrDefault(a => a.id == id);
    }

    public void Add(Auth auth)
    {
      _dbContext.Auths.Add(auth);
      _dbContext.SaveChanges();
    }

    public void Update(Auth auth)
    {
      _dbContext.Auths.Update(auth);
      _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
      var auth = _dbContext.Auths.FirstOrDefault(a => a.id == id);
      if (auth != null)
      {
        _dbContext.Auths.Remove(auth);
        _dbContext.SaveChanges();
      }
    }
  }
}
