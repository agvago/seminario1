﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Seminario.Model;

namespace Seminario.Validationes
{
	public class DatosTTValidator : EntityValidator<DatosTT>
	{
		public DatosTTValidator()
		{
		}
	}
}
