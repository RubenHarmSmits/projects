#!/bin/bash

# Docker compose configuration
COMPOSE_FILE_BASE="$(dirname "$0")/compose/docker-compose.yml"
export COMPOSE_PROJECT_NAME="lanthir-lunch"

# Application environment variables
#export STARTUP_DELAY=30
export MSSQL_SA_PASSWORD="w8ZkzkJL4UL9xrRp!"

# Set the standard compose with -f instead of COMPOSE_FILE to
# allow other files to be added on the command line
docker-compose -f "$COMPOSE_FILE_BASE" "$@"
