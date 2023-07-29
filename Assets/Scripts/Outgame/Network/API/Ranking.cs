using Cysharp.Threading.Tasks;
using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using static IGameAPIImplement;
using static Network.WebRequest;

namespace  Outgame
{
    [Serializable]
    public class APIResponceRankingUserInfo : APIResponceBase
    {
        public List<PointData> point;
        public List<UserNameData> userName;
    }

    [Serializable]
    public class PointData
    {
        public int point;
    }

    [Serializable]
    public class UserNameData
    {
        public string name;
    }

    public class APIResponceRankingLeaderboard : APIResponceBase
    {   
        
    }
    public class APIResponceRankingUpdate : APIResponceBase
    {   
        
    }
    
    public partial class NodeJSImplement : IGameAPIImplement
    {
        public async UniTask<APIResponceRankingUserInfo> RankingUserInfo()
        {
            string request = string.Format("{0}/ranking/userInfo?session={1}", GameSetting.GameAPIURI, _session);
            string json = await GetRequest(request);
            var res = GetPacketBody<APIResponceRankingUserInfo>(json);
            return res;
        }

        public async UniTask<APIResponceRankingLeaderboard> RankingLeaderboard()
        {
            string request = string.Format("{0}/ranking/leaderboard?session={1}", GameSetting.GameAPIURI, _session);
            string json = await GetRequest(request);
            APIResponceRankingLeaderboard res = GetPacketBody<APIResponceRankingLeaderboard>(json);
            return res;
        }
        
        public async UniTask<APIResponceRankingUpdate> RankingUpdate()
        {
            string url = string.Format("{0}/ranking/update", GameSetting.GameAPIURI);
            APIRequestBase request = CreateRequest<APIRequestBase>();
            string json = await PostRequest(url,request);
            APIResponceRankingUpdate res = GetPacketBody<APIResponceRankingUpdate>(json);
            return res;
        }
    }

    public partial class LocalImplement : IGameAPIImplement
    {
        public async UniTask<APIResponceRankingUserInfo> RankingUserInfo()
        {
            //ローカルテストを想定しないパケット
            return await UniTask.RunOnThreadPool(() => default(APIResponceRankingUserInfo));
        }

        public async UniTask<APIResponceRankingLeaderboard> RankingLeaderboard()
        {
            return await UniTask.RunOnThreadPool(() => default(APIResponceRankingLeaderboard));
        }
        public async UniTask<APIResponceRankingUpdate> RankingUpdate()
        {
            return await UniTask.RunOnThreadPool(() => default(APIResponceRankingUpdate));
        }
    }
}
