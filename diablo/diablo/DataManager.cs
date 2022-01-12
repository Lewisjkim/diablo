using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;


namespace Diablo
{
    
    class DataManager
    {
        //dictionary
        private Dictionary<int, CharacterData> dicCharacterDatas = new Dictionary<int, CharacterData>();
        private Dictionary<int, WeaponData> dicWeaponDatas = new Dictionary<int, WeaponData>();
        private Dictionary<int, MonsterData> dicMonsterDatas = new Dictionary<int, MonsterData>();
        //singletone
        private static DataManager instance;
        private const string DATA_PATH = "./Datas";
        private  DataManager()
        {

        }

        public static DataManager GetInstance()
        {
            if (DataManager.instance == null) DataManager.instance = new DataManager();
            return DataManager.instance;
        }
        //-----------------------------
        public void LoadDatas()
        {
            //캐릭터
            string path = string.Format("{0}/{1}", DATA_PATH, "character_data.json");
            string json = File.ReadAllText(path);
            CharacterData[] characterDatas = JsonConvert.DeserializeObject<CharacterData[]>(json);
            foreach(var data in characterDatas)
            {
                this.dicCharacterDatas.Add(data.id, data);
            }
            //무기
            path = string.Format("{0}/{1}", DATA_PATH, "weapon_data.json");
            json = File.ReadAllText(path);
            WeaponData[] weaponDatas = JsonConvert.DeserializeObject<WeaponData[]>(json);
            foreach (var data in weaponDatas)
            {
                this.dicWeaponDatas.Add(data.id, data);
            }
            //몬스터
            path = string.Format("{0}/{1}", DATA_PATH, "monster_data.json");
            json = File.ReadAllText(path);
            MonsterData[] monsterDatas = JsonConvert.DeserializeObject<MonsterData[]>(json);
            foreach (var data in monsterDatas)
            {
                this.dicMonsterDatas.Add(data.id, data);
            }
            Console.WriteLine("데이터를 불러오는 중");
            Console.WriteLine("모든 데이터를 로드 했습니다.");
            Console.WriteLine("캐릭터 데이터{0}개", this.dicCharacterDatas.Count);
            Console.WriteLine("무기 데이터{0}개", this.dicWeaponDatas.Count);
            Console.WriteLine("몬스터 데이터{0}개", this.dicMonsterDatas.Count);
        }
        public CharacterData[] GetCharacterDatas()
        {
            return this.dicCharacterDatas.Values.ToArray();//Values 넣어줘야
        }

        public WeaponData GetWeapoponData(int characterId)//무기ID를 받아서 캐릭터의 무기를 지급
        {
            var characterData = this.dicCharacterDatas[characterId];//딕셔네리값의 캐릭터 아이디로 캐릭터 정보를 불러와서
            var weaponData = this.dicWeaponDatas[characterData.defaultWeaponId];//캐릭터 정보 안의 무기 정보를 구한다
            return weaponData;
        }
    }
}
