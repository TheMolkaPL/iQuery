# iQuery
TeamSpeak 3 Query connection API for C#.

```cs
TeamSpeakQuery client = new TeamSpeakQuery(); // new query object
client.Connect("127.0.0.1", 10011); // connect with given host and port
Client.Send(string.Format("login {0} {1}", "serveradmin", "password")) // send the login query
.OnResponse += (e) => // will be handled when we got the response
{
    if (e.GetCommand().GetCommandError().GetID() == 0)
    {
        Console.WriteLine("logged in");
        Client.Send("use", new Parameter("sid", 1));
        Client.Send("clientupdate", new Parameter("client_nickname", "its3Query"));
    }
    else 
    {
        Console.WriteLine("failed to log in");
    }
}
```

Check out [TeamSpeak 3 Query manual](http://media.teamspeak.com/ts3_literature/TeamSpeak%203%20Server%20Query%20Manual.pdf) to see the available queries.
