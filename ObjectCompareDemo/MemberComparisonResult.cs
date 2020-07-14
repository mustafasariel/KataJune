namespace ObjectCompareDemo
{
    public class MemberComparisonResult
    {
        public string Name { get; set; }
        private object FirstValue { get; set; }
        private object SecondValue { get; set; }

        public MemberComparisonResult(string name, object xValue, object yValue)
        {
            this.Name = name;
            this.FirstValue = xValue;
            this.SecondValue = yValue;
        }

        public override string ToString()
        {
            return Name + " : " + FirstValue.ToString() + (FirstValue.Equals(SecondValue) ? " == " : " != ") + SecondValue.ToString();
        }
    }
}