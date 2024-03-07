using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;

    public List<GameObject> levels;

    [Header("Level pieces")]
    public List<LevelPieceBase> levelPieceStart; 
    public List<LevelPieceBase> levelsPieces;
    public List<LevelPieceBase> levelPieceEnd;

    public int piecesStartNumber = 1;
    public int piecesNumber = 5;
    public int piecesEndNumber = 1;


    [SerializeField] private int _index;
    private GameObject _currentLevel;


    // lista das peças já utilizadas 
    public List<LevelPieceBase> _spawnedPieces;


    public void Awake()
    {
        //SpawnNextLevel();
        CreateLevelP();
    }

    private void SpawnNextLevel()
    {
        if(_currentLevel != null)
        {
            Destroy(_currentLevel);
            _index++;
            if(_index >= levels.Count)
            {
                ResetLevelIndex();
            }
        }

        _currentLevel = Instantiate(levels[_index], container);
        _currentLevel.transform.localPosition = Vector3.zero;
    }


    private void ResetLevelIndex()
    {
        _index = 0;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SpawnNextLevel();
        }
    }

    #region
    // Level Pieces 

    private void CreateLevelP()
    {
        _spawnedPieces = new List<LevelPieceBase>();

        for (int i = 0; i < piecesStartNumber; i++)
        {
            CreateLevelPiece(levelPieceStart);
        }

        for (int i = 0; i < piecesNumber; i++)
        {
            CreateLevelPiece(levelsPieces);
        }

        for (int i = 0; i < piecesEndNumber; i++)
        {
            CreateLevelPiece(levelPieceEnd);
        }
    }
    
    private void CreateLevelPiece(List<LevelPieceBase> list)
    {
        var piece = list[Random.Range(0, list.Count)];
        var spannedPiece = Instantiate(piece, container);

        if (_spawnedPieces.Count >   0)
        {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];
            spannedPiece.transform.position = lastPiece.EndPiece.position;
        }

        _spawnedPieces.Add(spannedPiece);
    }


    #endregion
}
