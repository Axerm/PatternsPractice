namespace PatternsPractice.Patterns.Facade
{
    namespace AsMediator
    {
        public sealed record Sub1
        {
            public event Action<int>? EventNumberChanged;

            private int _number;
            public int Number
            {
                get => _number;
                set
                {
                    if (value != _number)
                    {
                        _number = value;
                        EventNumberChanged?.Invoke(_number);
                    }
                }
            }
        }

        public sealed record Sub2
        {
            private int _number;
            public int Number
            {
                get => _number;
                set
                {
                    var newValue = value * 2;
                    if (newValue != _number)
                        _number = newValue;
                }
            }
        }

        public sealed class Mediator
        {
            private Sub1 _sub1;
            private Sub2 _sub2;

            public Mediator(Sub1 sub1)
            {
                _sub1 = sub1;
                _sub2 = new();

                _sub1.EventNumberChanged += Sub1NumberChanged;
            }

            public void Sub1NumberChanged(int newValue)
                => _sub2.Number = newValue;

            public string GetInfo()
                => $"sub1 number: {_sub1.Number} | sub2 number: {_sub2.Number}";
        }
    }

    namespace AsFacade
    {
        public sealed record Sub1
        {
            private int _number;
            public int Number
            {
                get => _number;
                set
                {
                    if (value != _number)
                        _number = value;
                }
            }
        }

        public sealed record Sub2
        {
            private int _number;
            public int Number
            {
                get => _number;
                set
                {
                    var newValue = value * 2;
                    if (newValue != _number)
                        _number = newValue;
                }
            }
        }

        public sealed class Facade
        {
            private Sub1 _sub1;
            private Sub2 _sub2;

            public Facade() => (_sub1, _sub2) = (new(), new());

            public void SetNumber(int newValue)
                => _sub2.Number = _sub1.Number = newValue;

            public string GetInfo()
                => $"sub1 number: {_sub1.Number} | sub2 number: {_sub2.Number}";
        }
    }
}