
using System.Threading.Tasks;
using WebApiApp.CommonLayer.Model.Employee;
using WebApiApp.RepositoryLayer.Employee;

namespace WebApiApp.ServiceLayer.Employee
{
	public class EmployeeSL : IEmployeeSL
	{
		private readonly IEmployeeRL _employee;
		public EmployeeSL(IEmployeeRL employee) 
		{
			_employee = employee;
		}
		public async  Task<CreateRecordResponse> CreateEmployee(CreateRecordRequest request)
		{
			return await _employee.CreateEmployee(request);
		}
		public async Task<GetRecordResponse> GetEmployeeRecord()
		{
			return await _employee.GetEmployeeRecord();
		}
		public async Task<UpdateRecordResponse> UpdateEmployeeRecord(UpdateRecordRequest request)
		{
			return await _employee.UpdateEmployeeRecord(request);
		}
		public async Task<DeleteRecordResponse> DeleteEmployeeRecord(DeleteRecordRequest request)
		{
			return await _employee.DeleteEmployeeRecord(request);
		}
	}
}
