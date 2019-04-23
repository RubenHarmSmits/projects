#!/bin/bash

# Script that will run the integration tests
# after making sure the application starts correctly using its
# health check.

SERVICE_URL="http://services:80"
HEALTH_CHECK="$SERVICE_URL/health"
HEALTH_TIMEOUT=180

# Print the error message and exit
err() {
    echo 1>&2 "$1"
    exit "${2:-1}"
}

# Wait for a fixed delay before running the test suite
if [[ -n "$WAIT_TIME" ]]; then
    echo "Sleeping $WAIT_TIME seconds"
    sleep "$WAIT_TIME"
fi

# Wait until the container returns the healthy status
# or fail the test when the timeout is reached
TIME_ELAPSED=0
while [[ "$(curl -so /dev/null -w '%{http_code}' "$HEALTH_CHECK")" != "200" ]]; do
    echo "Waited $TIME_ELAPSED/$HEALTH_TIMEOUT seconds for $HEALTH_CHECK"
    TIME_ELAPSED=$(( $TIME_ELAPSED + 5 ))
    if (( $TIME_ELAPSED > $HEALTH_TIMEOUT )); then
        err "Timeout reached"
    fi
    sleep 5
done

echo "Healthy status after $TIME_ELAPSED seconds"

# Integration tests here

echo "Test succeeded" && exit 0
