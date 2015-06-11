using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinApp1.Modello;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinApp1.Droid.Servizi.RepositoryVideoRestSharp))]
namespace XamarinApp1.Droid.Servizi
{
    public class RepositoryVideoRestSharp : IRepositoryVideo
    {
        public IEnumerable<Video> Elenca()
        {
            var client = new RestSharp.RestClient("https://www.googleapis.com");
            var request = new RestSharp.RestRequest("youtube/v3/search", RestSharp.Method.GET);
            request.AddParameter("key", "API_KEY_HERE");
            request.AddParameter("channelId", "CHANNEL_ID_HERE");
            request.AddParameter("part", "snippet,id");
            request.AddParameter("order", "date");
            request.AddParameter("maxResults", "20");
            var response = client.Execute<RisultatiVideo>(request);
            return response.Data.items.Select(i => new Video {
                Nome = i.snippet.title,
                Immagine = ImageSource.FromUri(new Uri(i.snippet.thumbnails.medium.url)),
                Link = string.Format("http://www.youtube.com/watch?v={0}", i.id.videoId)
            });
        }
    }
}