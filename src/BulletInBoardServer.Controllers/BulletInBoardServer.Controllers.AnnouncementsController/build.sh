#!/usr/bin/env bash
#
# Generated by: https://openapi-generator.tech
#

dotnet restore src/BulletInBoardServer.Controllers.AnnouncementsController/ && \
    dotnet build src/BulletInBoardServer.Controllers.AnnouncementsController/ && \
    echo "Now, run the following to start the project: dotnet run -p src/BulletInBoardServer.Controllers.AnnouncementsController/BulletInBoardServer.Controllers.AnnouncementsController.csproj --launch-profile web"
