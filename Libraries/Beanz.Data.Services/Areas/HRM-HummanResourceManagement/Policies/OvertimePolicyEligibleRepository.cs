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
    public class OvertimePolicyEligibleRepository : IOvertimePolicyEligibleRepository
    {
        private readonly IMapper _mapper;

        public OvertimePolicyEligibleRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<OvertimePolicyEligibleDTO>> GetOvertimePolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetPOL_OvertimePolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@OvertimePolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<OvertimePolicyEligibleDTO>(_sql, _parameters);
            return data;
        }

        public async Task<BeanzResponseDTO> SetOvertimePolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.SetPOL_OvertimePolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@Json", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@OvertimePolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> PostOvertimePolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PostPOL_OvertimePolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@OvertimePolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> DelOvertimePolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.DelPOL_OvertimePolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@OvertimePolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<List<BeanzlookupDTO>> LookUpOvertimePolicyEligiblesAsync(BeanzCommonDTO lookup)
        {
            string _sql = "hrms.LookupPOL_OvertimePolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = lookup.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = lookup.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = lookup.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = lookup.LanguageID },
                new SqlParameter("@OvertimePolicyEligibleID", SqlDbType.Int) { Value = lookup.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<BeanzlookupDTO>(_sql, _parameters);
            return data;
        }

        public async Task<OvertimePolicyEligibleViewModel> GetInfoOvertimePolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetInfoPOL_OvertimePolicyEligibles";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@OvertimePolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _overtimePolicyEligibleDTOList = new List<OvertimePolicyEligibleDTO>();
            bool _isOvertimePolicyEligiblesConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var overtimePolicyEligibleData = objTemp.Where(c => c.TableName == "POL_OvertimePolicyEligibles");
                        if (overtimePolicyEligibleData.Count() > 0 && !_isOvertimePolicyEligiblesConsumed)
                        {
                            _overtimePolicyEligibleDTOList = _mapper.Map<List<OvertimePolicyEligibleDTO>>(overtimePolicyEligibleData);
                            _isOvertimePolicyEligiblesConsumed = true;
                            continue;
                        }
                    }
                }
                var _overtimePolicyEligibleDTO = _overtimePolicyEligibleDTOList.Where(x => x.OvertimePolicyEligibleID == common.PrimaryKeyID).FirstOrDefault();
                var result = new OvertimePolicyEligibleViewModel
                {
                    OvertimePolicyEligibles = _overtimePolicyEligibleDTOList,
                    OvertimePolicyEligible = _overtimePolicyEligibleDTO
                };
                return result;
            }
        }

        public async Task<OvertimePolicyEligibleViewModel> PrintOvertimePolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PrintPOL_OvertimePolicyEligibles";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@OvertimePolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _overtimePolicyEligibleDTOList = new List<OvertimePolicyEligibleDTO>();
            bool _isOvertimePolicyEligiblesConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var overtimePolicyEligibleData = objTemp.Where(c => c.TableName == "POL_OvertimePolicyEligibles");
                        if (overtimePolicyEligibleData.Count() > 0 && !_isOvertimePolicyEligiblesConsumed)
                        {
                            _overtimePolicyEligibleDTOList = _mapper.Map<List<OvertimePolicyEligibleDTO>>(overtimePolicyEligibleData);
                            _isOvertimePolicyEligiblesConsumed = true;
                            continue;
                        }
                    }
                }
                var _overtimePolicyEligibleDTO = _overtimePolicyEligibleDTOList.Where(x => x.OvertimePolicyEligibleID == common.PrimaryKeyID).FirstOrDefault();
                var result = new OvertimePolicyEligibleViewModel
                {
                    OvertimePolicyEligibles = _overtimePolicyEligibleDTOList,
                    OvertimePolicyEligible = _overtimePolicyEligibleDTO
                };
                return result;
            }
        }

        public async Task<BeanzResponseDTO> ApproveOvertimePolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.ApprovePOL_OvertimePolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@OvertimePolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID },
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
