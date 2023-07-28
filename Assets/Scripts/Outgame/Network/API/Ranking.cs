using Cysharp.Threading.Tasks;
using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static IGameAPIImplement;
using static Network.WebRequest;

namespace  Outgame
{
    public class APIResponceRankingUserInfo : APIResponceBase
    {
        public int point;
        public string name;
    }
    
    public partial class NodeJSImplement : IGameAPIImplement
    {
        public async UniTask<APIResponceRankingUserInfo> RankingUserInfo()
        {
            string request = string.Format("{0}/ranking/userInfo", GameSetting.GameAPIURI);

            string json = await GetRequest(request);
            APIResponceRankingUserInfo res = GetPacketBody<APIResponceRankingUserInfo>(json);
            Debug.Log($"ポイント{res.point},名前{res.name}");
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
    }
}
