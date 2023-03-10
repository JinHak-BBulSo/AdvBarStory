using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BattleTile : MonoBehaviour, ISelectHandler , IDeselectHandler
{
    private GameObject battleCursor = default;
    private GameObject fillTile = default;
    private Vector2 cursorOffset = new Vector2(0, 180);

    public GameObject onTileObject = default;

    void Start()
    {
        battleCursor = GameObject.Find("BattleObjs").FindChildObj("BattleCursor");
        fillTile = gameObject.FindChildObj("FillBattleTile");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnSelect(BaseEventData eventData)
    {
        battleCursor.GetRect().anchoredPosition = gameObject.GetRect().anchoredPosition + cursorOffset;
        BattleCursor.battleTile = GetComponent<BattleTile>();
        fillTile.SetActive(true);
    }
    public void OnSelect()
    {
        battleCursor.GetRect().anchoredPosition = gameObject.GetRect().anchoredPosition + cursorOffset;
        BattleCursor.battleTile = GetComponent<BattleTile>();
        fillTile.SetActive(true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        fillTile.SetActive(false);
    }
    public void OnDeselect()
    {
        fillTile.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Effect") return;
        onTileObject = collision.gameObject;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Effect") return;
        onTileObject = default;
    }
}
