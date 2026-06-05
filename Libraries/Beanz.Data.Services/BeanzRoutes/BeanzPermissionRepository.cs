using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using Beanz.DTOs.Common;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System;
//using Beanz.DTOs.FinancialAccountingSystem.Masters;
//using Beanz.Core.FinancialAccountingSystem.Masters;
//using Beanz.DTOs.FinancialAccountingSystem.Masters.Objects;
using Beanz.Core.BeanzRoutes;
using Beanz.DTOs.BeanzRoutes;
using Beanz.Data.Services.DataAccessLayer.DAL;
using Beanz.DTOs.BeanzCommon;

namespace Beanz.Data.Services.BeanzRoutes
{
      
        public class BeanzPermissionRepository : IBeanzPermissionRepository
        {

            private readonly IMapper _mapper;

            public BeanzPermissionRepository(IMapper mapper)
            {
                _mapper = mapper;
            }

            public async Task<List<BeanzPermissionDTO>> GetBeanzPermissionsAsync(BeanzRequestDTO common)
            {
                string _sql = "sec.GetUserRoutePermission";
            SqlParameter[] _parameters =
                {
                new SqlParameter("@CompanyID", SqlDbType.Int)
                {Value =common.CompanyID },

                new SqlParameter("@UserID", SqlDbType.Int)
                {Value =common.UserID },

                new SqlParameter("@LanguageID", SqlDbType.Int)
                {Value =common.LanguageID },

                new SqlParameter("@system", SqlDbType.NVarChar)
                {Value =common.system },

                new SqlParameter("@area", SqlDbType.NVarChar)
                {Value =common.area },

                new SqlParameter("@module", SqlDbType.NVarChar)
                {Value =common.module },

                new SqlParameter("@Action", SqlDbType.NVarChar)
                {Value =common.Action }
                };                

                var BeanzPermission = await DAL.GetObjectListWithParametersAsync<BeanzPermissionDTO>(_sql, _parameters);
                return BeanzPermission;
            }

            public async Task<string> SetBeanzPermissionsAsync(BeanzPermissionDTO common)
            {
                string _sql = "fas.SetMS_Accounts";

                SqlParameter[] _parameters =
                {

                new SqlParameter("@CompanyID", SqlDbType.Int)
                {Value =common.CompanyID },

                new SqlParameter("@UserID", SqlDbType.Int)
                {Value =common.UserID },

                new SqlParameter("@AccountID", SqlDbType.Int)
                {Value =common.PrimaryKeyID },

                new SqlParameter("@Json", SqlDbType.NVarChar)
                {Value =common.Json },

                new SqlParameter("@ReturnValue", SqlDbType.NVarChar)
                { Direction = ParameterDirection.Output }

            };
                string result = await DAL.ExecuteSetWithSingleOutputParametersAsync(_sql, "@ReturnValue", _parameters);
                return result;
            }

            public async Task<string> DelBeanzPermissionsAsync(BeanzPermissionDTO common)
            {
                string _sql = "fas.DelMS_Accounts";
                SqlParameter[] _parameters =
                {

                new SqlParameter("@CompanyID", SqlDbType.Int)
                {Value =common.CompanyID },

                new SqlParameter("@UserID", SqlDbType.Int)
                {Value =common.UserID },

                new SqlParameter("@AccountID", SqlDbType.Int)
                {Value =common.PrimaryKeyID },

                new SqlParameter("@ReturnValue", SqlDbType.NVarChar)
                { Direction = ParameterDirection.Output }

            };

                string result = await DAL.ExecuteSetWithSingleOutputParametersAsync(_sql, "@ReturnValue", _parameters);
                return result;

            }

            public async Task<List<BeanzlookupDTO>> LookUpBeanzPermissionsAsync(BeanzPermissionDTO lookup)
            {
                string _sql = "fas.LookupMS_Accounts";
                SqlParameter[] _parameters =
                {

                new SqlParameter("@CompanyID", SqlDbType.Int)
                {Value =lookup.CompanyID },

                new SqlParameter("@UserID", SqlDbType.Int)
                {Value =lookup.UserID },

                new SqlParameter("@Type", SqlDbType.Int)
                {Value =lookup.Type },

                new SqlParameter("@LanguageID", SqlDbType.Int)
                {Value =lookup.LanguageID },

                new SqlParameter("@AccountID", SqlDbType.Int)
                {Value =lookup.PrimaryKeyID }

            };

                var Accounts = await DAL.GetObjectListWithParametersAsync<BeanzlookupDTO>(_sql, _parameters);
                return Accounts;

            }

            //public async Task<AccountViewModel> GetInfoBeanzPermissionsAsync(BeanzCommonDTO common)
            //{
            //    string _sql = "fas.GetInfoMS_Accounts";
            //    SqlParameter[] paramList =
            //   {
            //    new SqlParameter("@CompanyID", SqlDbType.Int)
            //    {Value =common.CompanyID },
            //    new SqlParameter("@UserID", SqlDbType.Int)
            //    {Value =common.UserID },
            //    new SqlParameter("@Type", SqlDbType.Int)
            //    {Value =common.Type },
            //    new SqlParameter("@LanguageID", SqlDbType.Int)
            //    {Value =common.LanguageID },
            //    new SqlParameter("@AccountID", SqlDbType.Int)
            //    {Value =common.PrimaryKeyID }
            //};

            //    DynamicParameters p = new DynamicParameters();
            //    foreach (var param in paramList)
            //    {
            //        p.Add(param.ParameterName, param.Value);
            //    }
            //    var _accountDTOList = new List<AccountDTO>();
            //    bool _isAccountsConsumed = false;
            //    using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            //    {
            //        using (var objRecord = await SqlMapper.QueryMultipleAsync(_sqlConnection, _sql, p, commandType: CommandType.StoredProcedure))
            //        {
            //            while (!objRecord.IsConsumed)
            //            {
            //                var objTemp = objRecord.Read<dynamic>();
            //                var accountsData = objTemp.Where(c => c.TableName == "MS_Accounts");
            //                if (accountsData.Count() > 0 && !_isAccountsConsumed)
            //                {
            //                    _accountDTOList = _mapper.Map<List<AccountDTO>>(accountsData);
            //                    _isAccountsConsumed = true;
            //                    continue;
            //                }
            //            }
            //        }
            //        var _accountDTO = _accountDTOList.Where(x => x.AccountID == common.PrimaryKeyID).FirstOrDefault();
            //        var result = new AccountViewModel
            //        {
            //            Accounts = _accountDTOList,
            //            Account = _accountDTO
            //        };
            //        return result;
            //    }
            //}
        }


     
}
