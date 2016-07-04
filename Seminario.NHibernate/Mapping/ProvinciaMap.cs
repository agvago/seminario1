﻿using FluentNHibernate.Mapping;
using Seminario.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.NHibernate.Mapping
{
    public class ProvinciaMap : ClassMap<Provincia>
    {
        public ProvinciaMap()
        {
            Id(x => x.Id);
            Map(x => x.Nombre);
            Map(x => x.Sellado);
        }
    }
}
