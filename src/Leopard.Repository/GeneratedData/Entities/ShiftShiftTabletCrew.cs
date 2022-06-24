// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository {
	// Shift_ShiftTabletCrew
	public partial class ShiftShiftTabletCrew {
		public int Id { get; set; } // ID (Primary key)
		public int AgentId { get; set; } // AgentId
		public int ResourceId { get; set; } // ResourceId
		public int ShiftTabletId { get; set; } // ShiftTabletId
		public DateTime? EntranceTime { get; set; } // EntranceTime
		public DateTime? ExitTime { get; set; } // ExitTime
		public int? CreatedBy { get; set; } // CreatedBy
		public int? ModifiedBy { get; set; } // ModifiedBy
		public DateTime? CreateDateTime { get; set; } // CreateDateTime
		public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime
		public bool IsReplaced { get; set; } // IsReplaced
		public bool? IsDeleted { get; set; } // IsDeleted

		// Reverse navigation

		/// <summary>
		/// Child ShiftCrewRewardFines where [Shift_CrewRewardFine].[ShiftTabletCrewId] point to this entity (FK_Shift_CrewRewardFine_Shift_ShiftTabletCrew)
		/// </summary>
		public virtual ICollection<ShiftCrewRewardFine> ShiftCrewRewardFines { get; set; } // Shift_CrewRewardFine.FK_Shift_CrewRewardFine_Shift_ShiftTabletCrew

		/// <summary>
		/// Child ShiftShiftTabletCrewReplacements where [Shift_ShiftTabletCrewReplacement].[ShiftTabletCrewId] point to this entity (FK_Shift_ShiftTabletCrewReplacement_Shift_ShiftTabletCrew)
		/// </summary>
		public virtual ICollection<ShiftShiftTabletCrewReplacement> ShiftShiftTabletCrewReplacements_ShiftTabletCrewId { get; set; } // Shift_ShiftTabletCrewReplacement.FK_Shift_ShiftTabletCrewReplacement_Shift_ShiftTabletCrew

		/// <summary>
		/// Child ShiftShiftTabletCrewReplacements where [Shift_ShiftTabletCrewReplacement].[ShiftTabletCrewIdReplaceMent] point to this entity (FK_Shift_ShiftTabletCrewReplacement_Shift_ShiftTabletCrew1)
		/// </summary>
		public virtual ICollection<ShiftShiftTabletCrewReplacement> ShiftShiftTabletCrewReplacements_ShiftTabletCrewIdReplaceMent { get; set; } // Shift_ShiftTabletCrewReplacement.FK_Shift_ShiftTabletCrewReplacement_Shift_ShiftTabletCrew1

		// Foreign keys

		/// <summary>
		/// Parent SamtAgent pointed by [Shift_ShiftTabletCrew].([AgentId]) (FK_Shift_ShiftTabletCrew_SAMT_Agents)
		/// </summary>
		public virtual SamtAgent SamtAgent { get; set; } // FK_Shift_ShiftTabletCrew_SAMT_Agents

		/// <summary>
		/// Parent SamtResourceType pointed by [Shift_ShiftTabletCrew].([ResourceId]) (FK_Shift_ShiftTableCrew_SAMT_ResourceTypes)
		/// </summary>
		public virtual SamtResourceType SamtResourceType { get; set; } // FK_Shift_ShiftTableCrew_SAMT_ResourceTypes

		/// <summary>
		/// Parent ShiftShiftTablet pointed by [Shift_ShiftTabletCrew].([ShiftTabletId]) (FK_Shift_ShiftTableCrew_Shift_ShiftTablet)
		/// </summary>
		public virtual ShiftShiftTablet ShiftShiftTablet { get; set; } // FK_Shift_ShiftTableCrew_Shift_ShiftTablet

		public ShiftShiftTabletCrew() {
			ShiftCrewRewardFines = new List<ShiftCrewRewardFine>();
			ShiftShiftTabletCrewReplacements_ShiftTabletCrewId = new List<ShiftShiftTabletCrewReplacement>();
			ShiftShiftTabletCrewReplacements_ShiftTabletCrewIdReplaceMent = new List<ShiftShiftTabletCrewReplacement>();
			InitializePartial();
		}

		partial void InitializePartial();
	}

}
// </auto-generated>
