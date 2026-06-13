using AutoMapper;
using Beanz.Core.Areas.HumanResourceManagement.Employees;
using Beanz.Data.Services.DataAccessLayer;
using Beanz.Data.Services.DataAccessLayer.DAL;
using Beanz.DTOs.Areas;
using Beanz.DTOs.Areas.HumanResourceManagement.Employees;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Beanz.Data.Services.Areas.HumanResourceManagement.Employees
{
    public class EmployeeCalendarDayShiftRepository : IEmployeeCalendarDayShiftRepository
    {
        private readonly IMapper _mapper;

        public EmployeeCalendarDayShiftRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<EmployeeCalendarDayShiftDTO>> GetEmployeeCalendarDayShiftsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetEmployeeCalendarDayShifts";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EmployeeCalendarDayShiftID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<EmployeeCalendarDayShiftDTO>(_sql, _parameters);
            return data;
        }

        public async Task<BeanzResponseDTO> SetEmployeeCalendarDayShiftsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.SetEmployeeCalendarDayShifts";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@Json", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EmployeeCalendarDayShiftID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> PostEmployeeCalendarDayShiftsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PostEmployeeCalendarDayShifts";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@EmployeeCalendarDayShiftID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> DelEmployeeCalendarDayShiftsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.DelEmployeeCalendarDayShifts";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@EmployeeCalendarDayShiftID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<List<BeanzlookupDTO>> LookUpEmployeeCalendarDayShiftsAsync(BeanzCommonDTO lookup)
        {
            string _sql = "hrms.LookupEmployeeCalendarDayShifts";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = lookup.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = lookup.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = lookup.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = lookup.LanguageID },
                new SqlParameter("@EmployeeCalendarDayShiftID", SqlDbType.Int) { Value = lookup.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<BeanzlookupDTO>(_sql, _parameters);
            return data;
        }

        public async Task<EmployeeCalendarDayShiftViewModel> GetInfoEmployeeCalendarDayShiftsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetInfoEmployeeCalendarDayShifts";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EmployeeCalendarDayShiftID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _employeeCalendarDayShiftDTOList = new List<EmployeeCalendarDayShiftDTO>();
            bool _isEmployeeCalendarDayShiftsConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var employeeCalendarDayShiftData = objTemp.Where(c => c.TableName == "EmployeeCalendarDayShifts");
                        if (employeeCalendarDayShiftData.Count() > 0 && !_isEmployeeCalendarDayShiftsConsumed)
                        {
                            _employeeCalendarDayShiftDTOList = _mapper.Map<List<EmployeeCalendarDayShiftDTO>>(employeeCalendarDayShiftData);
                            _isEmployeeCalendarDayShiftsConsumed = true;
                            continue;
                        }
                    }
                }
                var _employeeCalendarDayShiftDTO = _employeeCalendarDayShiftDTOList.Where(x => x.EmployeeCalendarDayShiftID == common.PrimaryKeyID).FirstOrDefault();
                var result = new EmployeeCalendarDayShiftViewModel
                {
                    EmployeeCalendarDayShifts = _employeeCalendarDayShiftDTOList,
                    EmployeeCalendarDayShift = _employeeCalendarDayShiftDTO
                };
                return result;
            }
        }

        public async Task<EmployeeCalendarDayShiftViewModel> PrintEmployeeCalendarDayShiftsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PrintEmployeeCalendarDayShifts";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EmployeeCalendarDayShiftID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _employeeCalendarDayShiftDTOList = new List<EmployeeCalendarDayShiftDTO>();
            bool _isEmployeeCalendarDayShiftsConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var employeeCalendarDayShiftData = objTemp.Where(c => c.TableName == "EmployeeCalendarDayShifts");
                        if (employeeCalendarDayShiftData.Count() > 0 && !_isEmployeeCalendarDayShiftsConsumed)
                        {
                            _employeeCalendarDayShiftDTOList = _mapper.Map<List<EmployeeCalendarDayShiftDTO>>(employeeCalendarDayShiftData);
                            _isEmployeeCalendarDayShiftsConsumed = true;
                            continue;
                        }
                    }
                }
                var _employeeCalendarDayShiftDTO = _employeeCalendarDayShiftDTOList.Where(x => x.EmployeeCalendarDayShiftID == common.PrimaryKeyID).FirstOrDefault();
                var result = new EmployeeCalendarDayShiftViewModel
                {
                    EmployeeCalendarDayShifts = _employeeCalendarDayShiftDTOList,
                    EmployeeCalendarDayShift = _employeeCalendarDayShiftDTO
                };
                return result;
            }
        }

        public async Task<BeanzResponseDTO> ApproveEmployeeCalendarDayShiftsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.ApproveEmployeeCalendarDayShifts";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@EmployeeCalendarDayShiftID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }
    }
}
