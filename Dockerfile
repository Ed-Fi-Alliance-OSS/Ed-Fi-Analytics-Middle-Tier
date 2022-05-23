FROM mcr.microsoft.com/dotnet/core/sdk:3.1

RUN mkdir /Ed-Fi \
  && mkdir /Ed-Fi/AMT

ADD https://github.com/Ed-Fi-Alliance-OSS/Ed-Fi-Analytics-Middle-Tier/releases/download/2.9.0-pre-2067653593/EdFi.AnalyticsMiddleTier-win10.x64-2.9.0.zip /Ed-Fi/AMT/

RUN apt-get update && apt install unzip

RUN unzip /Ed-Fi/AMT/EdFi.AnalyticsMiddleTier-win10.x64-2.9.0.zip -d /Ed-Fi/AMT

COPY ./file.sh /Ed-Fi/AMT

RUN chmod +x /Ed-Fi/AMT/file.sh

ENTRYPOINT ["sh","/Ed-Fi/AMT/file.sh"]
