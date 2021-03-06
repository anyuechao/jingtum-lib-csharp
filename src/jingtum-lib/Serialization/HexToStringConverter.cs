﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JingTum.Lib
{
    internal class HexToStringConverter : JsonConverter
    {
        public override bool CanWrite => false;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if(reader.TokenType == JsonToken.String)
            {
                var value = reader.Value as string;
                try
                {
                    return Utils.HexToString(value);
                }
                catch
                {
                    return value;
                }
            }

            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
