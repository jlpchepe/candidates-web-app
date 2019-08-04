using AppPersistence.Repositories;
using AppPersistence.Repositories.Impl;
using AppPersistence.Validators;
using ReclutaCV.Candidatos.Edit;
using ReclutaCV.Candidatos.List;
using ReclutaCV.Utils.Commands;
using ReclutaCV.Ventanas.Catalogos.SolicitudesVacante.Edit;
using ReclutaCV.Ventanas.Catalogos.SolicitudesVacante.List;
using ReclutaCV.Ventanas.Operativas.EtapasCandidato;
using ReclutaCVData;
using ReclutaCVData.Entidades;
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

        private readonly Func<Db> db;
        private CrudRepository<TEntity, TPrimaryKey> CreateRepository<TEntity, TPrimaryKey>() where TEntity : class
        {
            return new DbCrudRepository<TEntity, TPrimaryKey>(
                new DbRepository(db),
                new DbModelValidator()
            );
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

        public ICommand VerListadoCandidatos => new SimpleCommand(() =>
        {
            var candidatoService = new CandidatoService(this.CreateRepository<Candidato, int>());

            var window = new CandidatoListViewModel(
                candidatoService,
                () => new CandidatoEditViewModel(candidatoService),
                ObtenerEtapasCandidatoViewModelFactory()
            );

            window.AbrirVentana();
        });

        public ICommand VerListadoDeSolicitudDeVacantes => new SimpleCommand(() =>
        {
            var service = new SolicitudVacantesService(this.CreateRepository<SolicitudVacante, int>());

            var window = new SolicitudVacanteListViewModel(
                service,
                () => new SolicitudVacanteEditViewModel(service)
            );

            window.AbrirVentana();
        });
    }
}
