using AutoMapper;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.Data.Services.DataAccessLayer;
using Beanz.Data.Services.DataAccessLayer.DAL;
using Beanz.DTOs.Areas;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Beanz.Data.Services.Areas.HummanResourceManagement.Masters
{
    public class AdvanceSalaryTypeRepository : IAdvanceSalaryTypeRepository
    {
        private readonly IMapper _mapper;

        public AdvanceSalaryTypeRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<AdvanceSalaryTypeDTO>> GetAdvanceSalaryTypesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetMS_AdvanceSalaryTypes";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@AdvanceSalaryTypeID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<AdvanceSalaryTypeDTO>(_sql, _parameters);
            return data;
        }

        public async Task<BeanzResponseDTO> SetAdvanceSalaryTypesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.SetMS_AdvanceSalaryTypes";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@Json", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@AdvanceSalaryTypeID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> PostAdvanceSalaryTypesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PostMS_AdvanceSalaryTypes";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@AdvanceSalaryTypeID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> DelAdvanceSalaryTypesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.DelMS_AdvanceSalaryTypes";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@AdvanceSalaryTypeID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<List<BeanzlookupDTO>> LookUpAdvanceSalaryTypesAsync(BeanzCommonDTO lookup)
        {
            string _sql = "hrms.LookupMS_AdvanceSalaryTypes";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = lookup.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = lookup.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = lookup.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = lookup.LanguageID },
                new SqlParameter("@AdvanceSalaryTypeID", SqlDbType.Int) { Value = lookup.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<BeanzlookupDTO>(_sql, _parameters);
            return data;
        }

        public async Task<AdvanceSalaryTypeViewModel> GetInfoAdvanceSalaryTypesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetInfoMS_AdvanceSalaryTypes";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@AdvanceSalaryTypeID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _advanceSalaryTypeDTOList = new List<AdvanceSalaryTypeDTO>();
            bool _isAdvanceSalaryTypesConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var advanceSalaryTypeData = objTemp.Where(c => c.TableName == "MS_AdvanceSalaryTypes");
                        if (advanceSalaryTypeData.Count() > 0 && !_isAdvanceSalaryTypesConsumed)
                        {
                            _advanceSalaryTypeDTOList = _mapper.Map<List<AdvanceSalaryTypeDTO>>(advanceSalaryTypeData);
                            _isAdvanceSalaryTypesConsumed = true;
                            continue;
                        }
                    }
                }
                var _advanceSalaryTypeDTO = _advanceSalaryTypeDTOList.Where(x => x.AdvanceSalaryTypeID == common.PrimaryKeyID).FirstOrDefault();
                var result = new AdvanceSalaryTypeViewModel
                {
                    AdvanceSalaryTypes = _advanceSalaryTypeDTOList,
                    AdvanceSalaryType = _advanceSalaryTypeDTO
                };
                return result;
            }
        }

        public async Task<AdvanceSalaryTypeViewModel> PrintAdvanceSalaryTypesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PrintMS_AdvanceSalaryTypes";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@AdvanceSalaryTypeID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _advanceSalaryTypeDTOList = new List<AdvanceSalaryTypeDTO>();
            bool _isAdvanceSalaryTypesConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var advanceSalaryTypeData = objTemp.Where(c => c.TableName == "MS_AdvanceSalaryTypes");
                        if (advanceSalaryTypeData.Count() > 0 && !_isAdvanceSalaryTypesConsumed)
                        {
                            _advanceSalaryTypeDTOList = _mapper.Map<List<AdvanceSalaryTypeDTO>>(advanceSalaryTypeData);
                            _isAdvanceSalaryTypesConsumed = true;
                            continue;
                        }
                    }
                }
                var _advanceSalaryTypeDTO = _advanceSalaryTypeDTOList.Where(x => x.AdvanceSalaryTypeID == common.PrimaryKeyID).FirstOrDefault();
                var result = new AdvanceSalaryTypeViewModel
                {
                    AdvanceSalaryTypes = _advanceSalaryTypeDTOList,
                    AdvanceSalaryType = _advanceSalaryTypeDTO
                };
                return result;
            }
        }

        public async Task<BeanzResponseDTO> ApproveAdvanceSalaryTypesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.ApproveMS_AdvanceSalaryTypes";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@AdvanceSalaryTypeID", SqlDbType.Int) { Value = common.PrimaryKeyID },
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
