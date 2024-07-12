using System.ComponentModel.DataAnnotations;
using System.Globalization;
using ArtInk.Site.ViewModels.Common;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ArtInk.Site.Configuration.CustomValidations;

/// <summary>
/// El m�todo RangeMonth es una clase de validaci�n personalizada
/// que hereda de ValidationAttribute e implementa la interfaz IClientModelValidator. 
/// Esta clase se utiliza para validar
/// que un valor de d�a del mes sea v�lido seg�n 
/// el mes especificado en otra propiedad del mismo objeto.
/// </summary>

public class RangeMonth : ValidationAttribute, IClientModelValidator
{
    private readonly int min;
    private readonly string propertyMonthToCheck;

    public RangeMonth(int min, string propertyMonthToCheck)
    {
        this.min = min;
        this.propertyMonthToCheck = propertyMonthToCheck;
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
            return new ValidationResult($"Ingrese un valor");

        var propertyName = validationContext.ObjectType.GetProperty(propertyMonthToCheck);
        if (propertyName == null)
            return new ValidationResult(string.Format(CultureInfo.CurrentCulture, "Unknown property {0}", new[] { propertyMonthToCheck }));

        var propertyValue = propertyName.GetValue(validationContext.ObjectInstance, null) as string;
        var propertyValueEnum = (Mes)Enum.Parse(typeof(Mes), propertyValue!);

        var diasMes = DateTime.DaysInMonth(2000, (int)propertyValueEnum);

        if (!int.TryParse(value.ToString()!, out var dia)) return new ValidationResult($"Ingrese un valor entre 1 y {diasMes}");

        if (dia > diasMes)
            return new ValidationResult($"Ingrese un valor entre 1 y {diasMes}");

        return ValidationResult.Success!;
    }

    public void AddValidation(ClientModelValidationContext context) {
		var errorMessage = FormatErrorMessage(context.ModelMetadata.GetDisplayName());
		context.Attributes.TryAdd("data-val-min", min.ToString());
		context.Attributes.TryAdd("data-val-property-month-check", propertyMonthToCheck);
        context.Attributes.TryAdd("data-val-range-month", errorMessage);
	}
}