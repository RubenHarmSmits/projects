FROM ubuntu

RUN apt-get -qqy update  \
        && apt-get -qqy install curl \
        && rm -rf /var/apt/lists/*

WORKDIR /

COPY . .

ENTRYPOINT [ "bash", "-c" ]
CMD ["/entrypoint.sh"]
