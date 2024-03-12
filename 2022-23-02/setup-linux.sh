#!/bin/bash

read -p "Mi legyen a projekt neve? " projectName

pattern=" |'"
while [[ $projectName =~ $pattern ]]
do
    echo "Space ne legyen a névben!"
    read -p "Mi legyen a projekt neve? " projectName
done

unitTest=false
echo "Legyen UnitTest a projekthez?"
select yn in "Igen" "Nem"; do
    case $yn in
        Igen ) unitTest=true; break;;
        Nem ) break;;
    esac
done

textFileDLL=false
echo "Hozzá akarod adni a TextFile.dll-t a projekthez?"
select yn in "Igen" "Nem"; do
    case $yn in
        Igen ) textFileDLL=true; break;;
        Nem ) break;;
    esac
done

if [ ! -f ./TextFile.dll ]; then
    echo "Kérlek másold a TextFile.dll-t a script mellé!"
    exit
fi

read -p "Milyen fájlokat akarsz hozzáadni a projekthez (space-el elválasztott fájlnevek)? " fileNames
includedFiles=($fileNames)

mkdir $projectName 
dotnet new console -n $projectName -o $projectName

dotnet new sln -n $projectName
dotnet sln add $projectName

if [ $unitTest = true ]
then
    testName="$projectName""Test"
    mkdir $testName
    dotnet new mstest -n $testName -o $testName
    dotnet sln add $testName
    dotnet add $testName/$testName.csproj reference $projectName/$projectName.csproj
fi

if [ $textFileDLL = true ]
then
    cp TextFile.dll $projectName/
    
    textFileContent='  <ItemGroup>\
    <Reference Include="TextFile">\
      <HintPath>TextFile.dll</HintPath>\
    </Reference>\
  </ItemGroup>'

    sed -i '/<\/Project>/i\'"$textFileContent" $projectName/$projectName.csproj

    copiedFiles='  <ItemGroup>\
    <Content Include="TextFile.dll">\
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>\
    </Content>\
' 
else
    copiedFiles='  <ItemGroup>'
fi

for file in "${includedFiles[@]}"
do
    copiedFiles+='    <Content Include="'$file'">\
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>\
    </Content>\
'
done

copiedFiles+='  </ItemGroup>'

sed -i '/<\/Project>/i\'"$copiedFiles" $projectName/$projectName.csproj