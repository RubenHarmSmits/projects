#!/bin/bash

if [ $# -ne 2 ]; then
    echo >&2 "Usage: $0 <service> <image>"
    exit 1
fi

cat <<EOF
spec:
    template:
        metadata:
            annotations:
                updated_at: \"$(date '+%s')\"
        spec:
            containers:
                - name: \"$1\"
                  image: \"$2\"
EOF
