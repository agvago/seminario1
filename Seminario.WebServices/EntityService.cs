﻿using Seminario.Model;
using Seminario.NHibernate;
using Seminario.WebServices;
using Seminario.WebServices.Contracts;
using Seminario.MapperProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Seminario.Validationes;
using FluentValidation;
using FluentValidation.Results;
using System.Reflection;

namespace Seminario.WebServices
{
    public abstract class EntityService<T,TDto> : IEntityService<T,TDto> 
        where T : Entity
        where TDto : EntityDto
        
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        IValidator _validator; 

        public EntityService(IUnitOfWork unitOfWork,IValidator<T> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            this._mapper = new AutoMapperConfig(_unitOfWork).Config().CreateMapper();
        }

        public virtual void Create(TDto entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var entityModel = _mapper.Map<TDto, T>(entity);
            ValidationResult result = this._validator.Validate(entityModel);
            if (result.IsValid)
            {
                _unitOfWork.Repository<T>().Add(entityModel);
                _unitOfWork.Save();
            }
            else
                throw new Exception(result.Errors.FirstOrDefault().ErrorMessage);
        }


        public virtual void Update(TDto entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _unitOfWork.Repository<T>().Update(_mapper.Map<TDto, T>(entity));
            _unitOfWork.Save();
        }

        public virtual void Delete(TDto entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _unitOfWork.Repository<T>().Remove(_mapper.Map<TDto, T>(entity));
            _unitOfWork.Save();
        }

        public virtual IEnumerable<TDto> GetAll()
        {
            return _mapper.Map<List<TDto>>(_unitOfWork.Repository<T>().ToList());
        }

        public virtual TDto Get(Expression<System.Func<T, bool>> expression)
        {
            return _mapper.Map<T, TDto>(_unitOfWork.Repository<T>().Where(expression).FirstOrDefault());
        }

        public virtual IEnumerable<TDto> GetMany(Expression<System.Func<T, bool>> expression)
        {
            return _mapper.Map<List<TDto>>(_unitOfWork.Repository<T>().Where(expression).ToList());
        }
        
        public virtual TDto GetById(int id)
        {
            return _mapper.Map<T, TDto>(_unitOfWork.Repository<T>().GetById(id));
        }
    }
} 
