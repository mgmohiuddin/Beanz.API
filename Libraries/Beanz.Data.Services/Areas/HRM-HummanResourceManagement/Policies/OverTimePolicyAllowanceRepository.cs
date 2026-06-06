using AutoMapper;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.Data.Services.DataAccessLayer;
using Beanz.Data.Services.DataAccessLayer.DAL;
using Beanz.DTOs.Areas;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Beanz.Data.Services.Areas.HummanResourceManagement.Policies
{
    public class OverTimePolicyAllowanceRepository : IOverTimePolicyAllowanceRepository
    {
        private readonly IMapper _mapper;

        public OverTimePolicyAllowanceRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<OverTimePolicyAllowanceDTO>> GetOverTimePolicyAllowancesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetPOL_OverTimePolicyAllowance";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@OverTimePolicyAllowanceID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<OverTimePolicyAllowanceDTO>(_sql, _parameters);
            return data;
        }

        public async Task<BeanzResponseDTO> SetOverTimePolicyAllowancesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.SetPOL_OverTimePolicyAllowance";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@Json", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@OverTimePolicyAllowanceID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> PostOverTimePolicyAllowancesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PostPOL_OverTimePolicyAllowance";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@OverTimePolicyAllowanceID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> DelOverTimePolicyAllowancesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.DelPOL_OverTimePolicyAllowance";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@OverTimePolicyAllowanceID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<List<BeanzlookupDTO>> LookUpOverTimePolicyAllowancesAsync(BeanzCommonDTO lookup)
        {
            string _sql = "hrms.LookupPOL_OverTimePolicyAllowance";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = lookup.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = lookup.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = lookup.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = lookup.LanguageID },
                new SqlParameter("@OverTimePolicyAllowanceID", SqlDbType.Int) { Value = lookup.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<BeanzlookupDTO>(_sql, _parameters);
            return data;
        }

        public async Task<OverTimePolicyAllowanceViewModel> GetInfoOverTimePolicyAllowancesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetInfoPOL_OverTimePolicyAllowance";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@OverTimePolicyAllowanceID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _overTimePolicyAllowanceDTOList = new List<OverTimePolicyAllowanceDTO>();
            bool _isOverTimePolicyAllowancesConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var overTimePolicyAllowanceData = objTemp.Where(c => c.TableName == "POL_OverTimePolicyAllowance");
                        if (overTimePolicyAllowanceData.Count() > 0 && !_isOverTimePolicyAllowancesConsumed)
                        {
                            _overTimePolicyAllowanceDTOList = _mapper.Map<List<OverTimePolicyAllowanceDTO>>(overTimePolicyAllowanceData);
                            _isOverTimePolicyAllowancesConsumed = true;
                            continue;
                        }
                    }
                }
                var _overTimePolicyAllowanceDTO = _overTimePolicyAllowanceDTOList.Where(x => x.OverTimePolicyAllowanceID == common.PrimaryKeyID).FirstOrDefault();
                var result = new OverTimePolicyAllowanceViewModel
                {
                    OverTimePolicyAllowances = _overTimePolicyAllowanceDTOList,
                    OverTimePolicyAllowance = _overTimePolicyAllowanceDTO
                };
                return result;
            }
        }

        public async Task<OverTimePolicyAllowanceViewModel> PrintOverTimePolicyAllowancesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PrintPOL_OverTimePolicyAllowance";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@OverTimePolicyAllowanceID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _overTimePolicyAllowanceDTOList = new List<OverTimePolicyAllowanceDTO>();
            bool _isOverTimePolicyAllowancesConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var overTimePolicyAllowanceData = objTemp.Where(c => c.TableName == "POL_OverTimePolicyAllowance");
                        if (overTimePolicyAllowanceData.Count() > 0 && !_isOverTimePolicyAllowancesConsumed)
                        {
                            _overTimePolicyAllowanceDTOList = _mapper.Map<List<OverTimePolicyAllowanceDTO>>(overTimePolicyAllowanceData);
                            _isOverTimePolicyAllowancesConsumed = true;
                            continue;
                        }
                    }
                }
                var _overTimePolicyAllowanceDTO = _overTimePolicyAllowanceDTOList.Where(x => x.OverTimePolicyAllowanceID == common.PrimaryKeyID).FirstOrDefault();
                var result = new OverTimePolicyAllowanceViewModel
                {
                    OverTimePolicyAllowances = _overTimePolicyAllowanceDTOList,
                    OverTimePolicyAllowance = _overTimePolicyAllowanceDTO
                };
                return result;
            }
        }

        public async Task<BeanzResponseDTO> ApproveOverTimePolicyAllowancesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.ApprovePOL_OverTimePolicyAllowance";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@OverTimePolicyAllowanceID", SqlDbType.Int) { Value = common.PrimaryKeyID },
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
