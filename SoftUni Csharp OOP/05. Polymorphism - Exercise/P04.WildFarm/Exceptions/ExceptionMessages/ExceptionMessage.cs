namespace WildFarm.Exceptions.ExceptionMessages
{
    public class ExceptionMessage
    {
        private const string NumberMustNotBeLessThanZeroMsg = "{0} must not be 0 or a negative number!";

        private const string StringIsNullEmptyOrWhitespacesMsg = "{0} must not be null, empty or white-spaces!";

        private const string FoodNotPrefferedMsg = "{0} does not eat {1}!";

        public string NegativeNumberExceptionMessage => NumberMustNotBeLessThanZeroMsg;

        public string InvalidStringExceptionMessage => StringIsNullEmptyOrWhitespacesMsg;

        public string FoodNotPrefferedMessage = FoodNotPrefferedMsg;
    }
}
