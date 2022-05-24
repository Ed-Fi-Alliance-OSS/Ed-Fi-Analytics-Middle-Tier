FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine

ENV PACKAGE_URL "https://github.com/Ed-Fi-Alliance-OSS/Ed-Fi-Analytics-Middle-Tier"
ENV PACKAGE_NAME "EdFi.AnalyticsMiddleTier"
ENV AMT_VERSION "2.8.0"
ENV RELEASE_URL "${PACKAGE_URL}/releases/download/${AMT_VERSION}/${PACKAGE_NAME}-${AMT_VERSION}.zip"

RUN mkdir /app

ADD $RELEASE_URL /app

RUN apk add --no-cache unzip

RUN unzip "/app/${PACKAGE_NAME}-${AMT_VERSION}.zip" -d /app

ADD Dockerfile_install.sh /app

RUN chmod +x /app/Dockerfile_install.sh

ENTRYPOINT ["sh","/app/Dockerfile_install.sh"]