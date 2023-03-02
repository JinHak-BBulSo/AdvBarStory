using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueBtn : MonoBehaviour
{
    private void Awake()
    {
        if(!DataManager.instance.isSaveDataExist)
        {
            gameObject.SetActive(false);
        }
        else
        {
            /*Do nothing*/
        }
    }

    public void OnClickContinue()
    {
        DataManager.instance.LoadData();
        PlayerManager.instance.player.transform.position = new Vector3(-0.5f, -3f, 0);

        SceneManager.LoadScene("02.TownScene");
    }
}
