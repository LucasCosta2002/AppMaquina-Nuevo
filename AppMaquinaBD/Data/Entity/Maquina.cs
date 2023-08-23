using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMaquinaBD.Data.Entity
{
    public class Maquina
    {
        public int Id { get; set; }
        public int NumMaquina { get; set; }
        public int MaquinistaId { get; set; }
        public Maquinista Maquinista { get; set; }
    }
}
