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
            options.DefaultRequestCulture.UICulture.NumberFormat.NumberGroupSeparator = ",";
            options.DefaultRequestCulture.UICulture.NumberFormat.NumberDecimalSeparator = ".";
            options.DefaultRequestCulture.UICulture.NumberFormat.CurrencyGroupSeparator = ",";
            options.DefaultRequestCulture.UICulture.NumberFormat.CurrencyDecimalSeparator = ".";

            options.SetDefaultCulture("en-US");
        });
    }
}