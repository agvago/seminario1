﻿using Seminario.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.WebServices.Contracts
{
    public interface IEmpleadoService : IEntityService<Empleado,EmpleadoDto>
    {
    }
}
