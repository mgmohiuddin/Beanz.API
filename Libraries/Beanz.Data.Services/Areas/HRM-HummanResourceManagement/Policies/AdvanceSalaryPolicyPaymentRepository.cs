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
    public class AdvanceSalaryPolicyPaymentRepository : IAdvanceSalaryPolicyPaymentRepository
    {
        private readonly IMapper _mapper;

        public AdvanceSalaryPolicyPaymentRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<AdvanceSalaryPolicyPaymentDTO>> GetAdvanceSalaryPolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetPOL_AdvanceSalaryPolicyPayments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@AdvanceSalaryPolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<AdvanceSalaryPolicyPaymentDTO>(_sql, _parameters);
            return data;
        }

        public async Task<BeanzResponseDTO> SetAdvanceSalaryPolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.SetPOL_AdvanceSalaryPolicyPayments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@Json", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@AdvanceSalaryPolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> PostAdvanceSalaryPolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PostPOL_AdvanceSalaryPolicyPayments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@AdvanceSalaryPolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> DelAdvanceSalaryPolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.DelPOL_AdvanceSalaryPolicyPayments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@AdvanceSalaryPolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<List<BeanzlookupDTO>> LookUpAdvanceSalaryPolicyPaymentsAsync(BeanzCommonDTO lookup)
        {
            string _sql = "hrms.LookupPOL_AdvanceSalaryPolicyPayments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = lookup.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = lookup.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = lookup.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = lookup.LanguageID },
                new SqlParameter("@AdvanceSalaryPolicyPaymentID", SqlDbType.Int) { Value = lookup.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<BeanzlookupDTO>(_sql, _parameters);
            return data;
        }

        public async Task<AdvanceSalaryPolicyPaymentViewModel> GetInfoAdvanceSalaryPolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetInfoPOL_AdvanceSalaryPolicyPayments";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@AdvanceSalaryPolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _advanceSalaryPolicyPaymentDTOList = new List<AdvanceSalaryPolicyPaymentDTO>();
            bool _isAdvanceSalaryPolicyPaymentsConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var advanceSalaryPolicyPaymentData = objTemp.Where(c => c.TableName == "POL_AdvanceSalaryPolicyPayments");
                        if (advanceSalaryPolicyPaymentData.Count() > 0 && !_isAdvanceSalaryPolicyPaymentsConsumed)
                        {
                            _advanceSalaryPolicyPaymentDTOList = _mapper.Map<List<AdvanceSalaryPolicyPaymentDTO>>(advanceSalaryPolicyPaymentData);
                            _isAdvanceSalaryPolicyPaymentsConsumed = true;
                            continue;
                        }
                    }
                }
                var _advanceSalaryPolicyPaymentDTO = _advanceSalaryPolicyPaymentDTOList.Where(x => x.AdvanceSalaryPolicyPaymentID == common.PrimaryKeyID).FirstOrDefault();
                var result = new AdvanceSalaryPolicyPaymentViewModel
                {
                    AdvanceSalaryPolicyPayments = _advanceSalaryPolicyPaymentDTOList,
                    AdvanceSalaryPolicyPayment = _advanceSalaryPolicyPaymentDTO
                };
                return result;
            }
        }

        public async Task<AdvanceSalaryPolicyPaymentViewModel> PrintAdvanceSalaryPolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PrintPOL_AdvanceSalaryPolicyPayments";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@AdvanceSalaryPolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _advanceSalaryPolicyPaymentDTOList = new List<AdvanceSalaryPolicyPaymentDTO>();
            bool _isAdvanceSalaryPolicyPaymentsConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var advanceSalaryPolicyPaymentData = objTemp.Where(c => c.TableName == "POL_AdvanceSalaryPolicyPayments");
                        if (advanceSalaryPolicyPaymentData.Count() > 0 && !_isAdvanceSalaryPolicyPaymentsConsumed)
                        {
                            _advanceSalaryPolicyPaymentDTOList = _mapper.Map<List<AdvanceSalaryPolicyPaymentDTO>>(advanceSalaryPolicyPaymentData);
                            _isAdvanceSalaryPolicyPaymentsConsumed = true;
                            continue;
                        }
                    }
                }
                var _advanceSalaryPolicyPaymentDTO = _advanceSalaryPolicyPaymentDTOList.Where(x => x.AdvanceSalaryPolicyPaymentID == common.PrimaryKeyID).FirstOrDefault();
                var result = new AdvanceSalaryPolicyPaymentViewModel
                {
                    AdvanceSalaryPolicyPayments = _advanceSalaryPolicyPaymentDTOList,
                    AdvanceSalaryPolicyPayment = _advanceSalaryPolicyPaymentDTO
                };
                return result;
            }
        }

        public async Task<BeanzResponseDTO> ApproveAdvanceSalaryPolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.ApprovePOL_AdvanceSalaryPolicyPayments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@AdvanceSalaryPolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID },
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
