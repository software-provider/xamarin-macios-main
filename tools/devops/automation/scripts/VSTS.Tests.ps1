<#
VSTS interaction unit tests.
#>

Import-Module ./VSTS -Force

Describe 'Stop-Pipeline' {
    Context 'with all the env vars present' -Skip {

        BeforeAll {
            $Script:envVariables = @{
                "SYSTEM_TEAMFOUNDATIONCOLLECTIONURI" = "SYSTEM_TEAMFOUNDATIONCOLLECTIONURI";
                "SYSTEM_TEAMPROJECT" = "SYSTEM_TEAMPROJECT";
                "BUILD_BUILDID" = "BUILD_BUILDID";
                "ACCESSTOKEN" = "ACCESSTOKEN"
            }

            $envVariables.GetEnumerator() | ForEach-Object {
                $key = $_.Key
                Set-Item -Path "Env:$key" -Value $_.Value
            }
        }

        It 'performs the rest call' {
            Mock Invoke-RestMethod {
                return @{"status"=200;}
            }

            Stop-Pipeline

            $expectedUri = "SYSTEM_TEAMFOUNDATIONCOLLECTIONURISYSTEM_TEAMPROJECT/_apis/build/builds/BUILD_BUILDID?api-version=5.1"
            Assert-MockCalled -CommandName Invoke-RestMethod -Times 1 -Scope It -ParameterFilter {
                # validate the paremters
                if ($Uri -ne $expectedUri) {
                    return $False
                }

                if ($Headers.Authorization -ne ("Bearer {0}" -f $envVariables["ACCESSTOKEN"])) {
                    return $False
                }

                if ($Method -ne "PATCH") {
                    return $False
                }

                if ($ContentType -ne "application/json") {
                    return $False
                }

                # compare the payload
                $bodyObj = ConvertFrom-Json $Body
                if ($bodyObj.status -ne "Cancelling") {
                    return $False
                }
                return $True
            }
        }

        It 'performs the rest method with an error' {
            Mock Invoke-RestMethod {
                throw [System.Exception]::("Test")
            }
            #set env vars
            { Stop-Pipeline } | Should -Throw
        }
    }

    Context 'without an env var' -Skip {
        BeforeAll {
            $Script:envVariables = @{
                "SYSTEM_TEAMFOUNDATIONCOLLECTIONURI" = "SYSTEM_TEAMFOUNDATIONCOLLECTIONURI";
                "SYSTEM_TEAMPROJECT" = "SYSTEM_TEAMPROJECT";
                "BUILD_BUILDID" = "BUILD_BUILDID";
                "ACCESSTOKEN" = "ACCESSTOKEN"
            }

            $Script:envVariables.GetEnumerator() | ForEach-Object {
                $key = $_.Key
                Set-Item -Path "Env:$key" -Value $_.Value
                Remove-Item -Path "Env:$key"
            }
        }

        It 'fails calling the rest method' {
            Mock Invoke-RestMethod {
                return @{"status"=200;}
            }

            { Stop-Pipeline } | Should -Throw
            Assert-MockCalled -CommandName Invoke-RestMethod -Times 0 -Scope It
        }
    }
}

Describe 'Set-PipelineResult' {
    Context 'with all the env vars present' -Skip {

        BeforeAll {
            $Script:envVariables = @{
                "SYSTEM_TEAMFOUNDATIONCOLLECTIONURI" = "SYSTEM_TEAMFOUNDATIONCOLLECTIONURI";
                "SYSTEM_TEAMPROJECT" = "SYSTEM_TEAMPROJECT";
                "BUILD_BUILDID" = "BUILD_BUILDID";
                "ACCESSTOKEN" = "ACCESSTOKEN"
            }

            $envVariables.GetEnumerator() | ForEach-Object {
                $key = $_.Key
                Set-Item -Path "Env:$key" -Value $_.Value
            }
        }

        It 'performs the rest call' {
            Mock Invoke-RestMethod {
                return @{"status"=200;}
            }

            Set-PipelineResult "succeeded"

            $expectedUri = "SYSTEM_TEAMFOUNDATIONCOLLECTIONURISYSTEM_TEAMPROJECT/_apis/build/builds/BUILD_BUILDID?api-version=5.1"
            Assert-MockCalled -CommandName Invoke-RestMethod -Times 1 -Scope It -ParameterFilter {
                # validate the paremters
                if ($Uri -ne $expectedUri) {
                    return $False
                }

                if ($Headers.Authorization -ne ("Bearer {0}" -f $envVariables["ACCESSTOKEN"])) {
                    return $False
                }

                if ($Method -ne "PATCH") {
                    return $False
                }

                if ($ContentType -ne "application/json") {
                    return $False
                }

                # compare the payload
                $bodyObj = ConvertFrom-Json $Body
                if ($bodyObj.result -ne "succeeded") {
                    return $False
                }
                return $True
            }
        }

        It 'performs the rest method with an error' {
            Mock Invoke-RestMethod {
                throw [System.Exception]::("Test")
            }
            #set env vars
            { Set-PipelineResult "failed" } | Should -Throw
        }
    }

    Context 'without an env var' -Skip {
        BeforeAll {
            $Script:envVariables = @{
                "SYSTEM_TEAMFOUNDATIONCOLLECTIONURI" = "SYSTEM_TEAMFOUNDATIONCOLLECTIONURI";
                "SYSTEM_TEAMPROJECT" = "SYSTEM_TEAMPROJECT";
                "BUILD_BUILDID" = "BUILD_BUILDID";
                "ACCESSTOKEN" = "ACCESSTOKEN"
            }

            $Script:envVariables.GetEnumerator() | ForEach-Object {
                $key = $_.Key
                Set-Item -Path "Env:$key" -Value $_.Value
                Remove-Item -Path "Env:$key"
            }
        }

        It 'fails calling the rest method' {
            Mock Invoke-RestMethod {
                return @{"status"=200;}
            }

            { Set-PipelineResult "failed" } | Should -Throw
            Assert-MockCalled -CommandName Invoke-RestMethod -Times 0 -Scope It
        }
    }
}

