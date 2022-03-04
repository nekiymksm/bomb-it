using System.Collections.Generic;
using UnityEngine;

public class SpawnPointersBuilder : Builder
{
    public override void Build(LevelAssembler levelAssembler)
    {
        SetSpawnPointers(levelAssembler);
        
        if (Successor != null)
            Successor.Build(levelAssembler);
    }

    private void SetSpawnPointers(LevelAssembler levelAssembler)
    {
        levelAssembler.Level.SpawnPointers = new List<SpawnPointer>();
        
        int obstaclesCountInLine = levelAssembler.HorizontalLevelSize / 2;
        float xAxisPointersModifier = levelAssembler.GroundLength / obstaclesCountInLine;
        float xAxisLengthIndent = levelAssembler.GroundLength / 2 / xAxisPointersModifier;
    
        for (int i = 0; i < levelAssembler.LevelConfig.SpawnPointersColumnsCount; i++)
        {
            float zAxisSpawnPointer = levelAssembler.GroundWidth / 2 - i * levelAssembler.GroundWidth;
            
            for (int j = 0; j < obstaclesCountInLine; j++)
            {
                float xAxisSpawnPointer = levelAssembler.GroundLength / 2 - xAxisLengthIndent - j * xAxisPointersModifier;
                
                var spawnPointer = GetLevelItem(levelAssembler.SpawnPointersPool);
                
                spawnPointer.transform.position = new Vector3(xAxisSpawnPointer, 0, zAxisSpawnPointer);
                levelAssembler.Level.SpawnPointers.Add(spawnPointer);
                spawnPointer.transform.SetParent(levelAssembler.Level.transform);
            }
        }
    }
}