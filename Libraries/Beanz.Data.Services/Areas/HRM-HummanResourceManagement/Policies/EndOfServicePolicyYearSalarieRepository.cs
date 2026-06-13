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
    public class EndOfServicePolicyYearSalarieRepository : IEndOfServicePolicyYearSalarieRepository
    {
        private readonly IMapper _mapper;

        public EndOfServicePolicyYearSalarieRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<EndOfServicePolicyYearSalarieDTO>> GetEndOfServicePolicyYearSalariesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetPOL_EndOfServicePolicyYearSalaries";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EndOfServicePolicyYearSalarieID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<EndOfServicePolicyYearSalarieDTO>(_sql, _parameters);
            return data;
        }

        public async Task<BeanzResponseDTO> SetEndOfServicePolicyYearSalariesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.SetPOL_EndOfServicePolicyYearSalaries";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@Json", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EndOfServicePolicyYearSalarieID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> PostEndOfServicePolicyYearSalariesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PostPOL_EndOfServicePolicyYearSalaries";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@EndOfServicePolicyYearSalarieID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> DelEndOfServicePolicyYearSalariesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.DelPOL_EndOfServicePolicyYearSalaries";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@EndOfServicePolicyYearSalarieID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<List<BeanzlookupDTO>> LookUpEndOfServicePolicyYearSalariesAsync(BeanzCommonDTO lookup)
        {
            string _sql = "hrms.LookupPOL_EndOfServicePolicyYearSalaries";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = lookup.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = lookup.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = lookup.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = lookup.LanguageID },
                new SqlParameter("@EndOfServicePolicyYearSalarieID", SqlDbType.Int) { Value = lookup.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<BeanzlookupDTO>(_sql, _parameters);
            return data;
        }

        public async Task<EndOfServicePolicyYearSalarieViewModel> GetInfoEndOfServicePolicyYearSalariesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetInfoPOL_EndOfServicePolicyYearSalaries";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EndOfServicePolicyYearSalarieID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _endOfServicePolicyYearSalarieDTOList = new List<EndOfServicePolicyYearSalarieDTO>();
            bool _isEndOfServicePolicyYearSalariesConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var endOfServicePolicyYearSalarieData = objTemp.Where(c => c.TableName == "POL_EndOfServicePolicyYearSalaries");
                        if (endOfServicePolicyYearSalarieData.Count() > 0 && !_isEndOfServicePolicyYearSalariesConsumed)
                        {
                            _endOfServicePolicyYearSalarieDTOList = _mapper.Map<List<EndOfServicePolicyYearSalarieDTO>>(endOfServicePolicyYearSalarieData);
                            _isEndOfServicePolicyYearSalariesConsumed = true;
                            continue;
                        }
                    }
                }
                var _endOfServicePolicyYearSalarieDTO = _endOfServicePolicyYearSalarieDTOList.Where(x => x.EndOfServicePolicyYearSalarieID == common.PrimaryKeyID).FirstOrDefault();
                var result = new EndOfServicePolicyYearSalarieViewModel
                {
                    EndOfServicePolicyYearSalaries = _endOfServicePolicyYearSalarieDTOList,
                    EndOfServicePolicyYearSalarie = _endOfServicePolicyYearSalarieDTO
                };
                return result;
            }
        }

        public async Task<EndOfServicePolicyYearSalarieViewModel> PrintEndOfServicePolicyYearSalariesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PrintPOL_EndOfServicePolicyYearSalaries";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@EndOfServicePolicyYearSalarieID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _endOfServicePolicyYearSalarieDTOList = new List<EndOfServicePolicyYearSalarieDTO>();
            bool _isEndOfServicePolicyYearSalariesConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var endOfServicePolicyYearSalarieData = objTemp.Where(c => c.TableName == "POL_EndOfServicePolicyYearSalaries");
                        if (endOfServicePolicyYearSalarieData.Count() > 0 && !_isEndOfServicePolicyYearSalariesConsumed)
                        {
                            _endOfServicePolicyYearSalarieDTOList = _mapper.Map<List<EndOfServicePolicyYearSalarieDTO>>(endOfServicePolicyYearSalarieData);
                            _isEndOfServicePolicyYearSalariesConsumed = true;
                            continue;
                        }
                    }
                }
                var _endOfServicePolicyYearSalarieDTO = _endOfServicePolicyYearSalarieDTOList.Where(x => x.EndOfServicePolicyYearSalarieID == common.PrimaryKeyID).FirstOrDefault();
                var result = new EndOfServicePolicyYearSalarieViewModel
                {
                    EndOfServicePolicyYearSalaries = _endOfServicePolicyYearSalarieDTOList,
                    EndOfServicePolicyYearSalarie = _endOfServicePolicyYearSalarieDTO
                };
                return result;
            }
        }

        public async Task<BeanzResponseDTO> ApproveEndOfServicePolicyYearSalariesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.ApprovePOL_EndOfServicePolicyYearSalaries";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@EndOfServicePolicyYearSalarieID", SqlDbType.Int) { Value = common.PrimaryKeyID },
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
