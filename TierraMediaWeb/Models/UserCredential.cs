using System.ComponentModel.DataAnnotations;

namespace TierraMediaWeb.Models
{
	public class UserCredential
	{
		[Key]
		public string? Id { get; set; }

		[Required(ErrorMessage = "This field is required.")]
		public string User { get; set; }

		[Required(ErrorMessage = "This field is required.")]
		public string Password { get; set; }
		public int Role { get; set; }
	}
	public enum RoleType
	{
		Admin = 1,
		Client = 2
	}
}
