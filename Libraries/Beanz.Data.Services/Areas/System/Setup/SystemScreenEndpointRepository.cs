using AutoMapper;
using Beanz.Core.Areas.BeanzSystem.Setup;
using Beanz.Data.Services.DataAccessLayer;
using Beanz.Data.Services.DataAccessLayer.DAL;
using Beanz.DTOs.Areas;
using Beanz.DTOs.Areas.BeanzSystem.Setup;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Beanz.Data.Services.Areas.BeanzSystem.Setup
{
    public class SystemScreenEndpointRepository : ISystemScreenEndpointRepository
    {
        private readonly IMapper _mapper;

        public SystemScreenEndpointRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<SystemScreenEndpointDTO>> GetSystemScreenEndpointsAsync(BeanzCommonDTO common)
        {
            string _sql = "ses.GetSystemScreenEndpoints";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID }, 
                new SqlParameter("@PrimaryKeyID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<SystemScreenEndpointDTO>(_sql, _parameters);
            return data;
        }

        public async Task<BeanzResponseDTO> SetSystemScreenEndpointsAsync(BeanzCommonDTO common)
        {
            string _sql = "ses.SetSystemScreenEndpoints";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@Json", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@PrimaryKeyID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> PostSystemScreenEndpointsAsync(BeanzCommonDTO common)
        {
            string _sql = "ses.PostSystemScreenEndpoints";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@PrimaryKeyID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> DelSystemScreenEndpointsAsync(BeanzCommonDTO common)
        {
            string _sql = "ses.DelSystemScreenEndpoints";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@PrimaryKeyID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<List<BeanzlookupDTO>> LookUpSystemScreenEndpointsAsync(BeanzCommonDTO lookup)
        {
            string _sql = "ses.LookupSystemScreenEndpoints";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = lookup.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = lookup.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = lookup.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = lookup.LanguageID },
                new SqlParameter("@PrimaryKeyID", SqlDbType.Int) { Value = lookup.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<BeanzlookupDTO>(_sql, _parameters);
            return data;
        }

        public async Task<SystemScreenEndpointViewModel> GetInfoSystemScreenEndpointsAsync(BeanzCommonDTO common)
        {
            string _sql = "ses.GetInfoSystemScreenEndpoints";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@Json", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@PrimaryKeyID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _systemScreenEndpointDTOList = new List<SystemScreenEndpointDTO>();
            bool _isSystemScreenEndpointsConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var systemScreenEndpointData = objTemp.Where(c => c.TableName == "SystemScreenEndpoints");
                        if (systemScreenEndpointData.Count() > 0 && !_isSystemScreenEndpointsConsumed)
                        {
                            _systemScreenEndpointDTOList = _mapper.Map<List<SystemScreenEndpointDTO>>(systemScreenEndpointData);
                            _isSystemScreenEndpointsConsumed = true;
                            continue;
                        }
                    }
                }
                var _systemScreenEndpointDTO = _systemScreenEndpointDTOList.Where(x => x.SystemScreenEndpointID == common.PrimaryKeyID).FirstOrDefault();
                var result = new SystemScreenEndpointViewModel
                {
                    SystemScreenEndpoints = _systemScreenEndpointDTOList,
                    SystemScreenEndpoint = _systemScreenEndpointDTO
                };
                return result;
            }
        }

        public async Task<SystemScreenEndpointViewModel> PrintSystemScreenEndpointsAsync(BeanzCommonDTO common)
        {
            string _sql = "ses.PrintSystemScreenEndpoints";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@Json", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@PrimaryKeyID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _systemScreenEndpointDTOList = new List<SystemScreenEndpointDTO>();
            bool _isSystemScreenEndpointsConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var systemScreenEndpointData = objTemp.Where(c => c.TableName == "SystemScreenEndpoints");
                        if (systemScreenEndpointData.Count() > 0 && !_isSystemScreenEndpointsConsumed)
                        {
                            _systemScreenEndpointDTOList = _mapper.Map<List<SystemScreenEndpointDTO>>(systemScreenEndpointData);
                            _isSystemScreenEndpointsConsumed = true;
                            continue;
                        }
                    }
                }
                var _systemScreenEndpointDTO = _systemScreenEndpointDTOList.Where(x => x.SystemScreenEndpointID == common.PrimaryKeyID).FirstOrDefault();
                var result = new SystemScreenEndpointViewModel
                {
                    SystemScreenEndpoints = _systemScreenEndpointDTOList,
                    SystemScreenEndpoint = _systemScreenEndpointDTO
                };
                return result;
            }
        }

        public async Task<BeanzResponseDTO> ApproveSystemScreenEndpointsAsync(BeanzCommonDTO common)
        {
            string _sql = "ses.ApproveSystemScreenEndpoints";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@PrimaryKeyID", SqlDbType.Int) { Value = common.PrimaryKeyID },
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
