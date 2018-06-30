using ReclutaCV.Candidatos.List;
using ReclutaCVData.Entidades;
using ReclutaCVLogic.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReclutaCV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var candidatoList = new CandidatoListView();
            candidatoList.InitializeComponent();

            var candidatoListContext = new CandidatoListViewModel();
            candidatoListContext.Items = new List<Candidato>()
            {
                new Candidato() { Nombre ="Dani", Estatus = EstatusCandidato.OtraVacante },
                new Candidato() { Nombre ="Juan", Estatus = EstatusCandidato.AnalizandoAlCandidato },
                new Candidato() { Nombre ="Pablo", Estatus = EstatusCandidato.CitadoParaExamen },
            };

            candidatoList.DataContext = candidatoListContext;
            candidatoList.Show();

            //InitializeComponent();

            this.Candidato = new Candidato();

            this.DataContext = this;

        }

        public void GuardarCandidato()
        {
            var candidatoRepositorio = new CandidatoRepositorio();

            candidatoRepositorio.Guardar(this.Candidato);
        }

        public Candidato Candidato { get; set; }

        private void Guardar(object sender, RoutedEventArgs e)
        {
            this.GuardarCandidato();
        }
    }
}
