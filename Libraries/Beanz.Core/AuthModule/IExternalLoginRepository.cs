using Beanz.Models.AuthModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.Core.AuthModule
{
    public interface IExternalLoginRepository
    {
        // One call used by ALL provider controllers (Google, Microsoft, Facebook, Apple, GitHub, Twitter, LinkedIn)
        // Returns the local User (created or existing) and a flag indicating whether a new user was created.
        Task<(User user, bool isNew)> UpsertExternalUserAsync(
            string provider,
            string providerUserId,
            string? email,
            string? displayName,
            string? pictureUrl);

        Task<IEnumerable<ExternalLogin>> GetLinksByUserAsync(long userId);
        Task<bool> UnlinkAsync(long userId, string provider);
    }
}
