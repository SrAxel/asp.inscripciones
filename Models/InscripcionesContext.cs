using Microsoft.EntityFrameworkCore;
using Inscripciones.Models;
using System.Drawing.Drawing2D;

namespace Inscripciones.Models
{
    public class InscripcionesContext : DbContext
    {
        public InscripcionesContext(DbContextOptions<InscripcionesContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;      
            //               Database=InscripcionesContext;
            //               User Id = sa; Password = 123;
            //               MultipleActiveResultSets = True; 
            //               Encrypt=false ") ;
            string cadenaConexion = "Server=5.57.213.17;Database=smartsof_axelvallejos;User=smartsof_axel;Password=vallejosaxel123;";

            optionsBuilder.UseMySql(cadenaConexion,
            ServerVersion.AutoDetect(cadenaConexion));
        }

        ///ESTE C�DIGO LO DEBEN AGREGAR A LA CLASE DBCONTEXT DESPU�S DE HABER CREADO EL MODELO MATERIA
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Datos semilla de carreras
            var tsds = new Carrera { Id = 1, Nombre = "Tecnicatura Superior en Desarrollo de Software" };
            var tssi = new Carrera { Id = 2, Nombre = "Tecnicatura Superior en Soporte de Infraestructura" };
            var tsgo = new Carrera { Id = 3, Nombre = "Tecnicatura Superior en Gestion de las Organizaciones" };
            var tse = new Carrera { Id = 4, Nombre = "Tecnicatura Superior en Enfermeria" };
            var pesca = new Carrera { Id = 5, Nombre = "Profesorado de Educaci�n Secundaria en Ciencias de la Administraci�n" };
            var pei = new Carrera { Id = 6, Nombre = "Profesorado de Educaci�n Inicial" };
            var pese = new Carrera { Id = 7, Nombre = "Profesorado de Educaci�n Secundaria en Econom�a" };
            var pet = new Carrera { Id = 8, Nombre = "Profesorado de Educaci�n Tecnol�gica" };
            var lcm = new Carrera { Id = 9, Nombre = "Licenciatura en Cooperativismo y Mutualismo" };
            modelBuilder.Entity<Carrera>().HasData(tsds, tssi, tsgo, tse, pesca, pei, pese, pet, lcm);
            #endregion

            #region Datos semillas de AnioCarreras
            //TECNICO SUPERIOR EN DESARROLLO DE SOFTWARE
            var ac1 = new AnioCarrera { Id = 1, CarreraId = 1, Nombre = "1er a�o" };
            var ac2 = new AnioCarrera { Id = 2, CarreraId = 1, Nombre = "2do a�o" };
            var ac3 = new AnioCarrera { Id = 3, CarreraId = 1, Nombre = "3er a�o" };
            //Tecnicatura Superior en Soporte de Infraestructura
            var ac4 = new AnioCarrera { Id = 4, CarreraId = 2, Nombre = "1er a�o" };
            var ac5 = new AnioCarrera { Id = 5, CarreraId = 2, Nombre = "2do a�o" };
            var ac6 = new AnioCarrera { Id = 6, CarreraId = 2, Nombre = "3er a�o" };
            //Tecnicatura Superior en Gestion de las Organizaciones
            var ac7 = new AnioCarrera { Id = 7, CarreraId = 3, Nombre = "1er a�o" };
            var ac8 = new AnioCarrera { Id = 8, CarreraId = 3, Nombre = "2do a�o" };
            var ac9 = new AnioCarrera { Id = 9, CarreraId = 3, Nombre = "3er a�o" };
            //Tecnicatura Superior en Enfermeria
            var ac10 = new AnioCarrera { Id = 10, CarreraId = 4, Nombre = "1er a�o" };
            var ac11 = new AnioCarrera { Id = 11, CarreraId = 4, Nombre = "2do a�o" };
            var ac12 = new AnioCarrera { Id = 12, CarreraId = 4, Nombre = "3er a�o" };
            //Profesorado de Educaci�n Secundaria en Ciencias de la Administraci�n
            var ac13 = new AnioCarrera { Id = 13, CarreraId = 5, Nombre = "1er a�o" };
            var ac14 = new AnioCarrera { Id = 14, CarreraId = 5, Nombre = "2do a�o" };
            var ac15 = new AnioCarrera { Id = 15, CarreraId = 5, Nombre = "3er a�o" };
            var ac16 = new AnioCarrera { Id = 16, CarreraId = 5, Nombre = "4to a�o" };
            //Profesorado de Educaci�n Inicial
            var ac17 = new AnioCarrera { Id = 17, CarreraId = 6, Nombre = "1er a�o" };
            var ac18 = new AnioCarrera { Id = 18, CarreraId = 6, Nombre = "2do a�o" };
            var ac19 = new AnioCarrera { Id = 19, CarreraId = 6, Nombre = "3er a�o" };
            var ac20 = new AnioCarrera { Id = 20, CarreraId = 6, Nombre = "4to a�o" };
            //Profesorado de Educaci�n Secundaria en Econom�a
            var ac21 = new AnioCarrera { Id = 21, CarreraId = 7, Nombre = "1er a�o" };
            var ac22 = new AnioCarrera { Id = 22, CarreraId = 7, Nombre = "2do a�o" };
            var ac23 = new AnioCarrera { Id = 23, CarreraId = 7, Nombre = "3er a�o" };
            var ac24 = new AnioCarrera { Id = 24, CarreraId = 7, Nombre = "4to a�o" };
            //Profesorado de Educaci�n Tecnol�gica
            var ac25 = new AnioCarrera { Id = 25, CarreraId = 8, Nombre = "1er a�o" };
            var ac26 = new AnioCarrera { Id = 26, CarreraId = 8, Nombre = "2do a�o" };
            var ac27 = new AnioCarrera { Id = 27, CarreraId = 8, Nombre = "3er a�o" };
            var ac28 = new AnioCarrera { Id = 28, CarreraId = 8, Nombre = "4to a�o" };

