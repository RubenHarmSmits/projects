FROM microsoft/dotnet:2.2-sdk

# Install Java for converting test results to junit
RUN apt-get -qqy update && apt-get install -qqy openjdk-8-jdk-headless \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /app/src

# Cache the dependencies
COPY Domain/Domain.csproj Domain/
COPY Repository/Repository.csproj Repository/
COPY Services/Services.csproj Services/

# Then copy the rest of the sources
COPY . .

# Add a test user
ARG UID=1000
ARG GID=1000
RUN groupadd -g ${GID} testuser && useradd -d /app -g testuser -u ${UID} testuser \
    && chown -R testuser:testuser /app

USER testuser

# Run dotnet test for all *Test directories in the source
RUN find . -maxdepth 1 -name '*Test' -type d -print0 | \
    xargs -0 -I "{}" sh -c "dotnet test {} \
        /p:CollectCoverage=true /p:CoverletOutput="/app/tests/coverage/$(basename {}).xml" \
        /p:CoverletOutputFormat=cobertura \
        --logger trx\\;LogFileName="/app/tests/nunit/$(basename {}).trx""

# Convert the nunit test results to junit
RUN find /app/tests/nunit -name '*.trx' \
    -exec sh -c 'java -jar Test/Tools/saxon9he.jar \
        -xsl:Test/Tools/trx-to-junit.xslt \
        -s:"$0" -o:"/app/tests/junit/$(basename ${0%.*}).xml"' {} \;