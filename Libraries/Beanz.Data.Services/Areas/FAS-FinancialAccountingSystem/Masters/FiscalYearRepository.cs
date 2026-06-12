using AutoMapper;
using Beanz.Core.Areas.FinancialAccountingSystem.Masters;
using Beanz.Data.Services.DataAccessLayer;
using Beanz.Data.Services.DataAccessLayer.DAL;
using Beanz.DTOs.Areas;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Masters;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Beanz.Data.Services.Areas.FinancialAccountingSystem.Masters
{
    public class FiscalYearRepository : IFiscalYearRepository
    {
        private readonly IMapper _mapper;

        public FiscalYearRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<FiscalYearDTO>> GetFiscalYearsAsync(BeanzCommonDTO common)
        {
            string _sql = "fas.GetMS_FiscalYears";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@FiscalYearID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<FiscalYearDTO>(_sql, _parameters);
            return data;
        }

        public async Task<BeanzResponseDTO> SetFiscalYearsAsync(BeanzCommonDTO common)
        {
            string _sql = "fas.SetMS_FiscalYears";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@Json", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@FiscalYearID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> PostFiscalYearsAsync(BeanzCommonDTO common)
        {
            string _sql = "fas.PostMS_FiscalYears";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@FiscalYearID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> DelFiscalYearsAsync(BeanzCommonDTO common)
        {
            string _sql = "fas.DelMS_FiscalYears";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@FiscalYearID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<List<BeanzlookupDTO>> LookUpFiscalYearsAsync(BeanzCommonDTO lookup)
        {
            string _sql = "fas.LookupMS_FiscalYears";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = lookup.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = lookup.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = lookup.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = lookup.LanguageID },
                new SqlParameter("@FiscalYearID", SqlDbType.Int) { Value = lookup.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<BeanzlookupDTO>(_sql, _parameters);
            return data;
        }

        public async Task<FiscalYearViewModel> GetInfoFiscalYearsAsync(BeanzCommonDTO common)
        {
            string _sql = "fas.GetInfoMS_FiscalYears";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@FiscalYearID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _fiscalYearDTOList = new List<FiscalYearDTO>();
            bool _isFiscalYearsConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var fiscalYearData = objTemp.Where(c => c.TableName == "MS_FiscalYears");
                        if (fiscalYearData.Count() > 0 && !_isFiscalYearsConsumed)
                        {
                            _fiscalYearDTOList = _mapper.Map<List<FiscalYearDTO>>(fiscalYearData);
                            _isFiscalYearsConsumed = true;
                            continue;
                        }
                    }
                }
                var _fiscalYearDTO = _fiscalYearDTOList.Where(x => x.FiscalYearID == common.PrimaryKeyID).FirstOrDefault();
                var result = new FiscalYearViewModel
                {
                    FiscalYears = _fiscalYearDTOList,
                    FiscalYear = _fiscalYearDTO
                };
                return result;
            }
        }

        public async Task<FiscalYearViewModel> PrintFiscalYearsAsync(BeanzCommonDTO common)
        {
            string _sql = "fas.PrintMS_FiscalYears";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@FiscalYearID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _fiscalYearDTOList = new List<FiscalYearDTO>();
            bool _isFiscalYearsConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var fiscalYearData = objTemp.Where(c => c.TableName == "MS_FiscalYears");
                        if (fiscalYearData.Count() > 0 && !_isFiscalYearsConsumed)
                        {
                            _fiscalYearDTOList = _mapper.Map<List<FiscalYearDTO>>(fiscalYearData);
                            _isFiscalYearsConsumed = true;
                            continue;
                        }
                    }
                }
                var _fiscalYearDTO = _fiscalYearDTOList.Where(x => x.FiscalYearID == common.PrimaryKeyID).FirstOrDefault();
                var result = new FiscalYearViewModel
                {
                    FiscalYears = _fiscalYearDTOList,
                    FiscalYear = _fiscalYearDTO
                };
                return result;
            }
        }

        public async Task<BeanzResponseDTO> ApproveFiscalYearsAsync(BeanzCommonDTO common)
        {
            string _sql = "fas.ApproveMS_FiscalYears";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@FiscalYearID", SqlDbType.Int) { Value = common.PrimaryKeyID },
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
