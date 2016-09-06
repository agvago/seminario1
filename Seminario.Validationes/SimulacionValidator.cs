﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Seminario.Model;

namespace Seminario.Validationes
{
	public class SimulacionValidator : EntityValidator<Simulacion>
	{
		public SimulacionValidator()
		{
			RuleFor(x => x.SpreadTotal).GreaterThan(3).WithLocalizedMessage(() => "Exito");
		}
	}
}
