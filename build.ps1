msbuild /t:Build /restore /p:Configuration=Release /p:OutDir=..\build

rm -R .\release -ErrorAction SilentlyContinue
mkdir .\release\

cp .\build\QolMod.dll .\release\
cp .\mod.json .\release\

rm .\QolMod.zip -ErrorAction SilentlyContinue
powershell Compress-Archive .\release\* .\QolMod.zip
