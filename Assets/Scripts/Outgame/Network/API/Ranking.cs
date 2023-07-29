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

    [Serializable]
    public class APIResponceRankingLeaderboard : APIResponceBase
    {   
        //public List<PointData>
    }

    public class RankingInfo
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
        
        public async UniTask<APIResponceBase> RankingUpdate()
        {
            string url = string.Format("{0}/ranking/update", GameSetting.GameAPIURI);
            APIRequestBase request = CreateRequest<APIRequestBase>();
            string json = await PostRequest(url,request);
            APIResponceBase res = GetPacketBody<APIResponceBase>(json);
            return res;
        }
        public async UniTask<APIResponceBase> RankingJoin()
        {
            string url = string.Format("{0}/ranking/join", GameSetting.GameAPIURI);
            APIRequestBase request = CreateRequest<APIRequestBase>();
            string json = await PostRequest(url,request);
            APIResponceBase res = GetPacketBody<APIResponceBase>(json);
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
        public async UniTask<APIResponceBase> RankingUpdate()
        {
            return await UniTask.RunOnThreadPool(() => default(APIResponceBase));
        }
        public async UniTask<APIResponceBase> RankingJoin()
        {
            return await UniTask.RunOnThreadPool(() => default(APIResponceBase));
        }
    }
}
