using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalReportApp.Core.Entities;

namespace CrystalReportApp.Core.Interfaces
{
    public interface IPerson
    {
        List<PersonModel> GetPersonList();
        PersonModel GetPersonById(int? id);
        void Insert(PersonModel personModel);
        void Commit();
        void Update(PersonModel personModel);
        void Delete(PersonModel personModel);
    }
}
