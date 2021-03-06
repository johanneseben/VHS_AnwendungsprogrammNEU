﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Kursort
    {
        public virtual int KursortID { get; set; }
        public virtual string Bezeichnung { get; set; }
        public virtual string Beschreibung { get; set; }
        public virtual string Strasse { get; set; }
        public virtual Postleitzahl PostleitzahlID { get; set; }

        [JsonIgnore]
        public virtual ICollection<Postleitzahl> Postleitzahl1 { get; set; }

        public Kursort()
        {
            this.Postleitzahl1 = new HashSet<Postleitzahl>();
        }
    }
}
