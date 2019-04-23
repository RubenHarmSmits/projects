# Build

This directory contains files related to the build process and development environment.

## On Windows

See https://docs.docker.com/docker-for-windows/

An easy way to use docker on Windows is to create a Linux VM and configure the docker client to use the remote daemon. The [`docker-machine`](https://docs.docker.com/machine/get-started/) tool can also be used to create docker VMs based on Virtualbox or Hyper-V and to setup the client.

## Docker compose

Docker compose provides a way to manage applications consisting of multiple containers that can be used as a way to quickly setup the application stack. [`docker-compose.yml`](./docker-compose.yml) contains the definitions of the containers that make up the application and describes additional resources such as networking and storage. See the [documentation](https://docs.docker.com/compose/) and [installation instructions](https://docs.docker.com/compose/install/).

The [`compose-run.sh` file](./compose.run.sh) is a wrapper script used for setting up the environment. It should be used instead of `docker-compose` for this project. The docker environment such as `DOCKER_HOST` can also be specified here.

Docker compose provides several commands which are often similar to the docker command-line. For example:

- `docker-compose build` rebuilds the images
- `docker-compose up` starts the application stack
- `docker-compose down` stops the application stack
- `docker-compose [cmd] --help` provides a list of commands and options

### Application environment

The [application stack](./docker-compose.yml) consists of the following containers:

- `services`: The API server built from the Services dockerfile with the debug configuration;
    - Maps ports 80 and 443 to a random port on the host which can be access with `compose-run.sh port services [80|443]`;
    - Can be rebuilt and restarted with `compose-run.sh up --force-recreate --build services`.
- `mssql-db`: The SQL Server database used by the API server.

## Jenkinsfile

The Jenkins [build pipeline](./Jenkinsfile) uses a declerative configuration and multibranch project. It builds the `master`, `develop` and `feature/*` branches but ignores any branches prefixed with `temp`. It handled the entire CD pipeline and will deploy `develop` to the staging and `master` to the production environments.