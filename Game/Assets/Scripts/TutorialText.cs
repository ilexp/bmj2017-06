using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace GameJam
{
	public class TutorialText : MonoBehaviour
	{
		[Serializable]
		private struct TutorialItem
		{
			[Multiline]
			public string Text;
			public float WaitForSeconds;
		}

		[SerializeField]
		private List<TutorialItem> items = new List<TutorialItem>
		{
			new TutorialItem { WaitForSeconds = 3.0f, Text = "Greetings, hero!" },
			new TutorialItem { WaitForSeconds = 5.0f, Text = "The city nearby is suffering from a terrible drought." },
			new TutorialItem { WaitForSeconds = 5.0f, Text = "For some reason the sun has been brighter than usual." },
			new TutorialItem { WaitForSeconds = 4.0f, Text = "Luckily you're here now. You have to save them!" },
			new TutorialItem { WaitForSeconds = 4.0f, Text = "Press the arrow keys to move." },
			new TutorialItem { WaitForSeconds = 8.0f, Text = "Use the right arrow key to go right." },
			new TutorialItem { WaitForSeconds = 10.0f, Text = "The arrow keys. You know, the keys that have an arrow on them." },
			new TutorialItem { WaitForSeconds = 10.0f, Text = "Uh... hello?" },
			new TutorialItem { WaitForSeconds = 10.0f, Text = "Anybody...?" },
			new TutorialItem { WaitForSeconds = 15.0f, Text = "The people are suffering." },
			new TutorialItem { WaitForSeconds = 15.0f, Text = "Will you please move." },
			new TutorialItem { WaitForSeconds = 15.0f, Text = "The town isn't going to save itself, you know." },
			new TutorialItem { WaitForSeconds = 10.0f, Text = "Come ON." },
			new TutorialItem { WaitForSeconds = 15.0f, Text = "..." }
		};
		private Text tutorial;


		private void ApplyText(string text)
		{
			this.tutorial.text = text;
		}

		private void Awake()
		{
			this.tutorial = GetComponent<Text>();
			StartCoroutine(TutorialScript().GetEnumerator());
		}

		private IEnumerable TutorialScript()
		{
			if (this.items == null) yield break;

			while (this.items.Count > 0)
			{
				TutorialItem item = this.items[0];

				this.items.RemoveAt(0);
				yield return new WaitForSeconds(item.WaitForSeconds);
				this.ApplyText(item.Text);
			}
		}
	}
}
