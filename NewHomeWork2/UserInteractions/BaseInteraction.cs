using System;

namespace NewHomeWork2.UserInteractions
{
	internal abstract class BaseInteraction
	{
		protected readonly BaseInteraction _previousInteraction;

		protected BaseInteraction(BaseInteraction previousInteraction)
		{
			this._previousInteraction = previousInteraction;
		}

		public abstract string GetHistory();
		protected abstract void StartInteraction();
		protected abstract void ShowOptions();
		protected abstract void ShowMainInfo();

		public void Start()
		{
			ConExt.Clear();
			ConExt.WriteLine(GetHistory());
			ConExt.WriteLine("\n------------------------------\n");
			ShowMainInfo();
			ConExt.WriteLine("\n------------------------------\n");
			ShowOptions(); 
			StartInteraction();
		}
	}
}