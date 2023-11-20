# Analytics Middle Tier installation with docker container.

- [Analytics Middle Tier installation with docker container.](#analytics-middle-tier-installation-with-docker-container)
  - [Prerequisites](#prerequisites)
  - [Overview](#overview)
  - [The creation of the image](#the-creation-of-the-image)
  - [Container execution](#container-execution)

*[Back to main readme](../readme.md)*  

## Prerequisites
The only prerequisites to install Analytics Middle Tier using the docker image is to have Docker installed.

## Overview
With the Dockerfile in the root folder we packaged the Analytics Middle Tier and all its dependencies.

With a simple helper script, this allows you to install Analytics Middle Tier without having to install the dependencies on your host machine.

## The creation of the image
To create the image go to the root folder, you will see a file with name Dockerfile.

Open a terminal on this folder and execute this command.

```powershell
docker build -t <image_name> .
```

Where 
* `<image_name>` is the name you want for the image.

For Example:
```powershell
docker build -t amt_image_installer .
```

At this point the image has been created. You can enter:

```powershell
docker images amt_image_installer
```

and the image must be listed. This is how you can confirm the image has been created.

## Container execution

Once the image has been created. By running the container the installer is executed as well. Just execute:

```powershell
docker run <image_name> --connectionString <connection_string> --options <options>
```

Where
* `<image_name>` is the name you gave to the image,
* `<connection_string>` is the connection string to get connected to the ODS where you want to install the AMT.
* And `<options>` are the options you want to include with the installation.

For Example:
```powershell
docker run amt_image_installer --connectionString "Data Source=localhost;Initial Catalog=EdFi_Ods;Trusted_Connection=False;User ID=username;Password=mypassword;" --options Indexes
```

And that is all you have to do to build and install install Analytics Middle Tier.