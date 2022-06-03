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
    public  class PublicationConverter<T> : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);

            // Using a nullable bool here in case "is_album" is not present on an item
            bool? isBook = (bool?)jo["IsBook"];
            

            Publication publication = null;
            User user = null;
            if (typeof(T).Equals(typeof(Publication)))
            {
                if (isBook.GetValueOrDefault())
                {
                    publication = new Book();
                }
                else if (!isBook.GetValueOrDefault())
                {
                    publication = new Magazine();
                }
                serializer.Populate(jo.CreateReader(), publication);
                jo = null;
                return publication;
            }
            else
            
            {
                
                user = new Reader();
                serializer.Populate(jo.CreateReader(), user);
                
                return user;

            }

                
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
