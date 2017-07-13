


using System.Threading;

namespace CrossGateClassic.Models
{
    class Game
    {
        public Game(int windowHwnd)
        {
            Hwnd = windowHwnd;
            Window = new GameWindow(Hwnd);
        }
        int hwnd;
        GameWindow Window;
        public int Hwnd
        {
            get
            {
                
                return hwnd;    

            }

            set
            {
                
                hwnd = value;
            }
        }


        public void SpeedFightOn()
        {
            Dm.instance.WriteData(Hwnd, "0450756", "90 90");
        }
        public void SpeedFightOff()
        {
            Dm.instance.WriteData(Hwnd, "0450756", "75 0B");
        }
        public void EnemyEveryStepOn()
        {
            Dm.instance.WriteData(Hwnd, "04865C9", "90 90");
            Dm.instance.WriteInt(Hwnd, "04865D1", 0,2);


        }
        public void EnemyEveryStepOff()
        {
            Dm.instance.WriteData(Hwnd, "04865C9", "EB 56");
            Dm.instance.WriteInt(Hwnd, "04865D1", 0, 3);
        }
        public void SetCollectSpeed(int value)
        {
            Dm.instance.WriteInt(Hwnd, "4077E5", 0, value);
        }


        public void MoveTo(int x, int y)
        {
            Dm.instance.WriteData(Hwnd, "0048940D", "B8 00 00 00 00");
            Dm.instance.WriteData(Hwnd, "00489431", "BA 00 00 00 00 90");
            Dm.instance.WriteInt(Hwnd, "0048940E", 0, x);
            Dm.instance.WriteInt(Hwnd, "00489432", 0, y);
            Dm.instance.WriteInt(Hwnd, "00CB89B0", 0, 1);
            Thread.Sleep(100);
            Dm.instance.WriteInt(Hwnd, "00CB89B0", 0, 0);
            Dm.instance.WriteData(Hwnd, "0048940D", "A1 90 89 CB 00");
            Dm.instance.WriteData(Hwnd, "00489431", "8B 15 88 89 CB 00");
        }

        public int MoveSpeed
        {
            get
            {
                return Dm.instance.ReadInt(Hwnd, "[010AEF88] + 168", 0);
            }
            set
            {
                Dm.instance.WriteInt(Hwnd, "[010AEF88] + 168", 0,value);
            }

        }
        public void Call(string content)
        {
            Dm.instance.WriteData(Hwnd, "00D59000",content);
            int len=content.Split(' ').Length;
            Dm.instance.AsmClear();
            Dm.instance.AsmAdd("push 00");
            Dm.instance.AsmAdd("push " + "0" + len.ToString("X"));
            Dm.instance.AsmAdd("push 00D59000");
            Dm.instance.AsmAdd("push [00E10820]");
            Dm.instance.AsmAdd("call 00564BDE");
            Dm.instance.AsmCall(Hwnd, 1);
        }



        public void FoodInCombatOn()
        {
            Dm.instance.WriteData(Hwnd, "004B33E2", "EB");
            Dm.instance.WriteData(Hwnd, "004B2FCF","90 90 90 90 90 90");
            
            
        }
        public void FoodInCombatOff()
        {
            Dm.instance.WriteData(Hwnd, "004B33E2", "75");
            Dm.instance.WriteData(Hwnd, "004B2FCF", "0F 84 D5 00 00 00");
        }

    }
}
