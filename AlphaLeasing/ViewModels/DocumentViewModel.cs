using AlphaLeasing.Common.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace AlphaLeasing.ViewModels
{
    public class DocumentViewModel
    {
        public List<HttpPostedFileBase> Files { get; set; } = new List<HttpPostedFileBase>();

        [Required(ErrorMessage = "Введите логин")]
        [MaxLength(DocumentValidation.NameLength, ErrorMessage = "Максимальная длина файла должна быть меньше 20 символов")]
        public string Name { get; set; }
    }
}