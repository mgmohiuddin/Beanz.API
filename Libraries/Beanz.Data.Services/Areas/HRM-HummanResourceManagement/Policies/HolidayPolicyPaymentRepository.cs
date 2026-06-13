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
    public class HolidayPolicyPaymentRepository : IHolidayPolicyPaymentRepository
    {
        private readonly IMapper _mapper;

        public HolidayPolicyPaymentRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<HolidayPolicyPaymentDTO>> GetHolidayPolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetPOL_HolidayPolicyPayments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@HolidayPolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<HolidayPolicyPaymentDTO>(_sql, _parameters);
            return data;
        }

        public async Task<BeanzResponseDTO> SetHolidayPolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.SetPOL_HolidayPolicyPayments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@Json", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@HolidayPolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> PostHolidayPolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PostPOL_HolidayPolicyPayments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@HolidayPolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> DelHolidayPolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.DelPOL_HolidayPolicyPayments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@HolidayPolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<List<BeanzlookupDTO>> LookUpHolidayPolicyPaymentsAsync(BeanzCommonDTO lookup)
        {
            string _sql = "hrms.LookupPOL_HolidayPolicyPayments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = lookup.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = lookup.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = lookup.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = lookup.LanguageID },
                new SqlParameter("@HolidayPolicyPaymentID", SqlDbType.Int) { Value = lookup.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<BeanzlookupDTO>(_sql, _parameters);
            return data;
        }

        public async Task<HolidayPolicyPaymentViewModel> GetInfoHolidayPolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetInfoPOL_HolidayPolicyPayments";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@HolidayPolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _holidayPolicyPaymentDTOList = new List<HolidayPolicyPaymentDTO>();
            bool _isHolidayPolicyPaymentsConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var holidayPolicyPaymentData = objTemp.Where(c => c.TableName == "POL_HolidayPolicyPayments");
                        if (holidayPolicyPaymentData.Count() > 0 && !_isHolidayPolicyPaymentsConsumed)
                        {
                            _holidayPolicyPaymentDTOList = _mapper.Map<List<HolidayPolicyPaymentDTO>>(holidayPolicyPaymentData);
                            _isHolidayPolicyPaymentsConsumed = true;
                            continue;
                        }
                    }
                }
                var _holidayPolicyPaymentDTO = _holidayPolicyPaymentDTOList.Where(x => x.HolidayPolicyPaymentID == common.PrimaryKeyID).FirstOrDefault();
                var result = new HolidayPolicyPaymentViewModel
                {
                    HolidayPolicyPayments = _holidayPolicyPaymentDTOList,
                    HolidayPolicyPayment = _holidayPolicyPaymentDTO
                };
                return result;
            }
        }

        public async Task<HolidayPolicyPaymentViewModel> PrintHolidayPolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PrintPOL_HolidayPolicyPayments";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@HolidayPolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _holidayPolicyPaymentDTOList = new List<HolidayPolicyPaymentDTO>();
            bool _isHolidayPolicyPaymentsConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var holidayPolicyPaymentData = objTemp.Where(c => c.TableName == "POL_HolidayPolicyPayments");
                        if (holidayPolicyPaymentData.Count() > 0 && !_isHolidayPolicyPaymentsConsumed)
                        {
                            _holidayPolicyPaymentDTOList = _mapper.Map<List<HolidayPolicyPaymentDTO>>(holidayPolicyPaymentData);
                            _isHolidayPolicyPaymentsConsumed = true;
                            continue;
                        }
                    }
                }
                var _holidayPolicyPaymentDTO = _holidayPolicyPaymentDTOList.Where(x => x.HolidayPolicyPaymentID == common.PrimaryKeyID).FirstOrDefault();
                var result = new HolidayPolicyPaymentViewModel
                {
                    HolidayPolicyPayments = _holidayPolicyPaymentDTOList,
                    HolidayPolicyPayment = _holidayPolicyPaymentDTO
                };
                return result;
            }
        }

        public async Task<BeanzResponseDTO> ApproveHolidayPolicyPaymentsAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.ApprovePOL_HolidayPolicyPayments";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@HolidayPolicyPaymentID", SqlDbType.Int) { Value = common.PrimaryKeyID },
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
