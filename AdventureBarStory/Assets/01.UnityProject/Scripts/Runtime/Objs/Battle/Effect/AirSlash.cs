using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSlash : MonoBehaviour
{
    Rigidbody2D airRigid = default;

    public Vector2 targetPos = default;
    public GameObject target = default;
    float speed = 500;
    Vector2 initPos = new Vector2(-21, -93);
    Vector2 dir = default;

    RectTransform rect = default;
    Animator ani = default;
    void Awake()
    {
        airRigid = GetComponent<Rigidbody2D>();
        rect = gameObject.GetRect();
        ani = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        target = BattleCursor.battleTile.onTileObject;
        targetPos = target.transform.parent.gameObject.GetRect().anchoredPosition;

        gameObject.GetRect().anchoredPosition = new Vector2(-21, -93);

        dir = targetPos - initPos;
        float z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);

        airRigid.velocity = dir.normalized * speed;
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == target.name)
        {
            ani.SetBool("isHit", true);
            StartCoroutine(SetActiveFalse());
            airRigid.velocity = Vector2.zero;

            Player player = BattleManager.instance.nowTurnPlayer.GetComponent<Player>();
            int _hitDamage = (int)(player.status._hit * 1.4f);
            target.GetComponent<Character>().Hit(_hitDamage);
        }
    }

    IEnumerator SetActiveFalse()
    {
        yield return new WaitForSeconds(0.3f);
        ani.SetBool("isHit", false);
        gameObject.SetActive(false);
    }
}
