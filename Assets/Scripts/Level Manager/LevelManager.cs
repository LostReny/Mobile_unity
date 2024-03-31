using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;

    public List<GameObject> levels;

    /*[Header("Level pieces")]
    public List<LevelPieceBase> levelPieceStart; 
    public List<LevelPieceBase> levelsPieces;
    public List<LevelPieceBase> levelPieceEnd;

    public int piecesStartNumber = 1;
    public int piecesNumber = 5;
    public int piecesEndNumber = 1;*/

    public List<LevelPieceSetup> _levelPieceSetups;


    [SerializeField] private int _index;
    private GameObject _currentLevel;


    // lista das peças já utilizadas 
    public List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();

    private LevelPieceSetup _currSet;

    public float timeBetweenPieces = 5f;


    // -------------------------

    public void Start()
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
            //SpawnNextLevel();
            CreateLevelP();
        }
    }

    #region
    // Level Pieces 

    private void CreateLevelP()
    {
        CleanedSpawnedPieces();

        //_spawnedPieces = new List<LevelPieceBase>();


        if(_currSet != null)
        {
            _index++;

            if(_index >= _levelPieceSetups.Count)
            {
                ResetLevelIndex();
            }
        }

        _currSet = _levelPieceSetups[_index];


        for (int i = 0; i < _currSet.piecesStartNumber; i++)
        {
            CreateLevelPiece(_currSet.levelPieceStart);
        }

        for (int i = 0; i < _currSet.piecesNumber; i++)
        {
            CreateLevelPiece(_currSet.levelsPieces);
        }

        for (int i = 0; i < _currSet.piecesEndNumber; i++)
        {
            CreateLevelPiece(_currSet.levelPieceEnd);
        }

        ColorManager.Instance.ChangeColorByType(_currSet.artType);
        CoinsAnimationManager.Instance.StartAnimations();
    }
    
    private void CreateLevelPiece(List<LevelPieceBase> list)
    {
        var piece = list[Random.Range(0, list.Count)];
        var spannedPiece = Instantiate(piece, container);

        if (_spawnedPieces.Count > 0)
        {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];
            spannedPiece.transform.position = lastPiece.EndPiece.position;
        }
        else
        {
            spannedPiece.transform.localPosition = Vector3.zero; 
        }

        /*foreach (var p in spannedPiece.GetComponentInChildren<ArtPiece>())
        {
            p.ChangePiece(ArtManager.Instance.GetSetupByType(_currSet.artType).gameObject);
        }*/

        /*var artPiece = spannedPiece.GetComponentInChildren<ArtPiece>();
        if (artPiece != null)
        {
            artPiece.ChangePiece(ArtManager.Instance.GetSetupByType(_currSet.artType).gameObject);
        }*/

        var artPieces = spannedPiece.GetComponentsInChildren<ArtPiece>();
        foreach (var p in artPieces)
        {
            p.ChangePiece(ArtManager.Instance.GetSetupByType(_currSet.artType)?.gameObject);
        }

        _spawnedPieces.Add(spannedPiece);
    }


    private void CleanedSpawnedPieces()
    {
        for(int i = _spawnedPieces.Count - 1; i >= 0 ; i--)
        {
            Destroy(_spawnedPieces[i].gameObject);
        }

        _spawnedPieces.Clear();
    }


    IEnumerator CreateLevelCoroutine()
    {
        _spawnedPieces = new List<LevelPieceBase>();
         
        for (int i = 0; i < _currSet.piecesNumber; i++)
        {
            CreateLevelPiece(_currSet.levelsPieces);
            yield return new WaitForSeconds(timeBetweenPieces);
        } 
    }

    #endregion
}
