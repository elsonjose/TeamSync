## Project Creation

- Following a DDD using the tutoral - https://www.youtube.com/watch?v=fhM0V2N1GpY&list=PLzYkqgWkHPKBcDIP5gzLfASkQyTdy0t4k
- Added extention - NuGet Reverse Package Search ("Add Package" support)

<hr>

The launchSetting.json file in Api/Properties is the set of configuration file for running the project on the development machine. There are 2 servers.
- IIS Express (Windows)
- Kersal (Linux/Mac)
The file has several profile. One of them can be used to run the project. The file also contains settings for IIS express server.

<hr>

Each layer should be responsible for injecting the required services. Hence created a static class in Application layer so that the Authentication service is injected from the application layer and not the api layer. 

<hr>
JWT key generation - https://randomgenerate.io/encryption-key-generator

<hr>
The infrastructure is referenced to api for dependency injection