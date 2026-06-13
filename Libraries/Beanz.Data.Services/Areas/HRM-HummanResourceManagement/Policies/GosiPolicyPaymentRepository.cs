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
    public class GosiPolicyPaymentRepository : IGosiPolicyPaymentRepository
    {
        private readonly IMapper _mapper;

        public GosiPolicyPaymentRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<GosiPolicyPaymentDTO>> GetGosiPolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetPOL_GosiPolicyPayments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@GosiPolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<GosiPolicyPaymentDTO>(_sql, _parameters);
            return data;
        }

        public async Task<BeanzResponseDTO> SetGosiPolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.SetPOL_GosiPolicyPayments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@Json", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@GosiPolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> PostGosiPolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PostPOL_GosiPolicyPayments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@GosiPolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> DelGosiPolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.DelPOL_GosiPolicyPayments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@GosiPolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<List<BeanzlookupDTO>> LookUpGosiPolicyPaymentsAsync(BeanzCommonDTO lookup)
        {
            string _sql = "hrms.LookupPOL_GosiPolicyPayments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = lookup.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = lookup.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = lookup.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = lookup.LanguageID },
                new SqlParameter("@GosiPolicyPaymentID", SqlDbType.Int) { Value = lookup.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<BeanzlookupDTO>(_sql, _parameters);
            return data;
        }

        public async Task<GosiPolicyPaymentViewModel> GetInfoGosiPolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetInfoPOL_GosiPolicyPayments";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@GosiPolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _gosiPolicyPaymentDTOList = new List<GosiPolicyPaymentDTO>();
            bool _isGosiPolicyPaymentsConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var gosiPolicyPaymentData = objTemp.Where(c => c.TableName == "POL_GosiPolicyPayments");
                        if (gosiPolicyPaymentData.Count() > 0 && !_isGosiPolicyPaymentsConsumed)
                        {
                            _gosiPolicyPaymentDTOList = _mapper.Map<List<GosiPolicyPaymentDTO>>(gosiPolicyPaymentData);
                            _isGosiPolicyPaymentsConsumed = true;
                            continue;
                        }
                    }
                }
                var _gosiPolicyPaymentDTO = _gosiPolicyPaymentDTOList.Where(x => x.GosiPolicyPaymentID == common.PrimaryKeyID).FirstOrDefault();
                var result = new GosiPolicyPaymentViewModel
                {
                    GosiPolicyPayments = _gosiPolicyPaymentDTOList,
                    GosiPolicyPayment = _gosiPolicyPaymentDTO
                };
                return result;
            }
        }

        public async Task<GosiPolicyPaymentViewModel> PrintGosiPolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PrintPOL_GosiPolicyPayments";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@GosiPolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _gosiPolicyPaymentDTOList = new List<GosiPolicyPaymentDTO>();
            bool _isGosiPolicyPaymentsConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var gosiPolicyPaymentData = objTemp.Where(c => c.TableName == "POL_GosiPolicyPayments");
                        if (gosiPolicyPaymentData.Count() > 0 && !_isGosiPolicyPaymentsConsumed)
                        {
                            _gosiPolicyPaymentDTOList = _mapper.Map<List<GosiPolicyPaymentDTO>>(gosiPolicyPaymentData);
                            _isGosiPolicyPaymentsConsumed = true;
                            continue;
                        }
                    }
                }
                var _gosiPolicyPaymentDTO = _gosiPolicyPaymentDTOList.Where(x => x.GosiPolicyPaymentID == common.PrimaryKeyID).FirstOrDefault();
                var result = new GosiPolicyPaymentViewModel
                {
                    GosiPolicyPayments = _gosiPolicyPaymentDTOList,
                    GosiPolicyPayment = _gosiPolicyPaymentDTO
                };
                return result;
            }
        }

        public async Task<BeanzResponseDTO> ApproveGosiPolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.ApprovePOL_GosiPolicyPayments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@GosiPolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID },
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
