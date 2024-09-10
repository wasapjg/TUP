using RepositoryExample.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryExample.Data
{
    public interface IBudgetRepository
    {
        Budget GetById(int id);
        List<Budget> GetAll();
        bool Save(Budget budget);
    }
}
