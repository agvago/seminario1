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
	public class ProductoService : EntityService<Producto, ProductoDto>, IProductoService
	{
		public IUnitOfWork UnitOfWork { get; set; }

		public IValidator<Producto> Validator { get; set; }

		public ProductoService(IUnitOfWork unitOfWork)
			: base(unitOfWork)
		{
			this.UnitOfWork = unitOfWork;
		}
	}
}