            modelBuilder.Entity<AnioCarrera>().HasData(
                ac1, ac2, ac3, ac4, ac5, ac6, ac7, ac8, ac9, ac10,
                ac11, ac12, ac13, ac14, ac15, ac16, ac17, ac18,
                ac19, ac20, ac21, ac22, ac23, ac24, ac25, ac26,
                ac27, ac28);
            #endregion



            #region Datos semilla de Materias

            // PROFESORADO DE EDUCACI�N SECUNDARIA EN ECONOM�A
            var materiasEconomia = new[]
            {
               new Materia { Id = 1, Nombre = "Pedagog�a", AnioCarreraId = 21 },
               new Materia { Id = 2, Nombre = "UCCV Sociolog�a", AnioCarreraId = 21 },
               new Materia { Id = 3, Nombre = "Administraci�n General", AnioCarreraId = 21 },
               new Materia { Id = 4, Nombre = "Econom�a I", AnioCarreraId = 21 },
               new Materia { Id = 5, Nombre = "Geograf�a Econ�mica", AnioCarreraId = 21 },
               new Materia { Id = 6, Nombre = "Historia Econ�mica", AnioCarreraId = 21 },
               new Materia { Id = 7, Nombre = "Construcci�n de Ciudadan�a", AnioCarreraId = 21 },
               new Materia { Id = 8, Nombre = "Sistema de Informaci�n Contable I", AnioCarreraId = 21 },
               new Materia { Id = 9, Nombre = "Matem�tica", AnioCarreraId = 21 },
               new Materia { Id = 10, Nombre = "Pr�ctica Docente I", AnioCarreraId = 21 },
               new Materia { Id = 11, Nombre = "Instituciones Educativas", AnioCarreraId = 22 },
               new Materia { Id = 12, Nombre = "Did�ctica y Curriculum", AnioCarreraId = 22 },
               new Materia { Id = 13, Nombre = "Psicolog�a y Educaci�n", AnioCarreraId = 22 },
               new Materia { Id = 14, Nombre = "Econom�a II", AnioCarreraId = 22 },
               new Materia { Id = 15, Nombre = "Sistema de Informaci�n Contable II", AnioCarreraId = 22 },
               new Materia { Id = 16, Nombre = "Derecho I", AnioCarreraId = 22 },
               new Materia { Id = 17, Nombre = "Estad�stica Aplicada", AnioCarreraId = 22 },
               new Materia { Id = 18, Nombre = "Did�ctica de la Econom�a I", AnioCarreraId = 22 },
               new Materia { Id = 19, Nombre = "Pr�ctica Docente II", AnioCarreraId = 22 },
               new Materia { Id = 20, Nombre = "Historia y Pol�tica de la Educaci�n Argentina", AnioCarreraId = 23 },
               new Materia { Id = 21, Nombre = "Filosof�a", AnioCarreraId = 23 },
               new Materia { Id = 22, Nombre = "Metodolog�a de la Investigaci�n", AnioCarreraId = 23 },
               new Materia { Id = 23, Nombre = "Econom�a III", AnioCarreraId = 23 },
               new Materia { Id = 24, Nombre = "Finanzas P�blicas", AnioCarreraId = 23 },
               new Materia { Id = 25, Nombre = "Derecho II", AnioCarreraId = 23 },
               new Materia { Id = 26, Nombre = "Sujetos de la Educaci�n Secundaria", AnioCarreraId = 23 },
               new Materia { Id = 27, Nombre = "Pr�ctica Docente III", AnioCarreraId = 23 },
               new Materia { Id = 28, Nombre = "Producci�n de los Recursos Did�cticos I", AnioCarreraId = 23 },
               new Materia { Id = 29, Nombre = "�tica y Trabajo Docente", AnioCarreraId = 24 },
               new Materia { Id = 30, Nombre = "Educaci�n Sexual Integral", AnioCarreraId = 24 },
               new Materia { Id = 31, Nombre = "UCCV Comunicaci�n Social", AnioCarreraId = 24 },
               new Materia { Id = 32, Nombre = "Econom�a Social y Sostenible", AnioCarreraId = 24 },
               new Materia { Id = 33, Nombre = "Econom�a Argentina Latinoamericana e Internacional", AnioCarreraId = 24 },
               new Materia { Id = 34, Nombre = "Pr�cticas de Investigaci�n", AnioCarreraId = 24 },
               new Materia { Id = 35, Nombre = "Pr�ctica Docente IV (Residencia)", AnioCarreraId = 24 },
               new Materia { Id = 36, Nombre = "Producci�n de los Recursos Did�cticos II", AnioCarreraId = 24 },
               new Materia { Id = 37, Nombre = "Unidad de Definici�n Institucional", AnioCarreraId = 24 }
           };

