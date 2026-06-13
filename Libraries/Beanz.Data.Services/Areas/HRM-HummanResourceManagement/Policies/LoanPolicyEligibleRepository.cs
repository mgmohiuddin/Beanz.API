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
    public class LoanPolicyEligibleRepository : ILoanPolicyEligibleRepository
    {
        private readonly IMapper _mapper;

        public LoanPolicyEligibleRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<LoanPolicyEligibleDTO>> GetLoanPolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetPOL_LoanPolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@LoanPolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<LoanPolicyEligibleDTO>(_sql, _parameters);
            return data;
        }

        public async Task<BeanzResponseDTO> SetLoanPolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.SetPOL_LoanPolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@Json", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@LoanPolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> PostLoanPolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PostPOL_LoanPolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@LoanPolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<BeanzResponseDTO> DelLoanPolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.DelPOL_LoanPolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@LoanPolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID },
                new SqlParameter("@ResponseID", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorCode", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
            return await SQLDataAccessLayer.MultipleOutputBySpAsync<BeanzResponseDTO>(_sql, _parameters);
        }

        public async Task<List<BeanzlookupDTO>> LookUpLoanPolicyEligiblesAsync(BeanzCommonDTO lookup)
        {
            string _sql = "hrms.LookupPOL_LoanPolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = lookup.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = lookup.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = lookup.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = lookup.LanguageID },
                new SqlParameter("@LoanPolicyEligibleID", SqlDbType.Int) { Value = lookup.PrimaryKeyID }
            };
            var data = await DAL.GetObjectListWithParametersAsync<BeanzlookupDTO>(_sql, _parameters);
            return data;
        }

        public async Task<LoanPolicyEligibleViewModel> GetInfoLoanPolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.GetInfoPOL_LoanPolicyEligibles";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@LoanPolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _loanPolicyEligibleDTOList = new List<LoanPolicyEligibleDTO>();
            bool _isLoanPolicyEligiblesConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var loanPolicyEligibleData = objTemp.Where(c => c.TableName == "POL_LoanPolicyEligibles");
                        if (loanPolicyEligibleData.Count() > 0 && !_isLoanPolicyEligiblesConsumed)
                        {
                            _loanPolicyEligibleDTOList = _mapper.Map<List<LoanPolicyEligibleDTO>>(loanPolicyEligibleData);
                            _isLoanPolicyEligiblesConsumed = true;
                            continue;
                        }
                    }
                }
                var _loanPolicyEligibleDTO = _loanPolicyEligibleDTOList.Where(x => x.LoanPolicyEligibleID == common.PrimaryKeyID).FirstOrDefault();
                var result = new LoanPolicyEligibleViewModel
                {
                    LoanPolicyEligibles = _loanPolicyEligibleDTOList,
                    LoanPolicyEligible = _loanPolicyEligibleDTO
                };
                return result;
            }
        }

        public async Task<LoanPolicyEligibleViewModel> PrintLoanPolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.PrintPOL_LoanPolicyEligibles";
            SqlParameter[] paramList =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@JSon", SqlDbType.NVarChar) { Value = common.Json },
                new SqlParameter("@LoanPolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID }
            };

            DynamicParameters p = new DynamicParameters();
            foreach (var param in paramList)
            {
                p.Add(param.ParameterName, param.Value);
            }
            var _loanPolicyEligibleDTOList = new List<LoanPolicyEligibleDTO>();
            bool _isLoanPolicyEligiblesConsumed = false;
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
                {
                    while (!objRecord.IsConsumed)
                    {
                        var objTemp = objRecord.Read<dynamic>();
                        var loanPolicyEligibleData = objTemp.Where(c => c.TableName == "POL_LoanPolicyEligibles");
                        if (loanPolicyEligibleData.Count() > 0 && !_isLoanPolicyEligiblesConsumed)
                        {
                            _loanPolicyEligibleDTOList = _mapper.Map<List<LoanPolicyEligibleDTO>>(loanPolicyEligibleData);
                            _isLoanPolicyEligiblesConsumed = true;
                            continue;
                        }
                    }
                }
                var _loanPolicyEligibleDTO = _loanPolicyEligibleDTOList.Where(x => x.LoanPolicyEligibleID == common.PrimaryKeyID).FirstOrDefault();
                var result = new LoanPolicyEligibleViewModel
                {
                    LoanPolicyEligibles = _loanPolicyEligibleDTOList,
                    LoanPolicyEligible = _loanPolicyEligibleDTO
                };
                return result;
            }
        }

        public async Task<BeanzResponseDTO> ApproveLoanPolicyEligiblesAsync(BeanzCommonDTO common)
        {
            string _sql = "hrms.ApprovePOL_LoanPolicyEligibles";
            SqlParameter[] _parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = common.CompanyID },
                new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                new SqlParameter("@Type", SqlDbType.Int) { Value = common.Type },
                new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                new SqlParameter("@LoanPolicyEligibleID", SqlDbType.Int) { Value = common.PrimaryKeyID },
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
