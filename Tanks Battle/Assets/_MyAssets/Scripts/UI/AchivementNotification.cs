using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TanksBattle.UI
{
    internal class AchivementNotification : MonoBehaviour
    {
        public Animator anim;
        public Text HeadingText;
        public Text SubText;

		private void Start()
		{
            HeadingText.text = "Welcome";
            SubText.text = "Play the Game";
		}

		public void ShowAchievement(string Heading, string subString)
		{
            anim.ResetTrigger("NewNotification");
            HeadingText.text = Heading;
            SubText.text = subString;

            anim.SetTrigger("NewNotification");
            Debug.Log("triggered");
        }
    }

}
