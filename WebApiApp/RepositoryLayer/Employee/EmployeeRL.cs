using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebApiApp.CommonLayer.Model.Employee;
using WebApiApp.Context;
using WebApiApp.Entities.Employee;

namespace WebApiApp.RepositoryLayer.Employee
{
	public class EmployeeRL : IEmployeeRL
	{
		private readonly TestDbContext _context;
		public EmployeeRL(TestDbContext context)
		{
			_context = context;
		}
		public async Task<CreateRecordResponse> CreateEmployee(CreateRecordRequest request)
		{
			CreateRecordResponse response = new CreateRecordResponse();
			response.IsSuccess = true;
			response.Message = "Data Saved Successfully";
			var empData = new TblEmpData()
			{
				EmpName = request.EmpName,
				EmpAddress = request.EmpAddress
			};
			try
			{
				_context.TblEmpData.AddRange(empData);
				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.Message = ex.Message + "Data Not Saved";
			}
			return response;
		}

		public async Task<GetRecordResponse> GetEmployeeRecord()
		{
			GetRecordResponse response = new GetRecordResponse();
			response.IsSuccess = true;
			response.Message = "Got the saved records";
			response.EmployeeData = new List<GetEmployeeData>();
			try
			{
				var empList = _context.TblEmpData
				.Select(col => new GetEmployeeData
				{
					Id = col.Id,
					EmpName = col.EmpName,
					EmpAddress = col.EmpAddress
				}).ToList();
				response.EmployeeData = empList;
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.Message = ex.Message + "Data Not Getting";
			}
			return response;
		}
		public async Task<UpdateRecordResponse> UpdateEmployeeRecord(UpdateRecordRequest request)
		{
			UpdateRecordResponse response = new UpdateRecordResponse();
			response.IsSuccess = true;
			response.Message = "Update Data Successfully";
			try
			{
				var query = _context.TblEmpData.FirstOrDefault(item => item.Id == request.Id);
				if (query != null)
				{
					query.EmpName = request.EmpName;
					query.EmpAddress = request.EmpAddress;
					_context.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				response.IsSuccess=false;
				response.Message = ex.Message + "Data Not Updated";
			}
			return response;
		}
		public async Task<DeleteRecordResponse> DeleteEmployeeRecord(DeleteRecordRequest request)
		{
			DeleteRecordResponse response = new DeleteRecordResponse();
			response.IsSuccess = true;
			response.Message = "Data Delete Successfully";

			try
			{
				var query = _context.TblEmpData.FirstOrDefault(item => item.Id == request.Id);
				if (query != null)
				{
					_context.Remove(query);
					await _context.SaveChangesAsync();
				}
			}
			catch (Exception ex)
			{
				response.IsSuccess=false;
				response.Message = ex.Message + "Data Not Deleted";
			}

			return response;
		}
	}
}
