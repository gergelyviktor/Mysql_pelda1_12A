using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mysql_pelda1_12A {
    internal class Konyv {
        public int Id { get; set; }
        public string Cim { get; set; }
        public int SzerzoId { get; set; }
        public int Helyezes { get; set; }
        public Konyv(int id, string cim, int szerzoId, int helyezes) {
            Id = id;
            Cim = cim;
            SzerzoId = szerzoId;
            Helyezes = helyezes;
        }
    }
}
