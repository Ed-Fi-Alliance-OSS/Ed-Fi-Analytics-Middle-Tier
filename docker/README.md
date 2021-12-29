# Ed-Fi-Analytics-Middle-Tier docker local configuration

This docker container satisfies the user story:
> As an AMT developer, I want to run integration tests using PostgreSQL and SQL Server in Docker containers on my localhost.

To build and run this container follow this steps:

- run in terminal
> docker-compose build
- when container is created, run the following in terminal
> docker-compose up

Docker Compose will start the container service in your computer.

If you need to configure specific databases configuration, you can go to .env files to change SQL engines variables.

## Legal Information

Copyright (c) 2020 Ed-Fi Alliance, LLC and contributors.

Licensed under the [Apache License, Version 2.0](LICENSE) (the "License").

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

See [NOTICES](NOTICES.md) for additional copyright and license notifications.