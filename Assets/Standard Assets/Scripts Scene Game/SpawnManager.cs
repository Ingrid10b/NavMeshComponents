using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject[] spawnPoints;
    public int maxEnemies = 20;
    private bool spawning;
    private bool noche = false;
    public float spawnInterval = 5.0f;
    public int countEnemys = 0;
   // public CicloDiaNoche lunaLight; // Referencia al componente CicloDiaNoche 

    private List<GameObject> spawnedEnemies = new List<GameObject>(); // Lista para rastrear los enemigos instanciados

    void Start()
    {
        spawning = false;

        // Asignar una instancia de CicloDiaNoche si existe en el objeto actual.
        //lunaLight = GetComponent<CicloDiaNoche>();

       // if (lunaLight == null)
        //{
            // Si no existe una instancia, agrega el componente al objeto.
           // lunaLight = gameObject.AddComponent<CicloDiaNoche>();
        //}

        // Suscribirse al evento OnMiVariableChanged del CicloDiaNoche.
        //lunaLight.OnMiVariableChanged += HandleMiVariableChanged;

        Invoke("EsperarYActivar", 10f);
    }

    void HandleMiVariableChanged(bool nuevoValor)
    {
        noche = nuevoValor;
        //Debug.Log(nuevoValor + "nuevoValor");
    }

    void OnDestroy()
    {
        // Asegúrate de cancelar la suscripción al evento cuando el objeto se destruya.
       // lunaLight.OnMiVariableChanged -= HandleMiVariableChanged;
    }

    void EsperarYActivar()
    {
        spawning = true;
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        //Debug.Log(noche + "noche");

        //  Debug.Log(noche + "IfNoche");
        for (int i = 0; i < maxEnemies; i++)
        {
            EnemySpawnPosition();
            yield return new WaitForSeconds(spawnInterval);
        }
        spawning = false;

    }

    void EnemySpawnPosition()
    {

        if (maxEnemies != 0 && noche == true)
        {

            int spawnPos = Random.Range(0, spawnPoints.Length);
            GameObject enemyInstance = Instantiate(EnemyPrefab, spawnPoints[spawnPos].transform.position, spawnPoints[spawnPos].transform.rotation);
            spawnedEnemies.Add(enemyInstance);
            maxEnemies--;
            countEnemys++;
        }
        else if (noche == false && countEnemys > 0)
        {
            foreach (var enemy in spawnedEnemies)
            {
                Destroy(enemy);
            }
            spawnedEnemies.Clear(); // Limpiar la lista
            countEnemys = 0;
        }
    }
}