using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace SlotMachine {
	public class ReelsManager : MonoBehaviour {
		private static ReelsManager instance;
		public static ReelsManager Instance => instance;

		public SymbolsData[] symbolDatas;
		public List<Reel> reels = new List<Reel>();

		public List<SymbolsData> line1Results, line2Results, line3Results;

		private void Awake() {
			instance = this;
		}

		private void Update() {
			if (Input.GetKeyDown(KeyCode.Space)) {
				StartAllReelSpin();
				StopAllReelSpin();
			}
		}

		public void StartAllReelSpin() {
			foreach (Reel reel in reels) {
				if (!reel.IsSpinning) reel.Spin();
			}
		}

		public void StopAllReelSpin() {
			foreach (Reel reel in reels) {
				if (reel.IsSpinning) reel.StopSpin();
			}

			CheckResults();
		}

		private void CheckResults() {
			if (reels.All(reel => !reel.IsSpinning)) {
				line1Results.Add(reels[0].result1);
				line1Results.Add(reels[1].result1);
				line1Results.Add(reels[2].result1);
				line1Results.Add(reels[3].result1);
				line1Results.Add(reels[4].result1);

				line2Results.Add(reels[0].result2);
				line2Results.Add(reels[1].result2);
				line2Results.Add(reels[2].result2);
				line2Results.Add(reels[3].result2);
				line2Results.Add(reels[4].result2);

				line3Results.Add(reels[0].result3);
				line3Results.Add(reels[1].result3);
				line3Results.Add(reels[2].result3);
				line3Results.Add(reels[3].result3);
				line3Results.Add(reels[4].result3);

				var totalWinnings = 0;

				if(line1Results[0].id == line1Results[1].id) {
					if(line1Results[0].id == line1Results[2].id) {
						if(line1Results[0].id == line1Results[3].id) {
							if(line1Results[0].id == line1Results[4].id) {
								totalWinnings += UserManager.Instance.CurrentBet * line1Results[0].payout5x;
							} else {
								totalWinnings += UserManager.Instance.CurrentBet * line1Results[0].payout4x;
							}
						} else {
							totalWinnings += UserManager.Instance.CurrentBet * line1Results[0].payout3x;
						}
					}
				}

				if (line2Results[0].id == line2Results[1].id) {
					if (line2Results[0].id == line2Results[2].id) {
						if (line2Results[0].id == line2Results[3].id) {
							if (line2Results[0].id == line2Results[4].id) {
								totalWinnings += UserManager.Instance.CurrentBet * line2Results[0].payout5x;
							} else {
								totalWinnings += UserManager.Instance.CurrentBet * line2Results[0].payout4x;
							}
						} else {
							totalWinnings += UserManager.Instance.CurrentBet * line2Results[0].payout3x;
						}
					}
				}

				if (line3Results[0].id == line3Results[1].id) {
					if (line3Results[0].id == line3Results[2].id) {
						if (line3Results[0].id == line3Results[3].id) {
							if (line3Results[0].id == line3Results[4].id) {
								totalWinnings += UserManager.Instance.CurrentBet * line3Results[0].payout5x;
							} else {
								totalWinnings += UserManager.Instance.CurrentBet * line3Results[0].payout4x;
							}
						} else {
							totalWinnings += UserManager.Instance.CurrentBet * line3Results[0].payout3x;
						}
					}
				}

				UserManager.Instance.SetWinnings(totalWinnings);
				UserManager.Instance.AddCoins(totalWinnings);
			}
		}
	} 
}
