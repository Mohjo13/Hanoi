using Microsoft.Xna.Framework;
using System.Collections.Generic;



namespace TowerOfHanoi2
{
    internal class Moves
    {
        public int TotowerIndex { get; set; }
        public Disc discToMove { get; set; }
        public Stack<Disc> targetTower { get; set; }
        private Tower tower { get; set; }

 
        public Vector2 TowerPos;
        public Moves(Disc disc, Stack<Disc> tTower, Tower tower, Vector2 targetTowerPos)
        {
            TowerPos = targetTowerPos;
            discToMove = disc;
            targetTower = tTower;
            this.tower = tower;
            targetTower.Push(discToMove);

        }
    }
}