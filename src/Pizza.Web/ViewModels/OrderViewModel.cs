using System.ComponentModel.DataAnnotations;

namespace Pizza.Web.ViewModels
{
    public class OrderViewModel
    {
        [Required(ErrorMessage = "Не указано имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Не указан адрес")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Не указано телефон")]
        [Phone(ErrorMessage = "неверный номер телефона")]
        public string Phone { get; set; }
    }
}
