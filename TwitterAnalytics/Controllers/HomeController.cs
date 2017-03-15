using System;
using System.Data.SqlClient;
using System.Text;
using System.Web.Mvc;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;
using TwitterAnalytics.Models;

namespace TwitterAnalytics.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(TweetSearch searchParam)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SearchTweets(searchParam);
                }

                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
     
        public ActionResult SearchTweets(TweetSearch searchParam)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Auth.SetUserCredentials("QpjkaVSPjeLRRvgKNQQqjsTz9", "OOLtYJKrBUZ3kE6eVteeQtDveryVa6cfsYGr1ih84gBeNYplvy", "813434345390309376-HQ5WWOVhyiQ3Wx0UdoF6UEzWfJa0L7r", "GkfjLUw2YMHzJqZqRFskWqTRNro35KTsn8SqZpm2KlWKr");

                    var searchParameter = new SearchTweetsParameters(new GeoCode(searchParam.Lat, searchParam.Long, searchParam.Radius, DistanceMeasure.Miles))
                    { 
                        MaximumNumberOfResults = 50000
                    };

                    var tweets = Search.SearchTweets(searchParameter);

                    StringBuilder query = new StringBuilder();

                    DateTime CreatedDate = DateTime.Now;

                    foreach (var item in tweets)
                    {
                        using (var ctx = new TwitterDemoEntities())
                        {
                            string commandText = @" INSERT INTO dbo.TweetInfo (TwitterId, JobId, TweetText, CreatedBy, Favorited, FavoriteCount, Retweeted, RetweetCount, CreatedDate) 
                                                    Values (@TwitterId, @JobId, @TweetText, @CreatedBy, @Favorited, @FavoriteCount, @Retweeted, @RetweetCount, @CreatedDate);";

                            ctx.Database.ExecuteSqlCommand(commandText,
                                                           new SqlParameter("@TwitterId", item.Id),
                                                           new SqlParameter("@JobId", "1"),
                                                           new SqlParameter("@TweetText", item.FullText.ToString()),
                                                           new SqlParameter("@CreatedBy", item.CreatedBy.ToString()),
                                                           new SqlParameter("@Favorited", item.Favorited.ToString()),
                                                           new SqlParameter("@FavoriteCount", item.FavoriteCount.ToString()),
                                                           new SqlParameter("@Retweeted", item.Retweeted.ToString()),
                                                           new SqlParameter("@RetweetCount", item.RetweetCount.ToString()),
                                                           new SqlParameter("@CreatedDate", CreatedDate));
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "One or more fields have been");
                }
            }
            catch (Exception)
            {

                throw;
            }

            return View();
        }
    }
}