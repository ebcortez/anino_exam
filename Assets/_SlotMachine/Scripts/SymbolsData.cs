using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotMachine {
	[CreateAssetMenu(fileName = "New Symbols Data", menuName = "Create Symbols Data")]
	public class SymbolsData : ScriptableObject {
		public string id;
		public string symbolName;
		public int payout3x, payout4x, payout5x;
		public Sprite symbolSprite;
	}
}