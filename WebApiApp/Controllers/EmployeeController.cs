using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApiApp.CommonLayer.Model.Employee;
using WebApiApp.ServiceLayer.Employee;

namespace WebApiApp.Controllers
{
	[Route("api/employee")]
	[ApiController]
	[Consumes("application/json")]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeSL _employee;
		public EmployeeController(IEmployeeSL employee)
		{
			_employee = employee;
		}
		[HttpPost]
		[Route("create")]
		public async Task<IActionResult> CreateEmployee(CreateRecordRequest request)
		{
			CreateRecordResponse response = null;
			try
			{
				response = await _employee.CreateEmployee(request);
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.Message = ex.Message;
			}
			return Ok(response);
		}
		[HttpGet]
		[Route("record")]
		public async Task<IActionResult> GetEmployeeRecord()
		{
			GetRecordResponse response = null;
			try
			{
				response = await _employee.GetEmployeeRecord();
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.Message = ex.Message;
			}
			return Ok(response);
		}
		[HttpPut]
		[Route("update")]
		public async Task<IActionResult> UpdateEmployeeRecord(UpdateRecordRequest request)
		{
			UpdateRecordResponse response = null;
			try
			{
				response = await _employee.UpdateEmployeeRecord(request);
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.Message = ex.Message;
			}
			return Ok(response);
		}
		[HttpDelete]
		[Route("delete")]
		public async Task<IActionResult> DeleteEmployeeRecord(DeleteRecordRequest request)
		{
			DeleteRecordResponse response = null;
			try
			{
				response = await _employee.DeleteEmployeeRecord(request);
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.Message = ex.Message;
			}
			return Ok(response);
		}
	}
}
