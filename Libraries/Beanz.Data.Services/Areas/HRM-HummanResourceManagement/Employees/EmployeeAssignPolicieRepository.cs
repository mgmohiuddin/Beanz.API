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
    public class EmployeeAssignPolicieRepository : IEmployeeAssignPolicieRepository
    {
        private readonly IMapper _mapper;

        public EmployeeAssignPolicieRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<EmployeeAssignPolicieDTO>> GetEmployeeAssignPoliciesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetEmployeeAssignPolicies";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EmployeeAssignPolicieID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<EmployeeAssignPolicieDTO>(_sql, _parameters);
            return data;
        }

        public async Task<BeanzResponseDTO> SetEmployeeAssignPoliciesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.SetEmployeeAssignPolicies";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@Json", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EmployeeAssignPolicieID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> PostEmployeeAssignPoliciesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PostEmployeeAssignPolicies";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@EmployeeAssignPolicieID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> DelEmployeeAssignPoliciesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.DelEmployeeAssignPolicies";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@EmployeeAssignPolicieID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<List<BeanzlookupDTO>> LookUpEmployeeAssignPoliciesAsync(BeanzCommonDTO lookup)
        {
            string _sql = "hrms.LookupEmployeeAssignPolicies";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = lookup.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = lookup.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = lookup.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = lookup.LanguageID },
                new SqlParameter("@EmployeeAssignPolicieID", SqlDbType.Int) { Value = lookup.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<BeanzlookupDTO>(_sql, _parameters);
            return data;
        }

        public async Task<EmployeeAssignPolicieViewModel> GetInfoEmployeeAssignPoliciesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetInfoEmployeeAssignPolicies";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EmployeeAssignPolicieID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _employeeAssignPolicieDTOList = new List<EmployeeAssignPolicieDTO>();
            bool _isEmployeeAssignPoliciesConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var employeeAssignPolicieData = objTemp.Where(c => c.TableName == "EmployeeAssignPolicies");
                        if (employeeAssignPolicieData.Count() > 0 && !_isEmployeeAssignPoliciesConsumed)
                        {
                            _employeeAssignPolicieDTOList = _mapper.Map<List<EmployeeAssignPolicieDTO>>(employeeAssignPolicieData);
                            _isEmployeeAssignPoliciesConsumed = true;
                            continue;
                        }
                    }
                }
                var _employeeAssignPolicieDTO = _employeeAssignPolicieDTOList.Where(x => x.EmployeeAssignPolicieID == common.PrimaryKeyID).FirstOrDefault();
                var result = new EmployeeAssignPolicieViewModel
                {
                    EmployeeAssignPolicies = _employeeAssignPolicieDTOList,
                    EmployeeAssignPolicie = _employeeAssignPolicieDTO
                };
                return result;
            }
        }

        public async Task<EmployeeAssignPolicieViewModel> PrintEmployeeAssignPoliciesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PrintEmployeeAssignPolicies";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EmployeeAssignPolicieID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _employeeAssignPolicieDTOList = new List<EmployeeAssignPolicieDTO>();
            bool _isEmployeeAssignPoliciesConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var employeeAssignPolicieData = objTemp.Where(c => c.TableName == "EmployeeAssignPolicies");
                        if (employeeAssignPolicieData.Count() > 0 && !_isEmployeeAssignPoliciesConsumed)
                        {
                            _employeeAssignPolicieDTOList = _mapper.Map<List<EmployeeAssignPolicieDTO>>(employeeAssignPolicieData);
                            _isEmployeeAssignPoliciesConsumed = true;
                            continue;
                        }
                    }
                }
                var _employeeAssignPolicieDTO = _employeeAssignPolicieDTOList.Where(x => x.EmployeeAssignPolicieID == common.PrimaryKeyID).FirstOrDefault();
                var result = new EmployeeAssignPolicieViewModel
                {
                    EmployeeAssignPolicies = _employeeAssignPolicieDTOList,
                    EmployeeAssignPolicie = _employeeAssignPolicieDTO
                };
                return result;
            }
        }

        public async Task<BeanzResponseDTO> ApproveEmployeeAssignPoliciesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.ApproveEmployeeAssignPolicies";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@EmployeeAssignPolicieID", SqlDbType.Int) { Value = common.PrimaryKeyID },
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
