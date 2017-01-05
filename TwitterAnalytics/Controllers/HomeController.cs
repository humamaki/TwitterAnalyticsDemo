using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;
using TwitterAnalytics.Models;

namespace TwitterAnalytics.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                // Set up your credentials (https://apps.twitter.com)
                Auth.SetUserCredentials("QpjkaVSPjeLRRvgKNQQqjsTz9", "OOLtYJKrBUZ3kE6eVteeQtDveryVa6cfsYGr1ih84gBeNYplvy", "813434345390309376-HQ5WWOVhyiQ3Wx0UdoF6UEzWfJa0L7r", "GkfjLUw2YMHzJqZqRFskWqTRNro35KTsn8SqZpm2KlWKr");

                // Publish the Tweet "Hello World" on your Timeline
                Tweetinvi.Tweet.PublishTweet("Hello World! Time is " + DateTime.Now);

                var searchParameter = new SearchTweetsParameters(28.950143, -81.771183, 200, DistanceMeasure.Miles);

                var tweets = Search.SearchTweets(searchParameter);

                StringBuilder query = new StringBuilder();

                foreach (var item in tweets)
                {
                    query.AppendLine(string.Format("INSERT INTO Tweet (JobId, TweetText, CreatedBy) Value (1, {0}, {1}, {2})", item.Text, item.CreatedBy, item.Place));
                }

                using (var ctx = new TwitterDemoEntities())
                {

                    ctx.Database.SqlQuery<int>(query.ToString());
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
    }
}