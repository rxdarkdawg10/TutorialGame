using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TutorialGame.Source.Engine;
using TutorialGame.Source.GamePlay.World.Buildings;
using TutorialGame.Source.GamePlay.World.SpawnPoints;
using TutorialGame.Source.GamePlay.World.Units;

namespace TutorialGame.Source.GamePlay.World
{
    internal class clsPlayer
    {
        public int id;
        public Hero hero;
        public List<Unit> units = new List<Unit>();
        public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
        public List<Building> buildings = new List<Building>();

        public clsPlayer(int ID, XElement DATA)
        {
            id = ID;

            LoadData(DATA);
        }

        public virtual void LoadData(XElement DATA)
        {
            List<XElement> spawnList = DATA.Descendants("SpawnPoint").Select(s => s).ToList<XElement>();

            for(int i = 0; i < spawnList.Count; i++)
            {
                spawnPoints.Add(new Portal(new Vector2(
                    Convert.ToInt32(spawnList[i].Element("Pos").Element("x").Value,Globals.culture),
                    Convert.ToInt32(spawnList[i].Element("Pos").Element("y").Value, Globals.culture)
                    ), id));

                spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(
                    Convert.ToInt32(spawnList[i].Element("timerAdd").Value, Globals.culture)
                    );
            }

            List<XElement> buildingList = DATA.Descendants("Building").Select(s => s).ToList<XElement>();

            for (int i = 0; i < buildingList.Count; i++)
            {
                buildings.Add(new Tower(new Vector2(
                    Convert.ToInt32(buildingList[i].Element("Pos").Element("x").Value, Globals.culture),
                    Convert.ToInt32(buildingList[i].Element("Pos").Element("y").Value, Globals.culture)
                    ), id));
            }

            if(DATA.Element("Hero") != null)
            {
                hero = new Hero("2d\\hero"
                    , new Vector2(
                    Convert.ToInt32(DATA.Element("Hero").Element("Pos").Element("x").Value, Globals.culture),
                    Convert.ToInt32(DATA.Element("Hero").Element("Pos").Element("y").Value, Globals.culture)
                    )
                    , new Vector2(48, 48), id);
            }
        }

        public virtual void Update(clsPlayer ENEMY, Vector2 OFFSET)
        {
            if (hero != null)
            {
                hero.Update(OFFSET);
            }

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                spawnPoints[i].Update(OFFSET);

                if (spawnPoints[i].dead)
                {
                    spawnPoints.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < units.Count; i++)
            {
                units[i].Update(OFFSET, ENEMY);
                if (units[i].dead)
                {
                    ChangeScore(1);
                    units.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < buildings.Count; i++)
            {
                buildings[i].Update(OFFSET, ENEMY);
                if (buildings[i].dead)
                {
                    buildings.RemoveAt(i);
                    i--;
                }
            }
        }

        public virtual void AddUnit(object INFO)
        {
            Unit tempUnit = (Unit)INFO;
            tempUnit.ownerId = id;
            units.Add(tempUnit);
        }

        public virtual void AddSpawnPoint(object INFO)
        {
            SpawnPoint tempSpawnPoint = (SpawnPoint)INFO;
            tempSpawnPoint.ownerId = id;
            spawnPoints.Add(tempSpawnPoint);
        }

        public virtual void ChangeScore(int SCORE)
        {

        }

        public virtual List<AttackableObject> GetAllObjects()
        {
            List<AttackableObject> tempObjects = new List<AttackableObject>();

            tempObjects.AddRange(units.ToList<AttackableObject>());
            tempObjects.AddRange(spawnPoints.ToList<AttackableObject>());
            tempObjects.AddRange(buildings.ToList<AttackableObject>());

            return tempObjects;
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            if (hero != null)
            {
                hero.Draw(OFFSET);
            }

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                spawnPoints[i].Draw(OFFSET);
            }

            for (int i = 0; i < buildings.Count; i++)
            {
                buildings[i].Draw(OFFSET);
            }

            for (int i = 0; i < units.Count; i++)
            {
                units[i].Draw(OFFSET);
            }


        }
    }
}
