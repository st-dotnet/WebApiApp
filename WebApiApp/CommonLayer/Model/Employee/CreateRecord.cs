namespace WebApiApp.CommonLayer.Model.Employee
{
	public class CreateRecordRequest
	{		
		public string EmpName { get; set; }
		public string EmpAddress { get; set; }
	}
	public class CreateRecordResponse
	{
		public bool IsSuccess { get; set; }
		public string Message { get; set; }
	}
}
