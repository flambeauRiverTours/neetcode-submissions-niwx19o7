public class Twitter {

    public Twitter() {
        idToFollowedUsersList = new Dictionary<int, HashSet<int>>();
        tweetIdToUserId = new Dictionary<int, int>();
        tweets = new List<int>();
    }
    private Dictionary<int, HashSet<int>> idToFollowedUsersList;
    private Dictionary<int, int> tweetIdToUserId;
    private List<int> tweets;
    public void PostTweet(int userId, int tweetId) {
        tweets.Add(tweetId);
        tweetIdToUserId[tweetId] = userId;
    }
    
    public List<int> GetNewsFeed(int userId) {
        List<int> result = new List<int>();
        if(!idToFollowedUsersList.ContainsKey(userId)){
            SetUpFollowers(userId);
        }
        for(int tweetIndex = tweets.Count - 1; tweetIndex >=0; tweetIndex--){
            if(idToFollowedUsersList[userId].Contains(tweetIdToUserId[tweets[tweetIndex]])){
                result.Add(tweets[tweetIndex]);
                if(result.Count == 10) {return result;}
            }
        }
        return result;
    }


    private void SetUpFollowers(int followerId){
        if(!idToFollowedUsersList.ContainsKey(followerId)){
            idToFollowedUsersList[followerId] = new HashSet<int>();
            idToFollowedUsersList[followerId].Add(followerId);
        }
    }
    
    public void Follow(int followerId, int followeeId) {
        SetUpFollowers(followerId);
        idToFollowedUsersList[followerId].Add(followeeId);
    }
    
    public void Unfollow(int followerId, int followeeId) {
        if(followerId == followeeId) {return;}
        idToFollowedUsersList[followerId].Remove(followeeId);
    }
}


