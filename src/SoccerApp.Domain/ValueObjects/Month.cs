
using System.ComponentModel.DataAnnotations;

namespace SoccerApp.Domain.ValueObjects
{
    public enum Month
    {
        [Display(Name = "Janeiro")]
        January = 1,

        [Display(Name = "Fevereiro")]
        February,

        [Display(Name = "Março")]
        March,

        [Display(Name = "Abril")]
        April,

        [Display(Name = "Maio")]
        May,

        [Display(Name = "Junho")]
        June,

        [Display(Name = "Julho")]
        July,

        [Display(Name = "Agosto")]
        August,

        [Display(Name = "Setembro")]
        September,

        [Display(Name = "Outubro")]
        October,

        [Display(Name = "Novembro")]
        November,

        [Display(Name = "Dezembro")]
        December
    }
}
