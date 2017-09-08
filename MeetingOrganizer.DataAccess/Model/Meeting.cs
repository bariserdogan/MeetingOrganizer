using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingOrganizer.DataAccess.Model
{
    [Table("Meetings")]
    public class Meeting
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int meetingID { get; set; }

        [Display(Name ="Toplantı Konusu")]
        [Required(ErrorMessage ="{0} alanı gereklidir")]
        [StringLength(150, ErrorMessage = "{0} alanı {1} karakterden fazla olamaz", MinimumLength = 5)]
        public string meetingTopic { get; set; }

        [Display(Name = "Toplantı Tarihi")]
        [Required(ErrorMessage = "{0} alanı gereklidir")]        
        public DateTime meetingDate { get; set; }

        [Display(Name = "Başlangıç Saati")]
        [Required(ErrorMessage = "{0} alanı gereklidir")]       
        public DateTime startTime { get; set; }

        [Display(Name = "Bitiş Saati")]
        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public DateTime finishTime { get; set; }      
     
    }
}
