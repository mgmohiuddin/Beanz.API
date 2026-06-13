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
    public class EmployeeDependentDocumentRepository : IEmployeeDependentDocumentRepository
    {
        private readonly IMapper _mapper;

        public EmployeeDependentDocumentRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<EmployeeDependentDocumentDTO>> GetEmployeeDependentDocumentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetEmployeeDependentDocuments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EmployeeDependentDocumentID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<EmployeeDependentDocumentDTO>(_sql, _parameters);
            return data;
        }

        public async Task<BeanzResponseDTO> SetEmployeeDependentDocumentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.SetEmployeeDependentDocuments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@Json", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EmployeeDependentDocumentID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> PostEmployeeDependentDocumentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PostEmployeeDependentDocuments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@EmployeeDependentDocumentID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> DelEmployeeDependentDocumentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.DelEmployeeDependentDocuments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@EmployeeDependentDocumentID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<List<BeanzlookupDTO>> LookUpEmployeeDependentDocumentsAsync(BeanzCommonDTO lookup)
        {
            string _sql = "hrms.LookupEmployeeDependentDocuments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = lookup.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = lookup.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = lookup.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = lookup.LanguageID },
                new SqlParameter("@EmployeeDependentDocumentID", SqlDbType.Int) { Value = lookup.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<BeanzlookupDTO>(_sql, _parameters);
            return data;
        }

        public async Task<EmployeeDependentDocumentViewModel> GetInfoEmployeeDependentDocumentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetInfoEmployeeDependentDocuments";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EmployeeDependentDocumentID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _employeeDependentDocumentDTOList = new List<EmployeeDependentDocumentDTO>();
            bool _isEmployeeDependentDocumentsConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var employeeDependentDocumentData = objTemp.Where(c => c.TableName == "EmployeeDependentDocuments");
                        if (employeeDependentDocumentData.Count() > 0 && !_isEmployeeDependentDocumentsConsumed)
                        {
                            _employeeDependentDocumentDTOList = _mapper.Map<List<EmployeeDependentDocumentDTO>>(employeeDependentDocumentData);
                            _isEmployeeDependentDocumentsConsumed = true;
                            continue;
                        }
                    }
                }
                var _employeeDependentDocumentDTO = _employeeDependentDocumentDTOList.Where(x => x.EmployeeDependentDocumentID == common.PrimaryKeyID).FirstOrDefault();
                var result = new EmployeeDependentDocumentViewModel
                {
                    EmployeeDependentDocuments = _employeeDependentDocumentDTOList,
                    EmployeeDependentDocument = _employeeDependentDocumentDTO
                };
                return result;
            }
        }

        public async Task<EmployeeDependentDocumentViewModel> PrintEmployeeDependentDocumentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PrintEmployeeDependentDocuments";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EmployeeDependentDocumentID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _employeeDependentDocumentDTOList = new List<EmployeeDependentDocumentDTO>();
            bool _isEmployeeDependentDocumentsConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var employeeDependentDocumentData = objTemp.Where(c => c.TableName == "EmployeeDependentDocuments");
                        if (employeeDependentDocumentData.Count() > 0 && !_isEmployeeDependentDocumentsConsumed)
                        {
                            _employeeDependentDocumentDTOList = _mapper.Map<List<EmployeeDependentDocumentDTO>>(employeeDependentDocumentData);
                            _isEmployeeDependentDocumentsConsumed = true;
                            continue;
                        }
                    }
                }
                var _employeeDependentDocumentDTO = _employeeDependentDocumentDTOList.Where(x => x.EmployeeDependentDocumentID == common.PrimaryKeyID).FirstOrDefault();
                var result = new EmployeeDependentDocumentViewModel
                {
                    EmployeeDependentDocuments = _employeeDependentDocumentDTOList,
                    EmployeeDependentDocument = _employeeDependentDocumentDTO
                };
                return result;
            }
        }

        public async Task<BeanzResponseDTO> ApproveEmployeeDependentDocumentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.ApproveEmployeeDependentDocuments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@EmployeeDependentDocumentID", SqlDbType.Int) { Value = common.PrimaryKeyID },
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
