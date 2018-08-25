using ReclutaCV.Candidatos.Edit;
using ReclutaCV.Candidatos.List;
using ReclutaCV.Utils.Commands;
using ReclutaCVData;
using ReclutaCVLogic.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReclutaCV.Ventanas.MenuPrincipal
{
    public class MenuPrincipalViewModel
    {
        public ICommand VerListadoCandidatos => new SimpleCommand(() =>
        {
            var candidatoService = new CandidatoService(() => new Db());

            var candidatoList = new CandidatoListViewModel(
                candidatoService,
                () => new CandidatoEditViewModel(candidatoService)
            );

            candidatoList.AbrirVentana();
        });
    }
}
