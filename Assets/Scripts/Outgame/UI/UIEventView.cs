using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outgame
{
    public class UIEventView : UIStackableView
    {
        protected override void AwakeCall()
        {
            ViewId = ViewID.Event;
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
            UIManager.NextView(ViewID.EventRanking);
        }
        
        public void Back()
        {
            UIManager.Back();
        }
    }
}

