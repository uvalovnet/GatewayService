using Entities.Commands.Account;
using Entities.Commands.Game;
using Entities.Queries.Account;
using Microsoft.AspNetCore.SignalR.Client;
using static System.Runtime.InteropServices.JavaScript.JSType;

HubConnection connection1;
HubConnection connection2;
var commandsList = new Dictionary<string, Action>();
try
{
    connection1 = new HubConnectionBuilder().WithUrl("http://localhost:5294/account").Build();
    connection1.StartAsync().Wait();
}
catch
{
    connection1 = new HubConnectionBuilder().WithUrl("http://localhost:5000/account").Build();
    connection1.StartAsync().Wait();
}


//connection2 = new HubConnectionBuilder().WithUrl("http://localhost:5294/game").Build();
//connection2.StartAsync().Wait();

Console.WriteLine("s1 = SignInAsync");
Console.WriteLine("s2 = SignUpAsync");
Console.WriteLine();
Console.WriteLine("g1 = GetGameList");
Console.WriteLine("g2 = AddToTable");
Console.WriteLine("g3 = RemoveFromTable");
Console.WriteLine("g4 = TakeAction");

commandsList.Add("s1", () => connection1.InvokeAsync("SignInAsync", new RegAndAuthCommand("fsf", "fsf", "gdfg", "sff", null, "", "")));
commandsList.Add("s2", () => connection1.InvokeAsync("SignUpAsync", new RegAndAuthCommand("fsf", "fsf", "gdfg", "sff", null, "", "")));

//commandsList.Add("g1", () => connection2.InvokeAsync("GetGameList"));
//commandsList.Add("g2", () => connection2.InvokeAsync("AddToTable", new GameActionCommand("fsf", "fsf", "gdfg", "sff", "")));
//commandsList.Add("g3", () => connection2.InvokeAsync("RemoveFromTable", new GameActionCommand("fsf", "fsf", "gdfg", "sff", "")));
//commandsList.Add("g4", () => connection2.InvokeAsync("TakeAction", new GameActionCommand("fsf", "fsf", "gdfg", "sff", "")));

connection1.On("SomeError", () =>
{
    Console.WriteLine("SomeError");
});

connection1.On<User>("Auth", (user) =>
{
    Console.WriteLine(user.NickName);
});
connection1.On<string>("AuthError", (error) =>
{
    Console.WriteLine(error);
});
connection1.On<bool>("Reg", (isReg) =>
{
    Console.WriteLine(isReg);
});
connection1.On<string>("RegError", (error) =>
{
    Console.WriteLine(error);
});


while (true)
{
    try
    {
        var command = Console.ReadLine();
        commandsList[command].Invoke();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
