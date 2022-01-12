using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;


namespace Diablo
{
    public enum eCharacterType 
    { 
        None,
        BARBARIAN,
        AMAZON,
        SOSURISE,
        PALADINE
    }
    class App
    {
        public App() 
        {
            
            DataManager.GetInstance().LoadDatas();
            Console.WriteLine("**********");
            Console.WriteLine("**Diablo**");
            Console.WriteLine("***start!**");
            Console.WriteLine("**********");
            
            //용사여 처음오셨군요
            CharacterData[] characterDatas = DataManager.GetInstance().GetCharacterDatas();
            for (int i = 0; i < characterDatas.Length; i++)
            {
                var data = characterDatas[i];
                int idx = i + 1;
                Console.WriteLine("{0}. {1}", idx, data.name);//1.바바리안~4.팔라딘
            }
            //1.바바리안
            //2.아마존
            //3.소서리스
            //4.팔라딘
            //캐릭터 선택해주세요(숫자1~4):1
            //Console.WriteLine("1.바바리안\n2.아마존\n3.소서리스\n4.팔라딘");
            Console.Write("캐릭터 선택해주세요(숫자1~4):");
            string input = Console.ReadLine();
            int num = int.Parse(input);
            CharacterData selectedCharacterData = characterDatas[num-1];//캐릭터 선택 후 맨트
            Console.WriteLine("NPC:환영합니다 {0} 용사님.", selectedCharacterData.name);
            Console.WriteLine("NPC:무기를 드리겠습니다.");
            eCharacterType characterType = (eCharacterType)num;//캐릭터 선택하면 무기 출력
            
            //무기 가져오기
            
            WeaponData weaponData = DataManager.GetInstance().GetWeapoponData(selectedCharacterData.id);//선택한 캐릭터 ID를 넣으면 무기 가져오기
            Weapon defaultWeapon = new Weapon(weaponData.id);
            Console.WriteLine("{0}을 획득했습니다", weaponData.name);
            
            //대사
            if(characterType == eCharacterType.PALADINE)
            {
                Console.WriteLine("저 팔라딘인데...");
                Console.WriteLine(".");
                Console.WriteLine(".");
                Console.WriteLine(".");
                Console.WriteLine("NPC:대장장이가 휴가라서...");
                // Test colors with blue background, white foreground.
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(weaponData.name);
                Console.ResetColor();

                Console.Write("을 받아가세요.");
                Console.WriteLine();
            }
            


            //바바리안님 환영합니다
            //장검을 획득했습니다
            //장검을 착용했습니다
            //당신은 필드로 나갑니다
            //당신은 고블린무리를 발견 했습니다

            //명령어를 입력해주세요(<대상> 쳐, 도망, 소지품, 저장) : 고블린 쳐
            //당신은 고블린을 공격했습니다
            //고블린은 당신을 공격했습니다
            //고블린이 죽었습니다 
            //고블린이 골드10을 드랍했습니다


        }
    }
}
