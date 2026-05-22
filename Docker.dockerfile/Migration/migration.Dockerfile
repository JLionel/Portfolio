FROM alpine:latest AS base

#RUN set -eux; \
#    apt-get update; \
#	apt-get install -y gosu; \
#	rm -rf /var/lib/apt/lists/*; \
#	gosu nobody true

RUN set -eux; \
    apk update; \
	apk add gosu libgcc libstdc++ icu-libs; \
	rm -rf /var/lib/apt/lists/*; \
	gosu nobody true

#USER $APP_UID

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
USER root
WORKDIR /src

COPY ["portfolio.backend/portfolio.backend.csproj", "portfolio.backend/"]
RUN dotnet restore "portfolio.backend/portfolio.backend.csproj"

COPY portfolio.backend/ portfolio.backend/
WORKDIR "/src/portfolio.backend"
RUN dotnet build "./portfolio.backend.csproj" -c $BUILD_CONFIGURATION


FROM build AS migration
ARG BUILD_CONFIGURATION=Release

ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet tool install --global dotnet-ef

ARG TARGETARCH

RUN if [ "$TARGETARCH" = "amd64" ]; then \
        RID="linux-musl-x64"; \
    else \
        RID="linux-musl-arm64"; \
    fi; \
    echo "Rid = $RID"; \
    dotnet ef migrations bundle --output /app/publish/migrate \
     --configuration $BUILD_CONFIGURATION \
     --self-contained -r "$RID" \
     --no-build

FROM base AS final
WORKDIR /app

COPY --from=migration /app/publish/migrate ./

COPY portfolio.backend/Scripts/Shell/migration-entrypoint.sh portfolio.backend/appsettings.json ./

USER root

ENTRYPOINT ["sh", "./migration-entrypoint.sh"]