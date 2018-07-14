# rateanime

I wrote this to help me rate anime better. It's in F#, because I felt like doing it that way.

## How Rating Works
Anime are rated in five categories: Art, Sound, Character, Plot, and Enjoyment.

Each category is weighted according the following percentages:

- Art: 11%
- Sound: 11%
- Character: 12%
- Plot: 26%
- Enjoyment: 40%

When you run the program, you will be prompted to rate each category on a scale of 1.0 to 5.0.

You can enter integers or decimal numbers.

After each category is rated they are weighted, added together, scaled to 1 to 10, and rounded down to the nearest 0.5.

## Running

To run this, first of all make sure you have .NET Core installed. Then, you can run by calling `dotnet run`.

Running `dotnet run help` will output some information regarding how rating works.

## Compiling to Executable

If you are on Windows 10 x64, you can run `dotnet publish -c Release -r win10-x64` to create a .exe (which should be in bin/Release/../../rateanime.exe).

For information on how to create an executable for your specific OS and architecture, see https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish?tabs=netcore21.

Similar to when running via `dotnet`, you can run `rateanime help` to get additional information.

## License

This application is licensed under the [MIT License](LICENSE).
