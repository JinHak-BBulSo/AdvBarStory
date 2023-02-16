using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrintItemList : MonoBehaviour
{
    List<GameObject> itemList = default;
    [SerializeField]
    public List<GameObject> btnList = default;
    public List<TMP_Text> textList = default;
    public List<Image> imageList = default;

    GameObject content = default;

    void Start()
    {
        content = gameObject.FindChildObj("Content");
        for(int i = 0; i < content.transform.childCount; i++)
        {
            btnList.Add(content.transform.GetChild(i).gameObject);
            textList.Add(content.transform.GetChild(i).GetChild(0).GetComponent<TMP_Text>());
            imageList.Add(content.transform.GetChild(i).GetChild(1).GetComponent<Image>());
            btnList[i].SetActive(false);
        }
    }

    public void OnClickEquipBtn()
    {

    }
    public void OnClickItemBtn()
    {

    }
    public void OnClickMaterialBtn()
    {

    }

    void FindItem(string _tag)
    {

    }
}
