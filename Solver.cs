using System.Diagnostics;
using System.Numerics;
using System.Collections.Generic;

namespace TowerOfHanoi2
{
    internal class Solver
    {
        private Tower tower;

        public Queue<Moves> moveQueue = new Queue<Moves>();

        public Disc discToMove;
        public Stack<Disc> discstower1 = new Stack<Disc>();
        public Stack<Disc> discstower2 = new Stack<Disc>();
        public Stack<Disc> discstower3 = new Stack<Disc>();

        private bool direction;
        private int toIndex;
        private int fromIndex;
        private int otherIndex;
        public bool moveToSource;
        public bool moveToAux;
        public bool moveToDest;
        public bool toMove;

        int totalDiscs;

        public Solver(int numberOfDiscs, Tower tower)
        {
            this.tower = tower;
            totalDiscs = numberOfDiscs;
            if (numberOfDiscs % 2 == 0)
            {
                direction = true;
            }
        }


       
        public void MoveSmallestDisc(Stack<Disc>[] stacks)
        {

            for (int i = 0; i < stacks.Length; i++)
            {

                if (stacks[i].Count > 0 && stacks[i].Peek().discCount == totalDiscs - 1)
                {
                    fromIndex = i;
                    discToMove = stacks[i].Pop();
                }
            }
            if (direction)
            {
                toIndex = (fromIndex + 1) % 3;
            }
            else
            {
                toIndex = (fromIndex + 2) % 3;
            }

            if (toIndex == 0)
            {
                moveToSource = true;
                moveToAux = false;
                moveToDest = false;


            }
            else if (toIndex == 1)
            {
                moveToSource = false;
                moveToAux = true;
                moveToDest = false;


            }
            else if (toIndex == 2)
            {
                moveToSource = false;
                moveToAux = false;
                moveToDest = true;
 
            }

            toMove = true;
            if (moveToAux)
            {
                Vector2 tTowerPos;
                tTowerPos.X = tower.towerAux.X - 45 + 5 * discToMove.discCount;
                tTowerPos.Y = tower.towerSource.Y + 300 - discstower2.Count * (discToMove.discHeight + 10);

                Moves move = new Moves(discToMove, discstower2, tower, tTowerPos);
                moveQueue.Enqueue(move);
            }
            else if (moveToDest)
            {
                Vector2 tTowerPos;
                tTowerPos.X = tower.towerDest.X - 45 + 5 * discToMove.discCount;
                tTowerPos.Y = tower.towerSource.Y + 300 - discstower3.Count * (discToMove.discHeight + 10);
                Moves move = new Moves(discToMove, discstower3, tower, tTowerPos);
                moveQueue.Enqueue(move);
            }
            else if (moveToSource)
            {
                Vector2 tTowerPos;
                tTowerPos.X = tower.towerSource.X - 45 + 5 * discToMove.discCount;
                tTowerPos.Y = tower.towerSource.Y + 300 - discstower1.Count * (discToMove.discHeight + 10);
                Moves move = new Moves(discToMove, discstower1, tower, tTowerPos);
                moveQueue.Enqueue(move);
            }

        }


     

        public void MoveOtherDisc(Stack<Disc>[] stacks)
        {
            for (int i = 0; i < stacks.Length; i++)
            {
                if (i != fromIndex && i != toIndex)
                {
                    otherIndex = i;
                    Debug.WriteLine(otherIndex);

                }
            }

            if (stacks[otherIndex].Count == 0 || (stacks[fromIndex].Count > 0 && stacks[fromIndex].Peek().discCount > stacks[otherIndex].Peek().discCount))
            {

                discToMove = stacks[fromIndex].Pop();
                if (otherIndex == 0)
                {
                    moveToSource = true;
                    moveToAux = false;
                    moveToDest = false;
                }
                else if (otherIndex == 1)
                {
                    moveToSource = false;
                    moveToAux = true;
                    moveToDest = false;
                }
                else if (otherIndex == 2)
                {
                    moveToSource = false;
                    moveToAux = false;
                    moveToDest = true;
                }

                toMove = true;
                if (moveToAux)
                {
                    Vector2 tTowerPos;
                    tTowerPos.X = tower.towerAux.X - 45 + 5 * discToMove.discCount;
                    tTowerPos.Y = tower.towerSource.Y + 300 - discstower2.Count * (discToMove.discHeight + 10);

                    Moves move = new Moves(discToMove, discstower2, tower, tTowerPos);
                    moveQueue.Enqueue(move);
                }
                else if (moveToDest)
                {
                    Vector2 tTowerPos;
                    tTowerPos.X = tower.towerDest.X - 45 + 5 * discToMove.discCount;
                    tTowerPos.Y = tower.towerSource.Y + 300 - discstower3.Count * (discToMove.discHeight + 10);
                    Moves move = new Moves(discToMove, discstower3, tower, tTowerPos);
                    moveQueue.Enqueue(move);
                }
                else if (moveToSource)
                {
                    Vector2 tTowerPos;
                    tTowerPos.X = tower.towerSource.X - 45 + 5 * discToMove.discCount;
                    tTowerPos.Y = tower.towerSource.Y + 300 - discstower1.Count * (discToMove.discHeight + 10);
                    Moves move = new Moves(discToMove, discstower1, tower, tTowerPos);
                    moveQueue.Enqueue(move);
                }
            }

            else
            {
                discToMove = stacks[otherIndex].Pop();
                if (fromIndex == 0)
                {
                    moveToSource = true;
                    moveToAux = false;
                    moveToDest = false;
                }
                else if (fromIndex == 1)
                {
                    moveToSource = false;
                    moveToAux = true;
                    moveToDest = false;
                }
                else if (fromIndex == 2)
                {
                    moveToSource = false;
                    moveToAux = false;
                    moveToDest = true;
                }
                toMove = true;
                if (moveToAux)
                {
                    Vector2 tTowerPos;
                    tTowerPos.X = tower.towerAux.X - 45 + 5 * discToMove.discCount;
                    tTowerPos.Y = tower.towerSource.Y + 300 - discstower2.Count * (discToMove.discHeight + 10);

                    Moves move = new Moves(discToMove, discstower2, tower, tTowerPos);
                    moveQueue.Enqueue(move);
                }
                else if (moveToDest)
                {
                    Vector2 tTowerPos;
                    tTowerPos.X = tower.towerDest.X - 45 + 5 * discToMove.discCount;
                    tTowerPos.Y = tower.towerSource.Y + 300 - discstower3.Count * (discToMove.discHeight + 10);
                    Moves move = new Moves(discToMove, discstower3, tower, tTowerPos);
                    moveQueue.Enqueue(move);
                }
                else if (moveToSource)
                {
                    Vector2 tTowerPos;
                    tTowerPos.X = tower.towerSource.X - 45 + 5 * discToMove.discCount;
                    tTowerPos.Y = tower.towerSource.Y + 300 - discstower1.Count * (discToMove.discHeight + 10);
                    Moves move = new Moves(discToMove, discstower1, tower, tTowerPos);
                    moveQueue.Enqueue(move);
                }
            }
        }
    }
}