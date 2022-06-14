// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // Clients
    public partial class Client
    {
        public int Id { get; set; } // Id (Primary key)
        public bool Enabled { get; set; } // Enabled
        public string ClientId { get; set; } // ClientId (length: 200)
        public string ProtocolType { get; set; } // ProtocolType (length: 200)
        public bool RequireClientSecret { get; set; } // RequireClientSecret
        public string ClientName { get; set; } // ClientName (length: 200)
        public string Description { get; set; } // Description (length: 1000)
        public string ClientUri { get; set; } // ClientUri (length: 2000)
        public string LogoUri { get; set; } // LogoUri (length: 2000)
        public bool RequireConsent { get; set; } // RequireConsent
        public bool AllowRememberConsent { get; set; } // AllowRememberConsent
        public bool AlwaysIncludeUserClaimsInIdToken { get; set; } // AlwaysIncludeUserClaimsInIdToken
        public bool RequirePkce { get; set; } // RequirePkce
        public bool AllowPlainTextPkce { get; set; } // AllowPlainTextPkce
        public bool RequireRequestObject { get; set; } // RequireRequestObject
        public bool AllowAccessTokensViaBrowser { get; set; } // AllowAccessTokensViaBrowser
        public string FrontChannelLogoutUri { get; set; } // FrontChannelLogoutUri (length: 2000)
        public bool FrontChannelLogoutSessionRequired { get; set; } // FrontChannelLogoutSessionRequired
        public string BackChannelLogoutUri { get; set; } // BackChannelLogoutUri (length: 2000)
        public bool BackChannelLogoutSessionRequired { get; set; } // BackChannelLogoutSessionRequired
        public bool AllowOfflineAccess { get; set; } // AllowOfflineAccess
        public int IdentityTokenLifetime { get; set; } // IdentityTokenLifetime
        public string AllowedIdentityTokenSigningAlgorithms { get; set; } // AllowedIdentityTokenSigningAlgorithms (length: 100)
        public int AccessTokenLifetime { get; set; } // AccessTokenLifetime
        public int AuthorizationCodeLifetime { get; set; } // AuthorizationCodeLifetime
        public int? ConsentLifetime { get; set; } // ConsentLifetime
        public int AbsoluteRefreshTokenLifetime { get; set; } // AbsoluteRefreshTokenLifetime
        public int SlidingRefreshTokenLifetime { get; set; } // SlidingRefreshTokenLifetime
        public int RefreshTokenUsage { get; set; } // RefreshTokenUsage
        public bool UpdateAccessTokenClaimsOnRefresh { get; set; } // UpdateAccessTokenClaimsOnRefresh
        public int RefreshTokenExpiration { get; set; } // RefreshTokenExpiration
        public int AccessTokenType { get; set; } // AccessTokenType
        public bool EnableLocalLogin { get; set; } // EnableLocalLogin
        public bool IncludeJwtId { get; set; } // IncludeJwtId
        public bool AlwaysSendClientClaims { get; set; } // AlwaysSendClientClaims
        public string ClientClaimsPrefix { get; set; } // ClientClaimsPrefix (length: 200)
        public string PairWiseSubjectSalt { get; set; } // PairWiseSubjectSalt (length: 200)
        public DateTime Created { get; set; } // Created
        public DateTime? Updated { get; set; } // Updated
        public DateTime? LastAccessed { get; set; } // LastAccessed
        public int? UserSsoLifetime { get; set; } // UserSsoLifetime
        public string UserCodeType { get; set; } // UserCodeType (length: 100)
        public int DeviceCodeLifetime { get; set; } // DeviceCodeLifetime
        public bool NonEditable { get; set; } // NonEditable

        // Reverse navigation

        /// <summary>
        /// Child ClientClaims where [ClientClaims].[ClientId] point to this entity (FK_ClientClaims_Clients_ClientId)
        /// </summary>
        public virtual ICollection<ClientClaim> ClientClaims { get; set; } // ClientClaims.FK_ClientClaims_Clients_ClientId

        /// <summary>
        /// Child ClientCorsOrigins where [ClientCorsOrigins].[ClientId] point to this entity (FK_ClientCorsOrigins_Clients_ClientId)
        /// </summary>
        public virtual ICollection<ClientCorsOrigin> ClientCorsOrigins { get; set; } // ClientCorsOrigins.FK_ClientCorsOrigins_Clients_ClientId

        /// <summary>
        /// Child ClientGrantTypes where [ClientGrantTypes].[ClientId] point to this entity (FK_ClientGrantTypes_Clients_ClientId)
        /// </summary>
        public virtual ICollection<ClientGrantType> ClientGrantTypes { get; set; } // ClientGrantTypes.FK_ClientGrantTypes_Clients_ClientId

        /// <summary>
        /// Child ClientIdPRestrictions where [ClientIdPRestrictions].[ClientId] point to this entity (FK_ClientIdPRestrictions_Clients_ClientId)
        /// </summary>
        public virtual ICollection<ClientIdPRestriction> ClientIdPRestrictions { get; set; } // ClientIdPRestrictions.FK_ClientIdPRestrictions_Clients_ClientId

        /// <summary>
        /// Child ClientPostLogoutRedirectUris where [ClientPostLogoutRedirectUris].[ClientId] point to this entity (FK_ClientPostLogoutRedirectUris_Clients_ClientId)
        /// </summary>
        public virtual ICollection<ClientPostLogoutRedirectUri> ClientPostLogoutRedirectUris { get; set; } // ClientPostLogoutRedirectUris.FK_ClientPostLogoutRedirectUris_Clients_ClientId

        /// <summary>
        /// Child ClientProperties where [ClientProperties].[ClientId] point to this entity (FK_ClientProperties_Clients_ClientId)
        /// </summary>
        public virtual ICollection<ClientProperty> ClientProperties { get; set; } // ClientProperties.FK_ClientProperties_Clients_ClientId

        /// <summary>
        /// Child ClientRedirectUris where [ClientRedirectUris].[ClientId] point to this entity (FK_ClientRedirectUris_Clients_ClientId)
        /// </summary>
        public virtual ICollection<ClientRedirectUri> ClientRedirectUris { get; set; } // ClientRedirectUris.FK_ClientRedirectUris_Clients_ClientId

        /// <summary>
        /// Child ClientScopes where [ClientScopes].[ClientId] point to this entity (FK_ClientScopes_Clients_ClientId)
        /// </summary>
        public virtual ICollection<ClientScope> ClientScopes { get; set; } // ClientScopes.FK_ClientScopes_Clients_ClientId

        /// <summary>
        /// Child ClientSecrets where [ClientSecrets].[ClientId] point to this entity (FK_ClientSecrets_Clients_ClientId)
        /// </summary>
        public virtual ICollection<ClientSecret> ClientSecrets { get; set; } // ClientSecrets.FK_ClientSecrets_Clients_ClientId

        public Client()
        {
            ClientClaims = new List<ClientClaim>();
            ClientCorsOrigins = new List<ClientCorsOrigin>();
            ClientGrantTypes = new List<ClientGrantType>();
            ClientIdPRestrictions = new List<ClientIdPRestriction>();
            ClientPostLogoutRedirectUris = new List<ClientPostLogoutRedirectUri>();
            ClientProperties = new List<ClientProperty>();
            ClientRedirectUris = new List<ClientRedirectUri>();
            ClientScopes = new List<ClientScope>();
            ClientSecrets = new List<ClientSecret>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>