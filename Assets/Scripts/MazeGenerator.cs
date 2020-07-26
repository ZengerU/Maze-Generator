/*  This script was created by:
 *  Umut Zenger
 */


using System;
using System.Collections.Generic;

public class MazeGenerator
{
    static System.Random rand = new System.Random();
    public static bool[,] GenerateMaze(int width, int height, float complexity, float density)
    {
        (int h, int w) shape = ((height / 2) * 2 + 1, (width / 2) * 2 + 1);
        int compl = (int)(complexity * (5 * (shape.h + shape.w)));
        int dens = (int)(density * ((shape.h/2) * (shape.w / 2)));
        bool[,] Maze = new bool[shape.h, shape.w];
        for(int i = 0; i < shape.w; i++)
        {
            Maze[0, i] = true;
            Maze[shape.h - 1, i] = true;
        }
        for (int i = 0; i < shape.h; i++)
        {
            Maze[i, 0] = true;
            Maze[i , shape.w-1] = true;
        }
        Debug.Log($"Dens is {dens}, comp is {compl}");
        for(int i = 0; i  < dens; i++)
        {
            int x = rand.Next(shape.w/2) * 2;
            int y = rand.Next(shape.h/2) * 2;
            Maze[y, x] = true;
            for(int j = 0; j < compl; j++)
            {
                List<(int, int)> neighbours = new List<(int, int)>();
                if (x > 1)
                    neighbours.Add((y, x - 2));
                if (x < shape.w - 2)
                    neighbours.Add((y, x + 2));
                if (y > 1)
                    neighbours.Add((y - 2, x));
                if (y < shape.h - 2)
                    neighbours.Add((y + 2, x));
                if(neighbours.Count > 0)
                {
                    int tmp = rand.Next(neighbours.Count-1);
                    int y_ = neighbours[tmp].Item1;
                    int x_ = neighbours[tmp].Item2;
                    if(!Maze[y_, x_])
                    {
                        Maze[y_, x_] = true;
                        Maze[y_ + (y - y_) / 2, x_ + (x - x_) / 2] = true;
                        x = x_;
                        y = y_;
                    }
                }
            }
        }
        return Maze;
    }
}
