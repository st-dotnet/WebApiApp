namespace WebApiApp.CommonLayer.Model.Employee
{
	public class UpdateRecordRequest
	{
		public int Id { get; set; }
		public string EmpName { get; set; }
		public string EmpAddress { get; set; }
	}
	public class UpdateRecordResponse
	{
		public bool IsSuccess { get; set; }
		public string Message { get; set; }
	}
}
