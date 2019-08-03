using System;
using System.Collections.Generic;
using Patrimonio.Business.Dto;
using Patrimonio.Business.Entities;
using Patrimonio.Business.Repositories;
using Patrimonio.Business.Services.Abstractions;
using Patrimonio.Business.Validations.Abstractions;

namespace Patrimonio.Business.Services
{
    public sealed class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _repository;
        private readonly IValidationFactory<EMarca> _validationInsertFactory;
        private readonly IValidationFactory<EMarca> _validationUpdateFactory;

        public MarcaService
        (
            IMarcaRepository repository,
            IValidationFactory<EMarca> validationInsertFactory,
            IValidationFactory<EMarca> validationUpdateFactory
        )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _validationInsertFactory = validationInsertFactory ?? throw new ArgumentNullException(nameof(validationInsertFactory));
            _validationUpdateFactory = validationUpdateFactory ?? throw new ArgumentNullException(nameof(validationUpdateFactory));
        }

        public ResponseBag<NoContent> Create(EMarca entity)
        {
            // Apply the validations rules to entity.
            var validations = _validationInsertFactory.Create();
            foreach (var validation in validations)
            {
                var result = validation.Validate(entity);
                if(!result.IsValid)
                {
                    return new ResponseBag<NoContent>
                    {
                        Ok = false,
                        Message = string.Join(", ", result.Errors)
                    };
                }
            }

            // Save the marca in database.
            _repository.Create(entity);

            return new ResponseBag<NoContent>{Ok = true};
        }

        public ResponseBag<NoContent> Delete(int marcaId)
        {
            _repository.Delete(marcaId);
            return new ResponseBag<NoContent>{Ok = true};
        }

        public ResponseBag<IEnumerable<EMarca>> GetAll()
        {
            var entities = _repository.GetAll();
            return new ResponseBag<IEnumerable<EMarca>>
            {
                Ok = true,
                ObjectResponse = entities
            };
        }

        public ResponseBag<EMarca> GetById(int marcaId)
        {
            var entity = _repository.GetById(marcaId);
            return new ResponseBag<EMarca>
            {
                Ok = true,
                ObjectResponse = entity
            };
        }

        public ResponseBag<NoContent> Update(EMarca entity)
        {
            // Apply the validations rules to entity.
            var validations = _validationUpdateFactory.Create();
            foreach (var validation in validations)
            {
                var result = validation.Validate(entity);
                if(!result.IsValid)
                {
                    return new ResponseBag<NoContent>
                    {
                        Ok = false,
                        Message = string.Join(", ", result.Errors)
                    };
                }
            }

            // Save the marca in database.
            _repository.Update(entity);

            return new ResponseBag<NoContent>{Ok = true};
        }
    }
}