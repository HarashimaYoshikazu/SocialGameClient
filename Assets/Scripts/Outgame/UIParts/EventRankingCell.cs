using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventRankingCell : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _rankingText;

    public void SetText(string name,int ranking)
    {
        _nameText.text = name;
        _rankingText.text = ranking.ToString() + "位";
    }
}
