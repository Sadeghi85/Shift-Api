// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Shift.Repository
{
    public partial interface IShiftDbContext : IDisposable
    {
        DbSet<Portal> Portals { get; set; } // Portals
        DbSet<RayanSetting> RayanSettings { get; set; } // RayanSettings
        DbSet<SamtAgent> SamtAgents { get; set; } // SAMT_Agents
        DbSet<SamtHrCooperationType> SamtHrCooperationTypes { get; set; } // SAMT_HRCooperationType
        DbSet<SamtHrJob> SamtHrJobs { get; set; } // SAMT_HRJob
        DbSet<SamtResourceType> SamtResourceTypes { get; set; } // SAMT_ResourceTypes
        DbSet<ShiftAgentMainPosition> ShiftAgentMainPositions { get; set; } // Shift_AgentMainPosition
        DbSet<ShiftAgentReport> ShiftAgentReports { get; set; } // Shift_AgentReport
        DbSet<ShiftCalculation> ShiftCalculations { get; set; } // Shift_Calculations
        DbSet<ShiftCrewRewardFine> ShiftCrewRewardFines { get; set; } // Shift_CrewRewardFine
        DbSet<ShiftCrewRewardFineReason> ShiftCrewRewardFineReasons { get; set; } // Shift_CrewRewardFineReason
        DbSet<ShiftEmploymentDetail> ShiftEmploymentDetails { get; set; } // Shift_EmploymentDetail
        DbSet<ShiftJob> ShiftJobs { get; set; } // Shift_Job
        DbSet<ShiftLocation> ShiftLocations { get; set; } // Shift_Locations
        DbSet<ShiftLog> ShiftLogs { get; set; } // Shift_Log
        DbSet<ShiftMonetarySetting> ShiftMonetarySettings { get; set; } // Shift_MonetarySettings
        DbSet<ShiftPortalLocation> ShiftPortalLocations { get; set; } // Shift_PortalLocations
        DbSet<ShiftShift> ShiftShifts { get; set; } // Shift_Shift
        DbSet<ShiftShiftTablet> ShiftShiftTablets { get; set; } // Shift_ShiftTablet
        DbSet<ShiftShiftTabletConductorChanx> ShiftShiftTabletConductorChanges { get; set; } // Shift_ShiftTabletConductorChanges
        DbSet<ShiftShiftTabletCrew> ShiftShiftTabletCrews { get; set; } // Shift_ShiftTabletCrew
        DbSet<ShiftShiftTabletCrewAttendance> ShiftShiftTabletCrewAttendances { get; set; } // Shift_ShiftTabletCrewAttendance
        DbSet<ShiftShiftTabletCrewReplacement> ShiftShiftTabletCrewReplacements { get; set; } // Shift_ShiftTabletCrewReplacement
        DbSet<ShiftShiftTabletPayment> ShiftShiftTabletPayments { get; set; } // Shift_ShiftTabletPayments
        DbSet<ShiftShiftTabletReport> ShiftShiftTabletReports { get; set; } // Shift_ShiftTabletReports
        DbSet<ShiftShiftTabletReviewProblem> ShiftShiftTabletReviewProblems { get; set; } // Shift_ShiftTabletReviewProblems
        DbSet<ShiftShiftTemplate> ShiftShiftTemplates { get; set; } // Shift_ShiftTemplate
        DbSet<TelavatAgentResourceType> TelavatAgentResourceTypes { get; set; } // TelavatAgentResourceTypes
        DbSet<User> Users { get; set; } // Users
        DbSet<UsersPortal> UsersPortals { get; set; } // UsersPortals
        DbSet<UserType> UserTypes { get; set; } // UserTypes
        DbSet<UserTypeGroup> UserTypeGroups { get; set; } // UserTypeGroups
        DbSet<UserTypeGroupRoleMenu> UserTypeGroupRoleMenus { get; set; } // UserTypeGroupRoleMenus
        DbSet<UserTypeGroupRoleModule> UserTypeGroupRoleModules { get; set; } // UserTypeGroupRoleModules
        DbSet<UserUserType> UserUserTypes { get; set; } // UserUserTypes
        DbSet<UserUserTypeGroup> UserUserTypeGroups { get; set; } // UserUserTypeGroups

        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken));
        DatabaseFacade Database { get; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        string ToString();

        EntityEntry Add(object entity);
        EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;
        Task AddRangeAsync(params object[] entities);
        Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default);
        ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class;
        ValueTask<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken = default);
        void AddRange(IEnumerable<object> entities);
        void AddRange(params object[] entities);

        EntityEntry Attach(object entity);
        EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class;
        void AttachRange(IEnumerable<object> entities);
        void AttachRange(params object[] entities);

        EntityEntry Entry(object entity);
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        TEntity Find<TEntity>(params object[] keyValues) where TEntity : class;
        ValueTask<TEntity> FindAsync<TEntity>(object[] keyValues, CancellationToken cancellationToken) where TEntity : class;
        ValueTask<TEntity> FindAsync<TEntity>(params object[] keyValues) where TEntity : class;
        ValueTask<object> FindAsync(Type entityType, object[] keyValues, CancellationToken cancellationToken);
        ValueTask<object> FindAsync(Type entityType, params object[] keyValues);
        object Find(Type entityType, params object[] keyValues);

        EntityEntry Remove(object entity);
        EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
        void RemoveRange(IEnumerable<object> entities);
        void RemoveRange(params object[] entities);

        EntityEntry Update(object entity);
        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
        void UpdateRange(IEnumerable<object> entities);
        void UpdateRange(params object[] entities);

        IQueryable<TResult> FromExpression<TResult> (Expression<Func<IQueryable<TResult>>> expression);

        // Stored Procedures
        List<SpShiftCheckShiftTabletCrewAttendanceReportReturnModel> SpShiftCheckShiftTabletCrewAttendanceReport(int? portalId, DateTime? dateFrom, DateTime? dateTo);
        List<SpShiftCheckShiftTabletCrewAttendanceReportReturnModel> SpShiftCheckShiftTabletCrewAttendanceReport(int? portalId, DateTime? dateFrom, DateTime? dateTo, out int procResult);
        Task<List<SpShiftCheckShiftTabletCrewAttendanceReportReturnModel>> SpShiftCheckShiftTabletCrewAttendanceReportAsync(int? portalId, DateTime? dateFrom, DateTime? dateTo);

        List<SpShiftCheckShiftTimeOverlapReturnModel> SpShiftCheckShiftTimeOverlap(int? id, int? portalId, int? shiftTypeId, TimeSpan? startTime, TimeSpan? endTime);
        List<SpShiftCheckShiftTimeOverlapReturnModel> SpShiftCheckShiftTimeOverlap(int? id, int? portalId, int? shiftTypeId, TimeSpan? startTime, TimeSpan? endTime, out int procResult);
        Task<List<SpShiftCheckShiftTimeOverlapReturnModel>> SpShiftCheckShiftTimeOverlapAsync(int? id, int? portalId, int? shiftTypeId, TimeSpan? startTime, TimeSpan? endTime);

        List<SpShiftPermissionsReturnModel> SpShiftPermissions(int? userId, int? moduleId, string moduleTitle, string permissionKey);
        List<SpShiftPermissionsReturnModel> SpShiftPermissions(int? userId, int? moduleId, string moduleTitle, string permissionKey, out int procResult);
        Task<List<SpShiftPermissionsReturnModel>> SpShiftPermissionsAsync(int? userId, int? moduleId, string moduleTitle, string permissionKey);

    }
}
// </auto-generated>
