using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;
using Microsoft.CSharp;

//using Weavver.VoiceScribe.Gateway;

// not being used by anything
namespace WeavverLib.VoiceScribeLib
{
     public class HotSwapper
     {
          private readonly string directoryToWatch;
          //private readonly IWindsorContainer container;
          private readonly Assembly assembly;
          private readonly string controllersNamespace;

          public HotSwapper(string directoryToWatch, /*VoiceScribeGatewayChannelInterface container,*/ Assembly assembly, string controllersNamespace)
          {
               this.directoryToWatch = directoryToWatch;
               //this.container = container;
               this.assembly = assembly;
               this.controllersNamespace = controllersNamespace;
          }

          public void Start()
          {
               FileSystemWatcher watcher = new FileSystemWatcher(directoryToWatch, "*.cs");
               watcher.Created += CodeChanged;
               watcher.Changed += CodeChanged;
               watcher.Renamed += CodeChanged;
               watcher.EnableRaisingEvents = true;
          }

          void CodeChanged(object sender, FileSystemEventArgs e)
          {
               string fileName = Path.GetFileNameWithoutExtension(e.FullPath);
               string typeName = controllersNamespace + "." + fileName;
               CompilerParameters options = CreateCompilerOptions();

               CSharpCodeProvider provider = new CSharpCodeProvider();
               CompilerResults compilerResults = provider
                    .CompileAssemblyFromFile(options, e.FullPath);

               //container.Kernel.RemoveComponent(typeName);

               if (compilerResults.Errors.HasErrors)
                    return;

               Type type = compilerResults.CompiledAssembly.GetType(typeName);
               //container.AddComponent(type.FullName, type);
          }

          private CompilerParameters CreateCompilerOptions()
          {
               CompilerParameters options = new CompilerParameters();
               options.GenerateInMemory = true;
               options.GenerateExecutable = false;
               options.ReferencedAssemblies.Add(assembly.Location);
               foreach (AssemblyName name in assembly.GetReferencedAssemblies())
               {
                    Assembly loaded = Assembly.Load(name.FullName);
                    options.ReferencedAssemblies.Add(loaded.Location);
               }
               options.IncludeDebugInformation = true;
               return options;
          }
     }
}
