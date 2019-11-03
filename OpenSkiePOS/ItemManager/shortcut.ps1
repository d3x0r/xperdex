if( $args.Length -gt 0 )
{
$target = $args[0]
}
else
{
$target = $pwd.Path
}

$wshshell = New-Object -ComObject WScript.Shell
$lnk = $wshshell.CreateShortcut($target + "\ItemManager\xperdex.item_manager.lnk")
$lnk.TargetPath = ".\xperdex.loader.exe" 
$lnk.Arguments = "xperdex.item_manager.config.xml"
$lnk.WorkingDirectory = "."
$lnk.Save()

