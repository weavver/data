using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities.Statements;
using System.Activities;

namespace Weavver.Workflows
{
     public sealed class WebResponse<T> : NativeActivity<T>
     {
          [RequiredArgument]
          public InArgument<string> BookmarkName { get; set; }
          //public OutArgument<string> Result { get; set; }

          public WebResponse() : base()
          {
          }

          protected override void Execute(NativeActivityContext context)
          {
               string bookmarkName = context.GetValue(this.BookmarkName);
               context.CreateBookmark(bookmarkName, new BookmarkCallback(this.Continue));
          }

          void Continue(NativeActivityContext context, Bookmark bookmark, object obj)
          {
               Result.Set(context, (T)obj);
          }

          protected override bool CanInduceIdle { get { return true; } }
     }
}