            // PROFESORADO DE EDUCACI�N TECNOL�GICA
            var materiasTecnologica = new[]
            {
               new Materia { Id = 38, Nombre = "Pedagog�a", AnioCarreraId = 25 },
               new Materia { Id = 39, Nombre = "Movimiento y Cuerpo", AnioCarreraId = 25 },
               new Materia { Id = 40, Nombre = "Pr�ctica Docente I: Escenarios Educativos", AnioCarreraId = 25 },
               new Materia { Id = 41, Nombre = "Introducci�n a la Tecnolog�a", AnioCarreraId = 25 },
               new Materia { Id = 42, Nombre = "Historia de la Tecnolog�a", AnioCarreraId = 25 },
               new Materia { Id = 43, Nombre = "Dise�o y Producci�n de la Tecnolog�a I", AnioCarreraId = 25 },
               new Materia { Id = 44, Nombre = "Matem�tica", AnioCarreraId = 25 },
               new Materia { Id = 45, Nombre = "F�sica", AnioCarreraId = 25 },
               new Materia { Id = 46, Nombre = "Psicolog�a de la Educaci�n", AnioCarreraId = 26 },
               new Materia { Id = 47, Nombre = "Did�ctica y Curriculum", AnioCarreraId = 26 },
               new Materia { Id = 48, Nombre = "Instituciones Educativas", AnioCarreraId = 26 },
               new Materia { Id = 49, Nombre = "Pr�ctica Docente II: La Instituci�n Escolar", AnioCarreraId = 26 },
               new Materia { Id = 50, Nombre = "Sujetos de la Educaci�n I", AnioCarreraId = 26 },
               new Materia { Id = 51, Nombre = "Tics para la Ense�anza", AnioCarreraId = 26 },
               new Materia { Id = 52, Nombre = "Procesos Productivos", AnioCarreraId = 26 },
               new Materia { Id = 53, Nombre = "Dise�o y Producci�n Tecnol�gica II", AnioCarreraId = 26 },
               new Materia { Id = 54, Nombre = "Did�ctica Espec�fica I", AnioCarreraId = 26 },
               new Materia { Id = 55, Nombre = "Filosof�a y Educaci�n", AnioCarreraId = 27 },
               new Materia { Id = 56, Nombre = "Historia Social de la Educaci�n", AnioCarreraId = 27 },
               new Materia { Id = 57, Nombre = "Metodolog�a de la Investigaci�n", AnioCarreraId = 27 },
               new Materia { Id = 58, Nombre = "Pr�ctica Docente III: La Clase", AnioCarreraId = 27 },
               new Materia { Id = 59, Nombre = "Sujetos de la Educaci�n II", AnioCarreraId = 27 },
               new Materia { Id = 60, Nombre = "Materiales", AnioCarreraId = 27 },
               new Materia { Id = 61, Nombre = "Qu�mica", AnioCarreraId = 27 },
               new Materia { Id = 62, Nombre = "Procesos de Control", AnioCarreraId = 27 },
               new Materia { Id = 63, Nombre = "Tecnolog�as Regionales", AnioCarreraId = 27 },
               new Materia { Id = 64, Nombre = "Dise�o y Producci�n Tecnol�gica III", AnioCarreraId = 27 },
               new Materia { Id = 65, Nombre = "Did�ctica Espec�fica II", AnioCarreraId = 27 },
               new Materia { Id = 66, Nombre = "�tica y Trabajo Docente", AnioCarreraId = 28 },
               new Materia { Id = 67, Nombre = "Educaci�n Sexual Integral", AnioCarreraId = 28 },
               new Materia { Id = 68, Nombre = "Unidades de Definici�n Institucional I", AnioCarreraId = 28 },
               new Materia { Id = 69, Nombre = "Unidades de Definici�n Institucional II", AnioCarreraId = 28 },
               new Materia { Id = 70, Nombre = "Pr�cticas de Investigaci�n", AnioCarreraId = 28 },
               new Materia { Id = 71, Nombre = "Pr�ctica Docente IV: El Rol Docente y su Pr�ctica", AnioCarreraId = 28 },
               new Materia { Id = 72, Nombre = "Biotecnolog�a", AnioCarreraId = 28 },
               new Materia { Id = 73, Nombre = "Procesos de Comunicaci�n", AnioCarreraId = 28 },
               new Materia { Id = 74, Nombre = "Problem�ticas Sociot�cnicas", AnioCarreraId = 28 },
               new Materia { Id = 75, Nombre = "Dise�o y Producci�n Tecnol�gica IV", AnioCarreraId = 28 },
               new Materia { Id = 76, Nombre = "Taller de Producci�n Did�ctica", AnioCarreraId = 28 }
           };

