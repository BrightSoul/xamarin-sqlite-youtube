using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinApp1.Modello;
using Xamarin.Forms;

namespace XamarinApp1.ViewModels
{
    public class VideoVM
    {
        private readonly IRepositoryVideo repo;
        public VideoVM()
        {
            repo = DependencyService.Get<IRepositoryVideo>();
        }

        private IEnumerable<Video> video;
        public IEnumerable<Video> Video
        {
            get
            {
                if (video == null)
                {
                    video = repo.Elenca();
                }
                return video;
            }
        }
    }
}
