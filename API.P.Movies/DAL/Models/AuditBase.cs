using System.ComponentModel.DataAnnotations;

namespace API.P.Movies.DAL.Models
{
    public class AuditBase
    {
        [Key] //Este decorator me indica que esta propiuedad es la PK
     public int Id { get; set; } //nuestra PK
     
        public DateTime? CreatedDate { get; set; }//Me indica la fehca de creacion de cada registro en BD

        public DateTime? UpdateDate { get; set; }//me indica la fecha o ModifiedDate
    }
}
