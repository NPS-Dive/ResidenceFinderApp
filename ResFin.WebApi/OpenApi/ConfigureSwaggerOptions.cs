using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ResFin.WebApi.OpenApi;

public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _descriptionProvider;

    public ConfigureSwaggerOptions( IApiVersionDescriptionProvider descriptionProvider )
    {
        _descriptionProvider = descriptionProvider;
    }

    public void Configure ( SwaggerGenOptions options )
        {
            foreach (var description in _descriptionProvider.ApiVersionDescriptions)
            {
              options.SwaggerDoc(description.GroupName,CreateVersionInfo(description));
            }
        }


    public void Configure ( string? name, SwaggerGenOptions options )
    {
        Configure(options);
    }

    private static OpenApiInfo CreateVersionInfo ( ApiVersionDescription description )
    {
        var openApiInfo = new OpenApiInfo()
        {
                        Title = $"ResFin.WebApi v{description.ApiVersion}",
                        Version =  description.ApiVersion.ToString()
        };

        if (description.IsDeprecated)
        {
            openApiInfo.Description += "The given API version has been deprecated";
        }

        return openApiInfo;
    }


    }