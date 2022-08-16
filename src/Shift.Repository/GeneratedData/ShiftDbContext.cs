// <auto-generated>
// ReSharper disable All

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shift.Repository
{
    public partial class ShiftDbContext : DbContext, IShiftDbContext
    {
        private readonly IConfiguration _configuration;

        public ShiftDbContext()
        {
            InitializePartial();
        }

        public ShiftDbContext(DbContextOptions<ShiftDbContext> options)
            : base(options)
        {
            InitializePartial();
        }

        public ShiftDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            InitializePartial();
        }

        public DbSet<Portal> Portals { get; set; } // Portals
        public DbSet<RayanSetting> RayanSettings { get; set; } // RayanSettings
        public DbSet<SamtAgent> SamtAgents { get; set; } // SAMT_Agents
        public DbSet<SamtHrCooperationType> SamtHrCooperationTypes { get; set; } // SAMT_HRCooperationType
        public DbSet<SamtHrJob> SamtHrJobs { get; set; } // SAMT_HRJob
        public DbSet<SamtResourceType> SamtResourceTypes { get; set; } // SAMT_ResourceTypes
        public DbSet<ShiftAgentReport> ShiftAgentReports { get; set; } // Shift_AgentReport
        public DbSet<ShiftCalculation> ShiftCalculations { get; set; } // Shift_Calculations
        public DbSet<ShiftCrewRewardFine> ShiftCrewRewardFines { get; set; } // Shift_CrewRewardFine
        public DbSet<ShiftCrewRewardFineReason> ShiftCrewRewardFineReasons { get; set; } // Shift_CrewRewardFineReason
        public DbSet<ShiftEmploymentDetail> ShiftEmploymentDetails { get; set; } // Shift_EmploymentDetail
        public DbSet<ShiftJob> ShiftJobs { get; set; } // Shift_Job
        public DbSet<ShiftLocation> ShiftLocations { get; set; } // Shift_Locations
        public DbSet<ShiftLog> ShiftLogs { get; set; } // Shift_Log
        public DbSet<ShiftPortalLocation> ShiftPortalLocations { get; set; } // Shift_PortalLocations
        public DbSet<ShiftShift> ShiftShifts { get; set; } // Shift_Shift
        public DbSet<ShiftShiftTablet> ShiftShiftTablets { get; set; } // Shift_ShiftTablet
        public DbSet<ShiftShiftTabletConductorChanx> ShiftShiftTabletConductorChanges { get; set; } // Shift_ShiftTabletConductorChanges
        public DbSet<ShiftShiftTabletCrew> ShiftShiftTabletCrews { get; set; } // Shift_ShiftTabletCrew
        public DbSet<ShiftShiftTabletCrewAttendance> ShiftShiftTabletCrewAttendances { get; set; } // Shift_ShiftTabletCrewAttendance
        public DbSet<ShiftShiftTabletCrewReplacement> ShiftShiftTabletCrewReplacements { get; set; } // Shift_ShiftTabletCrewReplacement
        public DbSet<ShiftShiftTabletReport> ShiftShiftTabletReports { get; set; } // Shift_ShiftTabletReports
        public DbSet<ShiftShiftTabletReviewProblem> ShiftShiftTabletReviewProblems { get; set; } // Shift_ShiftTabletReviewProblems
        public DbSet<ShiftShiftTemplate> ShiftShiftTemplates { get; set; } // Shift_ShiftTemplate
        public DbSet<TelavatAgentResourceType> TelavatAgentResourceTypes { get; set; } // TelavatAgentResourceTypes
        public DbSet<User> Users { get; set; } // Users
        public DbSet<UsersPortal> UsersPortals { get; set; } // UsersPortals
        public DbSet<UserType> UserTypes { get; set; } // UserTypes
        public DbSet<UserTypeGroup> UserTypeGroups { get; set; } // UserTypeGroups
        public DbSet<UserTypeGroupRoleMenu> UserTypeGroupRoleMenus { get; set; } // UserTypeGroupRoleMenus
        public DbSet<UserTypeGroupRoleModule> UserTypeGroupRoleModules { get; set; } // UserTypeGroupRoleModules
        public DbSet<UserUserType> UserUserTypes { get; set; } // UserUserTypes
        public DbSet<UserUserTypeGroup> UserUserTypeGroups { get; set; } // UserUserTypeGroups

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured && _configuration != null)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString(@"DefaultConnection"));
            }
        }

        public bool IsSqlParameterNull(SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == DBNull.Value);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PortalConfiguration());
            modelBuilder.ApplyConfiguration(new RayanSettingConfiguration());
            modelBuilder.ApplyConfiguration(new SamtAgentConfiguration());
            modelBuilder.ApplyConfiguration(new SamtHrCooperationTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SamtHrJobConfiguration());
            modelBuilder.ApplyConfiguration(new SamtResourceTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ShiftAgentReportConfiguration());
            modelBuilder.ApplyConfiguration(new ShiftCalculationConfiguration());
            modelBuilder.ApplyConfiguration(new ShiftCrewRewardFineConfiguration());
            modelBuilder.ApplyConfiguration(new ShiftCrewRewardFineReasonConfiguration());
            modelBuilder.ApplyConfiguration(new ShiftEmploymentDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ShiftJobConfiguration());
            modelBuilder.ApplyConfiguration(new ShiftLocationConfiguration());
            modelBuilder.ApplyConfiguration(new ShiftLogConfiguration());
            modelBuilder.ApplyConfiguration(new ShiftPortalLocationConfiguration());
            modelBuilder.ApplyConfiguration(new ShiftShiftConfiguration());
            modelBuilder.ApplyConfiguration(new ShiftShiftTabletConfiguration());
            modelBuilder.ApplyConfiguration(new ShiftShiftTabletConductorChanxConfiguration());
            modelBuilder.ApplyConfiguration(new ShiftShiftTabletCrewConfiguration());
            modelBuilder.ApplyConfiguration(new ShiftShiftTabletCrewAttendanceConfiguration());
            modelBuilder.ApplyConfiguration(new ShiftShiftTabletCrewReplacementConfiguration());
            modelBuilder.ApplyConfiguration(new ShiftShiftTabletReportConfiguration());
            modelBuilder.ApplyConfiguration(new ShiftShiftTabletReviewProblemConfiguration());
            modelBuilder.ApplyConfiguration(new ShiftShiftTemplateConfiguration());
            modelBuilder.ApplyConfiguration(new TelavatAgentResourceTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UsersPortalConfiguration());
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserTypeGroupConfiguration());
            modelBuilder.ApplyConfiguration(new UserTypeGroupRoleMenuConfiguration());
            modelBuilder.ApplyConfiguration(new UserTypeGroupRoleModuleConfiguration());
            modelBuilder.ApplyConfiguration(new UserUserTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserUserTypeGroupConfiguration());

            modelBuilder.Entity<SpShiftCheckShiftTimeOverlapReturnModel>().HasNoKey();
            modelBuilder.Entity<SpShiftPermissionsReturnModel>().HasNoKey();

            OnModelCreatingPartial(modelBuilder);
        }


        partial void InitializePartial();
        partial void DisposePartial(bool disposing);
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        static partial void OnCreateModelPartial(ModelBuilder modelBuilder, string schema);

        // Stored Procedures
        public List<SpShiftCheckShiftTimeOverlapReturnModel> SpShiftCheckShiftTimeOverlap(int? id, int? portalId, int? shiftTypeId, TimeSpan? startTime, TimeSpan? endTime)
        {
            int procResult;
            return SpShiftCheckShiftTimeOverlap(id, portalId, shiftTypeId, startTime, endTime, out procResult);
        }

        public List<SpShiftCheckShiftTimeOverlapReturnModel> SpShiftCheckShiftTimeOverlap(int? id, int? portalId, int? shiftTypeId, TimeSpan? startTime, TimeSpan? endTime, out int procResult)
        {
            var idParam = new SqlParameter { ParameterName = "@_id", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = id.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!id.HasValue)
                idParam.Value = DBNull.Value;

            var portalIdParam = new SqlParameter { ParameterName = "@_portalId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = portalId.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!portalId.HasValue)
                portalIdParam.Value = DBNull.Value;

            var shiftTypeIdParam = new SqlParameter { ParameterName = "@_shiftTypeId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = shiftTypeId.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!shiftTypeId.HasValue)
                shiftTypeIdParam.Value = DBNull.Value;

            var startTimeParam = new SqlParameter { ParameterName = "@_startTime", SqlDbType = SqlDbType.Time, Direction = ParameterDirection.Input, Value = startTime.GetValueOrDefault() };
            if (!startTime.HasValue)
                startTimeParam.Value = DBNull.Value;

            var endTimeParam = new SqlParameter { ParameterName = "@_endTime", SqlDbType = SqlDbType.Time, Direction = ParameterDirection.Input, Value = endTime.GetValueOrDefault() };
            if (!endTime.HasValue)
                endTimeParam.Value = DBNull.Value;

            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
            const string sqlCommand = "EXEC @procResult = [dbo].[SP_Shift_CheckShiftTimeOverlap] @_id, @_portalId, @_shiftTypeId, @_startTime, @_endTime";
            var procResultData = Set<SpShiftCheckShiftTimeOverlapReturnModel>()
                .FromSqlRaw(sqlCommand, idParam, portalIdParam, shiftTypeIdParam, startTimeParam, endTimeParam, procResultParam)
                .ToList();

            procResult = (int) procResultParam.Value;
            return procResultData;
        }

        public async Task<List<SpShiftCheckShiftTimeOverlapReturnModel>> SpShiftCheckShiftTimeOverlapAsync(int? id, int? portalId, int? shiftTypeId, TimeSpan? startTime, TimeSpan? endTime)
        {
            var idParam = new SqlParameter { ParameterName = "@_id", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = id.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!id.HasValue)
                idParam.Value = DBNull.Value;

            var portalIdParam = new SqlParameter { ParameterName = "@_portalId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = portalId.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!portalId.HasValue)
                portalIdParam.Value = DBNull.Value;

            var shiftTypeIdParam = new SqlParameter { ParameterName = "@_shiftTypeId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = shiftTypeId.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!shiftTypeId.HasValue)
                shiftTypeIdParam.Value = DBNull.Value;

            var startTimeParam = new SqlParameter { ParameterName = "@_startTime", SqlDbType = SqlDbType.Time, Direction = ParameterDirection.Input, Value = startTime.GetValueOrDefault() };
            if (!startTime.HasValue)
                startTimeParam.Value = DBNull.Value;

            var endTimeParam = new SqlParameter { ParameterName = "@_endTime", SqlDbType = SqlDbType.Time, Direction = ParameterDirection.Input, Value = endTime.GetValueOrDefault() };
            if (!endTime.HasValue)
                endTimeParam.Value = DBNull.Value;

            const string sqlCommand = "EXEC [dbo].[SP_Shift_CheckShiftTimeOverlap] @_id, @_portalId, @_shiftTypeId, @_startTime, @_endTime";
            var procResultData = await Set<SpShiftCheckShiftTimeOverlapReturnModel>()
                .FromSqlRaw(sqlCommand, idParam, portalIdParam, shiftTypeIdParam, startTimeParam, endTimeParam)
                .ToListAsync();

            return procResultData;
        }

        public List<SpShiftPermissionsReturnModel> SpShiftPermissions(int? userId, int? moduleId, string moduleTitle, string permissionKey)
        {
            int procResult;
            return SpShiftPermissions(userId, moduleId, moduleTitle, permissionKey, out procResult);
        }

        public List<SpShiftPermissionsReturnModel> SpShiftPermissions(int? userId, int? moduleId, string moduleTitle, string permissionKey, out int procResult)
        {
            var userIdParam = new SqlParameter { ParameterName = "@userId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = userId.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!userId.HasValue)
                userIdParam.Value = DBNull.Value;

            var moduleIdParam = new SqlParameter { ParameterName = "@moduleId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = moduleId.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!moduleId.HasValue)
                moduleIdParam.Value = DBNull.Value;

            var moduleTitleParam = new SqlParameter { ParameterName = "@moduleTitle", SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, Value = moduleTitle, Size = 50 };
            if (moduleTitleParam.Value == null)
                moduleTitleParam.Value = DBNull.Value;

            var permissionKeyParam = new SqlParameter { ParameterName = "@permissionKey", SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, Value = permissionKey, Size = 50 };
            if (permissionKeyParam.Value == null)
                permissionKeyParam.Value = DBNull.Value;

            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
            const string sqlCommand = "EXEC @procResult = [dbo].[SP_Shift_permissions] @userId, @moduleId, @moduleTitle, @permissionKey";
            var procResultData = Set<SpShiftPermissionsReturnModel>()
                .FromSqlRaw(sqlCommand, userIdParam, moduleIdParam, moduleTitleParam, permissionKeyParam, procResultParam)
                .ToList();

            procResult = (int) procResultParam.Value;
            return procResultData;
        }

        public async Task<List<SpShiftPermissionsReturnModel>> SpShiftPermissionsAsync(int? userId, int? moduleId, string moduleTitle, string permissionKey)
        {
            var userIdParam = new SqlParameter { ParameterName = "@userId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = userId.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!userId.HasValue)
                userIdParam.Value = DBNull.Value;

            var moduleIdParam = new SqlParameter { ParameterName = "@moduleId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = moduleId.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!moduleId.HasValue)
                moduleIdParam.Value = DBNull.Value;

            var moduleTitleParam = new SqlParameter { ParameterName = "@moduleTitle", SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, Value = moduleTitle, Size = 50 };
            if (moduleTitleParam.Value == null)
                moduleTitleParam.Value = DBNull.Value;

            var permissionKeyParam = new SqlParameter { ParameterName = "@permissionKey", SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, Value = permissionKey, Size = 50 };
            if (permissionKeyParam.Value == null)
                permissionKeyParam.Value = DBNull.Value;

            const string sqlCommand = "EXEC [dbo].[SP_Shift_permissions] @userId, @moduleId, @moduleTitle, @permissionKey";
            var procResultData = await Set<SpShiftPermissionsReturnModel>()
                .FromSqlRaw(sqlCommand, userIdParam, moduleIdParam, moduleTitleParam, permissionKeyParam)
                .ToListAsync();

            return procResultData;
        }

    }
}
// </auto-generated>
