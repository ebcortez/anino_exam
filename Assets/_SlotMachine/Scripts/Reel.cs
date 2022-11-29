using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SlotMachine {
	public class Reel : MonoBehaviour {
		public Symbols[] resultsSymbols;

		private bool isSpinning = false;
		public bool IsSpinning => isSpinning;
		private float buffer = 0;

		public SymbolsData result1, result2, result3;

		private void Update() {
			if (isSpinning) {
				if(buffer <= 0) {
					for (int childIndex = 0; childIndex < resultsSymbols.Length; childIndex++) {
						var resultSymbol = resultsSymbols[childIndex];
						resultSymbol.SpriteRenderer.sprite = ReelsManager.Instance.symbolDatas[Random.Range(0, ReelsManager.Instance.symbolDatas.Length - 1)].symbolSprite;
					}
					buffer = 0.1f;
				} else {
					buffer -= Time.deltaTime;
				}
			}
		}

		public void Spin() {
			result1 = null;
			result2 = null;
			result3 = null;
			isSpinning = true;
		}

		public void StopSpin() {
			isSpinning = false;

			int result1_ID, result2_ID, result3_ID;
			result1_ID = Random.Range(0, ReelsManager.Instance.symbolDatas.Length - 1);
			do {
				result2_ID = Random.Range(0, ReelsManager.Instance.symbolDatas.Length - 1);
			}
			while (result1_ID == result2_ID);
			do {
				result3_ID = Random.Range(0, ReelsManager.Instance.symbolDatas.Length - 1);
			}
			while (result1_ID == result3_ID || result2_ID == result3_ID);

			result1 = ReelsManager.Instance.symbolDatas[result1_ID];
			result2 = ReelsManager.Instance.symbolDatas[result2_ID];
			result3 = ReelsManager.Instance.symbolDatas[result3_ID];

			resultsSymbols[0].SpriteRenderer.sprite = result1.symbolSprite;
			resultsSymbols[1].SpriteRenderer.sprite = result2.symbolSprite;
			resultsSymbols[2].SpriteRenderer.sprite = result3.symbolSprite;

			buffer = 0;
		}
	}

#if UNITY_EDITOR
	[CustomEditor(typeof(Reel))]
	public class ReelCustomInspector : Editor {
		public override void OnInspectorGUI() {
			DrawDefaultInspector();
			Reel myTarget = (Reel)target;

			if (!Application.IsPlaying(myTarget)) {
				if (GUILayout.Button("Assign Sprite")) {
					for (int resultIndex = 0; resultIndex < myTarget.resultsSymbols.Length; resultIndex++) {
						var resultSymbol = myTarget.resultsSymbols[resultIndex];
						resultSymbol.SpriteRenderer.sprite = ReelsManager.Instance.symbolDatas[Random.Range(0, ReelsManager.Instance.symbolDatas.Length - 1)].symbolSprite;
					}
				}

				if (GUILayout.Button("Assign Default Sprite")) {
					for (int resultIndex = 0; resultIndex < myTarget.resultsSymbols.Length; resultIndex++) {
						var resultSymbol = myTarget.resultsSymbols[resultIndex];
						resultSymbol.SpriteRenderer.sprite = ReelsManager.Instance.symbolDatas[resultIndex].symbolSprite;
					}
				}
			}
		}
	}
#endif

}