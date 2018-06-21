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
            InitializeComponent();

            this.Candidato = new Candidato();

            this.DataContext = this;

        }

        public void GuardarCandidato()
        {
            var candidatoRepositorio = new CandidatoRepositorio();

            candidatoRepositorio.Guardar(this.Candidato);
        }

        public Candidato Candidato { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.GuardarCandidato();
        }
    }
}
