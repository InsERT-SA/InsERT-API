﻿using System.Text.Json.Serialization;

namespace MvcExample.Application.Services.Subiekt123.Dto
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum KindDto
    {
        Invoice,
        Receipt,
        Proforma
    }
}