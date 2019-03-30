using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] int breakableBlocks;

    SceneLoader sceneLoader;
    GameSession gameStatus;

    private void Start()
    {
        Cursor.visible = false;
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameStatus = FindObjectOfType<GameSession>();
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;


        if (breakableBlocks <= 3 && gameStatus.loseFailSafe == true)
        {
            gameStatus.gameSpeed = 3f;
        }

        if (breakableBlocks <= 0)
        {
            gameStatus.loseFailSafe = true;
            sceneLoader.LoadNextScene();
        }
    }
}
