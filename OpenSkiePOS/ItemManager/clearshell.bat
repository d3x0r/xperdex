set path=%path%;%SYSTEMROOT%\System32\WindowsPowerShell\v1.0

for /f %%i in ('powershell get-executionpolicy  ^< NUL') do set OLDMODE=%%i
PowerShell -Command set-executionpolicy unrestricted < NUL
PowerShell -Command "%*" < NUL
PowerShell -Command set-executionpolicy %OLDMODE% < NUL
