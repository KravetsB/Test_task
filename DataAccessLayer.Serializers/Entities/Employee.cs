using System;
using System.Runtime.Serialization;


namespace DataAccessLayer.Serializers.Entities
{

    [Serializable, DataContract]
    public class Employee  
    {
             
        [DataMember]
        public string first_name { get; set; }
        [DataMember]
        public string last_name { get; set; }
        [DataMember]
        public string gender { get; set; }
        [DataMember]
        public string department { get; set; }
        [DataMember]
        public double salary { get; set; }
        [DataMember]
        public string position { get; set; }


    }
}
