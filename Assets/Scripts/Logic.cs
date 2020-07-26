/*  This script was created by:
 *  Umut Zenger
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic : MonoBehaviour
{
    #region Public Members

    #endregion

    #region Private Members

    private bool[,] maze;
    [SerializeField]
    private GameObject wall;
    [SerializeField]
    private Transform platform, wallParent;
    [SerializeField]
    private int width, height;
    [SerializeField]
    private float density, complexity;
    private float time;

    #endregion
    
    #region Public Functions
    
    #endregion
    
    #region Private Functions
    void Start()
    {
        maze = MazeGenerator.GenerateMaze(width, height, density, complexity);
        time = Time.time;
        print($"Generated maze in {time} seconds.");
        CreateMaze();
    }

    void CreateMaze()
    {
        wallParent.position = new Vector3((maze.GetLength(1) - 1) / 2, 0, (maze.GetLength(0) - 1) / 2);
        platform.localScale = new Vector3(maze.GetLength(1) / 10, 1, maze.GetLength(0) / 10);
        for(int i = 0; i < maze.GetLength(0); i++)
        {
            for(int j = 0; j < maze.GetLength(1); j++)
            {
                if (maze[i, j])
                {
                    Instantiate(wall, new Vector3(j, .25f, i), Quaternion.identity, wallParent);
                }
            }
        }
        wallParent.position = new Vector3(0, 0, 0);
        print($"Created maze in {Time.time - time} seconds.");
    }
    #endregion
}
