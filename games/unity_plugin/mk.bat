set SOURCES=Surface.cs UnityClass1.cs MenuItemClass.cs saltyRandomGenerator.cs plasmagenerator.cs
"C:\Windows\Microsoft.NET\Framework\v4.0.30319\Csc.exe" /noconfig /nowarn:1701,1702,2008 /nostdlib+ /errorreport:prompt /warn:4 /define:DEBUG;TRACE /errorendlocation /preferreduilang:en-US /highentropyva- /reference:C:\Windows\Microsoft.NET\Framework\v2.0.50727\mscorlib.dll /reference:C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.Data.dll /reference:C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.dll /reference:C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.Xml.dll /reference:"C:\Program Files (x86)\Unity\Editor\Data\Managed\UnityEditor.dll"  /reference:"C:\Program Files (x86)\Unity\Editor\Data\Managed\UnityEngine.dll" /debug+ /debug:full /filealign:512 /optimize- /out:unity_plugin.dll /target:library /utf8output Properties\AssemblyInfo.cs %sources%