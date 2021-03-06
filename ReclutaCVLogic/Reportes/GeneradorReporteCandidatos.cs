﻿using ReclutaCVLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Reportes
{
    public interface GeneradorReporteCandidatos
    {
        Task<Reporte> GenerarReporteCandidatos(IReadOnlyList<FilaReporteCandidato> candidatos);
    }
}
