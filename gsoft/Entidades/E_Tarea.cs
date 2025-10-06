using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gsoft.Entidades
{
    public class E_Tarea
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaLimite { get; set; }
        public string Prioridad { get; set; }
        public int Horas { get; set; }
        public string ProyectoId { get; set; }
        public string ResponsableId { get; set; }
        public string Estado { get; set; }
    }
}
