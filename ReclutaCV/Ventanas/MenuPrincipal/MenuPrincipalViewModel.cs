using ReclutaCV.Candidatos.Edit;
using ReclutaCV.Candidatos.List;
using ReclutaCV.Utils.Commands;
using ReclutaCV.Ventanas.Catalogos.SolicitudesVacante.Edit;
using ReclutaCV.Ventanas.Catalogos.SolicitudesVacante.List;
using ReclutaCV.Ventanas.Operativas.EtapasCandidato;
using ReclutaCVData;
using ReclutaCVLogic.Servicios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReclutaCV.Ventanas.MenuPrincipal
{
    public class MenuPrincipalViewModel
    {
        public MenuPrincipalViewModel()
        {
            this.db = () => new Db();

            this.InitializeFirstDbContextFireForget();
        }

        private async void InitializeFirstDbContextFireForget()
        {
            try
            {
                var a = await this.db().Candidato.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Func<EtapasCandidatoViewModel> ObtenerEtapasCandidatoViewModelFactory()
        {
            var service = new EtapasCandidatoService(db);

            EtapasCandidatoViewModel windowFactory() => 
                new EtapasCandidatoViewModel(
                    service
                );

            return windowFactory;
        }

        private readonly Func<Db> db;

        public ICommand VerListadoCandidatos => new SimpleCommand(() =>
        {
            var candidatoService = new CandidatoService(this.db);

            var window = new CandidatoListViewModel(
                candidatoService,
                () => new CandidatoEditViewModel(candidatoService),
                ObtenerEtapasCandidatoViewModelFactory()
            );

            window.AbrirVentana();
        });
        public ICommand VerListadoDeSolicitudDeVacantes => new SimpleCommand(() =>
        {
            var service = new SolicitudVacantesService(db);

            var window = new SolicitudVacanteListViewModel(
                service,
                () => new SolicitudVacanteEditViewModel(service)
            );

            window.AbrirVentana();
        });

        

    }
}
