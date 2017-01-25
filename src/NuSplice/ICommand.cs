using System;
using System.Collections.Generic;

namespace NuSplice
{
	public abstract class Command
	{
		private readonly Dictionary<Type, Action<object>> _handlers;
		private readonly List<IEvent> _pending;

		protected Command()
		{
			_handlers = new Dictionary<Type, Action<object>>();
			_pending = new List<IEvent>();
		}

		protected void Register<TEvent>(Action<TEvent> handler)
			where TEvent : IEvent
		{
			_handlers[typeof(TEvent)] = e => handler((TEvent)e);
		}

		protected void Apply(IEvent e)
		{
			Action<object> handler;

			if (_handlers.TryGetValue(e.GetType(), out handler) == false)
				return;

			handler(e);
			_pending.Add(e);
		}

		protected void ClearPendingEvents() => _pending.Clear();
		public IEnumerable<IEvent> GetPendingEvents() => _pending;

		public abstract void Execute(CommandModel model);
	}

	public interface IEvent {}

	public class CommandModel
	{
		public string[] Args { get; set; }
	}
}
