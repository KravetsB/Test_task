using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;


namespace DataAccessLayer.Serializers
{
    public class JSONSerializer<T>
    {
        public string FilePath { get; set; }

        public JSONSerializer()
        {
            FilePath = "data.json";
        }
        public JSONSerializer(string filePath)
        {
            FilePath = filePath;
        }

        public void Clear()
        {
            if (!File.Exists(FilePath))
                throw new FileNotFoundException($"File '{FilePath}' does not exist.");
            FileStream stream = new FileStream(FilePath, FileMode.Truncate);
            stream.Close();
        }

        public T Deserialize()
        {
            if (!File.Exists(FilePath))
                throw new FileNotFoundException($"File '{FilePath}' does not exist.");
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
            using (FileStream stream = new FileStream(FilePath, FileMode.Open))
                return (T)jsonSerializer.ReadObject(stream);
        }

        public void Serialize(T data)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
            using (FileStream stream = new FileStream(FilePath, FileMode.OpenOrCreate))
                jsonSerializer.WriteObject(stream, data);
        }
    }
}
