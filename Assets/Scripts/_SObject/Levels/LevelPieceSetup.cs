using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class LevelPieceSetup : ScriptableObject
{
    public ArtManager.ArtType artType; 


    [Header("Level pieces")]
    public List<LevelPieceBase> levelPieceStart;
    public List<LevelPieceBase> levelsPieces;
    public List<LevelPieceBase> levelPieceEnd;

    public int piecesStartNumber = 1;
    public int piecesNumber = 5;
    public int piecesEndNumber = 1;
}
