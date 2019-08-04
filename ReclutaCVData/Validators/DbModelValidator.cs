using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AppPersistence.Enums;
using AppPersistence.Attributes;
using AppPersistence.Exceptions;
using AppPersistence.Validators;

namespace AppPersistence.Validators
{
    /// <summary>
    /// Validador de modelo que realiza validaciones contra memoria y en la base de datos
    /// </summary>
    public class DbModelValidator : ModelValidator
    {
        // TODO: crear lógica para obtener nombre de la llave primaria por reflexión
        private readonly string idPropertyName = "Id";

        /// <summary>
        /// Arroja una excepción con el primer error de validación que tiene el modelo
        /// Si el modelo es válido, no hace nada
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="model">Módelo que se validará</param>
        /// <param name="set">Conjunto al que pertenece el modelo</param>
        /// <exception cref="ValidationErrorException"></exception>
        public async Task ValidateOrThrow<TModel>(IQueryable<TModel> set, TModel model) where TModel : class
        {
            ValidateInMemoryOrThrow(model);
            await ValidateInDbOrThrow(set, model);
        }

        /// <summary>
        /// Realiza las validaciones que se pueden hacer en memoria sobre el modelo
        /// Tales como: <see cref="ValidationErrorType.Required"/>, entre otros
        /// </summary>
        /// <exception cref="ValidationErrorException"></exception>
        private void ValidateInMemoryOrThrow<TModel>(TModel model)
        {
            var validationContext = new ValidationContext(model);

            ICollection<ValidationResult> genericValidationResults = new List<ValidationResult>();

            Validator.TryValidateObject(
                model,
                validationContext,
                genericValidationResults,
                validateAllProperties: true
            );

            if (genericValidationResults.Any())
            {
                var firstGenericValidationErrors =
                    genericValidationResults.First();

                throw new ValidationErrorException(
                    firstGenericValidationErrors.MemberNames.ToList(), 
                    ValidationErrorType.Required
                );
            }
        }

        /// <summary>
        /// Realiza las validaciones que se pueden hacer solo consulta la base de datos
        /// Tales como: <see cref="ValidationErrorType.Unique"/>, entre otros
        /// </summary>
        /// <param name="model">Módelo que se validará</param>
        /// <param name="set">Conjunto al que pertenece el modelo</param>
        /// <exception cref="ValidationErrorException"></exception>
        private async Task ValidateInDbOrThrow<TModel>(
            IQueryable<TModel> set,
            TModel model
        ) where TModel : class
        {
            // Se obtiene el ID de la entidad indicada
            var modelId = (int)typeof(TModel).GetProperty(idPropertyName).GetValue(model);

            // Se generan las validaciones de índices únicos
            var uniqueIndexValidations = GenerateUniqueIndexValidationExpressions(modelId, model);

            if (!uniqueIndexValidations.Any())
            {
                return;
            }

            // Si hay alguna validación por hacer, las ejecutamos usando el set
            foreach (var validation in uniqueIndexValidations)
            {
                //Si alguna entidad del set pasa la validación..
                var modelIsInvalid =
                    await set.Where(validation.IsInvalidPredicate).AnyAsync();

                //..lanzamos el error de validación
                if (modelIsInvalid)
                {
                    throw new ValidationErrorException(
                        validation.Properties,
                        validation.Type
                    );
                }
            };
        }

        /// <summary>
        /// Genera las validaciones que se necesitan hacer para verificar indices únicos
        /// </summary>
        private IReadOnlyList<ValidationExpression<TModel>> GenerateUniqueIndexValidationExpressions<TModel>(
            int modelId,
            TModel model
        ) where TModel : class
        {
            var validationExpressions = 
                typeof(TModel)
                .GetProperties()
                .Select(property => new
                {
                    Property = property,
                    UniqueAttribute = property
                        .GetCustomAttributes(typeof(UniqueIndexAttribute), true)
                        .OfType<UniqueIndexAttribute>()
                        .FirstOrDefault()
                })
                .Where(property => property.UniqueAttribute != null)
                .Select(property => {
                    // Para verificar los índices únicos...
                    var entityParameter = Expression.Parameter(typeof(TModel), "entity");

                    var left = Expression.Property(entityParameter, idPropertyName);
                    var right = Expression.Constant(modelId);
                    var predicateNotEqualId = Expression.NotEqual(left, right);

                    left = Expression.Property(entityParameter, property.Property.Name);
                    right = Expression.Constant(property.Property.GetValue(model));
                    var predicateEqualUniqueColumn = Expression.Equal(left, right);

                    // Si el ID de la entidad no es igual al del modelo, y el valor de la propiedad única sí es igual, se tratará de un modelo inválido 
                    // ya que no respeta la unicidad de la propiedad
                    var predicateValidate = Expression.And(predicateNotEqualId, predicateEqualUniqueColumn);

                    var predicateToDetectInvalids = 
                        Expression.Lambda<Func<TModel, bool>>(
                            predicateValidate, 
                            new ParameterExpression[] { entityParameter }
                        );

                    return new ValidationExpression<TModel>(
                        predicateToDetectInvalids,
                        new[] { property.Property.Name },
                        ValidationErrorType.Unique
                    );
                })
                .ToList();

            return validationExpressions;
        }
    }
}
