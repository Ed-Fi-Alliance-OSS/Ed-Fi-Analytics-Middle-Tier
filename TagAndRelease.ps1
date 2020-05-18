# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

Param (
    [string]$accessToken = "%EdFiBuildAgentAccessToken%",
    [string]$scdZipFile = "%PublishScdZipFile%",
    [string]$fddZipFile = "%PublishFddZipFile%",
    [string]$publishDirectory = "%PublishDirectory%",
    [string]$tagName = "%GitTagName%",
    [string]$branch = "%GitBranchToTag%",
    [string]$repository = "%GitRepository%",
    [string]$gitHubUserName = "%GitUserName%"
)

$baseUrl = "https://api.github.com";
$contentType = "application/vnd.github+json";

[Net.ServicePointManager]::SecurityProtocol = "tls12, tls11, tls";

$headers = @{
    "Authorization" = "token $accessToken";
    "Content-Type" = $contentType;
    "User-Agent" = $gitHubUserName;
};


Try {
    # Create the release
    $body = @{
        "tag_name" = "$tagName";
        "target_commitish" = "$branch";
        "name" = "$tagName";
        "prerelease" = If ($branch -eq "master") { $False } else { $True };
    };

    $path = "$baseUrl/repos/$repository/releases";

    $result = Invoke-RestMethod -Method POST -Uri "$path" -Headers $headers -Body ($body|ConvertTo-Json);
    Write-Host $result;
    
    # Prepare to upload files
    $uploadUrl = $result.upload_url;
    $headers.'Content-Type' = "application/zip";

    # Upload Framework-dependent deployment zip file
    $uploadUrlFdd = $uploadUrl.replace("{?name,label}", "?name=$fddZipFile");
    $result = Invoke-RestMethod -Method POST -Uri "$uploadUrlFdd" -Headers $headers -Infile "$publishDirectory\$fddZipFile";
    Write-Host $result;

    # Upload Self-contained deployment zip file
    $uploadUrlScd = $uploadUrl.replace("{?name,label}", "?name=$scdZipFile");
    $result = Invoke-RestMethod -Method POST -Uri "$uploadUrlScd" -Headers $headers -Infile "$publishDirectory\$scdZipFile";
    Write-Host $result;
}
Catch {
    Write-Host "Web request failed for $path with message $_.Message";
    Write-Error $_;
}    