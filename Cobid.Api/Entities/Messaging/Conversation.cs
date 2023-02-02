using System.ComponentModel.DataAnnotations.Schema;

namespace Cobid.Api.Entities.Messaging;

public class Conversation
{
    public long ConversationId { get; set; }
    public long ProductId { get; set; }
    public int CreatedById { get; set; }
    public int ReceiverId { get; set; }
    public DateTime DateCreated { get; set; }
    public List<Message> Messages { get; set; } = new List<Message>();
    public string ConversationTitle { get; set; } = string.Empty;
    public bool IsRead { get; set; }
    public bool IsActive { get; set; }
}
