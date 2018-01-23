# RemoveVSPackage

RemoveVSPackage is remove old component from VS2017 offline installer image. 

## Installing

Just install expand zip file and store anywhere. This tool must require .NET Core 2.0 runtime.

## Build

```
dotnet build  --configuration "Release" removeoldpackage.sln
```

## Execute 

### Command line
```
dotnet removeoldpackage.dll "target folder"
```

### Execute image

![before folder](images\beforeimage.png)

before folder.

![after folder](images\afterimage.png)

after folder. 

## Changelog

###  1.0 
Initial Release