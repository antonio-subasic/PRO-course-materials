const int WAGON_PASSENGER = 1;
const int WAGON_LOCOMOTIVE = 2;

var myWagon = WAGON_LOCOMOTIVE;
var myNewWagon = WagonType.Locomotive;

Console.WriteLine(myWagon);
Console.WriteLine(myNewWagon);
Console.WriteLine((int)myNewWagon);

WagonType myOtherWagon = (WagonType)5;
Console.WriteLine(myOtherWagon);

var fileMode = FileMode.Read | FileMode.Write;
Console.WriteLine(fileMode);
Console.WriteLine((fileMode & FileMode.Read) == FileMode.Read);
Console.WriteLine((fileMode & FileMode.DeleteOnClose) == FileMode.DeleteOnClose);

fileMode = (FileMode)0b1111;
Console.WriteLine(fileMode);

enum WagonType
{
    Passenger,
    Locomotive,
    CarTransport = 5
}

[Flags]
enum FileMode
{
    Read = 0b0001,
    Write = 0b0010,
    CreateIfNotExists = 0b0100,
    DeleteOnClose = 0b1000
}
