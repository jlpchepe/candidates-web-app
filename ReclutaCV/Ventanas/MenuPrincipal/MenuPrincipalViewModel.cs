using ReclutaCV.Candidatos.Edit;
using ReclutaCV.Candidatos.List;
using ReclutaCV.Utils.Commands;
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
            var a = await this.db().Candidato.FirstOrDefaultAsync();
        }

        private readonly Func<Db> db;

        public ICommand VerListadoCandidatos => new SimpleCommand(() =>
        {
            var candidatoService = new CandidatoService(this.db);

            var candidatoList = new CandidatoListViewModel(
                candidatoService,
                () => new CandidatoEditViewModel(candidatoService)
            );

            candidatoList.AbrirVentana();
        });
    }
}
