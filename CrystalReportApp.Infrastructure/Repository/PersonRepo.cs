using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalReportApp.Core.Entities;
using CrystalReportApp.Core.Interfaces;
using CrystalReportApp.Infrastructure.Gateway;

namespace CrystalReportApp.Infrastructure.Repository
{
    public class PersonRepo:IPerson
    {
        private readonly CrystalReportAppDbContext _context;
        private bool _disposed = false;

        public PersonRepo(CrystalReportAppDbContext context)
        {
            _context = context;
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public List<PersonModel> GetPersonList()
        {
            return _context.PersonEntity.ToList();
        }

        public PersonModel GetPersonById(int? id)
        {
            return _context.PersonEntity.Find(id);
        }

        public void Insert(PersonModel personModel)
        {
            _context.PersonEntity.Add(personModel);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Update(PersonModel personModel)
        {
            _context.Entry(personModel).State = EntityState.Modified;
        }

        public void Delete(PersonModel personModel)
        {
            _context.PersonEntity.Remove(personModel);
        }
    }
}
