using System;
using System.Collections.Generic;
using Patrimonio.Business.BusinessRules.Abstractions;
using Patrimonio.Business.Dto;
using Patrimonio.Business.Entities;
using Patrimonio.Business.Repositories;
using Patrimonio.Business.Services.Abstractions;
using Patrimonio.Business.Validations.Abstractions;

namespace Patrimonio.Business.Services
{
    public sealed class PatrimonioService : IPatrimonioService
    {
        private readonly IPatrimonioRepository _repository;
        private readonly IValidationFactory<EPatrimonio> _validationInsertFactory;
        private readonly IValidationFactory<EPatrimonio> _validationUpdateFactory;
        private readonly IBusinessRulesFactory<EPatrimonio> _bizRulesInsertFactory;

        public PatrimonioService
        (
            IPatrimonioRepository repository,
            IValidationFactory<EPatrimonio> validationInsertFactory,
            IValidationFactory<EPatrimonio> validationUpdateFactory,
            IBusinessRulesFactory<EPatrimonio> bizRulesInsertFactory
        )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _validationInsertFactory = validationInsertFactory ?? throw new ArgumentNullException(nameof(validationInsertFactory));
            _validationUpdateFactory = validationUpdateFactory ?? throw new ArgumentNullException(nameof(validationUpdateFactory));
            _bizRulesInsertFactory = bizRulesInsertFactory ?? throw new ArgumentNullException(nameof(bizRulesInsertFactory));
        }

        public ResponseBag<int> Create(EPatrimonio entity)
        {
            // Apply the validations rules to entity.
            var validations = _validationInsertFactory.Create();
            foreach (var validation in validations)
            {
                var result = validation.Validate(entity);
                if(!result.IsValid)
                {
                    return new ResponseBag<int>
                    {
                        Ok = false,
                        Message = string.Join(", ", result.Errors)
                    };
                }
            }

            // Apply the business rules.
            var rules = _bizRulesInsertFactory.Create();
            foreach (var rule in rules)
            {
                rule.Apply(entity);
            }

            // Save the patrimônio in database.
            var affectedRows = _repository.Create(entity);

            return new ResponseBag<int>
            {
                Ok = true,
                ObjectResponse = affectedRows
            };
        }

        public ResponseBag<int> Delete(long patrimonioId)
        {
            var affectedRows = _repository.Delete(patrimonioId);
            return new ResponseBag<int>
            {
                Ok = true,
                ObjectResponse = affectedRows
            };
        }

        public ResponseBag<IEnumerable<EPatrimonio>> GetAll()
        {
            var entities = _repository.GetAll();
            return new ResponseBag<IEnumerable<EPatrimonio>>
            {
                Ok = true,
                ObjectResponse = entities
            };
        }

        public ResponseBag<EPatrimonio> GetById(long patrimonioId)
        {
            var entity = _repository.GetById(patrimonioId);
            return new ResponseBag<EPatrimonio>
            {
                Ok = true,
                ObjectResponse = entity
            };
        }

        public ResponseBag<IEnumerable<EPatrimonio>> GetByMarca(int marcaId)
        {
            var entities = _repository.GetByMarca(marcaId);
            return new ResponseBag<IEnumerable<EPatrimonio>>
            {
                Ok = true,
                ObjectResponse = entities
            };
        }

        public ResponseBag<int> Update(EPatrimonio entity)
        {
            // Apply the validations rules to entity.
            var validations = _validationUpdateFactory.Create();
            foreach (var validation in validations)
            {
                var result = validation.Validate(entity);
                if(!result.IsValid)
                {
                    return new ResponseBag<int>
                    {
                        Ok = false,
                        Message = string.Join(", ", result.Errors)
                    };
                }
            }

            // Save the patrimônio in database.
            var affectedRows = _repository.Update(entity);

            return new ResponseBag<int>
            {
                Ok = true,
                ObjectResponse = affectedRows
            };
        }
    }
}