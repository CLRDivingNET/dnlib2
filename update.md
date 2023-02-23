# update

> dnlib2

> 增加 MethodDef   GetILAsByteArray()   CodeSize



## GetILAsByteArray

```c#
Assembly assembly = Assembly.LoadFile(args[0]);
ModuleDef module = ModuleDefMD.Load(assembly.ManifestModule);
foreach (var item in module.Types)
{
    foreach (var method in item.Methods)
    {
        if (method.Name.StartsWith("get_") || method.Name.StartsWith("set_")) { continue; }
        if(method.Body != null) 
        {
            Console.WriteLine($"{method.Name} {method.Body.CodeSize}\t {method.GetILAsByteArray(module).ToHex()}");
        }
    }
}
```



```c#
public static class SharpExt
{
    public static string ToHex(this byte[] byteDatas)
    {
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < byteDatas.Length; i++)
        {
            stringBuilder.Append($"{byteDatas[i]:X2} ");
        }

        return stringBuilder.ToString().Trim();
    }
}
```

