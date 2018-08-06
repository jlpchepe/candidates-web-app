﻿using ReclutaCV.Candidatos.Edit;
using ReclutaCV.Utils.Commands;
using ReclutaCVData;
using ReclutaCVData.Entidades;
using ReclutaCVLogic.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReclutaCV.Candidatos.List
{
    public class CandidatoListViewModel
    {
        public CandidatoListViewModel(
            CandidatoService candidatoService,
            Func<CandidatoEditViewModel> candidatoEditViewModelFactory
        )
        {
            this.candidatoService = candidatoService;
            this.candidatoEditViewModelFactory = candidatoEditViewModelFactory;
            this.RefrescarCandidatos();
        }
    
        public List<Candidato> Items { get; internal set; }
        public Candidato Seleccionado { get; set; }
        private bool TieneSeleccionado => this.Seleccionado != null;

        private readonly Func<CandidatoEditViewModel> candidatoEditViewModelFactory;
        private readonly CandidatoService candidatoService;

        public ICommand Agregar => new SimpleCommand(this.candidatoEditViewModelFactory().CargarNuevoYAbrirVentana);
        public ICommand Editar => new SimpleCommand(() => this.candidatoEditViewModelFactory().CargarExistenteYAbrirVentana(this.Seleccionado.Id), () => TieneSeleccionado);
        public ICommand Borrar => new SimpleCommand(() => {
            this.candidatoService.Delete(this.Seleccionado.Id);
            this.RefrescarCandidatos();
        }, () => TieneSeleccionado);

        public void RefrescarCandidatos()
        {
            //Cargamos los candidatos desde la base de datos
            this.Items = this.candidatoService.FindAll();
        }
    }
}
