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
    public class EndOfServicePolicyAllowanceRepository : IEndOfServicePolicyAllowanceRepository
    {
        private readonly IMapper _mapper;

        public EndOfServicePolicyAllowanceRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<EndOfServicePolicyAllowanceDTO>> GetEndOfServicePolicyAllowancesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetPOL_EndOfServicePolicyAllowances";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EndOfServicePolicyAllowanceID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<EndOfServicePolicyAllowanceDTO>(_sql, _parameters);
            return data;
        }

        public async Task<BeanzResponseDTO> SetEndOfServicePolicyAllowancesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.SetPOL_EndOfServicePolicyAllowances";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@Json", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EndOfServicePolicyAllowanceID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> PostEndOfServicePolicyAllowancesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PostPOL_EndOfServicePolicyAllowances";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@EndOfServicePolicyAllowanceID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> DelEndOfServicePolicyAllowancesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.DelPOL_EndOfServicePolicyAllowances";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@EndOfServicePolicyAllowanceID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<List<BeanzlookupDTO>> LookUpEndOfServicePolicyAllowancesAsync(BeanzCommonDTO lookup)
        {
            string _sql = "hrms.LookupPOL_EndOfServicePolicyAllowances";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = lookup.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = lookup.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = lookup.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = lookup.LanguageID },
                new SqlParameter("@EndOfServicePolicyAllowanceID", SqlDbType.Int) { Value = lookup.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<BeanzlookupDTO>(_sql, _parameters);
            return data;
        }

        public async Task<EndOfServicePolicyAllowanceViewModel> GetInfoEndOfServicePolicyAllowancesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetInfoPOL_EndOfServicePolicyAllowances";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EndOfServicePolicyAllowanceID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _endOfServicePolicyAllowanceDTOList = new List<EndOfServicePolicyAllowanceDTO>();
            bool _isEndOfServicePolicyAllowancesConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var endOfServicePolicyAllowanceData = objTemp.Where(c => c.TableName == "POL_EndOfServicePolicyAllowances");
                        if (endOfServicePolicyAllowanceData.Count() > 0 && !_isEndOfServicePolicyAllowancesConsumed)
                        {
                            _endOfServicePolicyAllowanceDTOList = _mapper.Map<List<EndOfServicePolicyAllowanceDTO>>(endOfServicePolicyAllowanceData);
                            _isEndOfServicePolicyAllowancesConsumed = true;
                            continue;
                        }
                    }
                }
                var _endOfServicePolicyAllowanceDTO = _endOfServicePolicyAllowanceDTOList.Where(x => x.EndOfServicePolicyAllowanceID == common.PrimaryKeyID).FirstOrDefault();
                var result = new EndOfServicePolicyAllowanceViewModel
                {
                    EndOfServicePolicyAllowances = _endOfServicePolicyAllowanceDTOList,
                    EndOfServicePolicyAllowance = _endOfServicePolicyAllowanceDTO
                };
                return result;
            }
        }

        public async Task<EndOfServicePolicyAllowanceViewModel> PrintEndOfServicePolicyAllowancesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PrintPOL_EndOfServicePolicyAllowances";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EndOfServicePolicyAllowanceID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _endOfServicePolicyAllowanceDTOList = new List<EndOfServicePolicyAllowanceDTO>();
            bool _isEndOfServicePolicyAllowancesConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var endOfServicePolicyAllowanceData = objTemp.Where(c => c.TableName == "POL_EndOfServicePolicyAllowances");
                        if (endOfServicePolicyAllowanceData.Count() > 0 && !_isEndOfServicePolicyAllowancesConsumed)
                        {
                            _endOfServicePolicyAllowanceDTOList = _mapper.Map<List<EndOfServicePolicyAllowanceDTO>>(endOfServicePolicyAllowanceData);
                            _isEndOfServicePolicyAllowancesConsumed = true;
                            continue;
                        }
                    }
                }
                var _endOfServicePolicyAllowanceDTO = _endOfServicePolicyAllowanceDTOList.Where(x => x.EndOfServicePolicyAllowanceID == common.PrimaryKeyID).FirstOrDefault();
                var result = new EndOfServicePolicyAllowanceViewModel
                {
                    EndOfServicePolicyAllowances = _endOfServicePolicyAllowanceDTOList,
                    EndOfServicePolicyAllowance = _endOfServicePolicyAllowanceDTO
                };
                return result;
            }
        }

        public async Task<BeanzResponseDTO> ApproveEndOfServicePolicyAllowancesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.ApprovePOL_EndOfServicePolicyAllowances";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@EndOfServicePolicyAllowanceID", SqlDbType.Int) { Value = common.PrimaryKeyID },
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
