using System.Runtime.CompilerServices;

// Handling InternalsVisibleTo in new .csproj
// https://stackoverflow.com/questions/42810705/visual-studio-2017-new-csproj-internalsvisibleto
[assembly: InternalsVisibleTo("TestStack.Dossier.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")] 