Describe 'New-BuildConfiguration' {
    Context 'with all the env vars present' {
        BeforeAll {
            $Script:envVariables = @{
                "ACCESSTOKEN" = "ACCESSTOKEN"
                "BUILD_BUILDID" = "BUILD_BUILDID";
                "BUILD_REASON" = "BUILD_REASON"
                "BUILD_SOURCEBRANCH" = "BUILD_SOURCEBRANCH"
                "BUILD_SOURCEBRANCHNAME" = "BUILD_SOURCEBRANCHNAME"
                "BUILD_SOURCEVERSION" = "BUILD_SOURCEVERSION"
                "CONFIGURE_PLATFORMS_DOTNET_PLATFORMS" = "iOS tvOS"
                "CONFIGURE_PLATFORMS_INCLUDE_DOTNET_TVOS" = "true"
                "SYSTEM_TEAMFOUNDATIONCOLLECTIONURI" = "SYSTEM_TEAMFOUNDATIONCOLLECTIONURI";
                "SYSTEM_TEAMPROJECT" = "SYSTEM_TEAMPROJECT";
            }

            $envVariables.GetEnumerator() | ForEach-Object {
                $key = $_.Key
                Set-Item -Path "Env:$key" -Value $_.Value
            }
        }

        It 'gets the build build configuration' {
            $buildConfiguration = New-BuildConfiguration -AddTags $false

            $buildConfiguration | ConvertTo-Json | Should -Be "{
  ""BuildReason"": ""BUILD_REASON"",
  ""BuildSourceBranchName"": ""BUILD_SOURCEBRANCHNAME"",
  ""BuildSourceBranch"": ""BUILD_SOURCEBRANCH"",
  ""BuildId"": ""BUILD_BUILDID"",
  ""DOTNET_PLATFORMS"": ""iOS tvOS"",
  ""INCLUDE_DOTNET_IOS"": null,
  ""INCLUDE_DOTNET_TVOS"": ""true"",
  ""Commit"": ""BUILD_SOURCEVERSION"",
  ""Tags"": [
    ""ciBuild"",
    ""BUILD_SOURCEBRANCHNAME""
  ]
}"
        }

        It 'writes the file' {
            $testDirectory = Join-Path "." "subdir"
            $configFile = Join-Path $testDirectory "buildconfiguration.json"
            New-Item -Path "$testDirectory" -ItemType "directory" -Force
            New-BuildConfiguration -AddTags $false -ConfigFile $configFile

            $buildConfiguration = Get-Content -Path $configFile -Raw
            Remove-Item -Path $testDirectory -Recurse

            # Write-Host $buildConfiguration
            $buildConfiguration | Should -Be "{
  ""BuildReason"": ""BUILD_REASON"",
  ""BuildSourceBranchName"": ""BUILD_SOURCEBRANCHNAME"",
  ""BuildSourceBranch"": ""BUILD_SOURCEBRANCH"",
  ""BuildId"": ""BUILD_BUILDID"",
  ""DOTNET_PLATFORMS"": ""iOS tvOS"",
  ""INCLUDE_DOTNET_IOS"": null,
  ""INCLUDE_DOTNET_TVOS"": ""true"",
  ""Commit"": ""BUILD_SOURCEVERSION"",
  ""Tags"": [
    ""ciBuild"",
    ""BUILD_SOURCEBRANCHNAME""
  ]
}
"
        }
    }
}

Describe 'Import-BuildConfiguration' {
    Context 'import' {
        It 'gets the right values' {
            $config = "{
  ""BuildReason"": ""BUILD_REASON"",
  ""BuildSourceBranchName"": ""BUILD_SOURCEBRANCHNAME"",
  ""BuildSourceBranch"": ""BUILD_SOURCEBRANCH"",
  ""BuildId"": ""BUILD_BUILDID"",
  ""DOTNET_PLATFORMS"": ""iOS tvOS"",
  ""INCLUDE_DOTNET_IOS"": null,
  ""INCLUDE_DOTNET_TVOS"": ""true"",
  ""Commit"": ""BUILD_SOURCEVERSION"",
  ""Tags"": [
    ""ciBuild"",
    ""BUILD_SOURCEBRANCHNAME""
  ]
}"

            $testDirectory = Join-Path "." "subdir"
            $configFile = Join-Path $testDirectory "buildconfiguration.json"
            New-Item -Path "$testDirectory" -ItemType "directory" -Force
            Set-Content -Path $configFile -Value $config

            $buildConfiguration = Import-BuildConfiguration -ConfigFile $configFile

            Remove-Item -Path $testDirectory -Recurse
        }

        It 'null' {
            $config = "null"

            $testDirectory = Join-Path "." "subdir"
            $configFile = Join-Path $testDirectory "buildconfiguration.json"
            New-Item -Path "$testDirectory" -ItemType "directory" -Force
            Set-Content -Path $configFile -Value $config

            { Import-BuildConfiguration -ConfigFile $configFile } | Should -Throw

            Remove-Item -Path $testDirectory -Recurse
        }

        It 'inexistent path' {
            $testDirectory = Join-Path "." "subdir"
            $configFile = Join-Path $testDirectory "buildconfiguration.json"

            { Import-BuildConfiguration -ConfigFile $configFile } | Should -Throw
        }
    }
}
