﻿using System.Text.Json.Serialization;

namespace DotNetRpgProject.Model
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight = 0,
        Mage = 1,
        Cleric = 2
    }
}
