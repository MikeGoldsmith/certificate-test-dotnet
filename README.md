# Couchbase TLS/SSL certificate test for .NET SDK

This is a test application that can be used to verify if a TLS/SSL certificate has been correctly configured and can be used to connect a Couchbase cluster using the .NET SDK.

## Building / Running

This is a .NET Core 2.0 Application and requires the [.NET SDK](https://dotnet.microsoft.com/download) to build / run. The following commands clone this repo, build the application and then run it.

```shell
git clone https://github.com/MikeGoldsmith/certificate-test-dotnet.git
cd certificate-test-dotnet
dotnet build
dotnet run -p certificate-test-dotnet/certificate-test-dotnet.csproj
```

## Config file

The json.config file has the following properies that are required:

| Property | Description |
| - | - |
| `cluster` | The URI used to connect to the cluster |
| `bucket` | The bucket name to open |
| `thumbprint` | The certificate thumbprint to use |
| `doc_id` | The document ID to try and retrieve |

## TODO

- Logging
