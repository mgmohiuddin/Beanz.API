using AutoMapper;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.Data.Services.DataAccessLayer;
using Beanz.Data.Services.DataAccessLayer.DAL;
using Beanz.DTOs.Areas;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Beanz.Data.Services.Areas.HummanResourceManagement.Policies
{
    public class InsurancePolicieRepository : IInsurancePolicieRepository
    {
        private readonly IMapper _mapper;

        public InsurancePolicieRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<InsurancePolicieDTO>> GetInsurancePoliciesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetPOL_InsurancePolicies";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@InsurancePolicieID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<InsurancePolicieDTO>(_sql, _parameters);
            return data;
        }

        public async Task<BeanzResponseDTO> SetInsurancePoliciesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.SetPOL_InsurancePolicies";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@Json", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@InsurancePolicieID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> PostInsurancePoliciesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PostPOL_InsurancePolicies";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@InsurancePolicieID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> DelInsurancePoliciesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.DelPOL_InsurancePolicies";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@InsurancePolicieID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<List<BeanzlookupDTO>> LookUpInsurancePoliciesAsync(BeanzCommonDTO lookup)
        {
            string _sql = "hrms.LookupPOL_InsurancePolicies";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = lookup.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = lookup.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = lookup.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = lookup.LanguageID },
                new SqlParameter("@InsurancePolicieID", SqlDbType.Int) { Value = lookup.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<BeanzlookupDTO>(_sql, _parameters);
            return data;
        }

        public async Task<InsurancePolicieViewModel> GetInfoInsurancePoliciesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetInfoPOL_InsurancePolicies";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@InsurancePolicieID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _insurancePolicieDTOList = new List<InsurancePolicieDTO>();
            bool _isInsurancePoliciesConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var insurancePolicieData = objTemp.Where(c => c.TableName == "POL_InsurancePolicies");
                        if (insurancePolicieData.Count() > 0 && !_isInsurancePoliciesConsumed)
                        {
                            _insurancePolicieDTOList = _mapper.Map<List<InsurancePolicieDTO>>(insurancePolicieData);
                            _isInsurancePoliciesConsumed = true;
                            continue;
                        }
                    }
                }
                var _insurancePolicieDTO = _insurancePolicieDTOList.Where(x => x.InsurancePolicieID == common.PrimaryKeyID).FirstOrDefault();
                var result = new InsurancePolicieViewModel
                {
                    InsurancePolicies = _insurancePolicieDTOList,
                    InsurancePolicie = _insurancePolicieDTO
                };
                return result;
            }
        }

        public async Task<InsurancePolicieViewModel> PrintInsurancePoliciesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PrintPOL_InsurancePolicies";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@InsurancePolicieID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _insurancePolicieDTOList = new List<InsurancePolicieDTO>();
            bool _isInsurancePoliciesConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var insurancePolicieData = objTemp.Where(c => c.TableName == "POL_InsurancePolicies");
                        if (insurancePolicieData.Count() > 0 && !_isInsurancePoliciesConsumed)
                        {
                            _insurancePolicieDTOList = _mapper.Map<List<InsurancePolicieDTO>>(insurancePolicieData);
                            _isInsurancePoliciesConsumed = true;
                            continue;
                        }
                    }
                }
                var _insurancePolicieDTO = _insurancePolicieDTOList.Where(x => x.InsurancePolicieID == common.PrimaryKeyID).FirstOrDefault();
                var result = new InsurancePolicieViewModel
                {
                    InsurancePolicies = _insurancePolicieDTOList,
                    InsurancePolicie = _insurancePolicieDTO
                };
                return result;
            }
        }

        public async Task<BeanzResponseDTO> ApproveInsurancePoliciesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.ApprovePOL_InsurancePolicies";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@InsurancePolicieID", SqlDbType.Int) { Value = common.PrimaryKeyID },
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
