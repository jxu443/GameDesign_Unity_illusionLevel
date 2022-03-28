using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MazeRender : MonoBehaviour
{
    [SerializeField, Range(1, 20)] // make private var configurable
    private int width = 10;

    [SerializeField, Range(1, 20)]
    private int height = 10; 


    [SerializeField]
    private Transform wallPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        MazeGenerator gen = new MazeGenerator(width, height);
        var maze = gen.Generate();
        DrawMaze(maze);
    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.position = new Vector3(10, 0, 0);
        //transform.localScale = new Vector3(2, 1, 2);
    }

    private async void DrawMaze(WallState[,] maze) {
        for (int i = 0; i < width; i++) {
            for (int j = 0; j < height; j++) {
                var cell = maze[i,j];
                var position = new Vector3(-width/2 + i, 0, -height/2+j); // center the maze at (0,0)

                if (cell.HasFlag(WallState.UP)) {
                    var wall = Instantiate(wallPrefab) as Transform;
                    wall.position = position + new Vector3(0, 0, 0.5f); 
                    wall.SetParent(transform, false); // ***
                }
                if (cell.HasFlag(WallState.LEFT)) {
                    var wall = Instantiate(wallPrefab) as Transform;
                    wall.position = position + new Vector3(-0.5f, 0, 0); 
                    wall.eulerAngles = new Vector3(0, 90, 0);
                    wall.SetParent(transform, false); // ***
                }
                
                if (i == width -1) {
                    if (cell.HasFlag(WallState.RIGHT)) {
                        var wall = Instantiate(wallPrefab) as Transform;
                        wall.position = position + new Vector3(0.5f, 0, 0);
                        wall.eulerAngles = new Vector3(0, 90, 0); 
                        wall.SetParent(transform, false); // ***
                    }
                }

                if (j == 0) {
                    if (cell.HasFlag(WallState.DOWN)) {
                        var wall = Instantiate(wallPrefab) as Transform;
                        wall.position = position + new Vector3(0, 0, -0.5f); 
                        wall.SetParent(transform, false); // ***
                    }
                }
            }
        }
    }
}

