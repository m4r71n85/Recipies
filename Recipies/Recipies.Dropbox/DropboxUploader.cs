using System.Diagnostics;
using System.IO;
using Spring.Social.Dropbox.Api;
using Spring.Social.Dropbox.Connect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spring.Social.OAuth1;
using Spring.IO;

namespace Recipies.Dropbox
{
    public class DropboxUploader
    {
        private const string DropboxAppKey = "08fby1g84o3lznp";
        private const string DropboxAppSecret = "m2t18xrh24ffoc8";

        private const string OAuthTokenFileName = "OAuthTokenFileName.txt";

        private DropboxServiceProvider dropboxServiceProvider;

        public DropboxUploader()
        {
            this.dropboxServiceProvider =
                new DropboxServiceProvider(DropboxAppKey, DropboxAppSecret, AccessLevel.AppFolder);
        }

        public void Run(string fileName)
        {
            // Authenticate the application (if not authenticated) and load the OAuth token
            if (!File.Exists(OAuthTokenFileName))
            {
                AuthorizeAppOAuth();
            }
            OAuthToken oauthAccessToken = LoadOAuthToken();

            // Login in Dropbox
            IDropbox dropbox = dropboxServiceProvider.GetApi(oauthAccessToken.Value, oauthAccessToken.Secret);

            // Display user name (from his profile)
            DropboxProfile profile = dropbox.GetUserProfileAsync().Result;
            Console.WriteLine("Hi " + profile.DisplayName + "!");

            // Create new folder
            string newFolderName = "New_Folder_" + DateTime.Now.Ticks;
            Entry createFolderEntry = dropbox.CreateFolderAsync(newFolderName).Result;
            Console.WriteLine("Created folder: {0}", createFolderEntry.Path);

            // Upload a file

            /*Entry uploadFileEntry = dropbox.UploadFileAsync(
                new FileResource("../../DropboxExample.cs"),
                "/" + newFolderName + "/DropboxExample.cs").Result;
            Console.WriteLine("Uploaded a file: {0}", uploadFileEntry.Path);

            // Share a file
            DropboxLink sharedUrl = dropbox.GetShareableLinkAsync(uploadFileEntry.Path).Result;
            Process.Start(sharedUrl.Url);*/
        }

        private static OAuthToken LoadOAuthToken()
        {
            string[] lines = File.ReadAllLines(OAuthTokenFileName);
            OAuthToken oauthAccessToken = new OAuthToken(lines[0], lines[1]);
            return oauthAccessToken;
        }

        private void AuthorizeAppOAuth()
        {
            // Authorization without callback url
            //Console.Write("Getting request token...");
            OAuthToken oauthToken = dropboxServiceProvider.OAuthOperations.FetchRequestTokenAsync(null, null).Result;
            //Console.WriteLine("Done.");

            OAuth1Parameters parameters = new OAuth1Parameters();
            string authenticateUrl = dropboxServiceProvider.OAuthOperations.BuildAuthorizeUrl(
                oauthToken.Value, parameters);
            //Console.WriteLine("Redirect the user for authorization to {0}", authenticateUrl);
            Process.Start(authenticateUrl).WaitForExit();
            //Console.Write("Press [Enter] when authorization attempt has succeeded.");
            //Console.ReadLine();

            //.Write("Getting access token...");
            AuthorizedRequestToken requestToken = new AuthorizedRequestToken(oauthToken, null);
            OAuthToken oauthAccessToken =
                dropboxServiceProvider.OAuthOperations.ExchangeForAccessTokenAsync(requestToken, null).Result;
            //Console.WriteLine("Done.");

            string[] oauthData = new string[] { oauthAccessToken.Value, oauthAccessToken.Secret };
            File.WriteAllLines(OAuthTokenFileName, oauthData);
        }
    }
}
