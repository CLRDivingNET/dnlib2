using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet;

namespace Examples {
	internal class Example8 {
		public static void Run() => new Example8().DoIt();

		void DoIt() {
			ModuleDefMD original = ModuleDefMD.Load(@"D:\Desktop\RenameTest\SharpKatz.exe");
			var methodDef = original.Types.SelectMany(x => x.Methods).Where(y => y.Name == "FromBase64").FirstOrDefault();

			foreach (var type in original.Types) {
				foreach (var method in type.Methods) {
					foreach (ParamDef item in method.ParamDefs) {
						item.CustomAttributes.Add(method.ParamDefs[0].CustomAttributes[0]);
						//item.ElementType = ElementType.Object;
					}
				}
			}


		}
	}
}
