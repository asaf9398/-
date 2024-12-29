using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_Asaf_319094322_Liat_207918608
{
    public class GameEventManager
    {
        private static GameEventManager s_Instance;
        private readonly List<Action<string>> m_Listeners = new List<Action<string>>();

        // Singleton - גישה למופע יחיד
        public static GameEventManager Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    s_Instance = new GameEventManager();
                }
                return s_Instance;
            }
        }


        // רישום מאזין חדש
        public void RegisterListener(Action<string> i_Listener)
        {
            if (!m_Listeners.Contains(i_Listener))
            {
                m_Listeners.Add(i_Listener);
            }
        }

        // ביטול רישום מאזין
        public void UnregisterListener(Action<string> i_Listener)
        {
            if (m_Listeners.Contains(i_Listener))
            {
                m_Listeners.Remove(i_Listener);
            }
        }

        // יידוע כל המאזינים על אירוע
        public void Notify(string i_Message)
        {
            foreach (var listener in m_Listeners)
            {
                listener.Invoke(i_Message);
            }
        }
    }

}
