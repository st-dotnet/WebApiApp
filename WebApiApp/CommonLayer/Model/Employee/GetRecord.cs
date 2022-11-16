using System.Collections.Generic;

namespace WebApiApp.CommonLayer.Model.Employee
{
	public class GetRecordResponse
	{
		public bool IsSuccess { get; set; }
		public string Message { get; set; }
		public List<GetEmployeeData> EmployeeData { get; set; }
	}
	public class GetEmployeeData
	{
		public int Id { get; set; }
		public string EmpName { get; set; }
		public string EmpAddress { get; set; }
	}
}
