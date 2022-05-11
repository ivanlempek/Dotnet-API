using System.ComponentModel.DataAnnotations;

namespace novaAPI.ViewModels
{
    public class CreateApiViewModel
    {
        [Required] public string Title { get; set; }
    }
}