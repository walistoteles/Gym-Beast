using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public static Shop instace;
    public Color[] baseColor;
    public Material[] upgradeColor;

    private void Awake()
    {
        if (instace == null)
        {
            instace = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public List<EnemyBase> enemys = new List<EnemyBase>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(enemys.Count <= 0)
            {
                StartCoroutine(TocarCor());

                return;
            }
            RemoveEnemys(other.GetComponent<PlayerInventory>());
        }
    }
    internal void RemoveEnemys(PlayerInventory playerInventory)
    {

        for (int i = 0; i < enemys.Count; i++)
        {
            EnemyBase corpo = enemys[i];

            Destroy(corpo.espinhaRB.gameObject);
            Destroy(corpo.gameObject);

            playerInventory.Cash += 50;
        }

        enemys.Clear();
    }

    IEnumerator TocarCor()
    {
        foreach (var item in upgradeColor)
        {
            item.color = baseColor[0];
        }
        yield return new WaitForSeconds(0.7f);

        foreach (var item in upgradeColor)
        {
            item.color = baseColor[1];
        }
    }
}
