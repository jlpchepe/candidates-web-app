using ReclutaCVLogic.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCV.Ventanas.Operativas.EtapasCandidato
{
    public class EtapasCandidatoViewModel
    {
        public EtapasCandidatoViewModel(
            EtapasCandidatoService etapasCandidatoService
        )
        {
            this.etapasCandidatoService = etapasCandidatoService;
        }
        readonly EtapasCandidatoService etapasCandidatoService;


    }
}
