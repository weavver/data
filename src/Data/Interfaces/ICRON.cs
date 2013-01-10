using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Weavver.Utilities;

namespace Weavver.Data
{
     // This COULD be implemented as a static method on the classes but I like the idea of using
     //   an interface as a "contract" to promote consistency
     public interface ICRON
     {
          void RunCronTasks(CommandLineArguments args);
     }
}


// This is an example of using reflection to trigger static methods:
// (we aren't using this though because the interface requires an instantiated class)

//http://blogs.microsoft.co.il/blogs/bursteg/archive/2006/11/15/InvokeStaticGenericMethod.aspx
//Type typeofClassWithGenericStaticMethod = typeof(ClassWithGenericStaticMethod);
//MethodInfo methodInfo = typeofClassWithGenericStaticMethod.GetMethod("PrintName", System.Reflection.BindingFlags.Static | BindingFlags.Public);

//// Binding the method info to generic arguments
//Type[] genericArguments = new Type[] { typeof(Program) };
//MethodInfo genericMethodInfo = methodInfo.MakeGenericMethod(genericArguments);

//// Simply invoking the method and passing parameters
//// The null parameter is the object to call the method from. Since the method is
//// static, pass null.
//object returnValue = genericMethodInfo.Invoke(null, new object[] { "hello" });
