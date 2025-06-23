using UnityEngine;

namespace ShootEmUp
{
    public static class GameFinishHandler
    {
        public static void FinishGame()
        {
            Debug.Log("Game over!");
            Time.timeScale = 0;
        }
    }
}