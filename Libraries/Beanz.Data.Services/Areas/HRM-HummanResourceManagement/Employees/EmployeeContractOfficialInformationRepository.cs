using AutoMapper;
using Beanz.Core.Areas.HummanResourceManagement.Employees;
using Beanz.Data.Services.DataAccessLayer;
using Beanz.Data.Services.DataAccessLayer.DAL;
using Beanz.DTOs.Areas;
using Beanz.DTOs.Areas.HummanResourceManagement.Employees;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Beanz.Data.Services.Areas.HummanResourceManagement.Employees
{
    public class EmployeeContractOfficialInformationRepository : IEmployeeContractOfficialInformationRepository
    {
        private readonly IMapper _mapper;

        public EmployeeContractOfficialInformationRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<EmployeeContractOfficialInformationDTO>> GetEmployeeContractOfficialInformationsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetEmployeeContractOfficialInformations";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EmployeeContractOfficialInformationID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<EmployeeContractOfficialInformationDTO>(_sql, _parameters);
            return data;
        }

        public async Task<BeanzResponseDTO> SetEmployeeContractOfficialInformationsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.SetEmployeeContractOfficialInformations";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@Json", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EmployeeContractOfficialInformationID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> PostEmployeeContractOfficialInformationsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PostEmployeeContractOfficialInformations";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@EmployeeContractOfficialInformationID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> DelEmployeeContractOfficialInformationsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.DelEmployeeContractOfficialInformations";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@EmployeeContractOfficialInformationID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<List<BeanzlookupDTO>> LookUpEmployeeContractOfficialInformationsAsync(BeanzCommonDTO lookup)
        {
            string _sql = "hrms.LookupEmployeeContractOfficialInformations";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = lookup.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = lookup.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = lookup.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = lookup.LanguageID },
                new SqlParameter("@EmployeeContractOfficialInformationID", SqlDbType.Int) { Value = lookup.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<BeanzlookupDTO>(_sql, _parameters);
            return data;
        }

        public async Task<EmployeeContractOfficialInformationViewModel> GetInfoEmployeeContractOfficialInformationsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetInfoEmployeeContractOfficialInformations";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EmployeeContractOfficialInformationID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _employeeContractOfficialInformationDTOList = new List<EmployeeContractOfficialInformationDTO>();
            bool _isEmployeeContractOfficialInformationsConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var employeeContractOfficialInformationData = objTemp.Where(c => c.TableName == "EmployeeContractOfficialInformations");
                        if (employeeContractOfficialInformationData.Count() > 0 && !_isEmployeeContractOfficialInformationsConsumed)
                        {
                            _employeeContractOfficialInformationDTOList = _mapper.Map<List<EmployeeContractOfficialInformationDTO>>(employeeContractOfficialInformationData);
                            _isEmployeeContractOfficialInformationsConsumed = true;
                            continue;
                        }
                    }
                }
                var _employeeContractOfficialInformationDTO = _employeeContractOfficialInformationDTOList.Where(x => x.EmployeeContractOfficialInformationID == common.PrimaryKeyID).FirstOrDefault();
                var result = new EmployeeContractOfficialInformationViewModel
                {
                    EmployeeContractOfficialInformations = _employeeContractOfficialInformationDTOList,
                    EmployeeContractOfficialInformation = _employeeContractOfficialInformationDTO
                };
                return result;
            }
        }

        public async Task<EmployeeContractOfficialInformationViewModel> PrintEmployeeContractOfficialInformationsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PrintEmployeeContractOfficialInformations";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EmployeeContractOfficialInformationID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _employeeContractOfficialInformationDTOList = new List<EmployeeContractOfficialInformationDTO>();
            bool _isEmployeeContractOfficialInformationsConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var employeeContractOfficialInformationData = objTemp.Where(c => c.TableName == "EmployeeContractOfficialInformations");
                        if (employeeContractOfficialInformationData.Count() > 0 && !_isEmployeeContractOfficialInformationsConsumed)
                        {
                            _employeeContractOfficialInformationDTOList = _mapper.Map<List<EmployeeContractOfficialInformationDTO>>(employeeContractOfficialInformationData);
                            _isEmployeeContractOfficialInformationsConsumed = true;
                            continue;
                        }
                    }
                }
                var _employeeContractOfficialInformationDTO = _employeeContractOfficialInformationDTOList.Where(x => x.EmployeeContractOfficialInformationID == common.PrimaryKeyID).FirstOrDefault();
                var result = new EmployeeContractOfficialInformationViewModel
                {
                    EmployeeContractOfficialInformations = _employeeContractOfficialInformationDTOList,
                    EmployeeContractOfficialInformation = _employeeContractOfficialInformationDTO
                };
                return result;
            }
        }

        public async Task<BeanzResponseDTO> ApproveEmployeeContractOfficialInformationsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.ApproveEmployeeContractOfficialInformations";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@EmployeeContractOfficialInformationID", SqlDbType.Int) { Value = common.PrimaryKeyID },
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
