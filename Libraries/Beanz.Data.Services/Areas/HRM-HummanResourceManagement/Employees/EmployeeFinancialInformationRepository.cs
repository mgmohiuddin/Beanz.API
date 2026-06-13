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
    public class EmployeeFinancialInformationRepository : IEmployeeFinancialInformationRepository
    {
        private readonly IMapper _mapper;

        public EmployeeFinancialInformationRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<EmployeeFinancialInformationDTO>> GetEmployeeFinancialInformationsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetEmployeeFinancialInformations";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EmployeeFinancialInformationID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<EmployeeFinancialInformationDTO>(_sql, _parameters);
            return data;
        }

        public async Task<BeanzResponseDTO> SetEmployeeFinancialInformationsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.SetEmployeeFinancialInformations";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@Json", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EmployeeFinancialInformationID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> PostEmployeeFinancialInformationsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PostEmployeeFinancialInformations";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@EmployeeFinancialInformationID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> DelEmployeeFinancialInformationsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.DelEmployeeFinancialInformations";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@EmployeeFinancialInformationID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<List<BeanzlookupDTO>> LookUpEmployeeFinancialInformationsAsync(BeanzCommonDTO lookup)
        {
            string _sql = "hrms.LookupEmployeeFinancialInformations";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = lookup.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = lookup.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = lookup.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = lookup.LanguageID },
                new SqlParameter("@EmployeeFinancialInformationID", SqlDbType.Int) { Value = lookup.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<BeanzlookupDTO>(_sql, _parameters);
            return data;
        }

        public async Task<EmployeeFinancialInformationViewModel> GetInfoEmployeeFinancialInformationsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetInfoEmployeeFinancialInformations";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EmployeeFinancialInformationID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _employeeFinancialInformationDTOList = new List<EmployeeFinancialInformationDTO>();
            bool _isEmployeeFinancialInformationsConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var employeeFinancialInformationData = objTemp.Where(c => c.TableName == "EmployeeFinancialInformations");
                        if (employeeFinancialInformationData.Count() > 0 && !_isEmployeeFinancialInformationsConsumed)
                        {
                            _employeeFinancialInformationDTOList = _mapper.Map<List<EmployeeFinancialInformationDTO>>(employeeFinancialInformationData);
                            _isEmployeeFinancialInformationsConsumed = true;
                            continue;
                        }
                    }
                }
                var _employeeFinancialInformationDTO = _employeeFinancialInformationDTOList.Where(x => x.EmployeeFinancialInformationID == common.PrimaryKeyID).FirstOrDefault();
                var result = new EmployeeFinancialInformationViewModel
                {
                    EmployeeFinancialInformations = _employeeFinancialInformationDTOList,
                    EmployeeFinancialInformation = _employeeFinancialInformationDTO
                };
                return result;
            }
        }

        public async Task<EmployeeFinancialInformationViewModel> PrintEmployeeFinancialInformationsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PrintEmployeeFinancialInformations";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EmployeeFinancialInformationID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _employeeFinancialInformationDTOList = new List<EmployeeFinancialInformationDTO>();
            bool _isEmployeeFinancialInformationsConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var employeeFinancialInformationData = objTemp.Where(c => c.TableName == "EmployeeFinancialInformations");
                        if (employeeFinancialInformationData.Count() > 0 && !_isEmployeeFinancialInformationsConsumed)
                        {
                            _employeeFinancialInformationDTOList = _mapper.Map<List<EmployeeFinancialInformationDTO>>(employeeFinancialInformationData);
                            _isEmployeeFinancialInformationsConsumed = true;
                            continue;
                        }
                    }
                }
                var _employeeFinancialInformationDTO = _employeeFinancialInformationDTOList.Where(x => x.EmployeeFinancialInformationID == common.PrimaryKeyID).FirstOrDefault();
                var result = new EmployeeFinancialInformationViewModel
                {
                    EmployeeFinancialInformations = _employeeFinancialInformationDTOList,
                    EmployeeFinancialInformation = _employeeFinancialInformationDTO
                };
                return result;
            }
        }

        public async Task<BeanzResponseDTO> ApproveEmployeeFinancialInformationsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.ApproveEmployeeFinancialInformations";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@EmployeeFinancialInformationID", SqlDbType.Int) { Value = common.PrimaryKeyID },
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
