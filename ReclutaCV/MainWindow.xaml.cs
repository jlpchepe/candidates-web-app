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

            this.CandidatoList = new CandidatoListViewModel();

            candidatoList.DataContext = this.CandidatoList;
            candidatoList.Show();

            this.ReiniciarCandidato();

            this.DataContext = this;

        }

        public Candidato Candidato { get; set; }
        public CandidatoListViewModel CandidatoList { get; }

        void ReiniciarCandidato()
        {
            this.Candidato = new Candidato();
        }

        private void GuardarCandidato(object sender, RoutedEventArgs e)
        {
            var candidatoRepositorio = new CandidatoRepositorio();

            candidatoRepositorio.Guardar(this.Candidato);

            this.CandidatoList.RefrescarCandidatos();

            this.ReiniciarCandidato();
        }
    }
}
