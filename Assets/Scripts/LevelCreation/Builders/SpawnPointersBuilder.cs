using System.Collections.Generic;
using UnityEngine;

public class SpawnPointersBuilder : Builder
{
    public override void Build(LevelItemsDirector levelItemsDirector)
    {
        SetSpawnPointers(levelItemsDirector);
        
        if (Successor != null)
            Successor.Build(levelItemsDirector);
    }

    private void SetSpawnPointers(LevelItemsDirector levelItemsDirector)
    {
        levelItemsDirector.SpawnPointers = new List<SpawnPointer>();
        
        int obstaclesCountInLine = levelItemsDirector.HorizontalSize / 2;
        float xAxisPointersModifier = levelItemsDirector.LevelLength / obstaclesCountInLine;
        float xAxisLengthIndent = levelItemsDirector.LevelLength / 2 / xAxisPointersModifier;
    
        for (int i = 0; i < levelItemsDirector.LevelConfig.SpawnPointersColumnsCount; i++)
        {
            float zAxisSpawnPointer = levelItemsDirector.LevelWidth / 2 - i * levelItemsDirector.LevelWidth;
            
            for (int j = 0; j < obstaclesCountInLine; j++)
            {
                float xAxisSpawnPointer = levelItemsDirector.LevelLength / 2 - xAxisLengthIndent - j * xAxisPointersModifier;
                
                var spawnPointer = levelItemsDirector.SpawnPointersPool.TryGetItem();
                
                spawnPointer.transform.position = new Vector3(xAxisSpawnPointer, 0, zAxisSpawnPointer);
                levelItemsDirector.SpawnPointers.Add(spawnPointer.GetComponent<SpawnPointer>());
                spawnPointer.transform.SetParent(levelItemsDirector.Level.transform);
            }
        }
        
        ShuffleSpawnPoints(levelItemsDirector.SpawnPointers);
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