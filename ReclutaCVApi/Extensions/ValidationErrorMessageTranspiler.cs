using System.Collections.Generic;
using System.Linq;
using AppPersistence.Entities;
using AppPersistence.Exceptions;

namespace ReclutaCVApi.Extensions
{
    /// <summary>
    /// Transpilador de mensajes de error a partir de errores de validación <see cref="ValidationErrorException"/>
    /// </summary>
    internal class ValidationErrorMessageTranspiler
    {
        /// <summary>
        /// A partir de la excepción de validación, obtiene el mensaje amigable de validación
        /// Si no encuentra el mensaje amigable, regresa un código de error
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public string TranspileFriendlyMessage(ValidationErrorException error)
        {
            var errorCode =
                $"{string.Join("-", error.Properties)}:{error.Type.ToString()}".ToUpper();

            var errorTranslationExist =
                translationTable.TryGetValue(errorCode, out var errorMessage);

            return errorTranslationExist ? errorMessage : errorCode;
        }

        /// <summary>
        /// Diccionario que contiene la relación entre el código de error de validación y el mensaje al que equivale
        /// </summary>
        /// <remarks>La clave es el código de error y el valor es el mensaje amigable</remarks>
        private readonly IReadOnlyDictionary<string, string> translationTable =
            new Dictionary<string, string>
            {
                { nameof(WorkOrder.Advisor) + ":REQUIRED", "El asesor es requerido" },
                { nameof(WorkOrder.ClientName) + ":REQUIRED", "El nombre del cliente es requerido" },
                { nameof(WorkOrder.ClientLastName) + ":REQUIRED", "Los apellidos del cliente son requeridos" },
                { nameof(WorkOrder.ServiceNumber) + ":REQUIRED", "El número de servicio es requerido" },
                { nameof(WorkOrder.ServiceType) + ":REQUIRED", "El tipo de servicio es requerido" },
                { nameof(WorkOrder.CarVin) + ":REQUIRED", "El VIN del auto es requerido" },
                { nameof(WorkOrder.PromiseDate) + ":REQUIRED", "La fecha promesa es requerida" },
                { nameof(WorkOrder.EntryDate) + ":REQUIRED", "La fecha de entrada es requerida" },
                { nameof(WorkOrder.TowerColor) + ":REQUIRED", "El color de la torre es requerido" },
                { nameof(WorkOrder.TowerNumber) + ":REQUIRED", "El número de la torre es requerido" },
                { nameof(WorkOrder.ServiceNumber) + ":UNIQUE", "Otro registro ya tiene este número de servicio" },
                { "ACTIVE:REQUIRED", "El estatus es requerido" },
                { "NAME:REQUIRED", "El nombre es requerido" },
                { "CODE:REQUIRED", "El código es requerido" },
                { "EMPLOYEETYPE:REQUIRED", "El tipo de empleado es requerido" },
                { "WORKSTATION:REQUIRED", "La estación de trabajo es requerida" },
                { "MECHANICLEVEL:REQUIRED", "El nivel de mecánico es requerido" },
                { "REASON:REQUIRED", "La motivo es requerido" },
                { "ROLE:REQUIRED", "El rol es requerido" },
                { "STARTDATE:REQUIRED", "La fecha inicio es requerida" },
                { nameof(Absent.DueDate) + ":REQUIRED", "La fecha fin es requerida" },
                { "OPERATOR:REQUIRED", "El operador es requerido" },
                { nameof(Activity.EstimatedMinutes) + ":REQUIRED", "Los minutos son requeridos" },
                { "NAME:UNIQUE", "Otro registro ya tiene este nombre" },
                { "CODE:UNIQUE", "Otro registro ya tiene este código " },
                { "PASSWORD:REQUIRED", "La contraseña es requerida" },
                { "VALIDATION_PASSWORD:INVALID", "La contraseña es invalida" },
                { "USER:INVALID", "El usuario es invalido" },
                { "DATE:UNIQUE", "Otro registro ya tiene esta fecha" },
                { nameof(Configuration.SystemPrimaryColor) + ":INVALID", "Color primario es inválido" },
                { nameof(Configuration.SystemSecondaryColor) + ":INVALID", "Color secundario es inválido"},
                { nameof(Configuration.CompanyLogo) + ":INVALID", "Logo de la compañía es inválido"},
                { "DATE:REQUIRED", "La fecha es requerida" },
                { nameof(Absent.StartDate) + ":INVALID", "El rango de fechas esta en conflicto con una ausencia previamente registrada "},
                { nameof(Absent.DueDate) + nameof(Absent.HoursOfAbsent) + ":REQUIRED", "La fecha fin o las horas de ausencia es requerido" },
                { nameof(ActivityKit.ActivityKitActivities) + ":REQUIRED", "Las actividades del kit son requeridas"},
                { nameof(Absent.DueDate) + ":INVALID", "Rango de fechas inválido"},
                { nameof(Advisor.ConeColor) + ":REQUIRED", "El color del cono es requerido" },
                { nameof(WorkOrderActivity) + "StatusChange:INVALID", "Cambio de estatus de actividad inválido" },
                { "WorkOrderActivityOperatorBusy:INVALID", "El operador está ocupado en otra actividad" },
                { nameof(Configuration.ActivityTimeDangerPortion) + ":INVALID", "El tiempo de peligro de la actividad es invalido" },
                { nameof(Configuration.ActivityTimeWarningPortion) + ":INVALID", "El tiempo de advertencia de la actividad es invalido" },
                { nameof(Configuration.GlobalTimeDangerPortion) + ":INVALID", "El tiempo global de peligro es invalido" },
                { nameof(Configuration.GlobalTimeWarningPortion) + ":INVALID", "El tiempo global de advertencia es invalido" },
                { nameof(Configuration.ActivityTimeWarningPortion) + nameof(Configuration.ActivityTimeDangerPortion) + ":INVALID",
                  "El porcentaje de advertencia de actividad debe de ser menor al porcentaje de peligro." },
                { nameof(Configuration.GlobalTimeWarningPortion) + nameof(Configuration.GlobalTimeDangerPortion) + ":INVALID",
                  "El porcentaje de advertencia global debe de ser menor al porcentaje de peligro." },
                { nameof(Configuration.HalfDayHours) + ":REQUIRED", "Las horas en mediodia son requeridas"},
                { nameof(Configuration.GlobalTimeDangerPortion) + ":REQUIRED", "El tiempo global de peligro es requerido"},
                { nameof(Configuration.GlobalTimeWarningPortion) + ":REQUIRED", "El tiempo global de advertencia es requerido"},
                { nameof(Configuration.ActivityTimeDangerPortion) + ":REQUIRED", "El tiempo de peligro de la actividad es requerido"},
                { nameof(Configuration.ActivityTimeWarningPortion) + ":REQUIRED", "El tiempo de advertencia de la actividad es requerido"},
                { nameof(Configuration.DeliveryMarginTime) + ":REQUIRED", "El margen de tiempo de entrega es requerido"},
                { nameof(Configuration.ResendNotificationTime) + ":REQUIRED", "El tiempo de reenvio de notificaciones a asesores es requerido"},
                { nameof(Configuration.WorkHoursOnMonday) + ":REQUIRED", "Las horas en lunes son requeridas"},
                { nameof(Configuration.WorkHoursOnTuesday) + ":REQUIRED", "Las horas en martes son requeridas"},
                { nameof(Configuration.WorkHoursOnWednesday) + ":REQUIRED", "Las horas en miércoles son requeridas"},
                { nameof(Configuration.WorkHoursOnThursday) + ":REQUIRED", "Las horas en jueves son requeridas"},
                { nameof(Configuration.WorkHoursOnFriday) + ":REQUIRED", "Las horas en viernes son requeridas"},
                { nameof(Configuration.WorkHoursOnSaturday) + ":REQUIRED", "Las horas en sábado son requeridas"},
                { nameof(Configuration.WorkHoursOnSunday) + ":REQUIRED", "Las horas en domingo son requeridas"},
                { nameof(Configuration.SystemPrimaryColor) + ":REQUIRED", "El color primario del sistema es requerido"},
                { nameof(Configuration.SystemSecondaryColor) + ":REQUIRED", "El color secundario del sistema es requerido"},




            }
            .ToDictionary(x => x.Key.ToUpper(), x => x.Value);
    }
}