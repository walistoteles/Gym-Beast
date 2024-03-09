using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    private Rigidbody[] rbs => GetComponentsInChildren<Rigidbody>();

    public Rigidbody espinhaRB;
    Animator animator => GetComponent<Animator>();

    BoxCollider hitbox => GetComponent<BoxCollider>();
    NavMeshAgent agent => GetComponent<NavMeshAgent>();

    public EnemySpawner spawner;
    public int posNumber;
    public GameObject peso;

    void Start()
    {
        foreach (var rb in rbs)
        {
            rb.isKinematic = true;
        }

    }

    bool treinando;
    void Update()
    {
        float distanceForDestination = Vector3.Distance(transform.position, destination);

        if (distanceForDestination < 0.3f && !treinando)
        {
            agent.Stop();
            Training();
        }


        animator.SetFloat("Speed", agent.velocity.magnitude / 2);
    }

    public void Training()
    {
        if(treinando) { return; }

        Vector3 rotation = new Vector3 (0, 120, 0);
        transform.rotation = Quaternion.Euler(rotation);
        treinando = true;
        peso.active = true;
        animator.Play("Treinando");
    }

    public void HitEnemy(Vector3 playerPosition)
    {
        animator.enabled = false;
        ScreenShake.instance.StartShake();
        agent.Stop();
        agent.enabled = false;

        foreach (var rb in rbs)
        {
            rb.isKinematic = false;
        }

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
        Vector3 oppositeDirection = transform.position - playerPosition;
        espinhaRB.AddForce(oppositeDirection * 100, ForceMode.Impulse);
        hitbox.enabled = false;

        peso.active = false;
        StartCoroutine(TempoPraEmpilhar());
    }

    IEnumerator TempoPraEmpilhar()
    {
        yield return new WaitForSeconds(1.5f);
        PlayerInventory.Instance.EmpilharObj(this,espinhaRB);
        spawner.CleanSpace(posNumber);
    }

    private Vector3 destination;
    public void IrAte(Transform pos)
    {
        destination = pos.position;
        agent.SetDestination(destination);
    }
}
