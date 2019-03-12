using System.ServiceModel.Channels;

namespace Exhibition.Core
{
    public class NewtonsoftJsonContentTypeMapper : WebContentTypeMapper
    {
        public override WebContentFormat GetMessageFormatForContentType( string contentType )
        {
            return WebContentFormat.Raw;
        }
    }
}