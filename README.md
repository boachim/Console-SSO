# Console-SSO

A console application that demonstrates SSO login using both MSHTML WebBrowser and WebView2.

## Configuration

The application requires configuration of the target URL before use:

1. Open `Console-SSO/App.config`
2. Update the `ApplicationUrl` value in the `appSettings` section:

```xml
<appSettings>
    <add key="ApplicationUrl" value="https://your-application-url.com/" />
</appSettings>
```

3. Build and run the application

## Security Notes

- **Never commit** sensitive URLs or credentials directly in the code
- Use `App.config` for environment-specific settings
- For production deployments, consider using environment variables or Azure Key Vault
- The `App.config.example` file provides a template for configuration

## Usage

Run the application and choose from the menu:
1. Login with MSHTML - Uses the legacy WebBrowser control
2. Login with WebView2 - Uses the modern WebView2 control
3. Exit

## Requirements

- .NET Framework 4.7.2 or higher
- Microsoft WebView2 Runtime (for option 2)
