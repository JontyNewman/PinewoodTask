# Pinewood Technologies – Technical Task

This is my attempt at the technical task as specified by Pinewood Technologies.

## Quickstart

The solution uses an in-memory database and has two startup projects, namely WebApi and WebUi. You can [set multiple startup projects in Visual Studio](https://learn.microsoft.com/en-us/visualstudio/ide/how-to-set-multiple-startup-projects).

Alternatively, the two projects can be run concurrently using the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

```sh
cd path/to/WebApi
dotnet run
```

```sh
cd path/to/WebUi
dotnet run
```

If you are using the .NET CLI, you will need to **amend the `HttpCustomerRepository.BaseAddress` in `appSettings.Development.json` for WebUi**.

