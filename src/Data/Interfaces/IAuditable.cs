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
//     public static bool CanAdd(Weavver.Sys.User person, DBObject doc)
//     {
//          return (person.Id.ToString() == "6bb552e9-debb-40d3-a5a9-60329aedeaac");
//     }
////-------------------------------------------------------------------------------------------
//     public static bool CanDelete(Weavver.Sys.User person, DBObject doc)
//     {
//          return (person.Id.ToString() == "6bb552e9-debb-40d3-a5a9-60329aedeaac");
//     }
//-------------------------------------------------------------------------------------------
}
