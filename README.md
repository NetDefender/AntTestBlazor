# Notes

Publish container for Blazor SSR + Blazor WebAssembly in the same web app.

Url

Generate image:

`dotnet publish AntTestBlazor/AntTestBlazor.csproj -p:PublishProfile=DefaultContainer -c Release`

Run locally:

`docker run -p 8081:8081 netdefender/blazor-ssr-ant:<Tag>`

Push:

```pwsh
echo "<token>" | docker login --username netdefender --password-stdin

docker image push netdefender/blazor-ssr:1.0.X
```