using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    Rigidbody2D airRigid = default;

    public Vector2 targetPos = default;
    public GameObject target = default;
    public float speed = 500;
    public Vector2 initPos = new Vector2(0, 0);
    public float delay = 0.3f;
    public AudioSource effectAudio = default;
    public int _damage = default;
    public bool isMagic = false;
    
    Vector2 dir = default;

    Animator ani = default;
    void Awake()
    {
        airRigid = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        target = BattleCursor.battleTile.onTileObject;
        targetPos = target.transform.parent.gameObject.GetRect().anchoredPosition;
        
        if(gameObject.name == "FlashLight" || gameObject.name == "Heal")
        {
            if(gameObject.name == "Heal")
                targetPos = target.transform.gameObject.GetRect().anchoredPosition;

            initPos = targetPos;
            gameObject.GetRect().anchoredPosition = initPos;
            return;
        }

        gameObject.GetRect().anchoredPosition = initPos;
        dir = targetPos - initPos;
        float z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);

        airRigid.velocity = dir.normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == target.name)
        {
            if (ani != default || gameObject.name == "Heal")
            {
                ani.SetBool("isHit", true);
                StartCoroutine(HideEffect(delay));
                airRigid.velocity = Vector2.zero;
                return;
            }
            StartCoroutine(HideEffect(delay));
            airRigid.velocity = Vector2.zero;
            effectAudio.Play();

            if(!isMagic)
                target.GetComponent<Character>().Hit(_damage);
            else
                target.GetComponent<Character>().MagicHit(_damage);
        }
    }

    IEnumerator HideEffect(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        if (ani != default || gameObject.name == "Heal")
        {
            ani.SetBool("isHit", false);
        }
        gameObject.SetActive(false);
    }
}
