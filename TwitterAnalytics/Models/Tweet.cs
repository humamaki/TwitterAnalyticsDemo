//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TwitterAnalytics.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tweet
    {
        public int TweetId { get; set; }
        public long TwitterId { get; set; }
        public int JobId { get; set; }
        public string TweetText { get; set; }
        public string CreatedBy { get; set; }
        public string Place { get; set; }
        public int FollowersCount { get; set; }
        public bool Favorited { get; set; }
        public int FavoriteCount { get; set; }
        public bool ReTweeted { get; set; }
        public int RetweetCount { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