            // T�CNICO SUPERIOR EN DESARROLLO DE SOFTWARE
            var materiasSoftware = new[]
            {
               new Materia { Id = 77, Nombre = "Comunicaci�n (1� cuat.)", AnioCarreraId = 1 },
               new Materia { Id = 78, Nombre = "Unidad de definici�n Institucional (2� cuat.)", AnioCarreraId = 1 },
               new Materia { Id = 79, Nombre = "Matem�tica", AnioCarreraId = 1 },
               new Materia { Id = 80, Nombre = "Ingl�s T�cnico I", AnioCarreraId = 1 },
               new Materia { Id = 81, Nombre = "Administraci�n", AnioCarreraId = 1 },
               new Materia { Id = 82, Nombre = "Tecnolog�a de la Informaci�n", AnioCarreraId = 1 },
               new Materia { Id = 83, Nombre = "L�gica y Estructura de Datos", AnioCarreraId = 1 },
               new Materia { Id = 84, Nombre = "Ingenier�a de Software I", AnioCarreraId = 1 },
               new Materia { Id = 85, Nombre = "Sistemas Operativos", AnioCarreraId = 1 },
               new Materia { Id = 86, Nombre = "Problem�ticas Socio Contempor�neas (1� cuat.)", AnioCarreraId = 2 },
               new Materia { Id = 87, Nombre = "Unidad de definici�n Institucional (2� cuat.)", AnioCarreraId = 2 },
               new Materia { Id = 88, Nombre = "Ingl�s T�cnico II", AnioCarreraId = 2 },
               new Materia { Id = 89, Nombre = "Innovaci�n y Desarrollo Emprendedor", AnioCarreraId = 2 },
               new Materia { Id = 90, Nombre = "Estad�stica", AnioCarreraId = 2 },
               new Materia { Id = 91, Nombre = "Programaci�n I", AnioCarreraId = 2 },
               new Materia { Id = 92, Nombre = "Ingenier�a de Software II", AnioCarreraId = 2 },
               new Materia { Id = 93, Nombre = "Base de Datos I", AnioCarreraId = 2 },
               new Materia { Id = 94, Nombre = "Pr�ctica Profesionalizante I", AnioCarreraId = 2 },
               new Materia { Id = 95, Nombre = "�tica y Responsabilidad Social", AnioCarreraId = 3 },
               new Materia { Id = 96, Nombre = "Derecho y Legislaci�n Laboral", AnioCarreraId = 3 },
               new Materia { Id = 97, Nombre = "Redes y Comunicaci�n", AnioCarreraId = 3 },
               new Materia { Id = 98, Nombre = "Programaci�n II", AnioCarreraId = 3 },
               new Materia { Id = 99, Nombre = "Gesti�n de Proyectos de Software", AnioCarreraId = 3 },
               new Materia { Id = 100, Nombre = "Base de Datos II", AnioCarreraId = 3 },
               new Materia { Id = 101, Nombre = "Pr�ctica Profesionalizante II", AnioCarreraId = 3 }
           };

            // T�CNICO SUPERIOR EN ENFERMER�A
            var materiasEnfermeria = new[]
            {
               new Materia { Id = 102, Nombre = "Comunicaci�n", AnioCarreraId = 10 },
               new Materia { Id = 103, Nombre = "Unidad de Definici�n Institucional I", AnioCarreraId = 10 },
               new Materia { Id = 104, Nombre = "Salud P�blica", AnioCarreraId = 10 },
               new Materia { Id = 105, Nombre = "Biolog�a Humana I", AnioCarreraId = 10 },
               new Materia { Id = 106, Nombre = "Sujeto, Cultura y Sociedad", AnioCarreraId = 10 },
               new Materia { Id = 107, Nombre = "Fundamentos del Cuidado en Enfermer�a", AnioCarreraId = 10 },
               new Materia { Id = 108, Nombre = "Cuidados de Enfermer�a en la Comunidad y en la Familia", AnioCarreraId = 10 },
               new Materia { Id = 109, Nombre = "Pr�ctica Profesionalizante I", AnioCarreraId = 10 },
               new Materia { Id = 110, Nombre = "Problem�ticas Socio Contempor�neas", AnioCarreraId = 11 },
               new Materia { Id = 111, Nombre = "Unidad de Definici�n Institucional II", AnioCarreraId = 11 },
               new Materia { Id = 112, Nombre = "Inform�tica en Salud", AnioCarreraId = 11 },
               new Materia { Id = 113, Nombre = "Sujeto, Cultura y Sociedad II", AnioCarreraId = 11 },
               new Materia { Id = 114, Nombre = "Biolog�a Humana II", AnioCarreraId = 11 },
               new Materia { Id = 115, Nombre = "Bioseguridad y Medio Ambiente en el Trabajo", AnioCarreraId = 11 },
               new Materia { Id = 116, Nombre = "Farmacolog�a en Enfermer�a", AnioCarreraId = 11 },
               new Materia { Id = 117, Nombre = "Cuidados de Enfermer�a a los Adultos y Adultos Mayores", AnioCarreraId = 11 },
               new Materia { Id = 118, Nombre = "Pr�ctica Profesionalizante II", AnioCarreraId = 11 },
               new Materia { Id = 119, Nombre = "�tica y Responsabilidad Social", AnioCarreraId = 12 },
               new Materia { Id = 120, Nombre = "Derecho y Legislaci�n Laboral", AnioCarreraId = 12 },
               new Materia { Id = 121, Nombre = "Ingl�s T�cnico", AnioCarreraId = 12 },
               new Materia { Id = 122, Nombre = "Organizaci�n y Gesti�n en Instituciones de Salud", AnioCarreraId = 12 },
               new Materia { Id = 123, Nombre = "Investigaci�n en Enfermer�a", AnioCarreraId = 12 },
               new Materia { Id = 124, Nombre = "Cuidados de Enfermer�a en Salud Mental", AnioCarreraId = 12 },
               new Materia { Id = 125, Nombre = "Cuidados de Enfermer�a al Ni�o y al Adolescente", AnioCarreraId = 12 },
               new Materia { Id = 126, Nombre = "Pr�ctica Profesionalizante III", AnioCarreraId = 12 }
           };

