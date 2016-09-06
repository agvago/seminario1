﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Seminario.Model;
using Seminario.NHibernate;
using Seminario.WebServices.Contracts;

namespace Seminario.WebServices
{
	public class SimulacionService : EntityService<Simulacion, SimulacionDto>, ISimulacionService
	{
		public IUnitOfWork UnitOfWork { get; set; }
		public IValidator<Simulacion> Validator { get; set; }

		public SimulacionService(IUnitOfWork unitOfWork)
			: base(unitOfWork)
		{
			this.UnitOfWork = unitOfWork;
		}
	}
}
