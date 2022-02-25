using System.Collections.Generic;
using UnityEngine;

public class CharactersSpawner
{
    public void Spawn(List<Character> characters, List<SpawnPointer> spawnPointers)
    {
        ShuffleSpawnPoints(spawnPointers);

        for (int i = 0; i < spawnPointers.Count / 2 + 1; i++)
        {
            var spawnPointer = TryGetSpawnPoint(spawnPointers);

            characters[i].transform.position = spawnPointer.transform.position;
            characters[i].gameObject.SetActive(true);
            spawnPointer.gameObject.SetActive(false);
        }
    }
    
    private void ShuffleSpawnPoints(List<SpawnPointer> spawnPointers)
    {
        for (int i = 0; i < spawnPointers.Count; i++)
        {
            var temp = spawnPointers[i];
            var j = Random.Range(0, spawnPointers.Count);
            
            spawnPointers[i] = spawnPointers[j];
            spawnPointers[j] = temp;
        }
    }
    
    private SpawnPointer TryGetSpawnPoint(List<SpawnPointer> spawnPoints)
    {
        foreach (var spawnPoint in spawnPoints)
        {
            if (spawnPoint.gameObject.activeSelf)
                return spawnPoint;
        }
    
        return null;
    }
}