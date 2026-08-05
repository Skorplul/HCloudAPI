# Using the library in your project
```cs
using HCloudAPI;
using HCloudAPI.Model;

namespace YourProject
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Client client = new HCloudAPI.Client(/* Your Hetzner Cloud API Token Here */);
            
            /*
            Your Program Logic
            */
        }
    }
}
```

## Questions

- Q: How are tokens used?<br>
  A: Tokens are provided by a TokenProvider class. The default is RateLimitProvider which will perform client side rate limiting.
  Other providers can be used with the UseProvider method.<br><br>
- Q: Does an HttpRequest throw an error when the server response is not Ok?<br>
  A: It depends how you made the request. If the return type is ApiResponse<T> no error will be thrown, though the Content property will be null.
  StatusCode and ReasonPhrase will contain information about the error.
  If the return type is T, then it will throw. If the return type is TOrDefault, it will return null.<br>

## API Information
- Name: Hetzner Cloud API
- Version: 1.0.0

---
### Credit
This library was created with the help of the [OpenAPI Generator](https://openapi-generator.tech) project.
