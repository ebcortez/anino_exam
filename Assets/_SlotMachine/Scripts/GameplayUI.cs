using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace SlotMachine.UI {
	public class GameplayUI : MonoBehaviour {
		public GameObject startButton, stopButton;
		public TextMeshProUGUI currentCoinsText;
		public TextMeshProUGUI winningsText;
		public TextMeshProUGUI betText;

		public void UpdateCurrentCoins() => currentCoinsText.text = $"COINS: {UserManager.Instance.CurrentCoins}";
		public void UpdateWinings() => winningsText.text = $"WINNINGS: {UserManager.Instance.CurrentWinnings}";
		public void UpdateBet() => betText.text = UserManager.Instance.CurrentBet.ToString();

		public void AddBet() => UserManager.Instance.AddBet(5000);
		public void ReduceBet() => UserManager.Instance.ReduceBet(5000);

		private void Update() {
			UpdateCurrentCoins();
			UpdateWinings();
			UpdateBet();
		}

		public void StartSpin() {
			if(UserManager.Instance.CurrentCoins < UserManager.Instance.CurrentBet) return;
			ReelsManager.Instance.StartAllReelSpin();
			UserManager.Instance.ReduceCoins(UserManager.Instance.CurrentBet);
			UserManager.Instance.ResetWinnings();
			if(startButton.activeInHierarchy) startButton.SetActive(false);
			if (!stopButton.activeInHierarchy) stopButton.SetActive(true);
		}

		public void StopSpin() {
			ReelsManager.Instance.StopAllReelSpin();
			if (!startButton.activeInHierarchy) startButton.SetActive(true);
			if (stopButton.activeInHierarchy) stopButton.SetActive(false);
		}

		public void ResetGame() {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	} 
}