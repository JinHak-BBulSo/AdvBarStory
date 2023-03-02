using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupSkillSlot : MonoBehaviour
{
    public TMP_Text tooltipTxt = default;
    public string tooltip = default;

    public TMP_Text skillNameTxt = default;
    public TMP_Text skillMpTxt = default;

    public void OnClickSlot()
    {
        tooltipTxt.text = tooltip;
    }
}
