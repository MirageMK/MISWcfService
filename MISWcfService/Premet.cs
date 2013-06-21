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
        public int id;
        [DataMember]
        public string naslov;
        [DataMember]
        public string smer;
        [DataMember]
        public int semestar;
        [DataMember]
        public bool zadolzitelen;
        [DataMember]
        public string opis;
    }
}