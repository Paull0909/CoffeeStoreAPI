using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace Application.Service
{
    public class SwaggerNullableParameterFilter : IParameterFilter
    {
        public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
        {
            try
            {
                var type = context.ApiParameterDescription.Type;

                bool isNullable = !type.IsValueType || Nullable.GetUnderlyingType(type) != null;

                if (!parameter.Schema.Nullable && isNullable)
                {
                    parameter.Schema.Nullable = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
