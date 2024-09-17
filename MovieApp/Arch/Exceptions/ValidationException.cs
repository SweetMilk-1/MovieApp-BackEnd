using FluentValidation.Results;
using System.Net;

namespace MovieApp.Arch.Exceptions;
/// <summary>
/// Класс определяет формат ошибки валидации
/// </summary>
public class ValidationException : HttpErrorWithStatusCodeException
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public ValidationException()
        : base(HttpStatusCode.BadRequest, "Произошла одна или несколько ошибок валидации данных.")
    {
    }

    /// <summary>
    /// Преобразовывает список ошибок из FluentValidation в IDictionary
    /// </summary>
    /// <param name="errors">List ValidationFailure</param>
    public ValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        var errors = new Dictionary<string, string[]>();
        var propertyNames = failures
            .Select(e => e.PropertyName)
            .Distinct();

        foreach (var propertyName in propertyNames)
        {
            var propertyFailures = failures
                .Where(e => e.PropertyName == propertyName)
                .Select(e => e.ErrorMessage)
                .ToArray();

            errors.Add(propertyName, propertyFailures);
        }
        AdditionalData = errors;
    }
}

