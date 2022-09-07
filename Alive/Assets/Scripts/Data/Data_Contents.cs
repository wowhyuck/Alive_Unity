using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    #region Stat
    [Serializable]
    public class Stat
    {
        // json 변수명과 동일하게
        public int level;
        public float attack;
        public float defence;
        public float maxHp;
        public float regenHp;
        public float maxMp;
        public float regenMp;
        public float moveSpeed;
        public int totalExp;
        public int exp;
    }

    [Serializable]
    public class StatData : ILoader<int, Stat>
    {
        public List<Stat> stats = new List<Stat>();

        public Dictionary<int, Stat> MakeDict()
        {
            Dictionary<int, Stat> dict = new Dictionary<int, Stat>();

            foreach (Stat stat in stats)
                dict.Add(stat.level, stat);

            return dict;
        }

        public List<Stat> MakeList()
        {
            List<Stat> list = new List<Stat>();

            foreach (Stat stat in stats)
                list.Add(stat);

            return list;
        }
    }
    #endregion
}
