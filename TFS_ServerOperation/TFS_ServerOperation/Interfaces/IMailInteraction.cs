
namespace TFS_ServerOperation
{
    interface IMailInteraction
    {
        bool SendEmail(string to, string subject, string body, string attachmentFilename);
    }
}
