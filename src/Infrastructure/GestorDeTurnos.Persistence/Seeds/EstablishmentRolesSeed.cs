using GestorDeTurnos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeTurnos.Persistence.Seeds
{
    public static class EstablishmentRolesSeed
    {
        public static readonly List<EstablishmentRoles> DefaultValues = new List<EstablishmentRoles>
        {
            // Roles para Barberías
            new EstablishmentRoles
            {
                Id = 1,
                EstablishmentTypeId = 1,  // Id de Barberías
                RoleName = "Barbero"
            },
            new EstablishmentRoles
            {
                Id = 2,
                EstablishmentTypeId = 1,
                RoleName = "Estilista"
            },
            new EstablishmentRoles
            {
                Id = 3,
                EstablishmentTypeId = 1,
                RoleName = "Asistente de Barbero"
            },
            new EstablishmentRoles
            {
                Id = 4,
                EstablishmentTypeId = 1,
                RoleName = "Recepcionista"
            },
            new EstablishmentRoles
            {
                Id = 5,
                EstablishmentTypeId = 1,
                RoleName = "Gerente de Barbería"
            },

            // Roles para Salones de belleza
            new EstablishmentRoles
            {
                Id = 6,
                EstablishmentTypeId = 2,  // Id de Salones de belleza
                RoleName = "Estilista de Cabello"
            },
            new EstablishmentRoles
            {
                Id = 7,
                EstablishmentTypeId = 2,
                RoleName = "Maquillador/a"
            },
            new EstablishmentRoles
            {
                Id = 8,
                EstablishmentTypeId = 2,
                RoleName = "Manicurista"
            },
            new EstablishmentRoles
            {
                Id = 9,
                EstablishmentTypeId = 2,
                RoleName = "Esteticista"
            },
            new EstablishmentRoles
            {
                Id = 10,
                EstablishmentTypeId = 2,
                RoleName = "Gerente de Salón"
            },

            // Roles para Spas y centros de bienestar
            new EstablishmentRoles
            {
                Id = 11,
                EstablishmentTypeId = 3,  // Id de Spas y centros de bienestar
                RoleName = "Terapeuta de Masajes"
            },
            new EstablishmentRoles
            {
                Id = 12,
                EstablishmentTypeId = 3,
                RoleName = "Terapeuta de Spa"
            },
            new EstablishmentRoles
            {
                Id = 13,
                EstablishmentTypeId = 3,
                RoleName = "Recepcionista de Spa"
            },
            new EstablishmentRoles
            {
                Id = 14,
                EstablishmentTypeId = 3,
                RoleName = "Entrenador/a Personal"
            },
            new EstablishmentRoles
            {
                Id = 15,
                EstablishmentTypeId = 3,
                RoleName = "Gerente de Spa"
            },

            // Roles para Consultorios médicos
            new EstablishmentRoles
            {
                Id = 16,
                EstablishmentTypeId = 4,  // Id de Consultorios médicos
                RoleName = "Médico General"
            },
            new EstablishmentRoles
            {
                Id = 17,
                EstablishmentTypeId = 4,
                RoleName = "Especialista"
            },
            new EstablishmentRoles
            {
                Id = 18,
                EstablishmentTypeId = 4,
                RoleName = "Enfermero/a"
            },
            new EstablishmentRoles
            {
                Id = 19,
                EstablishmentTypeId = 4,
                RoleName = "Recepcionista de Consultorio"
            },
            new EstablishmentRoles
            {
                Id = 20,
                EstablishmentTypeId = 4,
                RoleName = "Administrador/a de Consultorio"
            },

            // Roles para Clínicas de salud
            new EstablishmentRoles
            {
                Id = 21,
                EstablishmentTypeId = 5,  // Id de Clínicas de salud
                RoleName = "Técnico de Laboratorio"
            },
            new EstablishmentRoles
            {
                Id = 22,
                EstablishmentTypeId = 5,
                RoleName = "Radiólogo/a"
            },
            new EstablishmentRoles
            {
                Id = 23,
                EstablishmentTypeId = 5,
                RoleName = "Asistente de Enfermería"
            },
            new EstablishmentRoles
            {
                Id = 24,
                EstablishmentTypeId = 5,
                RoleName = "Administrador/a de Clínica"
            },
            new EstablishmentRoles
            {
                Id = 25,
                EstablishmentTypeId = 5,
                RoleName = "Recepcionista de Clínica"
            },

            // Roles para Servicios de masajes
            new EstablishmentRoles
            {
                Id = 26,
                EstablishmentTypeId = 6,  // Id de Servicios de masajes
                RoleName = "Terapeuta de Masajes Terapéuticos"
            },
            new EstablishmentRoles
            {
                Id = 27,
                EstablishmentTypeId = 6,
                RoleName = "Terapeuta de Masajes Relajantes"
            },
            new EstablishmentRoles
            {
                Id = 28,
                EstablishmentTypeId = 6,
                RoleName = "Recepcionista de Servicios de Masajes"
            },
            new EstablishmentRoles
            {
                Id = 29,
                EstablishmentTypeId = 6,
                RoleName = "Administrador/a de Centro de Masajes"
            },
            new EstablishmentRoles
            {
                Id = 30,
                EstablishmentTypeId = 6,
                RoleName = "Entrenador/a Personal"
            },

            // Roles para Estudios de tatuajes y piercing
            new EstablishmentRoles
            {
                Id = 31,
                EstablishmentTypeId = 7,  // Id de Estudios de tatuajes y piercing
                RoleName = "Tatuador/a"
            },
            new EstablishmentRoles
            {
                Id = 32,
                EstablishmentTypeId = 7,
                RoleName = "Piercer"
            },
            new EstablishmentRoles
            {
                Id = 33,
                EstablishmentTypeId = 7,
                RoleName = "Asistente de Tatuador/Piercer"
            },
            new EstablishmentRoles
            {
                Id = 34,
                EstablishmentTypeId = 7,
                RoleName = "Recepcionista de Estudio de Tatuajes/Piercing"
            },
            new EstablishmentRoles
            {
                Id = 35,
                EstablishmentTypeId = 7,
                RoleName = "Gerente de Estudio de Tatuajes/Piercing"
            },

            // Roles para Gimnasios
            new EstablishmentRoles
            {
                Id = 36,
                EstablishmentTypeId = 8,  // Id de Gimnasios
                RoleName = "Entrenador Personal"
            },
            new EstablishmentRoles
            {
                Id = 37,
                EstablishmentTypeId = 8,
                RoleName = "Instructor/a de Clases Grupales"
            },
            new EstablishmentRoles
            {
                Id = 38,
                EstablishmentTypeId = 8,
                RoleName = "Recepcionista de Gimnasio"
            },
            new EstablishmentRoles
            {
                Id = 39,
                EstablishmentTypeId = 8,
                RoleName = "Gerente de Gimnasio"
            },
            new EstablishmentRoles
            {
                Id = 40,
                EstablishmentTypeId = 8,
                RoleName = "Limpiador/a de Gimnasio"
            },

            // Roles para Centros de tutoría o academias
            new EstablishmentRoles
            {
                Id = 41,
                EstablishmentTypeId = 9,  // Id de Centros de tutoría o academias
                RoleName = "Tutor/a Académico/a"
            },
            new EstablishmentRoles
            {
                Id = 42,
                EstablishmentTypeId = 9,
                RoleName = "Profesor/a Particular"
            },
            new EstablishmentRoles
            {
                Id = 43,    
                EstablishmentTypeId = 9,
                RoleName = "Administrador/a de Academia"
            },
            new EstablishmentRoles
            {
                Id = 44,
                EstablishmentTypeId = 9,
                RoleName = "Recepcionista de Academia"
            },
            new EstablishmentRoles
            {
                Id = 45,
                EstablishmentTypeId = 9,
                RoleName = "Director/a de Academia"
            },

            // Roles para Oficinas gubernamentales
            new EstablishmentRoles
            {
                Id = 46,
                EstablishmentTypeId = 10,  // Id de Oficinas gubernamentales
                RoleName = "Oficial de Servicio al Cliente"
            },
            new EstablishmentRoles
            {
                Id = 47,
                EstablishmentTypeId = 10,
                RoleName = "Asistente de Oficina"
            },
            new EstablishmentRoles
            {
                Id = 48,
                EstablishmentTypeId = 10,
                RoleName = "Secretario/a Administrativo/a"
            },
            new EstablishmentRoles
            {
                Id = 49,
                EstablishmentTypeId = 10,
                RoleName = "Gerente de Oficina Gubernamental"
            },
            new EstablishmentRoles
            {
                Id = 50,
                EstablishmentTypeId = 10,
                RoleName = "Recepcionista de Oficina Gubernamental"
            },

            // Roles para Agencias de viaje
            new EstablishmentRoles
            {
                Id = 51,
                EstablishmentTypeId = 11,  // Id de Agencias de viaje
                RoleName = "Agente de Viajes"
            },
            new EstablishmentRoles
            {
                Id = 52,
                EstablishmentTypeId = 11,
                RoleName = "Asesor/a de Viajes"
            },
            new EstablishmentRoles
            {
                Id = 53,
                EstablishmentTypeId = 11,
                RoleName = "Especialista en Reservas"
            },
            new EstablishmentRoles
            {
                Id = 54,
                EstablishmentTypeId = 11,
                RoleName = "Gerente de Agencia de Viajes"
            },
            new EstablishmentRoles
            {
                Id = 55,
                EstablishmentTypeId = 11,
                RoleName = "Recepcionista de Agencia de Viajes"
            },

            // Roles para Talleres mecánicos
            new EstablishmentRoles
            {
                Id = 56,
                EstablishmentTypeId = 12,  // Id de Talleres mecánicos
                RoleName = "Mecánico/a"
            },
            new EstablishmentRoles
            {
                Id = 57,
                EstablishmentTypeId = 12,
                RoleName = "Asistente de Mecánico/a"
            },
            new EstablishmentRoles
            {
                Id = 58,
                EstablishmentTypeId = 12,
                RoleName = "Recepcionista de Taller Mecánico"
            },
            new EstablishmentRoles
            {
                Id = 59,
                EstablishmentTypeId = 12,
                RoleName = "Gerente de Taller Mecánico"
            },
            new EstablishmentRoles
            {
                Id = 60,
                EstablishmentTypeId = 12,
                RoleName = "Administrador/a de Taller Mecánico"
            },
                    // Roles para Oficinas de servicios financieros
            new EstablishmentRoles
            {
                Id = 61,
                EstablishmentTypeId = 13,  // Id de Oficinas de servicios financieros
                RoleName = "Ejecutivo/a de Cuentas"
            },
            new EstablishmentRoles
            {
                Id = 62,
                EstablishmentTypeId = 13,
                RoleName = "Asesor/a Financiero/a"
            },
            new EstablishmentRoles
            {
                Id = 63,
                EstablishmentTypeId = 13,
                RoleName = "Cajero/a"
            },
            new EstablishmentRoles
            {
                Id = 64,
                EstablishmentTypeId = 13,
                RoleName = "Gerente de Oficina Financiera"
            },
            new EstablishmentRoles
            {
                Id = 65,
                EstablishmentTypeId = 13,
                RoleName = "Recepcionista de Oficina Financiera"
            },

            // Roles para Restaurantes y bares
            new EstablishmentRoles
            {
                Id = 66,
                EstablishmentTypeId = 14,  // Id de Restaurantes y bares
                RoleName = "Chef"
            },
            new EstablishmentRoles
            {
                Id = 67,
                EstablishmentTypeId = 14,
                RoleName = "Camarero/a"
            },
            new EstablishmentRoles
            {
                Id = 68,
                EstablishmentTypeId = 14,
                RoleName = "Bartender"
            },
            new EstablishmentRoles
            {
                Id = 69,
                EstablishmentTypeId = 14,
                RoleName = "Host/Hostess"
            },
            new EstablishmentRoles
            {
                Id = 70,
                EstablishmentTypeId = 14,
                RoleName = "Gerente de Restaurante/Bar"
            },

            // Roles para Clínicas veterinarias
            new EstablishmentRoles
            {
                Id = 71,
                EstablishmentTypeId = 15,  // Id de Clínicas veterinarias
                RoleName = "Veterinario/a"
            },
            new EstablishmentRoles
            {
                Id = 72,
                EstablishmentTypeId = 15,
                RoleName = "Asistente Veterinario/a"
            },
            new EstablishmentRoles
            {
                Id = 73,
                EstablishmentTypeId = 15,
                RoleName = "Recepcionista de Clínica Veterinaria"
            },
            new EstablishmentRoles
            {
                Id = 74,
                EstablishmentTypeId = 15,
                RoleName = "Gerente de Clínica Veterinaria"
            },
            new EstablishmentRoles
            {
                Id = 75,
                EstablishmentTypeId = 15,
                RoleName = "Auxiliar de Clínica Veterinaria"
            },

            // Roles para Centros de rehabilitación
            new EstablishmentRoles
            {
                Id = 76,
                EstablishmentTypeId = 16,  // Id de Centros de rehabilitación
                RoleName = "Terapeuta Físico/a"
            },
            new EstablishmentRoles
            {   Id = 77,
                EstablishmentTypeId = 16,
                RoleName = "Consejero/a"
            },
            new EstablishmentRoles
            {
                Id = 78,
                EstablishmentTypeId = 16,
                RoleName = "Asistente de Rehabilitación"
            },
            new EstablishmentRoles
            {
                Id = 79,
                EstablishmentTypeId = 16,
                RoleName = "Recepcionista de Centro de Rehabilitación"
            },
            new EstablishmentRoles
            {
                Id = 80,
                EstablishmentTypeId = 16,
                RoleName = "Gerente de Centro de Rehabilitación"
            },
        };
    }
}
