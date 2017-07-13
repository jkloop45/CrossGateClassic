

namespace CrossGateClassic.Models
{
    class GameWindow
    {
        int hwnd;
        public GameWindow(int hwnd)
        {
            Hwnd = hwnd;
        }
        public string Title
        {
            get
            {
                return "";
            }
        }

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

        string classname;
        string position;
        int height;
        int width;

    }
}
