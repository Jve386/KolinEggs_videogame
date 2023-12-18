using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class spawner : MonoBehaviour
{
   public GameObject mySphere;
   
   public void SpawnSphere(){
    {
        int spawnPointX = Random.Range(-10, 10);
        int spawnPointY = Random.Range(10, 20);
        int spawnPointZ = Random.Range(-10, 10);

        UnityEngine.Vector3 spawnPosition = new UnityEngine.Vector3(spawnPointX, spawnPointY, spawnPointZ);
         

        Instantiate(mySphere, spawnPosition, UnityEngine.Quaternion.identity);
    }
   }

}
