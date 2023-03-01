using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemGetTxt : MonoBehaviour, IPointerClickHandler
{
    public AudioSource getItemAudio = default;

    void OnEnable()
    {
        getItemAudio.Play();
        PlayerManager.instance.player.GetComponent<PlayerController>().enabled = false;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        PlayerManager.instance.player.GetComponent<PlayerController>().enabled = true;
        gameObject.SetActive(false);
    }
}
