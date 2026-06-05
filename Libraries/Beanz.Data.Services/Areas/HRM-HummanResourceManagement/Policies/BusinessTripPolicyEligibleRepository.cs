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
    public class BusinessTripPolicyEligibleRepository : IBusinessTripPolicyEligibleRepository
    {
        private readonly IMapper _mapper;

        public BusinessTripPolicyEligibleRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<BusinessTripPolicyEligibleDTO>> GetBusinessTripPolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetPOL_BusinessTripPolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@BusinessTripPolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<BusinessTripPolicyEligibleDTO>(_sql, _parameters);
            return data;
        }

        public async Task<BeanzResponseDTO> SetBusinessTripPolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.SetPOL_BusinessTripPolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@Json", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@BusinessTripPolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> PostBusinessTripPolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PostPOL_BusinessTripPolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@BusinessTripPolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> DelBusinessTripPolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.DelPOL_BusinessTripPolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@BusinessTripPolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<List<BeanzlookupDTO>> LookUpBusinessTripPolicyEligiblesAsync(BeanzCommonDTO lookup)
        {
            string _sql = "hrms.LookupPOL_BusinessTripPolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = lookup.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = lookup.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = lookup.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = lookup.LanguageID },
                new SqlParameter("@BusinessTripPolicyEligibleID", SqlDbType.Int) { Value = lookup.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<BeanzlookupDTO>(_sql, _parameters);
            return data;
        }

        public async Task<BusinessTripPolicyEligibleViewModel> GetInfoBusinessTripPolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetInfoPOL_BusinessTripPolicyEligibles";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@BusinessTripPolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _businessTripPolicyEligibleDTOList = new List<BusinessTripPolicyEligibleDTO>();
            bool _isBusinessTripPolicyEligiblesConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var businessTripPolicyEligibleData = objTemp.Where(c => c.TableName == "POL_BusinessTripPolicyEligibles");
                        if (businessTripPolicyEligibleData.Count() > 0 && !_isBusinessTripPolicyEligiblesConsumed)
                        {
                            _businessTripPolicyEligibleDTOList = _mapper.Map<List<BusinessTripPolicyEligibleDTO>>(businessTripPolicyEligibleData);
                            _isBusinessTripPolicyEligiblesConsumed = true;
                            continue;
                        }
                    }
                }
                var _businessTripPolicyEligibleDTO = _businessTripPolicyEligibleDTOList.Where(x => x.BusinessTripPolicyEligibleID == common.PrimaryKeyID).FirstOrDefault();
                var result = new BusinessTripPolicyEligibleViewModel
                {
                    BusinessTripPolicyEligibles = _businessTripPolicyEligibleDTOList,
                    BusinessTripPolicyEligible = _businessTripPolicyEligibleDTO
                };
                return result;
            }
        }

        public async Task<BusinessTripPolicyEligibleViewModel> PrintBusinessTripPolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PrintPOL_BusinessTripPolicyEligibles";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@BusinessTripPolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _businessTripPolicyEligibleDTOList = new List<BusinessTripPolicyEligibleDTO>();
            bool _isBusinessTripPolicyEligiblesConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var businessTripPolicyEligibleData = objTemp.Where(c => c.TableName == "POL_BusinessTripPolicyEligibles");
                        if (businessTripPolicyEligibleData.Count() > 0 && !_isBusinessTripPolicyEligiblesConsumed)
                        {
                            _businessTripPolicyEligibleDTOList = _mapper.Map<List<BusinessTripPolicyEligibleDTO>>(businessTripPolicyEligibleData);
                            _isBusinessTripPolicyEligiblesConsumed = true;
                            continue;
                        }
                    }
                }
                var _businessTripPolicyEligibleDTO = _businessTripPolicyEligibleDTOList.Where(x => x.BusinessTripPolicyEligibleID == common.PrimaryKeyID).FirstOrDefault();
                var result = new BusinessTripPolicyEligibleViewModel
                {
                    BusinessTripPolicyEligibles = _businessTripPolicyEligibleDTOList,
                    BusinessTripPolicyEligible = _businessTripPolicyEligibleDTO
                };
                return result;
            }
        }

        public async Task<BeanzResponseDTO> ApproveBusinessTripPolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.ApprovePOL_BusinessTripPolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@BusinessTripPolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID },
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
