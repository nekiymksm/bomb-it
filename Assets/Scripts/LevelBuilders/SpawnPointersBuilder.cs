using System.Collections.Generic;
using UnityEngine;

public class SpawnPointersBuilder : Builder
{
    public override void Build(LevelDirector levelDirector)
    {
        SetSpawnPointers(levelDirector);
        
        if (Successor != null)
            Successor.Build(levelDirector);
    }

    private void SetSpawnPointers(LevelDirector levelDirector)
    {
        levelDirector.SpawnPointers = new List<SpawnPointer>();
        
        int obstaclesCountInLine = levelDirector.HorizontalSize / 2;
        float xAxisPointersModifier = levelDirector.LevelLength / obstaclesCountInLine;
        float xAxisLengthIndent = levelDirector.LevelLength / 2 / xAxisPointersModifier;
    
        for (int i = 0; i < levelDirector.LevelConfig.SpawnPointersColumnsCount; i++)
        {
            float zAxisSpawnPointer = levelDirector.LevelWidth / 2 - i * levelDirector.LevelWidth;
            
            for (int j = 0; j < obstaclesCountInLine; j++)
            {
                float xAxisSpawnPointer = levelDirector.LevelLength / 2 - xAxisLengthIndent - j * xAxisPointersModifier;
                
                var spawnPointer = levelDirector.SpawnPointersPool.TryGetItem();
                
                spawnPointer.transform.position = new Vector3(xAxisSpawnPointer, 0, zAxisSpawnPointer);
                levelDirector.SpawnPointers.Add(spawnPointer.GetComponent<SpawnPointer>());
                spawnPointer.transform.SetParent(levelDirector.Level.transform);
            }
        }
        
        ShuffleSpawnPoints(levelDirector.SpawnPointers);
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
}