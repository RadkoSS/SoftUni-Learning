namespace BorderControl.Models
{
    using Contracts;

    public class Robot : Citizen, IRobot
    {
        public Robot(string model, string id) : base(id)
        {
            this.Model = model;
        }

        public string Model { get; }
    }
}
