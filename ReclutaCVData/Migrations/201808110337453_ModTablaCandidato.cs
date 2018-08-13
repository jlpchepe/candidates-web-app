namespace ReclutaCVData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModTablaCandidato : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Candidato",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AñosDeExperiencia = c.Int(nullable: false),
                        Nombre = c.String(),
                        FechaDeNacimiento = c.DateTime(nullable: false),
                        ApellidoPaterno = c.String(),
                        ApellidoMaterno = c.String(),
                        CiudadResidencia = c.String(),
                        SueldoActual = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SueldoEsperado = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Carrera = c.String(),
                        Universidad = c.String(),
                        NivelDeInglesHablado = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NivelDeInglesEscrito = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NivelDeInglesLectura = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cursos = c.String(),
                        Certificaciones = c.String(),
                        Telefono = c.String(),
                        Correo = c.String(),
                        EstatusAcademico = c.Int(nullable: false),
                        Nivel = c.Int(nullable: false),
                        Bolsa = c.String(),
                        FechaDeContacto = c.DateTime(nullable: false),
                        QuienLoContacto = c.String(),
                        Rol = c.Int(nullable: false),
                        FechaDeExamen = c.DateTime(nullable: false),
                        HoraDeExamen = c.DateTime(nullable: false),
                        CalificacionDelExamen = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaDeEntrevista = c.DateTime(nullable: false),
                        PropuestaEconomicaMonto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaDeIngresoALaEmpresa = c.DateTime(nullable: false),
                        Estatus = c.Int(nullable: false),
                        Comentarios = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("public.Candidato");
        }
    }
}
