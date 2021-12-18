using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] Sprite[] Sprites_car;
    [SerializeField] Sprite[] Sprites_shadow;
    SpriteRenderer SpriteRenderer_car;
    SpriteRenderer SpriteRenderer_shadow;
    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(3);
        float x = Random.Range(-3.42f, 3.42f);
        int sprite = Random.Range(0, Sprites_car.Length);
        GameObject enemy_new = Instantiate(Enemy, new Vector3(x, 6, 89), Quaternion.identity);
        SpriteRenderer_car = enemy_new.transform.Find("Body").GetComponent<SpriteRenderer>();
        SpriteRenderer_shadow = enemy_new.transform.Find("Shadow").GetComponent<SpriteRenderer>();
        SpriteRenderer_car.sprite = Sprites_car[sprite];
        SpriteRenderer_shadow.sprite = Sprites_shadow[sprite];
        StartCoroutine(Spawner());
    }
}
