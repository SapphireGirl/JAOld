using System;
using System.IO;

namespace PubSub
{
    public class Class1
    {
        // https://cloud.google.com/pubsub/docs/overview
        //void createClient(String private_key_file, String email) 
        //throws IOException, GeneralSecurityException {
        //    HttpTransport transport = GoogleNetHttpTransport.newTrustedTransport();
        //    GoogleCredential credential = new GoogleCredential.Builder()
        //        .setTransport(transport)
        //        .setJsonFactory(JSON_FACTORY)
        //        .setServiceAccountScopes(PubsubScopes.all())
        //        .setServiceAccountId(email)
        //        .setServiceAccountPrivateKeyFromP12File(new File(private_key_file))
        //        .build();
        //    pubsub = new Pubsub.Builder(transport, JSON_FACTORY, credential)
        //        .setApplicationName("eaipubsub")
        //        .build();
    }
}
