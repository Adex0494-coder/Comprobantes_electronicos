using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comprobantes_Electronicos
{
    public static class GlobalConstants
    {
        public const string testAutSemillaUrl = "https://ecf.dgii.gov.do/TesteCF/Autenticacion/api/Autenticacion/Semilla";
        public const string testAutValSemillaUrl = "https://ecf.dgii.gov.do/TesteCF/Autenticacion/api/Autenticacion/ValidarSemilla";

        public const string certAutSemillaUrl = "https://ecf.dgii.gov.do/CerteCF/Autenticacion/api/Autenticacion/Semilla";
        public const string certAutValSemillaUrl = "https://ecf.dgii.gov.do/CerteCF/Autenticacion/api/Autenticacion/ValidarSemilla";
        public const string certReceNcf = "https://ecf.dgii.gov.do/CerteCF/Recepcion/api/FacturasElectronicas";
        public const string certConsultaResultado = "https://ecf.dgii.gov.do/CerteCF/ConsultaResultado/api/Consultas/Estado";
    }
}
