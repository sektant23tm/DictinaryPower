using DictinaryPower.Infrastructure.Commands.Base;
using System;

namespace DictinaryPower.Infrastructure.Commands
{
    internal class LambdaCommand : Command
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public LambdaCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        //Второй конструктор будет "Паразитировать" на первом.+
        //На входе у нас делегаты без параметров,на их основании мы должны сформировать делегат с параметром через лямба выражение
        public LambdaCommand(Action Execute, Func<bool> CanExecute = null)
            : this(
                  p => Execute(),
                  CanExecute is null ? (Func<object, bool>)null : p => CanExecute())
        { }

        protected override void Execute(object p) => _execute(p);

        protected override bool CanExecute(object p) => _canExecute?.Invoke(p) ?? true;
    }
}
