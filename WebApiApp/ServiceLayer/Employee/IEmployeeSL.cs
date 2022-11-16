using System.Threading.Tasks;
using WebApiApp.CommonLayer.Model.Employee;

namespace WebApiApp.ServiceLayer.Employee
{
	public interface IEmployeeSL
	{
		public Task<CreateRecordResponse> CreateEmployee(CreateRecordRequest request);
		public Task<GetRecordResponse> GetEmployeeRecord();
		public Task<UpdateRecordResponse> UpdateEmployeeRecord(UpdateRecordRequest request);
		public Task<DeleteRecordResponse> DeleteEmployeeRecord(DeleteRecordRequest request);

	}
}
