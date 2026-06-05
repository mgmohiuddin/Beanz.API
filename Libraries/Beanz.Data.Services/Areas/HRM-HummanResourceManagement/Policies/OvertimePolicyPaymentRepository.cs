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
    public class OvertimePolicyPaymentRepository : IOvertimePolicyPaymentRepository
    {
        private readonly IMapper _mapper;

        public OvertimePolicyPaymentRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<OvertimePolicyPaymentDTO>> GetOvertimePolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetPOL_OvertimePolicyPayments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@OvertimePolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<OvertimePolicyPaymentDTO>(_sql, _parameters);
            return data;
        }

        public async Task<BeanzResponseDTO> SetOvertimePolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.SetPOL_OvertimePolicyPayments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@Json", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@OvertimePolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> PostOvertimePolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PostPOL_OvertimePolicyPayments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@OvertimePolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> DelOvertimePolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.DelPOL_OvertimePolicyPayments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@OvertimePolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<List<BeanzlookupDTO>> LookUpOvertimePolicyPaymentsAsync(BeanzCommonDTO lookup)
        {
            string _sql = "hrms.LookupPOL_OvertimePolicyPayments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = lookup.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = lookup.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = lookup.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = lookup.LanguageID },
                new SqlParameter("@OvertimePolicyPaymentID", SqlDbType.Int) { Value = lookup.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<BeanzlookupDTO>(_sql, _parameters);
            return data;
        }

        public async Task<OvertimePolicyPaymentViewModel> GetInfoOvertimePolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetInfoPOL_OvertimePolicyPayments";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@OvertimePolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _overtimePolicyPaymentDTOList = new List<OvertimePolicyPaymentDTO>();
            bool _isOvertimePolicyPaymentsConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var overtimePolicyPaymentData = objTemp.Where(c => c.TableName == "POL_OvertimePolicyPayments");
                        if (overtimePolicyPaymentData.Count() > 0 && !_isOvertimePolicyPaymentsConsumed)
                        {
                            _overtimePolicyPaymentDTOList = _mapper.Map<List<OvertimePolicyPaymentDTO>>(overtimePolicyPaymentData);
                            _isOvertimePolicyPaymentsConsumed = true;
                            continue;
                        }
                    }
                }
                var _overtimePolicyPaymentDTO = _overtimePolicyPaymentDTOList.Where(x => x.OvertimePolicyPaymentID == common.PrimaryKeyID).FirstOrDefault();
                var result = new OvertimePolicyPaymentViewModel
                {
                    OvertimePolicyPayments = _overtimePolicyPaymentDTOList,
                    OvertimePolicyPayment = _overtimePolicyPaymentDTO
                };
                return result;
            }
        }

        public async Task<OvertimePolicyPaymentViewModel> PrintOvertimePolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PrintPOL_OvertimePolicyPayments";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@OvertimePolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _overtimePolicyPaymentDTOList = new List<OvertimePolicyPaymentDTO>();
            bool _isOvertimePolicyPaymentsConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var overtimePolicyPaymentData = objTemp.Where(c => c.TableName == "POL_OvertimePolicyPayments");
                        if (overtimePolicyPaymentData.Count() > 0 && !_isOvertimePolicyPaymentsConsumed)
                        {
                            _overtimePolicyPaymentDTOList = _mapper.Map<List<OvertimePolicyPaymentDTO>>(overtimePolicyPaymentData);
                            _isOvertimePolicyPaymentsConsumed = true;
                            continue;
                        }
                    }
                }
                var _overtimePolicyPaymentDTO = _overtimePolicyPaymentDTOList.Where(x => x.OvertimePolicyPaymentID == common.PrimaryKeyID).FirstOrDefault();
                var result = new OvertimePolicyPaymentViewModel
                {
                    OvertimePolicyPayments = _overtimePolicyPaymentDTOList,
                    OvertimePolicyPayment = _overtimePolicyPaymentDTO
                };
                return result;
            }
        }

        public async Task<BeanzResponseDTO> ApproveOvertimePolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.ApprovePOL_OvertimePolicyPayments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@OvertimePolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID },
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
