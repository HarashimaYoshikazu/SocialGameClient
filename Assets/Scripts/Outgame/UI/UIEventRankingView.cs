using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Outgame
{
    public class UIEventRankingView : UIStackableView
    {
        [SerializeField,Header("自分のランキングを表示するText")] private TextMeshProUGUI _rankingText;

        [SerializeField,Header("ランキングの生成先")] private Transform _rankingRoot;
        [SerializeField, Header("ランキングプレハブ")] private EventRankingCell _rankingCellPrefab; 
        protected override void AwakeCall()
        {
            ViewId = ViewID.EventRanking;
            _hasPopUI = true;
        }

        public override void Enter()
        {
            base.Enter();
            UIStatusBar.Hide();

            
            
            Debug.Log(EventHelper.GetAllOpenedEvent());
            Debug.Log(EventHelper.IsEventOpen(1));
            Debug.Log(EventHelper.IsEventGamePlayable(1));
        }

        public void EventQuest()
        {
            
        }

        public void GoRankingView()
        {
            
        }
        
        public void Back()
        {
            UIManager.Back();
        }

        private async void GetRanking()
        {
            await GameAPI.API.RankingUserInfo();
        }
    }
}