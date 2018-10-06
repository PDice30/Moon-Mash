using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


namespace UnityEngine {

[Serializable]
    public class EnemySpawnData
    {
        public int sectorId;
        public string sectorName;
        public int planetId;
        public string planetName;
        public int round;
        public int spawn;
        public int enemyId;
        public string enemyTypeName;
        public int enemyTypeId;
        public string enemySubtypeName;
        public int enemySubtypeId;
        public Vector3 enemySpawnLocation;
    }
}
