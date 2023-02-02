using System.ComponentModel.DataAnnotations.Schema;

namespace Cobid.Api.Entities.Messaging;

public class Message
{
    public long MessageId { get; set; }
    public long ConversationId { get; set; }
    public int SenderId { get; set; }
    public string MessageContent { get; set; } = string.Empty;
    public string ImageData { get; set; } = string.Empty;
    public DateTime DateSent { get; set; }
    public bool IsRead { get; set; }
    public bool IsActive { get; set; }
}
