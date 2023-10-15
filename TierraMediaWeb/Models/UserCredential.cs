using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TierraMediaWeb.Models
{
	public class UserCredential
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id_user { get; set; }

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
