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
    public class PaidTimeOffPolicyEligibleRepository : IPaidTimeOffPolicyEligibleRepository
    {
        private readonly IMapper _mapper;

        public PaidTimeOffPolicyEligibleRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<PaidTimeOffPolicyEligibleDTO>> GetPaidTimeOffPolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetPOL_PaidTimeOffPolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@PaidTimeOffPolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<PaidTimeOffPolicyEligibleDTO>(_sql, _parameters);
            return data;
        }

        public async Task<BeanzResponseDTO> SetPaidTimeOffPolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.SetPOL_PaidTimeOffPolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@Json", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@PaidTimeOffPolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> PostPaidTimeOffPolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PostPOL_PaidTimeOffPolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@PaidTimeOffPolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> DelPaidTimeOffPolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.DelPOL_PaidTimeOffPolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@PaidTimeOffPolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<List<BeanzlookupDTO>> LookUpPaidTimeOffPolicyEligiblesAsync(BeanzCommonDTO lookup)
        {
            string _sql = "hrms.LookupPOL_PaidTimeOffPolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = lookup.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = lookup.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = lookup.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = lookup.LanguageID },
                new SqlParameter("@PaidTimeOffPolicyEligibleID", SqlDbType.Int) { Value = lookup.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<BeanzlookupDTO>(_sql, _parameters);
            return data;
        }

        public async Task<PaidTimeOffPolicyEligibleViewModel> GetInfoPaidTimeOffPolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetInfoPOL_PaidTimeOffPolicyEligibles";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@PaidTimeOffPolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _paidTimeOffPolicyEligibleDTOList = new List<PaidTimeOffPolicyEligibleDTO>();
            bool _isPaidTimeOffPolicyEligiblesConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var paidTimeOffPolicyEligibleData = objTemp.Where(c => c.TableName == "POL_PaidTimeOffPolicyEligibles");
                        if (paidTimeOffPolicyEligibleData.Count() > 0 && !_isPaidTimeOffPolicyEligiblesConsumed)
                        {
                            _paidTimeOffPolicyEligibleDTOList = _mapper.Map<List<PaidTimeOffPolicyEligibleDTO>>(paidTimeOffPolicyEligibleData);
                            _isPaidTimeOffPolicyEligiblesConsumed = true;
                            continue;
                        }
                    }
                }
                var _paidTimeOffPolicyEligibleDTO = _paidTimeOffPolicyEligibleDTOList.Where(x => x.PaidTimeOffPolicyEligibleID == common.PrimaryKeyID).FirstOrDefault();
                var result = new PaidTimeOffPolicyEligibleViewModel
                {
                    PaidTimeOffPolicyEligibles = _paidTimeOffPolicyEligibleDTOList,
                    PaidTimeOffPolicyEligible = _paidTimeOffPolicyEligibleDTO
                };
                return result;
            }
        }

        public async Task<PaidTimeOffPolicyEligibleViewModel> PrintPaidTimeOffPolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PrintPOL_PaidTimeOffPolicyEligibles";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@PaidTimeOffPolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _paidTimeOffPolicyEligibleDTOList = new List<PaidTimeOffPolicyEligibleDTO>();
            bool _isPaidTimeOffPolicyEligiblesConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var paidTimeOffPolicyEligibleData = objTemp.Where(c => c.TableName == "POL_PaidTimeOffPolicyEligibles");
                        if (paidTimeOffPolicyEligibleData.Count() > 0 && !_isPaidTimeOffPolicyEligiblesConsumed)
                        {
                            _paidTimeOffPolicyEligibleDTOList = _mapper.Map<List<PaidTimeOffPolicyEligibleDTO>>(paidTimeOffPolicyEligibleData);
                            _isPaidTimeOffPolicyEligiblesConsumed = true;
                            continue;
                        }
                    }
                }
                var _paidTimeOffPolicyEligibleDTO = _paidTimeOffPolicyEligibleDTOList.Where(x => x.PaidTimeOffPolicyEligibleID == common.PrimaryKeyID).FirstOrDefault();
                var result = new PaidTimeOffPolicyEligibleViewModel
                {
                    PaidTimeOffPolicyEligibles = _paidTimeOffPolicyEligibleDTOList,
                    PaidTimeOffPolicyEligible = _paidTimeOffPolicyEligibleDTO
                };
                return result;
            }
        }

        public async Task<BeanzResponseDTO> ApprovePaidTimeOffPolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.ApprovePOL_PaidTimeOffPolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@PaidTimeOffPolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID },
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
