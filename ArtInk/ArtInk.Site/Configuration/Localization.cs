using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;

namespace ArtInk.Site.Configuration;

public static class Localization
{
    public static void ConfigureLocalization(this IServiceCollection services)
    {
        services.Configure<RequestLocalizationOptions>(options =>
        {
            options.DefaultRequestCulture = new RequestCulture(culture: "es-CR", uiCulture: "es-CR");
            options.DefaultRequestCulture.Culture.NumberFormat.NumberGroupSeparator = ",";
            options.DefaultRequestCulture.Culture.NumberFormat.NumberDecimalSeparator = ".";
            options.DefaultRequestCulture.Culture.NumberFormat.CurrencyGroupSeparator = ",";
            options.DefaultRequestCulture.Culture.NumberFormat.CurrencyDecimalSeparator = ".";

            options.DefaultRequestCulture.UICulture.NumberFormat.NumberGroupSeparator = ",";
            options.DefaultRequestCulture.UICulture.NumberFormat.NumberDecimalSeparator = ".";
            options.DefaultRequestCulture.UICulture.NumberFormat.CurrencyGroupSeparator = ",";
            options.DefaultRequestCulture.UICulture.NumberFormat.CurrencyDecimalSeparator = ".";
        });
    }
}