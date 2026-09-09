# Publish self-contained single-file build for Windows (x64)
# Usage: powershell.exe -ExecutionPolicy Bypass -File .\scripts\publish-win.ps1
param(
	[string]$Configuration = 'Release'
)

$project = "SystemCleaner.csproj"
$rid = "win-x64"
$out = "artifacts/win-x64"
Remove-Item -Recurse -Force $out -ErrorAction SilentlyContinue

Write-Host "Publishing $project for $rid ($Configuration)..."

dotnet publish $project -c $Configuration -r $rid --self-contained true /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true -o $out

if ($LASTEXITCODE -ne 0) { Write-Error "dotnet publish failed"; exit 1 }

# Create zip
$zip = "artifacts/SystemCleaner-win-x64-$((Get-Date).ToString('yyyyMMdd-HHmmss')).zip"
if (Test-Path $zip) { Remove-Item $zip }
Write-Host "Creating zip $zip..."
Compress-Archive -Path "$out\*" -DestinationPath $zip
Write-Host "Done. Output: $out and $zip"