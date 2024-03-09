using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public Material playerMaterial;

    public Color corInicial;
    public Color[] cores;

    public int level = 0;

    public Color[] baseColor;
    public Material[] upgradeColor;

    private void Start()
    {
        playerMaterial.color = corInicial;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();

            if (inventory.Cash >= 300 && level <4)
            {
                inventory.Cash -= 300;
                level++;
                inventory.maxEmpilhamento += 2;
            }
            else
            {
                StartCoroutine(TocarCor());
            }

            playerMaterial.color = cores[level - 1];

        }
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
