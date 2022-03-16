using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig")]
public class GameConfig : ScriptableObject
{
    [SerializeField] private int _minimumScoresModifier;

    public int MinimumScoresModifier => _minimumScoresModifier;
}