            // T�CNICO SUPERIOR EN GESTI�N DE LAS ORGANIZACIONES
            var materiasOrganizaciones = new[]
            {
               new Materia { Id = 127, Nombre = "Comunicaci�n (1� cuatr.)", AnioCarreraId = 7 },
               new Materia { Id = 128, Nombre = "Unidad de Definici�n Institucional (2� cuatr.)", AnioCarreraId = 7 },
               new Materia { Id = 129, Nombre = "Econom�a", AnioCarreraId = 7 },
               new Materia { Id = 130, Nombre = "Matem�tica y Estad�stica", AnioCarreraId = 7 },
               new Materia { Id = 131, Nombre = "Contabilidad", AnioCarreraId = 7 },
               new Materia { Id = 132, Nombre = "Inform�tica", AnioCarreraId = 7 },
               new Materia { Id = 133, Nombre = "Administraci�n", AnioCarreraId = 7 },
               new Materia { Id = 134, Nombre = "Gesti�n de la Producci�n", AnioCarreraId = 7 },
               new Materia { Id = 135, Nombre = "Gesti�n del Talento Humano", AnioCarreraId = 7 },
               new Materia { Id = 136, Nombre = "Problem�ticas Contempor�neas (1� cuatr.)", AnioCarreraId = 8 },
               new Materia { Id = 137, Nombre = "Unidad de Definici�n Institucional (2� cuatr.)", AnioCarreraId = 8 },
               new Materia { Id = 138, Nombre = "Innovaci�n y Desarrollo Emprendedor", AnioCarreraId = 8 },
               new Materia { Id = 139, Nombre = "Ingl�s T�cnico", AnioCarreraId = 8 },
               new Materia { Id = 140, Nombre = "Legislaci�n Comercial y Tributaria", AnioCarreraId = 8 },
               new Materia { Id = 141, Nombre = "Gesti�n de Comercializaci�n e Investigaci�n Comercial", AnioCarreraId = 8 },
               new Materia { Id = 142, Nombre = "Gesti�n de Costos", AnioCarreraId = 8 },
               new Materia { Id = 143, Nombre = "Gesti�n Contable", AnioCarreraId = 8 },
               new Materia { Id = 144, Nombre = "Pr�ctica Profesionalizante I", AnioCarreraId = 8 },
               new Materia { Id = 145, Nombre = "Gesti�n de Seguridad, Salud Ocupacional y Medio Ambiente", AnioCarreraId = 9 },
               new Materia { Id = 146, Nombre = "�tica y Responsabilidad Social", AnioCarreraId = 9 },
               new Materia { Id = 147, Nombre = "Legislaci�n Laboral", AnioCarreraId = 9 },
               new Materia { Id = 148, Nombre = "Estrategia Empresarial", AnioCarreraId = 9 },
               new Materia { Id = 149, Nombre = "Sistema de Informaci�n para la Gesti�n de las Organizaciones", AnioCarreraId = 9 },
               new Materia { Id = 150, Nombre = "Gesti�n Financiera", AnioCarreraId = 9 },
               new Materia { Id = 151, Nombre = "Evaluaci�n y Administraci�n de Proyectos de Inversi�n", AnioCarreraId = 9 },
               new Materia { Id = 152, Nombre = "Control de Gesti�n", AnioCarreraId = 9 },
               new Materia { Id = 153, Nombre = "Pr�cticas Profesionalizantes II", AnioCarreraId = 9 }
           };

            // T�CNICO SUPERIOR EN SOPORTE DE INFRAESTRUCTURA DE TECNOLOG�A DE LA INFORMACI�N
            var materiasInfraestructura = new[]
            {
               new Materia { Id = 154, Nombre = "Comunicaci�n (1� cuat.)", AnioCarreraId = 4 },
               new Materia { Id = 155, Nombre = "Unidad de definici�n Institucional (2� cuat.)", AnioCarreraId = 4 },
               new Materia { Id = 156, Nombre = "Matem�tica", AnioCarreraId = 4 },
               new Materia { Id = 157, Nombre = "F�sica Aplicada a las Tecnolog�as de la Informaci�n", AnioCarreraId = 4 },
               new Materia { Id = 158, Nombre = "Administraci�n", AnioCarreraId = 4 },
               new Materia { Id = 159, Nombre = "Ingl�s T�cnico", AnioCarreraId = 4 },
               new Materia { Id = 160, Nombre = "Arquitectura de las Computadoras", AnioCarreraId = 4 },
               new Materia { Id = 161, Nombre = "L�gica y Programaci�n", AnioCarreraId = 4 },
               new Materia { Id = 162, Nombre = "Infraestructura de Redes I", AnioCarreraId = 4 },
               new Materia { Id = 163, Nombre = "Problem�ticas Socio Contempor�neas (1� cuat.)", AnioCarreraId = 5 },
               new Materia { Id = 164, Nombre = "Unidad de definici�n Institucional (2� cuat.)", AnioCarreraId = 5 },
               new Materia { Id = 165, Nombre = "Innovaci�n y Desarrollo Emprendedor", AnioCarreraId = 5 },
               new Materia { Id = 166, Nombre = "Estad�stica", AnioCarreraId = 5 },
               new Materia { Id = 167, Nombre = "Sistemas Operativos", AnioCarreraId = 5 },
               new Materia { Id = 168, Nombre = "Algoritmos y Estructuras de Datos", AnioCarreraId = 5 },
               new Materia { Id = 169, Nombre = "Base de Datos", AnioCarreraId = 5 },
               new Materia { Id = 170, Nombre = "Infraestructura de Redes II", AnioCarreraId = 5 },
               new Materia { Id = 171, Nombre = "Pr�ctica Profesionalizante I", AnioCarreraId = 5 },
               new Materia { Id = 172, Nombre = "�tica y Responsabilidad Social", AnioCarreraId = 6 },
               new Materia { Id = 173, Nombre = "Derecho y Legislaci�n Laboral", AnioCarreraId = 6 },
               new Materia { Id = 174, Nombre = "Administraci�n de Base de Datos", AnioCarreraId = 6 },
               new Materia { Id = 175, Nombre = "Integridad y Migraci�n de Datos", AnioCarreraId = 6 },
               new Materia { Id = 176, Nombre = "Seguridad de los Sistemas", AnioCarreraId = 6 },
               new Materia { Id = 177, Nombre = "Administraci�n de Sistemas Operativos y Redes", AnioCarreraId = 6 },
               new Materia { Id = 178, Nombre = "Pr�ctica Profesionalizante II", AnioCarreraId = 6 }
           };

