﻿using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Postex.SharedKernel.Swagger
{
    public class AddReadOnlyPropertiesFilter : ISchemaFilter
    {

        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema?.Properties?.Count > 0)
                schema.Properties.Values.SingleOrDefault(v => v.ReadOnly = false);
        }
    }
}

