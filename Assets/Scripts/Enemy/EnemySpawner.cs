using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyBase EnemyPrefab;

    public Transform[] positions;

    public List<int> numeros;


    void Start()
    {
        SpawnarEnemy();
        maxtimmer = Random.Range(5, 15);

    }

    float timmer;
    float maxtimmer;
    void Update()
    {
        timmer += Time.deltaTime;

        if (timmer > maxtimmer)
        {
            SpawnarEnemy();
            maxtimmer = Random.Range(5, 15);
            timmer = 0;
        }
    }

    public void SpawnarEnemy()
    {
        if (numeros.Count >= positions.Length)
        {
            return;
        }

        var inimigo = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
        inimigo.spawner = this;
        int n = numeros.Count;

        if (NumerosRemovidos.Count > 0)
        {
            n = NumerosRemovidos[0];
            NumerosRemovidos.RemoveAt(0);
        }

        numeros.Add(n);

        inimigo.posNumber = n;
        inimigo.IrAte(positions[n]);
    }

    public List<int> NumerosRemovidos = new List<int>();
    public void CleanSpace(int n)
    {
        numeros.Remove(n);
        NumerosRemovidos.Add(n);
    }

}
