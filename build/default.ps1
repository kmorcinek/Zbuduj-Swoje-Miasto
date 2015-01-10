Framework "4.6"

Properties {
    $solution_name = "KMorcinek.TheCityCardGame"
    $build_dir = Split-Path $psake.build_script_file
    $build_artifacts_dir = "$build_dir\BuildArtifacts"
    $code_dir = "$build_dir\..\src"
    $tools_directory = "$code_dir\packages"
    $xunit_output_dir = "$build_artifacts_dir\TestOutput"

    # nuget.exe that always need to be in repository to allow downloading other dependencies (and newest nuget version),
    # initialy /Nugets folder is empty
    # no need to update this file when new minor nuget versions are available
    $initial_nuget_path = "tools\nuget"

    # tools that require version unpdate after updating them in solution
    $xunit = "$tools_directory\xunit.runner.console.2.2.0\tools\xunit.console.exe"
}

FormatTaskName (("-"*25) + "[{0}]" + ("-"*25))

Task Default -Depends Build, Test

Task Build -Depends Clean {
    Write-Host "Restoring NuGet packages for $solution_name" -ForegroundColor Green
    & $initial_nuget_path restore "$code_dir\$solution_name.sln"

    Write-Host "Building $solution_name.sln" -ForegroundColor Green
    RunMsBuild { msbuild "$code_dir\$solution_name.sln" /t:Build /p:Configuration=$build_configuration /v:quiet /p:OutDir=$build_artifacts_dir }
}

Task Clean {
    Write-Host "Creating BuildArtifacts directory" -ForegroundColor Green

    Ensure-Directory-Is-Clean $build_artifacts_dir

    Write-Host "Cleaning $solution_name.sln" -ForegroundColor Green
    Exec { msbuild "$code_dir\$solution_name.sln" /t:Clean /p:Configuration=$build_configuration /v:quiet }
}

Task Test {
    assert(Test-Path($xunit)) "xUnit must be available."

    Ensure-Directory-Is-Clean $xunit_output_dir

    $testFolders = gci $build_artifacts_dir/*Tests.dll

    foreach($testFolder in $testFolders) { 
        write-host $testFolder
        
        $testFolderPath = $testFolder.FullName
     
        $test_name = $testFolder.Name
        $test_output_path = "$xunit_output_dir\$test_name.xml"
        write-host "****** found tests: $testFolderPath, output: $test_output_path"

        Exec {
            & $xunit $testFolderPath -xml $test_output_path
        }

        write-host "****** finished testing: $testFolderPath"
    }
}

function RunMsBuild
{
    Param(
      [scriptblock]$script
    )

    $errorLine = ""
    $outputArray = (&$script 2>&1)
    
    Foreach ($outputLine in $outputArray)
    {
        $warningPosition = $outputLine.IndexOf(": warning ")
        if ($warningPosition -eq -1)
        {
            $errorPosition = $outputLine.IndexOf(": error ")
            if ($errorPosition -eq -1)
            {
                Write-Host $outputLine
            } else {
                $errorLine = $outputLine
                Write-Host $outputLine -ForegroundColor Red
            }
        } else {
            Write-Host "##vso[task.logissue type=warning]"$outputLine -ForegroundColor Yellow
        }
    }
    
    if ($lastexitcode -ne 0) {
        throw ($errorLine)
    }
}

function Ensure-Directory-Is-Clean
{
    Param(
        [Parameter(Mandatory=$true)]
		[string]$directoryPath
    )

    if (Test-Path $directoryPath)
    {
        Remove-Item $directoryPath -rec -force | out-null
    }

    mkdir $directoryPath | out-null
}