            modelBuilder.Entity<Materia>().HasData(materiasEconomia);
            modelBuilder.Entity<Materia>().HasData(materiasTecnologica);
            modelBuilder.Entity<Materia>().HasData(materiasSoftware);
            modelBuilder.Entity<Materia>().HasData(materiasEnfermeria);
            modelBuilder.Entity<Materia>().HasData(materiasOrganizaciones);
            modelBuilder.Entity<Materia>().HasData(materiasInfraestructura);

            #region Datos semilla de Materias - Profesorado de Educaci�n Inicial

            // Primer A�o
            var m1 = new Materia { Id = 179, AnioCarreraId = 17, Nombre = "Psicolog�a y Educaci�n" };
            var m2 = new Materia { Id = 180, AnioCarreraId = 17, Nombre = "Pedagog�a" };
            var m3 = new Materia { Id = 181, AnioCarreraId = 17, Nombre = "Sociolog�a de la Educaci�n" };
            var m4 = new Materia { Id = 182, AnioCarreraId = 17, Nombre = "Historia Argentina y Latinoamericana (1� cuatr.)" };
            var m5 = new Materia { Id = 183, AnioCarreraId = 17, Nombre = "Movimiento y Cuerpo I" };
            var m6 = new Materia { Id = 184, AnioCarreraId = 17, Nombre = "Taller de Pr�ctica I" };
            var m7 = new Materia { Id = 185, AnioCarreraId = 17, Nombre = "Problem�ticas Contempor�neas de la Educaci�n Inicial I" };
            var m8 = new Materia { Id = 186, AnioCarreraId = 17, Nombre = "Comunicaci�n y Expresi�n Oral y Escrita" };
            var m9 = new Materia { Id = 187, AnioCarreraId = 17, Nombre = "Resoluci�n de Problemas y Creatividad (1� cuatr.)" };
            var m10 = new Materia { Id = 188, AnioCarreraId = 17, Nombre = "Ambiente y Sociedad (2� cuatr.)" };
            var m11 = new Materia { Id = 189, AnioCarreraId = 17, Nombre = "�rea Est�tico-Expresiva I" };
            var m12 = new Materia { Id = 190, AnioCarreraId = 17, Nombre = "Itinerarios por el Mundo de la Cultura" };
            var m13 = new Materia { Id = 191, AnioCarreraId = 17, Nombre = "Producci�n Pedag�gica" };

            // Segundo A�o
            var m14 = new Materia { Id = 192, AnioCarreraId = 18, Nombre = "Did�ctica General" };
            var m15 = new Materia { Id = 193, AnioCarreraId = 18, Nombre = "Filosof�a de la Educaci�n (1� cuatr.)" };
            var m16 = new Materia { Id = 194, AnioCarreraId = 18, Nombre = "Conocimiento y Educaci�n (2� cuatr.)" };
            var m17 = new Materia { Id = 195, AnioCarreraId = 18, Nombre = "Movimiento y Cuerpo II" };
            var m18 = new Materia { Id = 196, AnioCarreraId = 18, Nombre = "Taller de Pr�ctica II: Seminario de lo Grupal y los Grupos de Aprendizaje" };
            var m19 = new Materia { Id = 197, AnioCarreraId = 18, Nombre = "Sujeto de la Educaci�n Inicial" };
            var m20 = new Materia { Id = 198, AnioCarreraId = 18, Nombre = "Did�ctica de Educaci�n Inicial I" };
            var m21 = new Materia { Id = 199, AnioCarreraId = 18, Nombre = "Matem�tica y su Did�ctica I" };
            var m22 = new Materia { Id = 200, AnioCarreraId = 18, Nombre = "Literatura y su Did�ctica" };
            var m23 = new Materia { Id = 201, AnioCarreraId = 18, Nombre = "Ciencias Naturales y su Did�ctica" };
            var m24 = new Materia { Id = 202, AnioCarreraId = 18, Nombre = "Itinerarios por el Mundo de la Cultura" };
            var m25 = new Materia { Id = 203, AnioCarreraId = 18, Nombre = "Producci�n Pedag�gica" };

