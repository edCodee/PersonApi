using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonsApi.Models
{
    /// <summary>
    /// Representa un modelo de datos para una persona.
    /// </summary>
    public class PersonModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int person_serial { get; set; }

        [Required]
        [StringLength(10)]
        public string person_id { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string person_firstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string person_lastName { get; set; } = string.Empty;

        [Required]
        public DateOnly person_dateOfBirth { get; set; }

        public PersonModel() { }

        /// <summary>
        /// Constructor completo para inicializar el modelo de persona.
        /// </summary>
        /// <param name="personSerial">Clave primaria</param>
        /// <param name="personId">Identificador único</param>
        /// <param name="firstName">Primer nombre</param>
        /// <param name="lastName">Apellido</param>
        /// <param name="dateOfBirth">Fecha de nacimiento</param>
        /// 
        public PersonModel(int person_serial, string person_id, string person_firstName, string person_lastName, DateOnly person_dateOfBirth)
        {
            this.person_serial = person_serial;
            this.person_id = person_id;
            this.person_firstName = person_firstName;
            this.person_lastName = person_lastName;
            this.person_dateOfBirth = person_dateOfBirth;
        }
    }
}