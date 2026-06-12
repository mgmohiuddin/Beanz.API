using AutoMapper;
using Beanz.Core.Areas.FinancialAccountingSystem.Accounts;
using Beanz.Data.Services.DataAccessLayer;
using Beanz.Data.Services.DataAccessLayer.DAL;
using Beanz.DTOs.Areas;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Accounts;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Beanz.Data.Services.Areas.FinancialAccountingSystem.Accounts
{
    public class ChartOfAccountCodeSettingRepository : IChartOfAccountCodeSettingRepository
    {
        private readonly IMapper _mapper;

        public ChartOfAccountCodeSettingRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<ChartOfAccountCodeSettingDTO>> GetChartOfAccountCodeSettingsAsync(BeanzCommonDTO common)
        {
            string _sql = "fas.GetACC_ChartOfAccountCodeSettings";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@ChartOfAccountCodeSettingID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<ChartOfAccountCodeSettingDTO>(_sql, _parameters);
            return data;
        }

        public async Task<BeanzResponseDTO> SetChartOfAccountCodeSettingsAsync(BeanzCommonDTO common)
        {
            string _sql = "fas.SetACC_ChartOfAccountCodeSettings";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@Json", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@ChartOfAccountCodeSettingID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> PostChartOfAccountCodeSettingsAsync(BeanzCommonDTO common)
        {
            string _sql = "fas.PostACC_ChartOfAccountCodeSettings";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@ChartOfAccountCodeSettingID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> DelChartOfAccountCodeSettingsAsync(BeanzCommonDTO common)
        {
            string _sql = "fas.DelACC_ChartOfAccountCodeSettings";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@ChartOfAccountCodeSettingID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<List<BeanzlookupDTO>> LookUpChartOfAccountCodeSettingsAsync(BeanzCommonDTO lookup)
        {
            string _sql = "fas.LookupACC_ChartOfAccountCodeSettings";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = lookup.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = lookup.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = lookup.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = lookup.LanguageID },
                new SqlParameter("@ChartOfAccountCodeSettingID", SqlDbType.Int) { Value = lookup.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<BeanzlookupDTO>(_sql, _parameters);
            return data;
        }

        public async Task<ChartOfAccountCodeSettingViewModel> GetInfoChartOfAccountCodeSettingsAsync(BeanzCommonDTO common)
        {
            string _sql = "fas.GetInfoACC_ChartOfAccountCodeSettings";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@ChartOfAccountCodeSettingID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _chartOfAccountCodeSettingDTOList = new List<ChartOfAccountCodeSettingDTO>();
            bool _isChartOfAccountCodeSettingsConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var chartOfAccountCodeSettingData = objTemp.Where(c => c.TableName == "ACC_ChartOfAccountCodeSettings");
                        if (chartOfAccountCodeSettingData.Count() > 0 && !_isChartOfAccountCodeSettingsConsumed)
                        {
                            _chartOfAccountCodeSettingDTOList = _mapper.Map<List<ChartOfAccountCodeSettingDTO>>(chartOfAccountCodeSettingData);
                            _isChartOfAccountCodeSettingsConsumed = true;
                            continue;
                        }
                    }
                }
                var _chartOfAccountCodeSettingDTO = _chartOfAccountCodeSettingDTOList.Where(x => x.ChartOfAccountCodeSettingID == common.PrimaryKeyID).FirstOrDefault();
                var result = new ChartOfAccountCodeSettingViewModel
                {
                    ChartOfAccountCodeSettings = _chartOfAccountCodeSettingDTOList,
                    ChartOfAccountCodeSetting = _chartOfAccountCodeSettingDTO
                };
                return result;
            }
        }

        public async Task<ChartOfAccountCodeSettingViewModel> PrintChartOfAccountCodeSettingsAsync(BeanzCommonDTO common)
        {
            string _sql = "fas.PrintACC_ChartOfAccountCodeSettings";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@ChartOfAccountCodeSettingID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _chartOfAccountCodeSettingDTOList = new List<ChartOfAccountCodeSettingDTO>();
            bool _isChartOfAccountCodeSettingsConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var chartOfAccountCodeSettingData = objTemp.Where(c => c.TableName == "ACC_ChartOfAccountCodeSettings");
                        if (chartOfAccountCodeSettingData.Count() > 0 && !_isChartOfAccountCodeSettingsConsumed)
                        {
                            _chartOfAccountCodeSettingDTOList = _mapper.Map<List<ChartOfAccountCodeSettingDTO>>(chartOfAccountCodeSettingData);
                            _isChartOfAccountCodeSettingsConsumed = true;
                            continue;
                        }
                    }
                }
                var _chartOfAccountCodeSettingDTO = _chartOfAccountCodeSettingDTOList.Where(x => x.ChartOfAccountCodeSettingID == common.PrimaryKeyID).FirstOrDefault();
                var result = new ChartOfAccountCodeSettingViewModel
                {
                    ChartOfAccountCodeSettings = _chartOfAccountCodeSettingDTOList,
                    ChartOfAccountCodeSetting = _chartOfAccountCodeSettingDTO
                };
                return result;
            }
        }

        public async Task<BeanzResponseDTO> ApproveChartOfAccountCodeSettingsAsync(BeanzCommonDTO common)
        {
            string _sql = "fas.ApproveACC_ChartOfAccountCodeSettings";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@ChartOfAccountCodeSettingID", SqlDbType.Int) { Value = common.PrimaryKeyID },
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
