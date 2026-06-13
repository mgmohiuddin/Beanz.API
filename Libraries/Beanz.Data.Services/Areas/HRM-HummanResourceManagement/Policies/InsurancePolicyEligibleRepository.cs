using AutoMapper;
using Beanz.Core.Areas.HumanResourceManagement.Policies;
using Beanz.Data.Services.DataAccessLayer;
using Beanz.Data.Services.DataAccessLayer.DAL;
using Beanz.DTOs.Areas;
using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Beanz.Data.Services.Areas.HumanResourceManagement.Policies
{
    public class InsurancePolicyEligibleRepository : IInsurancePolicyEligibleRepository
    {
        private readonly IMapper _mapper;

        public InsurancePolicyEligibleRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<InsurancePolicyEligibleDTO>> GetInsurancePolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetPOL_InsurancePolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@InsurancePolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<InsurancePolicyEligibleDTO>(_sql, _parameters);
            return data;
        }

        public async Task<BeanzResponseDTO> SetInsurancePolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.SetPOL_InsurancePolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@Json", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@InsurancePolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> PostInsurancePolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PostPOL_InsurancePolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@InsurancePolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> DelInsurancePolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.DelPOL_InsurancePolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@InsurancePolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<List<BeanzlookupDTO>> LookUpInsurancePolicyEligiblesAsync(BeanzCommonDTO lookup)
        {
            string _sql = "hrms.LookupPOL_InsurancePolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = lookup.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = lookup.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = lookup.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = lookup.LanguageID },
                new SqlParameter("@InsurancePolicyEligibleID", SqlDbType.Int) { Value = lookup.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<BeanzlookupDTO>(_sql, _parameters);
            return data;
        }

        public async Task<InsurancePolicyEligibleViewModel> GetInfoInsurancePolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetInfoPOL_InsurancePolicyEligibles";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@InsurancePolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _insurancePolicyEligibleDTOList = new List<InsurancePolicyEligibleDTO>();
            bool _isInsurancePolicyEligiblesConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var insurancePolicyEligibleData = objTemp.Where(c => c.TableName == "POL_InsurancePolicyEligibles");
                        if (insurancePolicyEligibleData.Count() > 0 && !_isInsurancePolicyEligiblesConsumed)
                        {
                            _insurancePolicyEligibleDTOList = _mapper.Map<List<InsurancePolicyEligibleDTO>>(insurancePolicyEligibleData);
                            _isInsurancePolicyEligiblesConsumed = true;
                            continue;
                        }
                    }
                }
                var _insurancePolicyEligibleDTO = _insurancePolicyEligibleDTOList.Where(x => x.InsurancePolicyEligibleID == common.PrimaryKeyID).FirstOrDefault();
                var result = new InsurancePolicyEligibleViewModel
                {
                    InsurancePolicyEligibles = _insurancePolicyEligibleDTOList,
                    InsurancePolicyEligible = _insurancePolicyEligibleDTO
                };
                return result;
            }
        }

        public async Task<InsurancePolicyEligibleViewModel> PrintInsurancePolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PrintPOL_InsurancePolicyEligibles";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@InsurancePolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _insurancePolicyEligibleDTOList = new List<InsurancePolicyEligibleDTO>();
            bool _isInsurancePolicyEligiblesConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var insurancePolicyEligibleData = objTemp.Where(c => c.TableName == "POL_InsurancePolicyEligibles");
                        if (insurancePolicyEligibleData.Count() > 0 && !_isInsurancePolicyEligiblesConsumed)
                        {
                            _insurancePolicyEligibleDTOList = _mapper.Map<List<InsurancePolicyEligibleDTO>>(insurancePolicyEligibleData);
                            _isInsurancePolicyEligiblesConsumed = true;
                            continue;
                        }
                    }
                }
                var _insurancePolicyEligibleDTO = _insurancePolicyEligibleDTOList.Where(x => x.InsurancePolicyEligibleID == common.PrimaryKeyID).FirstOrDefault();
                var result = new InsurancePolicyEligibleViewModel
                {
                    InsurancePolicyEligibles = _insurancePolicyEligibleDTOList,
                    InsurancePolicyEligible = _insurancePolicyEligibleDTO
                };
                return result;
            }
        }

        public async Task<BeanzResponseDTO> ApproveInsurancePolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.ApprovePOL_InsurancePolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@InsurancePolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID },
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
