# Hetzner Cloud API .NET Library
[![.NET Version](https://img.shields.io/badge/dotnet%20versions-net5.0_to_net10.0-blue?style=flat-square)](https://www.nuget.org/packages/HCloudAPI/#supportedframeworks-body-tab)
[![License](https://img.shields.io/github/license/Skorplul/HCloudAPI.svg?style=flat-square)](https://github.com/Skorplul/HCloudAPI/blob/main/LICENSE)
[![Build](https://github.com/Skorplul/HCloudAPI/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Skorplul/HCloudAPI/actions/workflows/dotnet.yml)
[![NuGet Downloads](https://img.shields.io/nuget/dt/HCloudAPI)](http://www.nuget.org/packages/HCloudAPI/)
[![NuGet](https://img.shields.io/nuget/v/HCloudAPI.svg?style=flat-square)](http://nuget.org/packages/HCloudAPI)
---

This a .NET library made for .NET frameworks 5.0 to 10.0, which gives you the ability to use the Hetzner Cloud API easily.<br>
I am currently working on including more quality of life improvements, as the library only really supplies general communication between API and the user at the moment.<br>
If you have any problems or suggestions, feel free to open an issue :)

## Installation
.NET CLI
```shell
dotnet add package HCloudAPI --version 1.0.2
```
PackageReference
```xml
<PackageReference Include="HCloudAPI" Version="1.0.2" />
```
---
## Example of how to use the API
```cs
using HCloudAPI;
using HCloudAPI.Model;

namespace YourProject
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Client client = new HCloudAPI.Client(Config.token);
            
            var newServer = new CreateServerRequest(
                "Foo", // Server Name
                "cpx12", // Server Type
                "ubuntu-26.04", // Image
                "fsn1" // Location
            );

            var request = await _client.ServersApi.CreateServerAsync(newServer);
            var result = request.Created();
            
            await _client.ActionsApi.WaitForAction(result.Action);
            
            var serverRequest = await _client.ServersApi.GetServerOrDefaultAsync(result.Server.Id);
            
            if (serverRequest == null)
            {
                Console.WriteLine("Request Failed");
                return;
            }
            
            var serverResult = serverRequest.Ok();
            
            if (serverResult != null)
            {
                if (serverResult.Server != null)
                {
                    Console.WriteLine($"server is called {serverResult.Server.Name}");
                }
                else
                {
                    Console.WriteLine($"server not found");
                }
            }
        }
    }
}
```
---
### API Information
Full documentation for this library can be found [HERE](https://skorplul.github.io/HCloudAPI/) <br>
Full documentation for the entire Hetzner Cloud API can be found [HERE](https://docs.hetzner.cloud/reference/cloud)

### Credit
This library was created with the help of the [OpenAPI Generator](https://openapi-generator.tech) project.
