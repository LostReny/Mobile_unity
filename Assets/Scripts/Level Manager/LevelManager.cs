using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;

    public List<GameObject> levels;

    [Header("Level pieces")]
    public List<GameObject> levelsPieces;
    public int piecesNumber = 5;


    [SerializeField] private int _index;
    private GameObject _currentLevel;


    public void Awake()
    {
        SpawnNextLevel();
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



    #endregion
}
