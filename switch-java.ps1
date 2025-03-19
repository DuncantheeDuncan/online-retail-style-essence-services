param (
    [string]$version
)

$javaPaths = @{
    "8" = "C:\Program Files (x86)\Java\jdk-1.8"
    "17" = "C:\Program Files (x86)\Java\jdk-17.0.13"
    "23" = "C:\Program Files\Java\jdk-23"
}

if ($javaPaths.ContainsKey($version)) {
    $env:JAVA_HOME=$javaPaths[$version]
    $env:PATH="$env:JAVA_HOME\bin;$env:PATH"
    Write-Output "Switched to Java $version"
} else {
    Write-Output "Java version $version not found."
}

#Run app
# .\switch-java.ps1