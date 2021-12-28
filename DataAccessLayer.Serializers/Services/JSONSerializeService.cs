using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Serializers.Services
{
    public class JSONSerializerService<T>
    {
        protected JSONSerializer<T> _serializer;
        public void Clear()
        {
            _serializer.Clear();
        }

        public T Read()
        {
            return _serializer.Deserialize();
        }

        public void Write(T data)
        {
            _serializer.Serialize(data);
        }

        public JSONSerializerService()
        {
            _serializer = new JSONSerializer<T>();
        }
        public JSONSerializerService(string filePath)
        {
            _serializer = new JSONSerializer<T>(filePath);
        }
    }
}