            // Tercer A�o
            var m26 = new Materia { Id = 204, AnioCarreraId = 19, Nombre = "Tecnolog�as de la Informaci�n y de la Comunicaci�n" };
            var m27 = new Materia { Id = 205, AnioCarreraId = 19, Nombre = "Historia Social de la Educaci�n y Pol�tica Educativa Argentina" };
            var m28 = new Materia { Id = 206, AnioCarreraId = 19, Nombre = "Trayecto de Pr�ctica III: Seminario de Instituciones Educativas" };
            var m29 = new Materia { Id = 207, AnioCarreraId = 19, Nombre = "Matem�tica y su Did�ctica II" };
            var m30 = new Materia { Id = 208, AnioCarreraId = 19, Nombre = "Lengua y su Did�ctica (1� cuatr.)" };
            var m31 = new Materia { Id = 209, AnioCarreraId = 19, Nombre = "Alfabetizaci�n Inicial (2� cuatr.)" };
            var m32 = new Materia { Id = 210, AnioCarreraId = 19, Nombre = "Ciencias Sociales y su Did�ctica" };
            var m33 = new Materia { Id = 211, AnioCarreraId = 19, Nombre = "�rea Est�tico-Expresiva II" };
            var m34 = new Materia { Id = 212, AnioCarreraId = 19, Nombre = "Problem�ticas Contempor�neas de la Educaci�n Inicial II (1� cuatr.)" };
            var m35 = new Materia { Id = 213, AnioCarreraId = 19, Nombre = "Did�ctica de la Educaci�n Inicial II (2� cuatr.)" };
            var m36 = new Materia { Id = 214, AnioCarreraId = 19, Nombre = "Espacios de Definici�n Institucional (1� cuatr.)" };
            var m37 = new Materia { Id = 215, AnioCarreraId = 19, Nombre = "Espacios de Definici�n Institucional (2� cuatr.)" };
            var m38 = new Materia { Id = 216, AnioCarreraId = 19, Nombre = "Itinerarios por el Mundo de la Cultura" };
            var m39 = new Materia { Id = 217, AnioCarreraId = 19, Nombre = "Producci�n Pedag�gica" };

            // Cuarto A�o
            var m40 = new Materia { Id = 218, AnioCarreraId = 20, Nombre = "�tica, Trabajo Docente, Derechos Humanos y Ciudadanos" };
            var m41 = new Materia { Id = 219, AnioCarreraId = 20, Nombre = "Taller de Pr�ctica IV" };
            var m42 = new Materia { Id = 220, AnioCarreraId = 20, Nombre = "Ateneo: (Matem�tica- Ambiente y Sociedad (Ciencias Naturales- Ciencias Sociales) Lengua y Literatura- Formaci�n �tica y Ciudadana)" };
            var m43 = new Materia { Id = 221, AnioCarreraId = 20, Nombre = "Sexualidad Humana y Educaci�n (1� cuatr.)" };
            var m44 = new Materia { Id = 222, AnioCarreraId = 20, Nombre = "Itinerarios por el Mundo de la Cultura" };
            var m45 = new Materia { Id = 223, AnioCarreraId = 20, Nombre = "Producci�n Pedag�gica" };

            modelBuilder.Entity<Materia>().HasData(
                m1, m2, m3, m4, m5, m6, m7, m8, m9, m10,
                m11, m12, m13, m14, m15, m16, m17, m18,
                m19, m20, m21, m22, m23, m24, m25, m26,
                m27, m28, m29, m30, m31, m32, m33, m34,
                m35, m36, m37, m38, m39, m40, m41, m42,
                m43, m44, m45);

            #endregion

            #region Datos semillas de Materias para Profesorado de Educaci�n Secundaria en Ciencias de la Administraci�n

            // Primer A�o
            var mm1 = new Materia { Id = 224, AnioCarreraId = 13, Nombre = "Pedagog�a" };
            var mm2 = new Materia { Id = 225, AnioCarreraId = 13, Nombre = "UCCV Sociolog�a" };
            var mm3 = new Materia { Id = 226, AnioCarreraId = 13, Nombre = "Administraci�n General" };
            var mm4 = new Materia { Id = 227, AnioCarreraId = 13, Nombre = "Administraci�n I" };
            var mm5 = new Materia { Id = 228, AnioCarreraId = 13, Nombre = "Sistema de Informaci�n Contable I" };
            var mm6 = new Materia { Id = 229, AnioCarreraId = 13, Nombre = "Construcci�n de Ciudadan�a" };
            var mm7 = new Materia { Id = 230, AnioCarreraId = 13, Nombre = "Historia Econ�mica" };
            var mm8 = new Materia { Id = 231, AnioCarreraId = 13, Nombre = "Matem�tica" };
            var mm9 = new Materia { Id = 232, AnioCarreraId = 13, Nombre = "Pr�ctica Docente I" };

            // Segundo A�o
            var mm10 = new Materia { Id = 233, AnioCarreraId = 14, Nombre = "Instituciones Educativas" };
            var mm11 = new Materia { Id = 234, AnioCarreraId = 14, Nombre = "Did�ctica y Curriculum" };
            var mm12 = new Materia { Id = 235, AnioCarreraId = 14, Nombre = "Psicolog�a y Educaci�n" };
            var mm13 = new Materia { Id = 236, AnioCarreraId = 14, Nombre = "Administraci�n II" };
            var mm14 = new Materia { Id = 237, AnioCarreraId = 14, Nombre = "Sistema de Informaci�n Contable II" };
            var mm15 = new Materia { Id = 238, AnioCarreraId = 14, Nombre = "Derecho I" };
            var mm16 = new Materia { Id = 239, AnioCarreraId = 14, Nombre = "Econom�a" };
            var mm17 = new Materia { Id = 240, AnioCarreraId = 14, Nombre = "Estad�stica Aplicada" };
            var mm18 = new Materia { Id = 241, AnioCarreraId = 14, Nombre = "Did�ctica de la Administraci�n I" };
            var mm19 = new Materia { Id = 242, AnioCarreraId = 14, Nombre = "Pr�ctica Docencia II" };

