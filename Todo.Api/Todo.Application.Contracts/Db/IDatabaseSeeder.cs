using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.Contracts.Db
{
    public interface IDatabaseSeeder
    {
        void Initialise(bool shouldSeed);
    }
}
