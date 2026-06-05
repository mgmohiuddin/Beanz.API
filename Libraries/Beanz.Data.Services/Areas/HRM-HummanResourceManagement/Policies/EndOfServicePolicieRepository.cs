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
    public class EndOfServicePolicieRepository : IEndOfServicePolicieRepository
    {
        private readonly IMapper _mapper;

        public EndOfServicePolicieRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<EndOfServicePolicieDTO>> GetEndOfServicePoliciesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetPOL_EndOfServicePolicies";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EndOfServicePolicieID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<EndOfServicePolicieDTO>(_sql, _parameters);
            return data;
        }

        public async Task<BeanzResponseDTO> SetEndOfServicePoliciesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.SetPOL_EndOfServicePolicies";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@Json", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EndOfServicePolicieID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> PostEndOfServicePoliciesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PostPOL_EndOfServicePolicies";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@EndOfServicePolicieID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> DelEndOfServicePoliciesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.DelPOL_EndOfServicePolicies";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@EndOfServicePolicieID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<List<BeanzlookupDTO>> LookUpEndOfServicePoliciesAsync(BeanzCommonDTO lookup)
        {
            string _sql = "hrms.LookupPOL_EndOfServicePolicies";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = lookup.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = lookup.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = lookup.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = lookup.LanguageID },
                new SqlParameter("@EndOfServicePolicieID", SqlDbType.Int) { Value = lookup.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<BeanzlookupDTO>(_sql, _parameters);
            return data;
        }

        public async Task<EndOfServicePolicieViewModel> GetInfoEndOfServicePoliciesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetInfoPOL_EndOfServicePolicies";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EndOfServicePolicieID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _endOfServicePolicieDTOList = new List<EndOfServicePolicieDTO>();
            bool _isEndOfServicePoliciesConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var endOfServicePolicieData = objTemp.Where(c => c.TableName == "POL_EndOfServicePolicies");
                        if (endOfServicePolicieData.Count() > 0 && !_isEndOfServicePoliciesConsumed)
                        {
                            _endOfServicePolicieDTOList = _mapper.Map<List<EndOfServicePolicieDTO>>(endOfServicePolicieData);
                            _isEndOfServicePoliciesConsumed = true;
                            continue;
                        }
                    }
                }
                var _endOfServicePolicieDTO = _endOfServicePolicieDTOList.Where(x => x.EndOfServicePolicieID == common.PrimaryKeyID).FirstOrDefault();
                var result = new EndOfServicePolicieViewModel
                {
                    EndOfServicePolicies = _endOfServicePolicieDTOList,
                    EndOfServicePolicie = _endOfServicePolicieDTO
                };
                return result;
            }
        }

        public async Task<EndOfServicePolicieViewModel> PrintEndOfServicePoliciesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PrintPOL_EndOfServicePolicies";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EndOfServicePolicieID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _endOfServicePolicieDTOList = new List<EndOfServicePolicieDTO>();
            bool _isEndOfServicePoliciesConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var endOfServicePolicieData = objTemp.Where(c => c.TableName == "POL_EndOfServicePolicies");
                        if (endOfServicePolicieData.Count() > 0 && !_isEndOfServicePoliciesConsumed)
                        {
                            _endOfServicePolicieDTOList = _mapper.Map<List<EndOfServicePolicieDTO>>(endOfServicePolicieData);
                            _isEndOfServicePoliciesConsumed = true;
                            continue;
                        }
                    }
                }
                var _endOfServicePolicieDTO = _endOfServicePolicieDTOList.Where(x => x.EndOfServicePolicieID == common.PrimaryKeyID).FirstOrDefault();
                var result = new EndOfServicePolicieViewModel
                {
                    EndOfServicePolicies = _endOfServicePolicieDTOList,
                    EndOfServicePolicie = _endOfServicePolicieDTO
                };
                return result;
            }
        }

        public async Task<BeanzResponseDTO> ApproveEndOfServicePoliciesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.ApprovePOL_EndOfServicePolicies";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@EndOfServicePolicieID", SqlDbType.Int) { Value = common.PrimaryKeyID },
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
