using System;
using System.Collections.Generic;
using System.Linq;


public class Message
{
    public int Id { get; set; }
    public string Text { get; set; }
    public bool IsRead { get; set; }
}


public class MessageContext : DbContext
{
    public DbSet<Message> Messages { get; set; }
}


public List<Message> GetUnreadMessages(int clientId)
{
    using (var context = new MessageContext())
    {
        List<Message> unreadMessages = context.Messages.Where(m => !m.IsRead && m.ClientId == clientId).ToList();
        return unreadMessages;
    }
}


List<Message> unreadMessages = GetUnreadMessages(1);

/
foreach (var message in unreadMessages)
{
    Console.WriteLine(message.Text);
}