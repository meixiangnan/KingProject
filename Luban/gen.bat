set WORKSPACE=..

set GEN_CLIENT=%WORKSPACE%\Luban\Tools\Luban\Luban.dll
set CONF_ROOT=%WORKSPACE%\DataTables

dotnet %GEN_CLIENT% ^
    -t client ^
    -c cs-simple-json ^
    -d json  ^
    --conf %CONF_ROOT%\luban.conf ^
    -x outputCodeDir=%WORKSPACE%\Assets/Gen ^
    -x outputDataDir=%WORKSPACE%\Assets\GenerateDatas\json ^
    -x pathValidator.rootDir=E:\Project\Unity\KingProject_new ^
    -x l10n.provider=default ^
    -x l10n.textFile.path=*@%WORKSPACE%\DataTables\Datas\l10n\texts.json ^
    -x l10n.textFile.keyFieldName=key

pause