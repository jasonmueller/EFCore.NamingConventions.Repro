# Reproducing the issue

The issue happens regardless of database provider (presumably, tried PostgresQL and SqlServer).

The issue happens with or without a property on the derived type.  I added the propery
on the derived type just to provide a more realistic use case.

## Get prepared

### Delete the unbuildable files

First, delete the failing migrations or EF won't be able to build the project.
`rm .\Data\Migrations\*__WithOriginal*.cs`
`rm .\Data\Migrations\DatabaseModelSnapshot.cs`

### Install packages and tools (first time)

`dotnet restore`
`pushd .\Data; dotnet tool restore; popd`

## Reproduce

`cd .\Data`
`dotnet ef migrations add __WithOriginalConventions_WithSchema`

Review the `__WithOriginalConventions_WithSchema.Designer.cs`.  It won't build.
