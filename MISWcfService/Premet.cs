using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MISWcfService
{
    [DataContract]
    public class Premet
    {
        [DataMember]
        public int ID;
        [DataMember]
        public string key;
        [DataMember]
        public string title;
        [DataMember]
        public string subtitle;
        [DataMember]
        public string backgroundImage;
        [DataMember]
        public string description;
    }
}