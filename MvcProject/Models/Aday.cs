using System.ComponentModel.DataAnnotations;

namespace MvcProject.Models
{
	public class Aday
	{
        public int Id { get; set; }
        [Required(ErrorMessage = "E-mail girilmesi zorunludur")]
		[EmailAddress]
		public string? Email { get; set; } = string.Empty;

		[Required(ErrorMessage = "isim girilmesi zorunludur")]
		public string? FirstName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Soyadı girilmesi zorunludur")]
		public string? LastName { get; set; } = string.Empty;

		public string? FullName => $"{FirstName} {LastName?.ToUpper()}";

        public int? Age { get; set; }

		[Required(ErrorMessage = "1 adet kurs seçilmek zorunludur")]
		public string? SelectedCourse { get; set; } = string.Empty;
		public DateTime ApplyAt { get; set; } // şu tarihte başvurdu
        public Aday()
        {
			ApplyAt = DateTime.Now;

		}

    }
	public class UpdateAday
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "E-mail girilmesi zorunludur")]
		[EmailAddress]
		public string? Email { get; set; } = string.Empty;

		[Required(ErrorMessage = "isim girilmesi zorunludur")]
		public string? FirstName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Soyadı girilmesi zorunludur")]
		public string? LastName { get; set; } = string.Empty;

		public string? FullName => $"{FirstName} {LastName?.ToUpper()}";

		public int? Age { get; set; }

		[Required(ErrorMessage = "1 adet kurs seçilmek zorunludur")]
		public string? SelectedCourse { get; set; } = string.Empty;
		public DateTime ApplyAt { get; set; } // şu tarihte başvurdu
		public UpdateAday()
		{
			ApplyAt = DateTime.Now;

		}
	}
}
