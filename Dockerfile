FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine

ENV PACKAGE_URL "https://github.com/Ed-Fi-Alliance-OSS/Ed-Fi-Analytics-Middle-Tier"
ENV PACKAGE_NAME "EdFi.AnalyticsMiddleTier"
ENV AMT_VERSION "4.0.0"
ENV RELEASE_URL "${PACKAGE_URL}/releases/download/${AMT_VERSION}/${PACKAGE_NAME}-${AMT_VERSION}.zip"

RUN mkdir /app

ADD $RELEASE_URL /app

RUN apk add --no-cache unzip

RUN unzip "/app/${PACKAGE_NAME}-${AMT_VERSION}.zip" -d /app

RUN rm "/app/${PACKAGE_NAME}-${AMT_VERSION}.zip"

ADD Dockerfile_install.sh /app

RUN chmod +x /app/Dockerfile_install.sh

ENTRYPOINT ["sh","/app/Dockerfile_install.sh"]