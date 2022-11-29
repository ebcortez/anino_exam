using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotMachine {
	public class UserManager : MonoBehaviour {
		private static UserManager instance;
		public static UserManager Instance => instance;

		public int CurrentCoins { get; private set; }
		public int CurrentBet { get; private set; }
		public int CurrentWinnings { get; private set; }

		[SerializeField] private int defaultCoin, startingBet, maxBet, minBet;

		private void Awake() {
			instance = this;
		}

		private void Start() {
			AddCoins(defaultCoin);
			AddBet(startingBet);
		}

		public void AddCoins(int coinsToAdd) =>	CurrentCoins += coinsToAdd;
		public void ReduceCoins(int coinsToReduce) {
			CurrentCoins -= coinsToReduce;
			if(CurrentCoins <= 0) {
				CurrentCoins = 0;
			}
		}

		public void AddBet(int betToAdd) {
			CurrentBet += betToAdd;
			if(CurrentBet >= maxBet) CurrentBet = maxBet;
		}

		public void ReduceBet(int betToReduce) {
			CurrentBet -= betToReduce;
			if (CurrentBet <= minBet) CurrentBet = minBet;
		}

		public void ResetWinnings() {
			CurrentWinnings = 0;
		}

		public void SetWinnings(int winnings) {
			CurrentWinnings += winnings;
		}
	} 
}
