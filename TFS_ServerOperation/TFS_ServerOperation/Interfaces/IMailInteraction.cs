
namespace TFS_ServerOperation
{
    public interface IMailInteraction
    {
        bool SendEmail(string to, string subject, string body, string attachmentFilename);
    }
}
