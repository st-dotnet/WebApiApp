using System.ComponentModel.DataAnnotations;

namespace WebApiApp.Entities.Employee
{
	public class TblEmpData
	{
		[Key]
		public int Id { get; set; }
		public string EmpName { get; set; }
		public string EmpAddress { get; set; }
	}
}
