# honestus
Versioning helper command line utility

## Usage examples
### Stamp `*.rc` files
Read version string from file `version.txt` and replace both `File Version` and `Product Version` attributes in resource file `ExampleProject.rc`:

`honestus --version-from-file version.txt --target-file "%solution%\ExampleProject\ExampleProject.rc" --resource.file-version --resource.product-version`

### Stamp .NET `AssemblyInfo`
Read version string from file `version.txt` and replace both `AssemblyVersion` and `AssemblyFileVersion` attributes in `AssemblyInfo.cs`:

`honestus --version-from-file version.txt --target-file "%solution%\ExampleProject\Properties\AssemblyInfo.cs" --assembly.version --assembly.file-version`

### Stamp Windows Driver Project
Read version string from file `version.txt` and replace `TimeStamp` attribute in `ExampleProject.vcxproj`:

`honestus --version-from-file version.txt --target-file "%solution%\ExampleProject\ExampleProject.vcxproj" --vcxproj.inf-time-stamp`
