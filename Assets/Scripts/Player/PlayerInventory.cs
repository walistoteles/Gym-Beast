using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Rigidbody> espinhas = new List<Rigidbody>();

    public static PlayerInventory Instance;


    public TextMeshProUGUI cash_text;
    public int Cash;

    public Transform[] slots;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public int maxEmpilhamento;
    
    public void EmpilharObj(EnemyBase obj, Rigidbody espinha)
    {
        if (Shop.instace.enemys.Count >= maxEmpilhamento) { return; }

        Shop.instace.enemys.Add(obj);


        espinha.isKinematic = true;
        espinha.transform.parent = slots[Shop.instace.enemys.Count - 1].transform;
        obj.transform.parent = slots[Shop.instace.enemys.Count - 1].transform;
        espinha.transform.position = slots[Shop.instace.enemys.Count - 1].transform.position;


    }


    private void Update()
    {
        cash_text.text = Cash.ToString();
    }

   
}
