using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject playerObject;
    public GameObject[] spawnPoints;
    public int maxEnemies = 100;
    private bool spawning;
    private bool noche = false;
    public float spawnInterval = 15.0f;
    public int countEnemys = 0;
    private CicloDiaNoche lunaLight; // Referencia al componente CicloDiaNoche 

    private List<GameObject> spawnedEnemies = new List<GameObject>(); // Lista para rastrear los enemigos instanciados

    void Start()
    {
        spawning = false;

        // Asignar una instancia de CicloDiaNoche si existe en el objeto actual.
        lunaLight = GetComponent<CicloDiaNoche>();

        if (lunaLight == null)
        {
            // Si no existe una instancia, agrega el componente al objeto.
            lunaLight = gameObject.AddComponent<CicloDiaNoche>();
        }

        // Suscribirse al evento OnMiVariableChanged del CicloDiaNoche.
        lunaLight.OnMiVariableChanged += HandleMiVariableChanged;

        Invoke("EsperarYActivar", 15f);
    }

    void HandleMiVariableChanged(bool nuevoValor)
    {
        noche = nuevoValor;
        Debug.Log(nuevoValor + "nuevoValor");
    }

    void OnDestroy()
    {
        lunaLight.OnMiVariableChanged -= HandleMiVariableChanged;
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
        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("No hay puntos de spawn configurados.");
            return;
        }
        if (maxEnemies != 0 && noche == true)
        {
            // Inicializamos algunas variables para realizar el seguimiento del punto de aparición más cercano
            Transform playerTransform = playerObject.transform; // Suponiendo que playerObject es la referencia al objeto del jugador
            Transform closestSpawnPoint = null;
            float closestDistance = Mathf.Infinity;

            // Iteramos a través de todos los objetos en la lista spawnPoints
            foreach (GameObject spawnPointObject in spawnPoints)
            {
                // Obtener el componente Transform del objeto de spawnPointObject
                Transform spawnPoint = spawnPointObject.transform;

                // Calculamos la distancia entre el punto de aparición actual y el jugador
                float distanceToPlayer = Vector3.Distance(spawnPoint.position, playerTransform.position);

                // Si esta distancia es menor que la distancia más cercana encontrada hasta ahora
                if (distanceToPlayer < closestDistance)
                {
                    // Actualizamos la distancia más cercana y el punto de aparición más cercano
                    closestDistance = distanceToPlayer;
                    closestSpawnPoint = spawnPoint;
                }
            }

            // Una vez que hayamos encontrado el punto de aparición más cercano, lo utilizamos para instanciar el enemigo
            if (closestSpawnPoint != null)
            {
                GameObject enemyInstance = Instantiate(EnemyPrefab, closestSpawnPoint.position, closestSpawnPoint.rotation);
                spawnedEnemies.Add(enemyInstance);
                maxEnemies--;
                countEnemys++;
            }
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