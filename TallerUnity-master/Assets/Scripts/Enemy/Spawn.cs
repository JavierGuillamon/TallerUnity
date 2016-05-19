using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
    public Transform tgt;
    public GameObject sensor;
    public Transform[] spawnPoints;
    public int wave;
    public GameObject enmyInofensivo;
    public GameObject enmyOfDistancia;
    public GameObject enmyOfMelee;
    bool spawn=false;
    public int deadCount;
    public EntrarSala es;
    public int cantidadWave1;
    public int cantidadWave2;
    public int cantidadWave3;
    public int cantidadWave41;
    public int cantidadWave42;
    // Update is called once per frame
    void Update () {
        WaveControl();
        endwave();
    }
    void endwave()
    {
        if (deadCount == cantidadWave1 && spawn)
        {
            deadCount = 0;
            spawn = false;
            wave++;
        }
    }
    void spawnEnemy(GameObject enemy, int cantidad,bool melee)
    {
        for (int i = 1; i <= cantidad; i++)
        {
            StartCoroutine(inof(1,enemy,cantidad,melee));
            if (i == cantidad) spawn = true;       
        }
    }
    void WaveControl()
    {
        if (!spawn)
        {
            switch (wave)
            {
                case 0:
                    spawnEnemy(enmyInofensivo, cantidadWave1,false);
                    
                    break;
                case 1:
                    spawnEnemy(enmyOfMelee, cantidadWave2,true);
                    break;
                case 2:
                    spawnEnemy(enmyOfDistancia, cantidadWave3, true);
                    break;
                case 3:
                    spawnEnemy(enmyOfMelee, cantidadWave41, true);
                    spawnEnemy(enmyOfDistancia, cantidadWave42, true);
                    break;
                case 4:
                    es.ApagarSala();
                    break;

            }
        }
    }
    IEnumerator inof(float x,GameObject enemy, int cantidad, bool melee)
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        yield return new WaitForSeconds(x);
        GameObject enemigo = Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as GameObject;
        Inofensive scrpt = enemigo.GetComponentInChildren<Inofensive>();
        scrpt.sensorEntrada = sensor;
        if (melee)
        {
            moveEnemyMelee script = enemigo.GetComponent<moveEnemyMelee>();
            script.target = tgt;
        }
    }
}
