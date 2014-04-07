using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Weavver.Web;

namespace Weavver.Data
{
     public interface IAuditable
     {
          Guid Id { get; set; }
//-------------------------------------------------------------------------------------------
          Guid OrganizationId { get; set; }
//-------------------------------------------------------------------------------------------
          [SecureColumn(ColumnActions.DenyWrite)]
          [HideColumnIn(PageTemplate.List)]
          [ReadOnly(true)]
          DateTime CreatedAt { get; set; }
//-------------------------------------------------------------------------------------------
          [SecureColumn(ColumnActions.DenyWrite)]
          [HideColumnIn(PageTemplate.List)]
          [ReadOnly(true)]
          Guid CreatedBy { get; set; }
//-------------------------------------------------------------------------------------------
          [SecureColumn(ColumnActions.DenyWrite)]
          [HideColumnIn(PageTemplate.List)]
          [ReadOnly(true)]
          DateTime UpdatedAt { get; set; }
//-------------------------------------------------------------------------------------------
          [SecureColumn(ColumnActions.DenyWrite)]
          [HideColumnIn(PageTemplate.List)]
          [ReadOnly(true)]
          Guid UpdatedBy { get; set; }
//-------------------------------------------------------------------------------------------
          //public WeavverMenuItem GetDepartmentMenu();
//-------------------------------------------------------------------------------------------
     }
//-------------------------------------------------------------------------------------------
}
