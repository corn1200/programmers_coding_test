using System;
using System.Collections.Generic;

public class Solution {
    public static (int, int)[] Move = { (1, 0), (-1, 0), (0, 1), (0, -1) };
    public static int BoardLen = 0;
    public static int[,] Board;
    public static int[,] Table;
    
    public Queue<Block>[] tableQueue = new Queue<Block>[7];
    public Queue<Block>[] boardQueue = new Queue<Block>[7];

    public class Block
    {
        private (int, int) realPos;
        private (int, int) centerPos;
        private int xMin = 12;
        private int yMin = 12;
        private int xMax = 0;
        private int yMax = 0;
        
        public int[,] shape = new int[11, 11];
        public int count;
        public int xLen;
        public int yLen;

        public Block(int x, int y)
        {
            count = 0;
            realPos = (x, y);
            centerPos = (5, 5);
        }
        
        public void AddShape((int, int) pos)
        {
            var tx = pos.Item1 - realPos.Item1 + centerPos.Item1;
            var ty = pos.Item2 - realPos.Item2 + centerPos.Item2;

            if (xMin > tx)
            {
                xMin = tx;
            }
            
            if (yMin > ty)
            {
                yMin = ty;
            }
            
            if (xMax < tx)
            {
                xMax = tx;
            }
            
            if (yMax < ty)
            {
                yMax = ty;
            }
            
            shape[tx, ty] = 1;
            count++;
        }

        public void TrimShape()
        {
            xLen = xMax - xMin + 1;
            yLen = yMax - yMin + 1;

            var temp = new int[xLen, yLen];

            for (int x = 0; x < xLen; x++)
            {
                for (int y = 0; y < yLen; y++)
                {
                    temp[x, y] = shape[x + xMin, y + yMin];
                }
            }

            shape = temp;
        }

        public bool IsSimilarBlock(int xLen, int yLen)
        {
            bool con1 = this.xLen == xLen || this.xLen == yLen;
            bool con2 = this.yLen == yLen || this.yLen == xLen;

            return con1 && con2;
        }
    }
    
    public bool CanMove((int, int) pos, int w, int[,] check, (int, int) dir, out (int, int) newPos)
    {
        var newX = pos.Item1 + dir.Item1;
        var newY = pos.Item2 + dir.Item2;
        
        if (newX < 0 || newY < 0 || newX >= BoardLen || newY >= BoardLen || check[newX, newY] == w || check[newX, newY] == -1)
        {
            newPos = (0, 0);
            return false;
        }

        newPos = (newX, newY);
        return true;
    }

    public void CheckFourDir((int, int) pos, int w, int[,] check, Queue<(int, int)> queue)
    {
        foreach (var dir in Move)
        {
            if (CanMove(pos, w, check, dir, out var newPos))
            {
                check[newPos.Item1, newPos.Item2] = -1;
                queue.Enqueue(newPos);
            }
        }
    }

    public void ProcessingBlocks(int x, int y, int w, int[,] map, Queue<Block>[] queues)
    {
        var nextTile = new Queue<(int, int)>();
        var block = new Block(x, y);
        nextTile.Enqueue((x, y));
        map[x, y] = -1;
        
        while (nextTile.Count > 0)
        {
            var tile = nextTile.Dequeue();
            block.AddShape(tile);
            CheckFourDir(tile, w, map, nextTile);
        }

        block.TrimShape();
        
        if (queues[block.count] == null)
        {
            queues[block.count] = new Queue<Block>();
        }

        queues[block.count].Enqueue(block);
    }

    public void ProcessingTable(int[,] data)
    {
        for (int x = 0; x < BoardLen; x++)
        {
            for (int y = 0; y < BoardLen; y++)
            {
                if (data[x, y] == 1)
                {
                    ProcessingBlocks(x, y, 0, Table, tableQueue);
                }
            }
        }
    }
    
    public void ProcessingBoard(int[,] data)
    {
        for (int x = 0; x < BoardLen; x++)
        {
            for (int y = 0; y < BoardLen; y++)
            {
                if (data[x, y] == 0)
                {
                    ProcessingBlocks(x, y, 1, Board, boardQueue);
                }
            }
        }
    }
    
    public int[,] RotateMatrix(int[,] matrix)
    {
        int rowCount = matrix.GetLength(0);
        int colCount = matrix.GetLength(1);
        int[,] rotatedMatrix = new int[colCount, rowCount];

        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < colCount; col++)
            {
                rotatedMatrix[col, rowCount - row - 1] = matrix[row, col];
            }
        }

        return rotatedMatrix;
    }

    public bool IsSameArray(int[,] arr1, int[,] arr2)
    {
        var lenX = arr1.GetLength(0);
        var lenY = arr1.GetLength(1);

        if (lenX != arr2.GetLength(0) || lenY != arr2.GetLength(1))
        {
            return false;
        }

        for (int x = 0; x < lenX; x++)
        {
            for (int y = 0; y < lenY; y++)
            {
                if (arr1[x, y] != arr2[x, y])
                {
                    return false;
                }
            }
        }
        
        return true;
    }

    public bool RotateArrayCheck(int[,] arr1, int[,] arr2)
    {
        if (IsSameArray(arr1, arr2))
        {
            return true;
        }

        var newArr = arr2;
        for (int i = 0; i < 3; i++)
        {
            newArr = RotateMatrix(newArr);

            if (IsSameArray(arr1, newArr))
            {
                return true;
            }
        }

        return false;
    }

    public int solution(int[,] game_board, int[,] table)
    {
        Board = game_board;
        Table = table;
        BoardLen = game_board.GetLength(0);

        ProcessingBoard(Board);
        ProcessingTable(Table);

        var answer = 0;
        for (int i = 1; i < 7; i++)
        {
            if (boardQueue[i] == null || tableQueue[i] == null)
            {
                continue;
            }

            while (boardQueue[i].Count > 0)
            {
                var blank = boardQueue[i].Dequeue();

                var loopMax = tableQueue[i].Count;
                while (0 < loopMax)
                {
                    var tile = tableQueue[i].Dequeue();

                    if (blank.IsSimilarBlock(tile.xLen, tile.yLen))
                    {
                        if (RotateArrayCheck(blank.shape, tile.shape))
                        {
                            answer += i;
                            break;
                        }
                    }

                    tableQueue[i].Enqueue(tile);
                    loopMax--;
                }
            }
        }
        
        return answer;
    }
}
