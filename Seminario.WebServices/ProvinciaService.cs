﻿using Seminario.Model;
using Seminario.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.WebServices
{
    public class ProvinciaService : EntityService<Provincia>, IProvinciaService
    {
        public IUnitOfWork UnitOfWork { get; set; }
        
        
        public ProvinciaService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }


    }
}
