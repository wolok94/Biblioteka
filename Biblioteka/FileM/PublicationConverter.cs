using Biblioteka.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Biblioteka
{
    public  class PublicationConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Publication).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);

            // Using a nullable bool here in case "is_album" is not present on an item
            bool? isBook = (bool?)jo["IsBook"];
            

            Publication publication = null;
            if (isBook.GetValueOrDefault())
            {
                publication = new Book();
            }
            else
            {
                publication = new Magazine();
            }

            serializer.Populate(jo.CreateReader(), publication);

            return publication;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer,
            object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