            // Tercer A�o
            var mm20 = new Materia { Id = 243, AnioCarreraId = 15, Nombre = "Historia y Pol�tica de la Educaci�n Argentina" };
            var mm21 = new Materia { Id = 244, AnioCarreraId = 15, Nombre = "Filosof�a" };
            var mm22 = new Materia { Id = 245, AnioCarreraId = 15, Nombre = "Metodolog�a de la Investigaci�n" };
            var mm23 = new Materia { Id = 246, AnioCarreraId = 15, Nombre = "Administraci�n III" };
            var mm24 = new Materia { Id = 247, AnioCarreraId = 15, Nombre = "Sistema de Informaci�n Contable III" };
            var mm25 = new Materia { Id = 248, AnioCarreraId = 15, Nombre = "Pr�ctica Impositiva y Laboral" };
            var mm26 = new Materia { Id = 249, AnioCarreraId = 15, Nombre = "Derecho II" };
            var mm27 = new Materia { Id = 250, AnioCarreraId = 15, Nombre = "Did�ctica de la Administraci�n II" };
            var mm28 = new Materia { Id = 251, AnioCarreraId = 15, Nombre = "Sujetos de la Educaci�n Secundaria" };
            var mm29 = new Materia { Id = 252, AnioCarreraId = 15, Nombre = "Pr�ctica Docente III" };
            var mm30 = new Materia { Id = 253, AnioCarreraId = 15, Nombre = "Producci�n de los Recursos Did�cticos I" };

            // Cuarto A�o
            var mm31 = new Materia { Id = 254, AnioCarreraId = 16, Nombre = "�tica y Trabajo Docente" };
            var mm32 = new Materia { Id = 255, AnioCarreraId = 16, Nombre = "Educaci�n Sexual Integral" };
            var mm33 = new Materia { Id = 256, AnioCarreraId = 16, Nombre = "UCCV Comunicaci�n Social" };
            var mm34 = new Materia { Id = 257, AnioCarreraId = 16, Nombre = "Administraci�n IV" };
            var mm35 = new Materia { Id = 258, AnioCarreraId = 16, Nombre = "Gesti�n Organizacional" };
            var mm36 = new Materia { Id = 259, AnioCarreraId = 16, Nombre = "Matem�tica Financiera" };
            var mm37 = new Materia { Id = 260, AnioCarreraId = 16, Nombre = "Pr�cticas de Investigaci�n" };
            var mm38 = new Materia { Id = 261, AnioCarreraId = 16, Nombre = "Pr�ctica Docente IV (Residencia)" };
            var mm39 = new Materia { Id = 262, AnioCarreraId = 16, Nombre = "Producci�n de los Recursos Did�cticos II" };
            var mm40 = new Materia { Id = 263, AnioCarreraId = 16, Nombre = "Unidad de Definici�n Institucional" };

            modelBuilder.Entity<Materia>().HasData(
                mm1, mm2, mm3, mm4, mm5, mm6, mm7, mm8, mm9, mm10,
                mm11, mm12, mm13, mm14, mm15, mm16, mm17, mm18, mm19, mm20,
                mm21, mm22, mm23, mm24, mm25, mm26, mm27, mm28, mm29, mm30,
                mm31, mm32, mm33, mm34, mm35, mm36, mm37, mm38, mm39, mm40
            );
            #endregion
            #endregion


            #region datos semillas alumnos
            var ale = new Alumno { Id = 1, ApellidoNombre = "Rub�n Alejandro Ramirez", Email = "aleramirezsj@gmail.com", Direccion = "Bv Roque Saenz Pe�a 2942", Telefono = "15447106" };

            modelBuilder.Entity<Alumno>().HasData(ale);
            #endregion


            #region definici�n de filtros de eliminaci�n
            // (este c�digo no lo habilitamos todav�a porque es cuando agregamos un campo Eliminado a las tablas y modificamos los
            // repository para que al mandar a eliminar solo cambien este campo y lo pongan en verdadero, esta configuraci�n de
            // eliminaci�n hace que el sistema ignore los registros que tengan el eliminado en verdadero, as� que hace que en
            // apariencia y funcionalidad est� "eliminado", pero van a seguir estando ah� para que podamos observar las eliminaciones que hubo)
            //modelBuilder.Entity<Alumno>().HasQueryFilter(m => !m.Eliminado);
            //modelBuilder.Entity<AnioCarrera>().HasQueryFilter(m => !m.Eliminado);
            //modelBuilder.Entity<Carrera>().HasQueryFilter(m => !m.Eliminado);
            //modelBuilder.Entity<Materia>().HasQueryFilter(m => !m.Eliminado);
            #endregion
        }
        public virtual DbSet<Alumno> alumnos { get; set; }
        public virtual DbSet<Carrera> carreras { get; set; }
        public virtual DbSet<Inscripcion> inscripciones { get; set; }
        public virtual DbSet<Materia> Materias { get; set; }
        public virtual DbSet<AnioCarrera> AnioCarreras { get; set; }
        public virtual DbSet<DetalleInscripcion> DetalleInscripciones { get; set; }

    }
}